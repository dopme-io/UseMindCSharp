namespace MindSetCSharp.Core.Encapsulamento;

/// <summary>
/// Classe demonstrando encapsulamento de regras de negócio complexas.
/// </summary>
public class CarrinhoCompras
{
    // Classe interna encapsulada
    private class ItemCarrinho
    {
        public string Produto { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal => PrecoUnitario * Quantidade;
    }

    // Coleção privada - não pode ser acessada diretamente
    private readonly List<ItemCarrinho> _itens;
    private decimal _descontoAplicado;
    private string? _cupomUtilizado;

    // Propriedades somente leitura
    public int QuantidadeItens => _itens.Sum(i => i.Quantidade);
    public decimal ValorSubtotal => _itens.Sum(i => i.Subtotal);
    public decimal ValorDesconto => _descontoAplicado;
    public decimal ValorTotal => ValorSubtotal - _descontoAplicado;
    public bool TemCupomAplicado => !string.IsNullOrEmpty(_cupomUtilizado);

    public CarrinhoCompras()
    {
        _itens = new List<ItemCarrinho>();
        _descontoAplicado = 0;
    }

    // Método público com validação encapsulada
    public void AdicionarProduto(string produto, decimal preco, int quantidade)
    {
        if (string.IsNullOrWhiteSpace(produto))
        {
            Console.WriteLine("❌ Nome do produto inválido.");
            return;
        }

        if (preco <= 0)
        {
            Console.WriteLine("❌ Preço deve ser positivo.");
            return;
        }

        if (quantidade <= 0)
        {
            Console.WriteLine("❌ Quantidade deve ser positiva.");
            return;
        }

        // Verifica se o produto já existe
        var itemExistente = _itens.FirstOrDefault(i => 
            i.Produto.Equals(produto, StringComparison.OrdinalIgnoreCase));

        if (itemExistente != null)
        {
            itemExistente.Quantidade += quantidade;
            Console.WriteLine($"✅ Quantidade atualizada: {itemExistente.Produto} ({itemExistente.Quantidade} unidades)");
        }
        else
        {
            _itens.Add(new ItemCarrinho 
            { 
                Produto = produto, 
                PrecoUnitario = preco, 
                Quantidade = quantidade 
            });
            Console.WriteLine($"✅ Produto adicionado: {produto} ({quantidade} x R$ {preco:F2})");
        }

        // Recalcula desconto após adicionar item
        RecalcularDescontos();
    }

    public void RemoverProduto(string produto)
    {
        var item = _itens.FirstOrDefault(i => 
            i.Produto.Equals(produto, StringComparison.OrdinalIgnoreCase));

        if (item != null)
        {
            _itens.Remove(item);
            Console.WriteLine($"✅ Produto removido: {produto}");
            RecalcularDescontos();
        }
        else
        {
            Console.WriteLine($"❌ Produto não encontrado: {produto}");
        }
    }

    public bool AplicarCupom(string cupom)
    {
        if (string.IsNullOrWhiteSpace(cupom))
        {
            Console.WriteLine("❌ Cupom inválido.");
            return false;
        }

        if (TemCupomAplicado)
        {
            Console.WriteLine($"⚠️  Já existe um cupom aplicado: {_cupomUtilizado}");
            return false;
        }

        if (_itens.Count == 0)
        {
            Console.WriteLine("❌ Carrinho vazio. Adicione produtos antes de aplicar cupom.");
            return false;
        }

        // Simula validação de cupom
        var descontoPercentual = ValidarCupom(cupom);
        
        if (descontoPercentual > 0)
        {
            _cupomUtilizado = cupom;
            RecalcularDescontos();
            Console.WriteLine($"✅ Cupom '{cupom}' aplicado! Desconto de {descontoPercentual}%");
            return true;
        }

        Console.WriteLine($"❌ Cupom '{cupom}' inválido.");
        return false;
    }

    public void RemoverCupom()
    {
        if (!TemCupomAplicado)
        {
            Console.WriteLine("⚠️  Nenhum cupom aplicado.");
            return;
        }

        Console.WriteLine($"✅ Cupom '{_cupomUtilizado}' removido.");
        _cupomUtilizado = null;
        RecalcularDescontos();
    }

    // Método privado - encapsula lógica de validação
    private int ValidarCupom(string cupom)
    {
        // Simulação de validação de cupons
        return cupom.ToUpper() switch
        {
            "DESC10" => 10,
            "DESC20" => 20,
            "DESC30" => 30,
            "NATAL25" => 25,
            "BLACK50" => 50,
            _ => 0
        };
    }

    // Método privado - encapsula lógica de cálculo
    private void RecalcularDescontos()
    {
        _descontoAplicado = 0;

        // Desconto por cupom
        if (TemCupomAplicado)
        {
            var percentual = ValidarCupom(_cupomUtilizado!);
            _descontoAplicado += ValorSubtotal * (percentual / 100m);
        }

        // Desconto progressivo por valor
        if (ValorSubtotal >= 1000m)
        {
            _descontoAplicado += ValorSubtotal * 0.05m; // 5% adicional
        }
    }

    public void ExibirResumo()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║            CARRINHO DE COMPRAS                       ║");
        Console.WriteLine("╠═══════════════════════════════════════════════════════╣");
        
        if (_itens.Count == 0)
        {
            Console.WriteLine("  (Carrinho vazio)");
        }
        else
        {
            Console.WriteLine($"  {"Produto",-30} {"Qtd",5} {"Preço",12} {"Subtotal",12}");
            Console.WriteLine("  " + new string('─', 59));
            
            foreach (var item in _itens)
            {
                Console.WriteLine($"  {item.Produto,-30} {item.Quantidade,5} R$ {item.PrecoUnitario,8:F2} R$ {item.Subtotal,8:F2}");
            }
            
            Console.WriteLine("├───────────────────────────────────────────────────────┤");
            Console.WriteLine($"  Subtotal: {ValorSubtotal,45:C}");
            
            if (_descontoAplicado > 0)
            {
                Console.WriteLine($"  Desconto: {-_descontoAplicado,45:C}");
                
                if (TemCupomAplicado)
                {
                    Console.WriteLine($"    • Cupom '{_cupomUtilizado}'");
                }
                
                if (ValorSubtotal >= 1000m)
                {
                    Console.WriteLine($"    • Desconto por valor alto (5%)");
                }
            }
            
            Console.WriteLine("├───────────────────────────────────────────────────────┤");
            Console.WriteLine($"  TOTAL: {ValorTotal,48:C}");
        }
        
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
    }

    // Método para limpar o carrinho
    public void Limpar()
    {
        _itens.Clear();
        _descontoAplicado = 0;
        _cupomUtilizado = null;
        Console.WriteLine("🗑️  Carrinho limpo.");
    }
}
