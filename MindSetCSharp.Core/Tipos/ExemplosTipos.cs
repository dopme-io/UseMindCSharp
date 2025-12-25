namespace MindSetCSharp.Core.Tipos;

/// <summary>
/// Exemplos práticos demonstrando tipos em C#.
/// </summary>
public static class ExemplosTipos
{
    /// <summary>
    /// Exemplo 1: Diferença entre struct e class
    /// </summary>
    public static void ExemploStructVsClass()
    {
        TiposValorReferencia.DemonstrarDiferencas();
    }

    /// <summary>
    /// Exemplo 2: Tipos primitivos e seus limites
    /// </summary>
    public static void ExemploTiposPrimitivos()
    {
        TiposPrimitivos.DemonstrarTipos();
    }

    /// <summary>
    /// Exemplo 3: Tipos nullable (anuláveis)
    /// </summary>
    public static void ExemploNullable()
    {
        TiposNullable.DemonstrarNullable();
        TiposNullable.ExemploUsuarioComNullable();
    }

    /// <summary>
    /// Exemplo 4: Conversões de tipos (casting)
    /// </summary>
    public static void ExemploConversoes()
    {
        ConversoesTipos.DemonstrarConversoes();
    }

    /// <summary>
    /// Exemplo 5: Tipo dynamic
    /// </summary>
    public static void ExemploDynamic()
    {
        TipoDynamic.DemonstrarDynamic();
    }

    /// <summary>
    /// Exemplo 6: Tuplas - agrupamento de valores
    /// </summary>
    public static void ExemploTuplas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    TUPLAS (TUPLES)                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📦 CRIAÇÃO DE TUPLAS:\n");

        // Tupla simples
        var tupla1 = (1, 2);
        Console.WriteLine($"tupla1: {tupla1}");
        Console.WriteLine($"  Item1: {tupla1.Item1}");
        Console.WriteLine($"  Item2: {tupla1.Item2}");

        // Tupla com nomes
        var pessoa = (Nome: "João", Idade: 30, Cidade: "São Paulo");
        Console.WriteLine($"\npessoa: {pessoa}");
        Console.WriteLine($"  Nome: {pessoa.Nome}");
        Console.WriteLine($"  Idade: {pessoa.Idade}");
        Console.WriteLine($"  Cidade: {pessoa.Cidade}");

        // Tupla como retorno de método
        Console.WriteLine("\n\n🔄 RETORNANDO MÚLTIPLOS VALORES:\n");

        var resultado = DividirComResto(17, 5);
        Console.WriteLine($"17 ÷ 5:");
        Console.WriteLine($"  Quociente: {resultado.Quociente}");
        Console.WriteLine($"  Resto: {resultado.Resto}");

        // Desconstrução (deconstruction)
        var (quociente, resto) = DividirComResto(23, 7);
        Console.WriteLine($"\n23 ÷ 7:");
        Console.WriteLine($"  Quociente: {quociente}");
        Console.WriteLine($"  Resto: {resto}");

        // Tupla com tipos diferentes
        var dados = (Id: 1, Nome: "Produto", Preco: 29.99m, Disponivel: true);
        Console.WriteLine($"\n\nProduto:");
        Console.WriteLine($"  ID: {dados.Id}");
        Console.WriteLine($"  Nome: {dados.Nome}");
        Console.WriteLine($"  Preço: R$ {dados.Preco:F2}");
        Console.WriteLine($"  Disponível: {dados.Disponivel}");

        // Retornando dados de pessoa
        var (nome, idade, email) = ObterDadosUsuario();
        Console.WriteLine($"\n\nUsuário:");
        Console.WriteLine($"  Nome: {nome}");
        Console.WriteLine($"  Idade: {idade}");
        Console.WriteLine($"  Email: {email}");

        Console.WriteLine("\n\n💡 QUANDO USAR TUPLAS:\n");
        Console.WriteLine("✅ BOM para:");
        Console.WriteLine("   • Retornar múltiplos valores temporários");
        Console.WriteLine("   • Agrupamentos simples de dados");
        Console.WriteLine("   • Métodos privados/locais");
        Console.WriteLine("   • Processamento intermediário");

