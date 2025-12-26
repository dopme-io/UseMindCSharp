namespace MindSetCSharp.Core.Revisao;

/// <summary>
/// Exercícios de Revisão: Manipulação de Dados
/// Prática com tipos primitivos e operações de dados
/// </summary>
public static class ExerciciosManipulacaoDados
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║    EXERCÍCIOS: Manipulação de Dados                  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Exercicio1_ConversoesNuméricas();
        Exercicio2_OperaçõesComStrings();
        Exercicio3_DataeHora();
        Exercicio4_OperaçõesMatemáticas();
        Exercicio5_Validacoes();
    }

    /// <summary>
    /// Exercício 1: Converter tipos de dados
    /// </summary>
    private static void Exercicio1_ConversoesNuméricas()
    {
        Console.WriteLine("🔢 EXERCÍCIO 1: Conversões Numéricas\n");

        // Conversão implícita
        int numero = 100;
        double valor = numero;
        Console.WriteLine($"✓ Conversão implícita: {numero} → {valor}");

        // Conversão explícita (casting)
        double preco = 199.99;
        int precoInteiro = (int)preco;
        Console.WriteLine($"✓ Conversão explícita: {preco} → {precoInteiro}");

        // Parse
        string numeroStr = "42";
        int parsado = int.Parse(numeroStr);
        Console.WriteLine($"✓ Parse: \"{numeroStr}\" → {parsado}");

        // TryParse (mais seguro)
        string invalido = "abc";
        if (int.TryParse(invalido, out int resultado))
        {
            Console.WriteLine($"✓ Conversão bem-sucedida: {resultado}");
        }
        else
        {
            Console.WriteLine($"✓ TryParse falhou com segurança: \"{invalido}\" não é um número válido");
        }

        // Convert
        string valor100 = "100";
        int convertido = Convert.ToInt32(valor100);
        Console.WriteLine($"✓ Convert: \"{valor100}\" → {convertido}");
    }

    /// <summary>
    /// Exercício 2: Operações com Strings
    /// </summary>
    private static void Exercicio2_OperaçõesComStrings()
    {
        Console.WriteLine("\n📝 EXERCÍCIO 2: Operações com Strings\n");

        string texto = "  MindSet CSharp  ";
        
        // Trim, ToUpper, ToLower
        Console.WriteLine($"Original: '{texto}'");
        Console.WriteLine($"Trim: '{texto.Trim()}'");
        Console.WriteLine($"ToUpper: '{texto.ToUpper()}'");
        Console.WriteLine($"ToLower: '{texto.ToLower()}'");

        // Length, Contains, StartsWith, EndsWith
        string mensagem = "Olá, Mundo!";
        Console.WriteLine($"\nMensagem: '{mensagem}'");
        Console.WriteLine($"Comprimento: {mensagem.Length}");
        Console.WriteLine($"Contém 'Mundo': {mensagem.Contains("Mundo")}");
        Console.WriteLine($"Começa com 'Olá': {mensagem.StartsWith("Olá")}");
        Console.WriteLine($"Termina com '!': {mensagem.EndsWith("!")}");

        // IndexOf, Substring
        int indiceVirgula = mensagem.IndexOf(",");
        Console.WriteLine($"\nÍndice da vírgula: {indiceVirgula}");
        string primeiraParteStr = mensagem.Substring(0, indiceVirgula);
        Console.WriteLine($"Substring(0, {indiceVirgula}): '{primeiraParteStr}'");

        // Replace, Split
        string textoReplace = mensagem.Replace("Mundo", "CSharp");
        Console.WriteLine($"Replace 'Mundo' por 'CSharp': '{textoReplace}'");

        string[] palavras = mensagem.Split(" ");
        Console.WriteLine($"\nSplit por espaço: {string.Join(", ", palavras)}");

        // String interpolation
        string nome = "João";
        int idade = 30;
        Console.WriteLine($"Interpolação: Nome: {nome}, Idade: {idade}");
    }

    /// <summary>
    /// Exercício 3: Data e Hora
    /// </summary>
    private static void Exercicio3_DataeHora()
    {
        Console.WriteLine("\n📅 EXERCÍCIO 3: Data e Hora\n");

        // Data atual
        DateTime agora = DateTime.Now;
        Console.WriteLine($"Data e hora atual: {agora:dd/MM/yyyy HH:mm:ss}");
        Console.WriteLine($"Apenas data: {agora:dd/MM/yyyy}");
        Console.WriteLine($"Apenas hora: {agora:HH:mm:ss}");

        // Criar data específica
        DateTime aniversario = new DateTime(1990, 5, 15);
        Console.WriteLine($"\nData específica: {aniversario:dd/MM/yyyy}");

        // Diferença entre datas
        TimeSpan diferenca = agora - aniversario;
        Console.WriteLine($"Dias desde 15/05/1990: {diferenca.Days}");

        // Adicionar/Subtrair
        DateTime proximoAno = agora.AddYears(1);
        DateTime semanaPassada = agora.AddDays(-7);
        Console.WriteLine($"Próximo ano: {proximoAno:dd/MM/yyyy}");
        Console.WriteLine($"Semana passada: {semanaPassada:dd/MM/yyyy}");

        // Componentes
        Console.WriteLine($"\nAno: {agora.Year}, Mês: {agora.Month}, Dia: {agora.Day}");
        Console.WriteLine($"Hora: {agora.Hour}, Minuto: {agora.Minute}, Segundo: {agora.Second}");
    }

    /// <summary>
    /// Exercício 4: Operações Matemáticas
    /// </summary>
    private static void Exercicio4_OperaçõesMatemáticas()
    {
        Console.WriteLine("\n🧮 EXERCÍCIO 4: Operações Matemáticas\n");

        double numero = 16.5;

        // Math operations
        Console.WriteLine($"Número: {numero}");
        Console.WriteLine($"Math.Abs: {Math.Abs(-numero)}");
        Console.WriteLine($"Math.Floor: {Math.Floor(numero)}");
        Console.WriteLine($"Math.Ceiling: {Math.Ceiling(numero)}");
        Console.WriteLine($"Math.Round: {Math.Round(numero)}");
        Console.WriteLine($"Math.Sqrt: {Math.Sqrt(numero)}");
        Console.WriteLine($"Math.Pow(2, 3): {Math.Pow(2, 3)}");
        Console.WriteLine($"Math.Min(5, 3): {Math.Min(5, 3)}");
        Console.WriteLine($"Math.Max(5, 3): {Math.Max(5, 3)}");

        // Média
        int[] notas = { 8, 9, 7, 10 };
        double media = notas.Average();
        Console.WriteLine($"\nMédia de notas: {media:F2}");

        // Soma
        int soma = notas.Sum();
        Console.WriteLine($"Soma de notas: {soma}");

        // Modulo e resto
        Console.WriteLine($"\n10 % 3 = {10 % 3}");
        Console.WriteLine($"10 / 3 = {10 / 3}");
    }

    /// <summary>
    /// Exercício 5: Validações
    /// </summary>
    private static void Exercicio5_Validacoes()
    {
        Console.WriteLine("\n✅ EXERCÍCIO 5: Validações\n");

        // Validar email
        string email = "usuario@email.com";
        bool emailValido = email.Contains("@") && email.Contains(".");
        Console.WriteLine($"Email '{email}' válido? {emailValido}");

        // Validar CPF (simples)
        string cpf = "123.456.789-00";
        bool cpfValido = cpf.Length == 14 && cpf[3] == '.' && cpf[7] == '.' && cpf[11] == '-';
        Console.WriteLine($"CPF '{cpf}' no formato correto? {cpfValido}");

        // Validar idade
        DateTime dataNascimento = new DateTime(1995, 3, 20);
        int idade = DateTime.Now.Year - dataNascimento.Year;
        bool maiorIdade = idade >= 18;
        Console.WriteLine($"Maior de idade ({idade} anos)? {maiorIdade}");

        // Validar senha forte
        string senha = "Sen@ha123";
        bool senhaForte = senha.Length >= 8 &&
                         senha.Any(char.IsUpper) &&
                         senha.Any(char.IsLower) &&
                         senha.Any(char.IsDigit) &&
                         senha.Any(c => !char.IsLetterOrDigit(c));
        Console.WriteLine($"Senha forte? {senhaForte}");

        // Validar número em range
        int numero = 50;
        bool noRange = numero >= 0 && numero <= 100;
        Console.WriteLine($"Número {numero} está entre 0-100? {noRange}");
    }
}

