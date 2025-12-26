namespace MindSetCSharp.Core.Delegates;

/// <summary>
/// Exemplos práticos de delegates em C#
/// </summary>
public static class ExemplosDelegates
{
    /// <summary>
    /// Exemplo 1: Delegate básico e invocação
    /// </summary>
    public static void ExemploBasico()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 1: Delegate Básico                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Declaração e atribuição
        OperacaoBinaria soma = (a, b) => a + b;
        OperacaoBinaria multiplicacao = (a, b) => a * b;

        Console.WriteLine($"  Soma: 4 + 5 = {soma(4, 5)}");
        Console.WriteLine($"  Multiplicação: 4 * 5 = {multiplicacao(4, 5)}\n");

        // Passando delegate como parâmetro
        double Calcular(OperacaoBinaria op, double x, double y) => op(x, y);
        Console.WriteLine($"  Calcular (soma): {Calcular(soma, 10, 2)}");
        Console.WriteLine($"  Calcular (mult): {Calcular(multiplicacao, 10, 2)}\n");
    }

    /// <summary>
    /// Exemplo 2: Multicast delegates
    /// </summary>
    public static void ExemploMulticast()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 2: Multicast Delegates                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Action pipeline = null!;
        pipeline += () => Console.WriteLine("  Passo 1");
        pipeline += () => Console.WriteLine("  Passo 2");
        pipeline += () => Console.WriteLine("  Passo 3");

        pipeline();

        Console.WriteLine("\n📌 Ordem é a de inscrição (+=)");
        Console.WriteLine("📌 Se um handler lança exceção, a cadeia é interrompida");
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 3: Func, Action, Predicate
    /// </summary>
    public static void ExemploFuncActionPredicate()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 3: Func / Action / Predicate            ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Action<string> log = msg => Console.WriteLine($"  Log: {msg}");
        Func<int, int, int> somar = (a, b) => a + b;
        Predicate<int> ehPar = n => n % 2 == 0;

        log("Iniciando cálculos");
        Console.WriteLine($"  Soma 3+4 = {somar(3, 4)}");
        Console.WriteLine($"  8 é par? {ehPar(8)}\n");

        // Uso com LINQ
        var numeros = Enumerable.Range(1, 10).ToList();
        var pares = numeros.Where(n => ehPar(n)).ToList();
        Console.WriteLine($"  Pares: {string.Join(", ", pares)}\n");
    }

    /// <summary>
    /// Exemplo 4: Callbacks
    /// </summary>
    public static void ExemploCallbacks()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 4: Callbacks                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        void ProcessarArquivos(string pasta, Action<string> aoProcessar)
        {
            var arquivos = new[] { "a.txt", "b.txt", "c.txt" };
            foreach (var arq in arquivos)
            {
                aoProcessar(arq);
            }
        }

        ProcessarArquivos("/tmp", arq => Console.WriteLine($"  Processando {arq}"));
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 5: Delegates como estratégia (Strategy Pattern)
    /// </summary>
    public static void ExemploEstrategia()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 5: Strategy com Delegates              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var calculadora = new CalculadoraPreco();

        Console.WriteLine("  Produto: R$ 100, Estratégia: Padrão");
        Console.WriteLine($"  → Total: R$ {calculadora.Calcular(100, calculadora.PrecoPadrao):F2}\n");

        Console.WriteLine("  Produto: R$ 100, Estratégia: Black Friday");
        Console.WriteLine($"  → Total: R$ {calculadora.Calcular(100, calculadora.PrecoBlackFriday):F2}\n");

        Console.WriteLine("  Produto: R$ 100, Estratégia: Premium");
        Console.WriteLine($"  → Total: R$ {calculadora.Calcular(100, calculadora.PrecoPremium):F2}\n");
    }

    /// <summary>
    /// Exemplo 6: Covariância e Contravariância em delegates
    /// </summary>
    public static void ExemploCovarianciaContravariancia()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 6: Covariância / Contravariância       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Covariância: retorno mais derivado é aceito
        CriarAnimal criador = CriarCachorro;
        Animal a = criador();
        Console.WriteLine($"  Criado: {a.Nome} ({a.GetType().Name})\n");

        // Contravariância: parâmetro mais genérico é aceito
        ProcessarCachorro processador = ProcessarAnimal; // aceita Animal
        processador(new Cachorro("Rex"));
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 7: Delegates e eventos simples
    /// </summary>
    public static void ExemploDelegatesEventos()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 7: Delegates + Eventos                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var chat = new ChatSimples();
        chat.MensagemRecebida += msg => Console.WriteLine($"  Novo chat: {msg}");

        chat.Enviar("Olá mundo");
        chat.Enviar("Delegates são legais");
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 8: Boas práticas
    /// </summary>
    public static void ExemploBoasPraticas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 8: Boas Práticas                       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📌 Dicas rápidas:");
        Console.WriteLine("  • Prefira Func/Action/Predicate a delegates custom quando possível");
        Console.WriteLine("  • Multicast delegates executam em ordem de inscrição");
        Console.WriteLine("  • Trate exceções por handler para não interromper a cadeia");
        Console.WriteLine("  • Evite stateful lambdas quando possível (reduz acoplamento)");
        Console.WriteLine("  • Use delegates para estratégias e callbacks, não para tudo");
        Console.WriteLine();
    }

    // Helpers usados nos exemplos de covariância/contravariância
    private static Animal CriarCachorro() => new Cachorro("Bolt");
    private static void ProcessarAnimal(Animal a) => Console.WriteLine($"  Processando {a.Nome}");
}

// ==================== TIPOS AUXILIARES ====================

public delegate double OperacaoBinaria(double a, double b);

public class CalculadoraPreco
{
    public double Calcular(double precoBase, Func<double, double> estrategia)
        => estrategia(precoBase);

    public double PrecoPadrao(double preco) => preco;
    public double PrecoBlackFriday(double preco) => preco * 0.7;
    public double PrecoPremium(double preco) => preco * 1.2;
}

public class ChatSimples
{
    public Action<string>? MensagemRecebida;
    public void Enviar(string mensagem)
    {
        MensagemRecebida?.Invoke(mensagem);
    }
}

public class Animal
{
    public string Nome { get; set; }
    public Animal(string nome) => Nome = nome;
}

public class Cachorro : Animal
{
    public Cachorro(string nome) : base(nome) { }
}

public delegate Animal CriarAnimal();      // retorno covariante
public delegate void ProcessarCachorro(Cachorro c); // parâmetro contravariante
