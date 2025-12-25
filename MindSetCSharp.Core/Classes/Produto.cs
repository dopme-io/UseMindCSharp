namespace MindSetCSharp.Core.Classes;

/// <summary>
/// Classe Produto demonstrando estrutura básica de uma classe.
/// Mostra diferentes tipos de membros: campos, propriedades, construtores e métodos.
/// </summary>
public class Produto
{
    // Campo privado (convenção: usar camelCase com underscore)
    private decimal _precoBase;
    private int _quantidadeEstoque;

    // Propriedades auto-implementadas
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public string Categoria { get; set; }

    // Propriedade com validação (get/set customizado)
    public decimal Preco
    {
        get => _precoBase;
        set
        {
            if (value < 0)
                throw new ArgumentException("Preço não pode ser negativo.");
            _precoBase = value;
        }
    }

    // Propriedade somente leitura calculada
    public decimal PrecoComImposto => _precoBase * 1.15m; // 15% de imposto

    // Propriedade com lógica
    public int QuantidadeEstoque
    {
        get => _quantidadeEstoque;
        set
        {
            if (value < 0)
                throw new ArgumentException("Estoque não pode ser negativo.");
            _quantidadeEstoque = value;
        }
    }

    // Propriedade calculada
    public bool EmEstoque => _quantidadeEstoque > 0;
    public bool EstoqueBaixo => _quantidadeEstoque > 0 && _quantidadeEstoque <= 5;

    // Construtores
    public Produto()
    {
        Nome = "Produto Sem Nome";
        Codigo = "000000";
        Categoria = "Geral";
        _precoBase = 0;
        _quantidadeEstoque = 0;
    }

    public Produto(string nome, decimal preco, int quantidade)
    {
        Nome = nome;
        Codigo = GerarCodigo();
        Categoria = "Geral";
        Preco = preco;
        QuantidadeEstoque = quantidade;
    }

    public Produto(string nome, string codigo, string categoria, decimal preco, int quantidade)
    {
        Nome = nome;
        Codigo = codigo;
        Categoria = categoria;
        Preco = preco;
        QuantidadeEstoque = quantidade;
    }

    // Métodos de instância
    public bool Vender(int quantidade)
    {
        if (quantidade <= 0)
        {
            Console.WriteLine("❌ Quantidade inválida para venda.");
            return false;
        }

        if (quantidade > _quantidadeEstoque)
        {
            Console.WriteLine($"❌ Estoque insuficiente. Disponível: {_quantidadeEstoque}");
            return false;
        }

        _quantidadeEstoque -= quantidade;
        Console.WriteLine($"✅ Venda realizada: {quantidade} unidade(s) de {Nome}");
        Console.WriteLine($"   Estoque restante: {_quantidadeEstoque}");
        
        if (EstoqueBaixo)
            Console.WriteLine("⚠️  Atenção: Estoque baixo!");

        return true;
    }

    public void Repor(int quantidade)
    {
        if (quantidade <= 0)
        {
            Console.WriteLine("❌ Quantidade inválida para reposição.");
            return;
        }

        _quantidadeEstoque += quantidade;
        Console.WriteLine($"✅ Reposição realizada: {quantidade} unidade(s) de {Nome}");
        Console.WriteLine($"   Novo estoque: {_quantidadeEstoque}");
    }

    public decimal CalcularValorTotal()
    {
        return _precoBase * _quantidadeEstoque;
    }

    public void AplicarDesconto(decimal percentual)
    {
        if (percentual < 0 || percentual > 100)
        {
            Console.WriteLine("❌ Percentual de desconto inválido (0-100).");
            return;
        }

        decimal precoAntigo = _precoBase;
        _precoBase -= _precoBase * (percentual / 100);
        Console.WriteLine($"💰 Desconto de {percentual}% aplicado em {Nome}");
        Console.WriteLine($"   De R$ {precoAntigo:F2} para R$ {_precoBase:F2}");
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine($"  Produto: {Nome}");
        Console.WriteLine($"  Código: {Codigo}");
        Console.WriteLine($"  Categoria: {Categoria}");
        Console.WriteLine($"  Preço: R$ {_precoBase:F2}");
        Console.WriteLine($"  Preço c/ Imposto: R$ {PrecoComImposto:F2}");
        Console.WriteLine($"  Estoque: {_quantidadeEstoque} unidades");
        Console.WriteLine($"  Valor Total: R$ {CalcularValorTotal():F2}");
        Console.WriteLine($"  Status: {(EmEstoque ? "✅ Em estoque" : "❌ Sem estoque")}");
        Console.WriteLine("╚════════════════════════════════════════════╝");
    }

    // Método estático privado auxiliar
    private static string GerarCodigo()
    {
        return Guid.NewGuid().ToString("N")[..8].ToUpper();
    }

    // Override do ToString
    public override string ToString()
    {
        return $"{Nome} (R$ {_precoBase:F2}) - Estoque: {_quantidadeEstoque}";
    }
}