/// <summary>
/// Exercícios de Revisão: Lógica de Programação
/// Desafios clássicos de algoritmos
/// </summary>
public static class ExerciciosLogicaProgramacao
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXERCÍCIOS: Lógica de Programação                  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Exercicio1_NumerosPares();
        Exercicio2_FatorialRecursivo();
        Exercicio3_FibonacciSequencia();
        Exercicio4_PrimeiroNumerosPrimos();
        Exercicio5_MaioreMenor();
    }

    /// <summary>
    /// Exercício 1: Números Pares e Ímpares
    /// </summary>
    private static void Exercicio1_NumerosPares()
    {
        Console.WriteLine("📊 EXERCÍCIO 1: Números Pares e Ímpares\n");

        Console.WriteLine("Números pares de 1 a 20:");
        for (int i = 1; i <= 20; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write($"{i} ");
            }
        }

        Console.WriteLine("\n\nNúmeros ímpares de 1 a 20:");
        for (int i = 1; i <= 20; i++)
        {
            if (i % 2 != 0)
            {
                Console.Write($"{i} ");
            }
        }

        Console.WriteLine("\n");
    }

    /// <summary>
    /// Exercício 2: Fatorial (Recursivo)
    /// </summary>
    private static void Exercicio2_FatorialRecursivo()
    {
        Console.WriteLine("🔢 EXERCÍCIO 2: Fatorial (Recursivo)\n");

        Console.WriteLine("Fatorial de números:");
        for (int i = 1; i <= 6; i++)
        {
            long fatorial = Fatorial(i);
            Console.WriteLine($"  {i}! = {fatorial}");
        }

        Console.WriteLine();
    }

    private static long Fatorial(int n)
    {
        if (n <= 1)
            return 1;
        return n * Fatorial(n - 1);
    }

    /// <summary>
    /// Exercício 3: Sequência de Fibonacci
    /// </summary>
    private static void Exercicio3_FibonacciSequencia()
    {
        Console.WriteLine("🔀 EXERCÍCIO 3: Fibonacci\n");

        Console.WriteLine("Primeiros 15 números de Fibonacci:");
        int[] fibonacci = new int[15];
        fibonacci[0] = 1;
        fibonacci[1] = 1;

        for (int i = 2; i < fibonacci.Length; i++)
        {
            fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
        }

        Console.WriteLine(string.Join(", ", fibonacci));
        Console.WriteLine();
    }

    /// <summary>
    /// Exercício 4: Primeiros números primos
    /// </summary>
    private static void Exercicio4_PrimeiroNumerosPrimos()
    {
        Console.WriteLine("✨ EXERCÍCIO 4: Números Primos\n");

        Console.WriteLine("Primeiros 20 números primos:");
        var primos = new List<int>();
        int numero = 2;

        while (primos.Count < 20)
        {
            if (EhPrimo(numero))
            {
                primos.Add(numero);
            }
            numero++;
        }

        Console.WriteLine(string.Join(", ", primos));
        Console.WriteLine();
    }

    private static bool EhPrimo(int numero)
    {
        if (numero < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(numero); i++)
        {
            if (numero % i == 0)
                return false;
        }
        return true;
    }

    /// <summary>
    /// Exercício 5: Maior e Menor valor
    /// </summary>
    private static void Exercicio5_MaioreMenor()
    {
        Console.WriteLine("📈 EXERCÍCIO 5: Maior e Menor\n");

        int[] numeros = { 45, 23, 89, 12, 56, 34, 78, 90, 11, 67 };

        int maior = numeros[0];
        int menor = numeros[0];

        foreach (int num in numeros)
        {
            if (num > maior)
                maior = num;
            if (num < menor)
                menor = num;
        }

        Console.WriteLine($"Array: {string.Join(", ", numeros)}");
        Console.WriteLine($"Maior valor: {maior}");
        Console.WriteLine($"Menor valor: {menor}");
        Console.WriteLine($"Diferença: {maior - menor}");
        Console.WriteLine();
    }
}