        Console.WriteLine("\n❌ EVITE para:");
        Console.WriteLine("   • APIs públicas (prefira classes)");
        Console.WriteLine("   • Dados complexos ou com lógica");
        Console.WriteLine("   • Quando precisa de métodos/validações");
        Console.WriteLine("   • Retornos que serão usados extensivamente");
    }

    private static (int Quociente, int Resto) DividirComResto(int dividendo, int divisor)
    {
        int quociente = dividendo / divisor;
        int resto = dividendo % divisor;
        return (quociente, resto);
    }

    private static (string Nome, int Idade, string Email) ObterDadosUsuario()
    {
        // Simula busca no banco de dados
        return ("Maria Silva", 28, "maria@email.com");
    }

    /// <summary>
    /// Exemplo 7: Comparação de performance - Struct vs Class
    /// </summary>
    public static void ExemploPerformance()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║         PERFORMANCE: STRUCT vs CLASS                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        const int iteracoes = 1_000_000;

        // Teste com Struct
        var sw = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < iteracoes; i++)
        {
            var ponto = new TiposValorReferencia.PontoStruct(i, i);
            _ = ponto.X + ponto.Y;
        }
        sw.Stop();
        var tempoStruct = sw.ElapsedMilliseconds;

        // Teste com Class
        sw.Restart();
        for (int i = 0; i < iteracoes; i++)
        {
            var ponto = new TiposValorReferencia.PontoClasse(i, i);
            _ = ponto.X + ponto.Y;
        }
        sw.Stop();
        var tempoClass = sw.ElapsedMilliseconds;

        Console.WriteLine($"🏃 Performance ({iteracoes:N0} iterações):\n");
        Console.WriteLine($"Struct (tipo de valor): {tempoStruct,10} ms");
        Console.WriteLine($"Class (tipo de ref):    {tempoClass,10} ms");
        Console.WriteLine($"Diferença:              {Math.Abs(tempoClass - tempoStruct),10} ms");

        if (tempoStruct < tempoClass)
        {
            var percentual = ((double)(tempoClass - tempoStruct) / tempoClass) * 100;
            Console.WriteLine($"\n✅ Struct foi ~{percentual:F1}% mais rápido");
        }

        Console.WriteLine("\n\n💡 QUANDO USAR CADA UM:\n");
        Console.WriteLine("USE STRUCT quando:");
        Console.WriteLine("   • Tipo pequeno (< 16 bytes recomendado)");
        Console.WriteLine("   • Imutável (não muda após criação)");
        Console.WriteLine("   • Sem herança necessária");
        Console.WriteLine("   • Performance crítica");
        Console.WriteLine("   • Muitas instâncias temporárias");
        Console.WriteLine("   Exemplos: Point, Rectangle, Color, Complex");

        Console.WriteLine("\nUSE CLASS quando:");
        Console.WriteLine("   • Tipo grande ou complexo");
        Console.WriteLine("   • Precisa de herança");
        Console.WriteLine("   • Identidade importante (referência)");
        Console.WriteLine("   • Mutável (estado muda frequentemente)");
        Console.WriteLine("   • Maioria dos casos!");
        Console.WriteLine("   Exemplos: Cliente, Produto, Pedido");
    }

    /// <summary>
    /// Exemplo 8: Tipo object e polimorfismo universal
    /// </summary>
    public static void ExemploTipoObject()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║            TIPO OBJECT - Base Universal              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📦 OBJECT - Todo tipo herda de System.Object:\n");

        // Array de objects pode conter qualquer coisa
        object[] colecao = new object[]
        {
            42,                    // int
            "texto",              // string
            3.14,                 // double
            true,                 // bool
            new DateTime(2025, 12, 25), // DateTime
            new[] { 1, 2, 3 }    // array
        };

        Console.WriteLine("Coleção heterogênea (object[]):");
        foreach (var item in colecao)
        {
            Console.WriteLine($"  Valor: {item,-30} | Tipo: {item.GetType().Name}");
        }

        // Métodos herdados de object
        Console.WriteLine("\n\n🔧 MÉTODOS DE SYSTEM.OBJECT:\n");

        object obj = "Exemplo";
        Console.WriteLine($"ToString():     {obj.ToString()}");
        Console.WriteLine($"GetType():      {obj.GetType()}");
        Console.WriteLine($"GetHashCode():  {obj.GetHashCode()}");
        Console.WriteLine($"Equals(obj):    {obj.Equals("Exemplo")}");

        Console.WriteLine("\n\n⚠️  PROBLEMAS DO TIPO OBJECT:\n");
        Console.WriteLine("❌ Sem type safety:");
        Console.WriteLine("   object x = 42;");
        Console.WriteLine("   string s = (string)x;  // Erro em runtime!");

        Console.WriteLine("\n❌ Requer boxing/unboxing:");
        Console.WriteLine("   int valor = 100;");
        Console.WriteLine("   object obj = valor;    // Boxing");
        Console.WriteLine("   int x = (int)obj;      // Unboxing");

        Console.WriteLine("\n✅ SOLUÇÃO: Use GENÉRICOS!");
        Console.WriteLine("   List<int> ao invés de ArrayList");
        Console.WriteLine("   Dictionary<K,V> ao invés de Hashtable");
        Console.WriteLine("   Queue<T> ao invés de Queue");
    }
}
