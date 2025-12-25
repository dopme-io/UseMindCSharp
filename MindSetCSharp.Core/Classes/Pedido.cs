namespace MindSetCSharp.Core.Classes;

/// <summary>
/// Classe Pedido demonstrando composição e relacionamento entre classes.
/// Mostra como classes podem conter e interagir com outras classes.
/// </summary>
public class Pedido
{
    // Classe interna (nested class) para itens do pedido
    public class ItemPedido
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal => PrecoUnitario * Quantidade;

        public ItemPedido(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = produto.Preco;
        }

        public override string ToString()
        {
            return $"{Produto.Nome} x{Quantidade} = R$ {Subtotal:F2}";
        }
    }

    // Enum para status do pedido (tipos relacionados)
    public enum StatusPedido
    {
        Pendente,
        Processando,
        Enviado,
        Entregue,
        Cancelado
    }

    // Campos e propriedades
    private static int _proximoNumero = 1000;
    private List<ItemPedido> _itens;

    public int Numero { get; }
    public Cliente Cliente { get; set; }
    public DateTime DataPedido { get; }
    public StatusPedido Status { get; private set; }
    
    public IReadOnlyList<ItemPedido> Itens => _itens.AsReadOnly();
    
    public decimal ValorTotal => _itens.Sum(item => item.Subtotal);
    public int TotalItens => _itens.Sum(item => item.Quantidade);

    // Construtor
    public Pedido(Cliente cliente)
    {
        Numero = _proximoNumero++;
        Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        DataPedido = DateTime.Now;
        Status = StatusPedido.Pendente;
        _itens = new List<ItemPedido>();
    }

    // Métodos para gerenciar itens
    public void AdicionarItem(Produto produto, int quantidade)
    {
        if (produto == null)
        {
            Console.WriteLine("❌ Produto inválido.");
            return;
        }

        if (quantidade <= 0)
        {
            Console.WriteLine("❌ Quantidade deve ser positiva.");
            return;
        }

        if (Status != StatusPedido.Pendente)
        {
            Console.WriteLine($"❌ Não é possível adicionar itens. Pedido está: {Status}");
            return;
        }

        // Verifica se já existe o produto no pedido
        var itemExistente = _itens.FirstOrDefault(i => i.Produto.Codigo == produto.Codigo);
        
        if (itemExistente != null)
        {
            itemExistente.Quantidade += quantidade;
            Console.WriteLine($"✅ Quantidade atualizada: {produto.Nome} ({itemExistente.Quantidade} unidades)");
        }
        else
        {
            _itens.Add(new ItemPedido(produto, quantidade));
            Console.WriteLine($"✅ Item adicionado: {quantidade}x {produto.Nome}");
        }
    }

    public void RemoverItem(string codigoProduto)
    {
        if (Status != StatusPedido.Pendente)
        {
            Console.WriteLine($"❌ Não é possível remover itens. Pedido está: {Status}");
            return;
        }

        var item = _itens.FirstOrDefault(i => i.Produto.Codigo == codigoProduto);
        
        if (item != null)
        {
            _itens.Remove(item);
            Console.WriteLine($"✅ Item removido: {item.Produto.Nome}");
        }
        else
        {
            Console.WriteLine("❌ Item não encontrado no pedido.");
        }
    }

    // Métodos para gerenciar status
    public void Processar()
    {
        if (Status != StatusPedido.Pendente)
        {
            Console.WriteLine($"❌ Pedido não pode ser processado. Status atual: {Status}");
            return;
        }

        if (_itens.Count == 0)
        {
            Console.WriteLine("❌ Pedido vazio. Adicione itens antes de processar.");
            return;
        }

        Status = StatusPedido.Processando;
        Console.WriteLine($"✅ Pedido #{Numero} em processamento.");
    }

    public void Enviar()
    {
        if (Status != StatusPedido.Processando)
        {
            Console.WriteLine($"❌ Pedido não pode ser enviado. Status atual: {Status}");
            return;
        }

        Status = StatusPedido.Enviado;
        Console.WriteLine($"📦 Pedido #{Numero} enviado para {Cliente.Nome}.");
    }

    public void Entregar()
    {
        if (Status != StatusPedido.Enviado)
        {
            Console.WriteLine($"❌ Pedido não pode ser entregue. Status atual: {Status}");
            return;
        }

        Status = StatusPedido.Entregue;
        Console.WriteLine($"✅ Pedido #{Numero} entregue!");
    }

    public void Cancelar()
    {
        if (Status == StatusPedido.Entregue)
        {
            Console.WriteLine("❌ Pedido já foi entregue. Não pode ser cancelado.");
            return;
        }

        if (Status == StatusPedido.Cancelado)
        {
            Console.WriteLine("⚠️  Pedido já está cancelado.");
            return;
        }

        Status = StatusPedido.Cancelado;
        Console.WriteLine($"🚫 Pedido #{Numero} cancelado.");
    }

    // Método para exibir resumo
    public void ExibirResumo()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine($"║  PEDIDO #{Numero}");
        Console.WriteLine("╠═══════════════════════════════════════════════════════╣");
        Console.WriteLine($"  Cliente: {Cliente.Nome}");
        Console.WriteLine($"  Data: {DataPedido:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"  Status: {ObterEmojiStatus()} {Status}");
        Console.WriteLine("├───────────────────────────────────────────────────────┤");
        Console.WriteLine("  ITENS:");
        
        if (_itens.Count == 0)
        {
            Console.WriteLine("    (Nenhum item no pedido)");
        }
        else
        {
            foreach (var item in _itens)
            {
                Console.WriteLine($"    • {item.Quantidade}x {item.Produto.Nome,-25} R$ {item.Subtotal,10:F2}");
            }
        }
        
        Console.WriteLine("├───────────────────────────────────────────────────────┤");
        Console.WriteLine($"  Total de Itens: {TotalItens}");
        Console.WriteLine($"  VALOR TOTAL: R$ {ValorTotal:F2}");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
    }

    private string ObterEmojiStatus()
    {
        return Status switch
        {
            StatusPedido.Pendente => "⏳",
            StatusPedido.Processando => "⚙️",
            StatusPedido.Enviado => "📦",
            StatusPedido.Entregue => "✅",
            StatusPedido.Cancelado => "🚫",
            _ => "❓"
        };
    }

    public override string ToString()
    {
        return $"Pedido #{Numero} - {Cliente.Nome} - {Status} - R$ {ValorTotal:F2}";
    }
}