/// <summary>
/// Exercícios de Revisão: Orientação a Objetos
/// Prática com classes e relacionamentos
/// </summary>
public static class ExerciciosOrientacaoObjetos
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXERCÍCIOS: Orientação a Objetos                   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Exercicio1_ClassePessoa();
        Exercicio2_HerancaAnimal();
        Exercicio3_InterfaceVeiculo();
    }

    /// <summary>
    /// Exercício 1: Criar classe Pessoa
    /// </summary>
    private static void Exercicio1_ClassePessoa()
    {
        Console.WriteLine("👤 EXERCÍCIO 1: Classe Pessoa\n");

        var pessoa1 = new Pessoa("João Silva", 30, "João Silva");
        var pessoa2 = new Pessoa("Maria Santos", 25, "Maria Santos");

        pessoa1.ExibirDetalhes();
        pessoa2.ExibirDetalhes();

        pessoa1.FazerAniversario();
        Console.WriteLine($"\nApós aniversário: {pessoa1.Nome} agora tem {pessoa1.Idade} anos");
        Console.WriteLine();
    }

    /// <summary>
    /// Exercício 2: Herança com Animais
    /// </summary>
    private static void Exercicio2_HerancaAnimal()
    {
        Console.WriteLine("🐾 EXERCÍCIO 2: Herança - Animais\n");

        Animal cachorro = new Cachorro("Rex", 5);
        Animal gato = new Gato("Miau", 3);
        Animal passaro = new Passaro("Tweety", 2);

        cachorro.FazerSom();
        gato.FazerSom();
        passaro.FazerSom();

        Console.WriteLine();
    }

    /// <summary>
    /// Exercício 3: Interface Veículo
    /// </summary>
    private static void Exercicio3_InterfaceVeiculo()
    {
        Console.WriteLine("🚗 EXERCÍCIO 3: Interface - Veículos\n");

        IVeiculo carro = new Carro("Sedan", "Toyota");
        IVeiculo bicicleta = new Bicicleta("Mountain Bike", "Caloi");
        IVeiculo moto = new Moto("Big Bike", "Harley-Davidson");

        carro.Acelerar();
        bicicleta.Acelerar();
        moto.Acelerar();

        carro.Frear();
        bicicleta.Frear();
        moto.Frear();

        Console.WriteLine();
    }
}

