namespace MindSetCSharp.Core.Objetos;

/// <summary>
/// Classe com exemplos práticos de criação e manipulação de objetos.
/// Demonstra os conceitos fundamentais de POO em C#.
/// </summary>
public static class ExemplosObjetos
{
    /// <summary>
    /// Exemplo 1: Criando e usando objetos Pessoa
    /// </summary>
    public static void ExemploPessoa()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║         EXEMPLO 1: Objetos Pessoa                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando objetos usando diferentes construtores
        Pessoa pessoa1 = new Pessoa();
        Console.WriteLine("Pessoa 1 (construtor padrão):");
        pessoa1.ApresentarSe();

        Console.WriteLine();

        Pessoa pessoa2 = new Pessoa("Maria Silva", 25, "maria@email.com");
        Console.WriteLine("Pessoa 2 (construtor completo):");
        pessoa2.ApresentarSe();

        Console.WriteLine();

        Pessoa pessoa3 = new Pessoa("João Santos", 17);
        Console.WriteLine("Pessoa 3 (construtor sem e-mail):");
        pessoa3.ApresentarSe();

        // Verificando maioridade
        Console.WriteLine($"\n{pessoa2.Nome} é maior de idade? {pessoa2.EhMaiorDeIdade()}");
        Console.WriteLine($"{pessoa3.Nome} é maior de idade? {pessoa3.EhMaiorDeIdade()}");

        // Fazendo aniversário
        Console.WriteLine();
        pessoa3.FazerAniversario();
        Console.WriteLine($"{pessoa3.Nome} agora é maior de idade? {pessoa3.EhMaiorDeIdade()}");

        // Usando ToString
        Console.WriteLine("\n--- Representação dos objetos ---");
        Console.WriteLine(pessoa1.ToString());
        Console.WriteLine(pessoa2.ToString());
        Console.WriteLine(pessoa3.ToString());
    }

    /// <summary>
    /// Exemplo 2: Sistema bancário demonstrando estado e comportamento
    /// </summary>
    public static void ExemploContaBancaria()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 2: Sistema Bancário (Estado e Ação)    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando contas bancárias
        ContaBancaria conta1 = new ContaBancaria("Ana Paula", "12345-6", 1000m);
        ContaBancaria conta2 = new ContaBancaria("Carlos Souza", "78910-1", 500m);

        // Exibindo extratos iniciais
        conta1.ExibirExtrato();
        conta2.ExibirExtrato();

        // Realizando operações
        Console.WriteLine("--- OPERAÇÕES BANCÁRIAS ---\n");
        
        conta1.Depositar(500m);
        Console.WriteLine();
        
        conta1.Sacar(200m);
        Console.WriteLine();
        
        conta1.Sacar(2000m); // Tentativa de saque com saldo insuficiente
        Console.WriteLine();
        
        conta1.Transferir(conta2, 300m);

        // Extratos finais
        Console.WriteLine("\n--- EXTRATOS FINAIS ---");
        conta1.ExibirExtrato();
        conta2.ExibirExtrato();
    }

    /// <summary>
    /// Exemplo 3: Múltiplos objetos e interações
    /// </summary>
    public static void ExemploMultiplosObjetos()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 3: Múltiplos Objetos Interagindo       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando uma lista de pessoas
        List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa("Alice", 30, "alice@email.com"),
            new Pessoa("Bruno", 25),
            new Pessoa("Carla", 35, "carla@email.com"),
            new Pessoa("Daniel", 16),
            new Pessoa("Elena", 28, "elena@email.com")
        };

        Console.WriteLine("📋 Lista de Pessoas Cadastradas:\n");
        foreach (Pessoa pessoa in pessoas)
        {
            Console.WriteLine($"  • {pessoa.Nome} - {pessoa.Idade} anos");
        }

        // Filtrando maiores de idade
        Console.WriteLine("\n👥 Pessoas Maiores de Idade:\n");
        foreach (Pessoa pessoa in pessoas)
        {
            if (pessoa.EhMaiorDeIdade())
            {
                Console.WriteLine($"  ✓ {pessoa.Nome} ({pessoa.Idade} anos)");
            }
        }

        // Contando maiores de idade usando LINQ
        int quantidadeMaiores = pessoas.Count(p => p.EhMaiorDeIdade());
        Console.WriteLine($"\n📊 Total de maiores de idade: {quantidadeMaiores} de {pessoas.Count}");

        // Pessoa mais velha
        Pessoa maisVelha = pessoas.OrderByDescending(p => p.Idade).First();
        Console.WriteLine($"👴 Pessoa mais velha: {maisVelha.Nome} com {maisVelha.Idade} anos");

        // Pessoa mais jovem
        Pessoa maisJovem = pessoas.OrderBy(p => p.Idade).First();
        Console.WriteLine($"👶 Pessoa mais jovem: {maisJovem.Nome} com {maisJovem.Idade} anos");
    }

    /// <summary>
    /// Conceitos de referência: dois nomes para o mesmo objeto
    /// </summary>
    public static void ExemploReferencias()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║        EXEMPLO 4: Objetos e Referências             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Pessoa pessoa1 = new Pessoa("Roberto", 40, "roberto@email.com");
        Pessoa pessoa2 = pessoa1; // pessoa2 referencia o MESMO objeto que pessoa1

        Console.WriteLine("Estado inicial:");
        Console.WriteLine($"pessoa1: {pessoa1.Nome}, {pessoa1.Idade} anos");
        Console.WriteLine($"pessoa2: {pessoa2.Nome}, {pessoa2.Idade} anos");

        Console.WriteLine("\nAlterando pessoa2.Nome...");
        pessoa2.Nome = "Roberto Carlos";

        Console.WriteLine("\nEstado após alteração:");
        Console.WriteLine($"pessoa1: {pessoa1.Nome}, {pessoa1.Idade} anos");
        Console.WriteLine($"pessoa2: {pessoa2.Nome}, {pessoa2.Idade} anos");

        Console.WriteLine("\n💡 Ambos apontam para o MESMO objeto na memória!");
        Console.WriteLine($"   pessoa1 == pessoa2? {pessoa1 == pessoa2}");
    }
}