/// <summary>
/// Exercícios de Revisão: Algoritmos
/// Desafios clássicos de computação
/// </summary>
public static class ExerciciosAlgoritmos
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXERCÍCIOS: Algoritmos                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Exercicio1_BuscaBinaria();
        Exercicio2_BolhaSort();
        Exercicio3_InversaoString();
    }

    /// <summary>
    /// Exercício 1: Busca Binária
    /// </summary>
    private static void Exercicio1_BuscaBinaria()
    {
        Console.WriteLine("🔍 EXERCÍCIO 1: Busca Binária\n");

        int[] numeros = { 2, 5, 8, 12, 16, 23, 38, 45, 56, 67, 78 };
        int alvo = 23;

        int indice = BuscaBinaria(numeros, alvo);

        if (indice != -1)
        {
            Console.WriteLine($"Array: {string.Join(", ", numeros)}");
            Console.WriteLine($"Número {alvo} encontrado no índice {indice}");
        }
        else
        {
            Console.WriteLine($"Número {alvo} não encontrado");
        }

        Console.WriteLine();
    }

    private static int BuscaBinaria(int[] array, int alvo)
    {
        int esquerda = 0;
        int direita = array.Length - 1;

        while (esquerda <= direita)
        {
            int meio = (esquerda + direita) / 2;

            if (array[meio] == alvo)
                return meio;

            if (array[meio] < alvo)
                esquerda = meio + 1;
            else
                direita = meio - 1;
        }

        return -1;
    }

    /// <summary>
    /// Exercício 2: Ordenação por Bolha
    /// </summary>
    private static void Exercicio2_BolhaSort()
    {
        Console.WriteLine("🫧 EXERCÍCIO 2: Ordenação por Bolha\n");

        int[] numeros = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine($"Original: {string.Join(", ", numeros)}");

        OrdenacaoBolha(numeros);

        Console.WriteLine($"Ordenado: {string.Join(", ", numeros)}");
        Console.WriteLine();
    }

    private static void OrdenacaoBolha(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Trocar
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    /// <summary>
    /// Exercício 3: Invertendo uma string
    /// </summary>
    private static void Exercicio3_InversaoString()
    {
        Console.WriteLine("🔄 EXERCÍCIO 3: Inversão de String\n");

        string texto = "MindSet CSharp";
        string invertido = new string(texto.Reverse().ToArray());

        Console.WriteLine($"Original:  {texto}");
        Console.WriteLine($"Invertido: {invertido}");

        // Verificar palíndromo
        string palindromo = "arara";
        string palindromoInvertido = new string(palindromo.Reverse().ToArray());
        bool ehPalindromo = palindromo == palindromoInvertido;

        Console.WriteLine($"\n'{palindromo}' é palíndromo? {ehPalindromo}");
        Console.WriteLine();
    }
}

/// <summary>
/// Exercícios de Revisão: Coleções
/// Prática com listas, dicionários, etc
/// </summary>
public static class ExerciciosColeções
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXERCÍCIOS: Coleções                             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Exercicio1_ListaCompras();
        Exercicio2_DicionarioEstoque();
        Exercicio3_HashSetUnicos();
    }

    /// <summary>
    /// Exercício 1: Lista de Compras
    /// </summary>
    private static void Exercicio1_ListaCompras()
    {
        Console.WriteLine("🛒 EXERCÍCIO 1: Lista de Compras\n");

        var listaCompras = new List<string>
        {
            "Leite",
            "Pão",
            "Ovos",
            "Frutas",
            "Verduras"
        };

        Console.WriteLine("Lista inicial:");
        for (int i = 0; i < listaCompras.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {listaCompras[i]}");
        }

        listaCompras.Add("Queijo");
        Console.WriteLine("\n✅ Adicionado: Queijo");

        listaCompras.Remove("Pão");
        Console.WriteLine("❌ Removido: Pão");

        Console.WriteLine("\nLista final:");
        for (int i = 0; i < listaCompras.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {listaCompras[i]}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exercício 2: Dicionário de Estoque
    /// </summary>
    private static void Exercicio2_DicionarioEstoque()
    {
        Console.WriteLine("📦 EXERCÍCIO 2: Dicionário de Estoque\n");

        var estoque = new Dictionary<string, int>
        {
            { "Notebook", 10 },
            { "Mouse", 50 },
            { "Teclado", 30 },
            { "Monitor", 15 }
        };

        Console.WriteLine("Estoque atual:");
        foreach (var item in estoque)
        {
            Console.WriteLine($"  {item.Key}: {item.Value} unidades");
        }

        estoque["Notebook"] -= 2;
        Console.WriteLine("\n✓ Vendido 2 Notebooks");
        Console.WriteLine($"Estoque de Notebook: {estoque["Notebook"]}");

        estoque["USB"] = 100;
        Console.WriteLine("\n✓ Adicionado novo produto: USB (100 unidades)");

        Console.WriteLine();
    }

    /// <summary>
    /// Exercício 3: HashSet para valores únicos
    /// </summary>
    private static void Exercicio3_HashSetUnicos()
    {
        Console.WriteLine("⚡ EXERCÍCIO 3: Valores Únicos com HashSet\n");

        int[] numerosComDuplicatas = { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5 };
        var numeroUnicos = new HashSet<int>(numerosComDuplicatas);

        Console.WriteLine($"Array com duplicatas: {string.Join(", ", numerosComDuplicatas)}");
        Console.WriteLine($"Valores únicos: {string.Join(", ", numeroUnicos.OrderBy(n => n))}");
        Console.WriteLine($"Quantidade de duplicatas removidas: {numerosComDuplicatas.Length - numeroUnicos.Count}");

        Console.WriteLine();
    }
}

/// <summary>
/// Desafios Práticos: Cenários do Mundo Real
/// </summary>
public static class DesafiosPraticos
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     DESAFIOS PRÁTICOS: Mundo Real                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Desafio1_CalculadoraIMC();
        Desafio2_GerenciadorTarefas();
        Desafio3_SistemaNotas();
    }

    /// <summary>
    /// Desafio 1: Calculadora de IMC
    /// </summary>
    private static void Desafio1_CalculadoraIMC()
    {
        Console.WriteLine("⚕️  DESAFIO 1: Calculadora de IMC\n");

        var pessoas = new List<PessoaIMC>
        {
            new PessoaIMC("Ana Silva", 65, 1.70),
            new PessoaIMC("Bruno Santos", 85, 1.80),
            new PessoaIMC("Carlos Junior", 95, 1.75)
        };

        foreach (var pessoa in pessoas)
        {
            double imc = pessoa.CalcularIMC();
            string classificacao = ClassificarIMC(imc);

            Console.WriteLine($"👤 {pessoa.Nome}");
            Console.WriteLine($"   Peso: {pessoa.Peso} kg | Altura: {pessoa.Altura} m");
            Console.WriteLine($"   IMC: {imc:F2} ({classificacao})");
            Console.WriteLine();
        }
    }

    private static string ClassificarIMC(double imc)
    {
        return imc switch
        {
            < 18.5 => "Abaixo do peso",
            < 25 => "Peso normal",
            < 30 => "Sobrepeso",
            _ => "Obeso"
        };
    }

    /// <summary>
    /// Desafio 2: Gerenciador de Tarefas
    /// </summary>
    private static void Desafio2_GerenciadorTarefas()
    {
        Console.WriteLine("✅ DESAFIO 2: Gerenciador de Tarefas\n");

        var tarefas = new List<Tarefa>
        {
            new Tarefa(1, "Estudar C#", false),
            new Tarefa(2, "Criar projeto", true),
            new Tarefa(3, "Revisar código", false),
            new Tarefa(4, "Documentar", false)
        };

        Console.WriteLine("Todas as tarefas:");
        foreach (var tarefa in tarefas)
        {
            string status = tarefa.Concluida ? "✓" : "○";
            Console.WriteLine($"  {status} [{tarefa.Id}] {tarefa.Descricao}");
        }

        Console.WriteLine($"\nTarefas concluídas: {tarefas.Count(t => t.Concluida)}");
        Console.WriteLine($"Tarefas pendentes: {tarefas.Count(t => !t.Concluida)}");

        Console.WriteLine();
    }

    /// <summary>
    /// Desafio 3: Sistema de Notas
    /// </summary>
    private static void Desafio3_SistemaNotas()
    {
        Console.WriteLine("📊 DESAFIO 3: Sistema de Notas\n");

        var alunos = new List<Aluno>
        {
            new Aluno("Ana Silva", new[] { 8.0, 9.0, 8.5 }),
            new Aluno("Bruno Santos", new[] { 7.0, 7.5, 8.0 }),
            new Aluno("Carlos Junior", new[] { 9.0, 9.5, 10.0 })
        };

        foreach (var aluno in alunos)
        {
            double media = aluno.CalcularMedia();
            string situacao = media >= 7 ? "✓ Aprovado" : "✗ Reprovado";

            Console.WriteLine($"📚 {aluno.Nome}");
            Console.WriteLine($"   Notas: {string.Join(", ", aluno.Notas.Select(n => n.ToString("F1")))}");
            Console.WriteLine($"   Média: {media:F2} - {situacao}");
            Console.WriteLine();
        }
    }
}

// ==================== CLASSES AUXILIARES ====================

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Documento { get; set; }

    public Pessoa(string nome, int idade, string documento)
    {
        Nome = nome;
        Idade = idade;
        Documento = documento;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Idade: {Idade} anos");
        Console.WriteLine($"Documento: {Documento}");
    }

    public void FazerAniversario()
    {
        Idade++;
    }
}

public abstract class Animal
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Animal(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public abstract void FazerSom();
}

public class Cachorro : Animal
{
    public Cachorro(string nome, int idade) : base(nome, idade) { }

    public override void FazerSom()
    {
        Console.WriteLine($"🐕 {Nome}: Au au au!");
    }
}

public class Gato : Animal
{
    public Gato(string nome, int idade) : base(nome, idade) { }

    public override void FazerSom()
    {
        Console.WriteLine($"🐈 {Nome}: Miau!");
    }
}

public class Passaro : Animal
{
    public Passaro(string nome, int idade) : base(nome, idade) { }

    public override void FazerSom()
    {
        Console.WriteLine($"🐦 {Nome}: Piu piu!");
    }
}

public interface IVeiculo
{
    void Acelerar();
    void Frear();
}

public class Carro : IVeiculo
{
    public string Tipo { get; set; }
    public string Marca { get; set; }

    public Carro(string tipo, string marca)
    {
        Tipo = tipo;
        Marca = marca;
    }

    public void Acelerar()
    {
        Console.WriteLine($"🚗 {Marca} {Tipo}: Vroom! Acelerou.");
    }

    public void Frear()
    {
        Console.WriteLine($"🚗 {Marca} {Tipo}: Freou com freios a disco.");
    }
}

public class Bicicleta : IVeiculo
{
    public string Tipo { get; set; }
    public string Marca { get; set; }

    public Bicicleta(string tipo, string marca)
    {
        Tipo = tipo;
        Marca = marca;
    }

    public void Acelerar()
    {
        Console.WriteLine($"🚲 {Marca} {Tipo}: Pedalou mais rápido.");
    }

    public void Frear()
    {
        Console.WriteLine($"🚲 {Marca} {Tipo}: Freou com freio a sapata.");
    }
}

public class Moto : IVeiculo
{
    public string Tipo { get; set; }
    public string Marca { get; set; }

    public Moto(string tipo, string marca)
    {
        Tipo = tipo;
        Marca = marca;
    }

    public void Acelerar()
    {
        Console.WriteLine($"🏍️  {Marca} {Tipo}: Vrroooom! Acelerou com tudo.");
    }

    public void Frear()
    {
        Console.WriteLine($"🏍️  {Marca} {Tipo}: Freou com freios hidráulicos.");
    }
}

public class PessoaIMC
{
    public string Nome { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }

    public PessoaIMC(string nome, double peso, double altura)
    {
        Nome = nome;
        Peso = peso;
        Altura = altura;
    }

    public double CalcularIMC()
    {
        return Peso / (Altura * Altura);
    }
}

public class Tarefa
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; set; }

    public Tarefa(int id, string descricao, bool concluida = false)
    {
        Id = id;
        Descricao = descricao;
        Concluida = concluida;
    }
}

public class Aluno
{
    public string Nome { get; set; }
    public double[] Notas { get; set; }

    public Aluno(string nome, double[] notas)
    {
        Nome = nome;
        Notas = notas;
    }

    public double CalcularMedia()
    {
        return Notas.Average();
    }
}
