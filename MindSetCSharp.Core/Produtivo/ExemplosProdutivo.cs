namespace MindSetCSharp.Core.Produtivo;
using System.Collections.Concurrent;
using System.Diagnostics;

/// <summary>
/// Exemplos de técnicas para aumentar produtividade em C#
/// </summary>
public static class ExemplosProdutivo
{
    /// <summary>
    /// Exemplo 1: LINQ Avançado
    /// Operações complexas em coleções
    /// </summary>
    public static void ExemploLinqAvancado()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 1: LINQ Avançado                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var produtos = new List<Produto>
        {
            new("Notebook", 3000, "Eletrônicos"),
            new("Mouse", 50, "Acessórios"),
            new("Teclado", 150, "Acessórios"),
            new("Monitor", 800, "Eletrônicos"),
            new("Webcam", 200, "Acessórios")
        };

        // Group by com agregação
        Console.WriteLine("📌 Agrupamento e Agregação:\n");
        var porCategoria = produtos
            .GroupBy(p => p.Categoria)
            .Select(g => new
            {
                Categoria = g.Key,
                Quantidade = g.Count(),
                PreçoMédio = g.Average(p => p.Preco),
                PreçoTotal = g.Sum(p => p.Preco)
            })
            .OrderByDescending(x => x.PreçoTotal);

        foreach (var grupo in porCategoria)
        {
            Console.WriteLine($"  • {grupo.Categoria}");
            Console.WriteLine($"    - Qtd: {grupo.Quantidade} | Média: R$ {grupo.PreçoMédio:F2} | Total: R$ {grupo.PreçoTotal:F2}\n");
        }

        // Join com múltiplas tabelas
        Console.WriteLine("📌 Join com Múltiplas Fontes:\n");
        var vendas = new List<(string Produto, int Quantidade)>
        {
            ("Notebook", 2),
            ("Mouse", 10),
            ("Monitor", 1)
        };

        var relatorio = produtos
            .Join(
                vendas,
                p => p.Nome,
                v => v.Produto,
                (p, v) => new
                {
                    p.Nome,
                    p.Preco,
                    v.Quantidade,
                    Total = p.Preco * v.Quantidade
                }
            )
            .OrderByDescending(x => x.Total);

        foreach (var item in relatorio)
        {
            Console.WriteLine($"  • {item.Nome}: {item.Quantidade}x R$ {item.Preco:F2} = R$ {item.Total:F2}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 2: Lambda Expressions
    /// Funções anônimas para código conciso
    /// </summary>
    public static void ExemploLambdaExpressions()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 2: Lambda Expressions                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Lambda para Func<T, TResult>
        Console.WriteLine("📌 Lambdas com Func e Action:\n");
        
        Func<int, int, int> somar = (a, b) => a + b;
        Func<int, int, int> multiplicar = (a, b) => a * b;
        Func<double, double> raizQuadrada = x => Math.Sqrt(x);

        Console.WriteLine($"  • Soma: 5 + 3 = {somar(5, 3)}");
        Console.WriteLine($"  • Multiplicação: 5 × 3 = {multiplicar(5, 3)}");
        Console.WriteLine($"  • Raiz: √16 = {raizQuadrada(16)}\n");

        // Expression bodies
        Console.WriteLine("📌 Expression Bodies (C# 6+):\n");
        var calcular = (int a, int b) => (
            Soma: a + b,
            Diferença: a - b,
            Produto: a * b,
            Quociente: b != 0 ? a / (double)b : 0
        );

        var resultado = calcular(20, 4);
        Console.WriteLine($"  • Soma: {resultado.Soma}");
        Console.WriteLine($"  • Diferença: {resultado.Diferença}");
        Console.WriteLine($"  • Produto: {resultado.Produto}");
        Console.WriteLine($"  • Quociente: {resultado.Quociente}\n");

        // Predicados
        Console.WriteLine("📌 Predicados (Filtros):\n");
        var numeros = Enumerable.Range(1, 10).ToList();
        
        Func<int, bool> éPar = n => n % 2 == 0;
        Func<int, bool> éMaiorQueCinco = n => n > 5;

        var pares = numeros.Where(éPar).ToList();
        var maiores = numeros.Where(éMaiorQueCinco).ToList();

        Console.WriteLine($"  • Pares: {string.Join(", ", pares)}");
        Console.WriteLine($"  • Maiores que 5: {string.Join(", ", maiores)}\n");
    }

    /// <summary>
    /// Exemplo 3: Extension Methods
    /// Estender funcionalidade de tipos existentes
    /// </summary>
    public static void ExemploExtensionMethods()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 3: Extension Methods                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // String extensions
        Console.WriteLine("📌 String Extensions:\n");
        string texto = "Hello World";
        
        Console.WriteLine($"  • Original: \"{texto}\"");
        Console.WriteLine($"  • Invertido: \"{texto.Inverter()}\"");
        Console.WriteLine($"  • Capitalizado: \"{texto.Capitalizar()}\"");
        Console.WriteLine($"  • Primeiras 5 letras: \"{texto.Primeiras(5)}\"\n");

        // Collection extensions
        Console.WriteLine("📌 Collection Extensions:\n");
        var numeros = new[] { 1, 2, 3, 4, 5 };
        
        Console.WriteLine($"  • Array: [{string.Join(", ", numeros)}]");
        Console.WriteLine($"  • Media: {numeros.Media()}");
        Console.WriteLine($"  • Variância: {numeros.Variancia():F2}");
        Console.WriteLine($"  • Desvio Padrão: {numeros.DesvioPadrao():F2}\n");

        // Object extensions
        Console.WriteLine("📌 Object Extensions:\n");
        var obj = new { Nome = "João", Idade = 30 };
        
        Console.WriteLine($"  • Objeto: {obj}");
        Console.WriteLine($"  • JSON: {obj.ParaJson()}");
        Console.WriteLine($"  • Tipo: {obj.GetType().Name}\n");
    }

    /// <summary>
    /// Exemplo 4: Pattern Matching
    /// Código mais limpo com pattern matching
    /// </summary>
    public static void ExemploPatternMatching()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 4: Pattern Matching                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Type pattern
        Console.WriteLine("📌 Type Pattern:\n");
        object[] valores = { 10, "texto", 3.14, null, true, new Produto("Produto", 100, "Cat") };

        foreach (var valor in valores)
        {
            Console.Write($"  • {valor?.ToString() ?? "null"} => ");
            Console.WriteLine(valor switch
            {
                int i => $"Inteiro: {i}",
                string s => $"String: {s}",
                double d => $"Double: {d}",
                bool b => $"Bool: {b}",
                Produto p => $"Produto: {p.Nome}",
                null => "Nulo",
                _ => "Desconhecido"
            });
        }

        // Relational pattern
        Console.WriteLine("\n📌 Relational Pattern (Comparações):\n");
        var idades = new[] { 5, 15, 25, 45, 75 };

        foreach (var idade in idades)
        {
            Console.Write($"  • Idade {idade}: ");
            Console.WriteLine(idade switch
            {
                < 13 => "Criança",
                < 18 => "Adolescente",
                < 60 => "Adulto",
                _ => "Idoso"
            });
        }

        // Property pattern
        Console.WriteLine("\n📌 Property Pattern:\n");
        var pessoas = new[]
        {
            new Pessoa { Nome = "Alice", Idade = 25, Salario = 3000 },
            new Pessoa { Nome = "Bob", Idade = 35, Salario = 5000 },
            new Pessoa { Nome = "Charlie", Idade = 22, Salario = 2000 }
        };

        foreach (var pessoa in pessoas)
        {
            var categoria = pessoa switch
            {
                { Idade: >= 30, Salario: >= 4000 } => "Senior bem remunerado",
                { Idade: >= 30 } => "Senior",
                { Salario: >= 3000 } => "Bem remunerado",
                _ => "Junior"
            };

            Console.WriteLine($"  • {pessoa.Nome}: {categoria}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 5: Task Parallel Library
    /// Processamento paralelo
    /// </summary>
    public static void ExemploTaskParallel()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 5: Task Parallel Library                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Parallel.For
        Console.WriteLine("📌 Parallel.For:\n");
        var sw = Stopwatch.StartNew();
        var resultados = new int[10];

        Parallel.For(0, 10, i =>
        {
            System.Threading.Thread.Sleep(100); // Simular trabalho
            resultados[i] = i * i;
        });

        sw.Stop();
        Console.WriteLine($"  • Sequencial esperado: ~1000ms");
        Console.WriteLine($"  • Paralelo obtido: ~{sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"  • Ganho: {(1000 - sw.ElapsedMilliseconds) / 1000.0:P0}\n");

        // Parallel.ForEach
        Console.WriteLine("📌 Parallel.ForEach com PLINQ:\n");
        var numeros = Enumerable.Range(1, 10).ToList();

        sw.Restart();
        var quadrados = numeros
            .AsParallel()
            .Select(n => { System.Threading.Thread.Sleep(100); return n * n; })
            .OrderBy(n => n)
            .ToList();
        sw.Stop();

        Console.WriteLine($"  • Resultado: [{string.Join(", ", quadrados.Take(5))}...]");
        Console.WriteLine($"  • Tempo: ~{sw.ElapsedMilliseconds}ms\n");
    }

    /// <summary>
    /// Exemplo 6: Async/Await
    /// Programação assíncrona
    /// </summary>
    public static void ExemploAsyncAwait()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 6: Async/Await                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Simular operação assíncrona
        Console.WriteLine("📌 Operações Assíncronas:\n");
        
        var tarefas = new[]
        {
            ExecutarOperacaoAsync("Download dados", 500),
            ExecutarOperacaoAsync("Processar", 300),
            ExecutarOperacaoAsync("Salvar", 200)
        };

        Task.WaitAll(tarefas);
        Console.WriteLine("  ✓ Todas as operações concluídas!\n");

        // Async LINQ
        Console.WriteLine("📌 Async Combinado com LINQ:\n");
        ProcessarDadosAsync();
    }

    /// <summary>
    /// Exemplo 7: Records (C# 9+)
    /// Tipos de dados imutáveis
    /// </summary>
    public static void ExemploRecords()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 7: Records                               ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Record positional
        Console.WriteLine("📌 Record Positional:\n");
        var ponto1 = new Ponto(10, 20);
        var ponto2 = new Ponto(10, 20);
        var ponto3 = new Ponto(5, 15);

        Console.WriteLine($"  • Ponto1: {ponto1}");
        Console.WriteLine($"  • Ponto2: {ponto2}");
        Console.WriteLine($"  • Ponto1 == Ponto2: {ponto1 == ponto2}");
        Console.WriteLine($"  • Ponto1 == Ponto3: {ponto1 == ponto3}\n");

        // With expressions
        Console.WriteLine("📌 With Expressions (Imutabilidade):\n");
        var produto1 = new ProdutoRecord("Notebook", 3000, "Eletrônicos");
        var produto2 = produto1 with { Preco = 2500 }; // Cria cópia modificada

        Console.WriteLine($"  • Original: {produto1}");
        Console.WriteLine($"  • Modificado: {produto2}");
        Console.WriteLine($"  • Mesmo objeto? {ReferenceEquals(produto1, produto2)}\n");
    }

    /// <summary>
    /// Exemplo 8: Programação Funcional
    /// Composição e funções puras
    /// </summary>
    public static void ExemploFunctional()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 8: Programação Funcional                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Composição de funções
        Console.WriteLine("📌 Composição de Funções:\n");
        
        Func<int, int> dobrar = x => x * 2;
        Func<int, int> adicionar10 = x => x + 10;
        Func<int, int> elevarAoQuadrado = x => x * x;

        // Compor: elevar ao quadrado (dobrar + 10)
        var resultado = elevarAoQuadrado(adicionar10(dobrar(5)));
        Console.WriteLine($"  • Entrada: 5");
        Console.WriteLine($"  • Dobrar: 5 × 2 = 10");
        Console.WriteLine($"  • Adicionar 10: 10 + 10 = 20");
        Console.WriteLine($"  • Elevar ao quadrado: 20² = {resultado}\n");

        // Pipeline de transformações
        Console.WriteLine("📌 Pipeline de Transformações:\n");
        var dados = Enumerable.Range(1, 5).ToList();

        var pipeline = dados
            .Select(x => x * 2)      // Dobrar
            .Where(x => x > 5)       // Filtrar maiores que 5
            .Select(x => x + 10)     // Adicionar 10
            .ToList();

        Console.WriteLine($"  • Entrada: [1, 2, 3, 4, 5]");
        Console.WriteLine($"  • Após pipeline: [{string.Join(", ", pipeline)}]\n");

        // Curry (Redução de Parâmetros)
        Console.WriteLine("📌 Currying:\n");
        
        Func<int, Func<int, Func<int, int>>> adicionarCurryfied = a => b => c => a + b + c;
        var adicionar5 = adicionarCurryfied(5);
        var adicionar5e3 = adicionar5(3);
        var resultado2 = adicionar5e3(2);

        Console.WriteLine($"  • Curried function: adicionarCurryfied(5)(3)(2) = {resultado2}\n");
    }

    // Métodos auxiliares
    private static async Task ExecutarOperacaoAsync(string nome, int delay)
    {
        Console.WriteLine($"  → Iniciando: {nome}...");
        await Task.Delay(delay);
        Console.WriteLine($"  ✓ Concluído: {nome}");
    }

    private static async void ProcessarDadosAsync()
    {
        var tarefas = new[]
        {
            FetchDadosAsync("API 1"),
            FetchDadosAsync("API 2"),
            FetchDadosAsync("API 3")
        };

        var resultados = await Task.WhenAll(tarefas);
        Console.WriteLine($"  • Resultados: [{string.Join(", ", resultados)}]");
    }

    private static async Task<string> FetchDadosAsync(string fonte)
    {
        await Task.Delay(Random.Shared.Next(100, 300));
        return $"{fonte}=OK";
    }
}

// ==================== TIPOS AUXILIARES ====================

/// <summary>
/// Classe de Produto
/// </summary>
public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string Categoria { get; set; }

    public Produto(string nome, decimal preco, string categoria)
    {
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
    }
}

/// <summary>
/// Classe de Pessoa
/// </summary>
public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public decimal Salario { get; set; }
}

/// <summary>
/// Record de Ponto (C# 9+)
/// </summary>
public record Ponto(int X, int Y)
{
    public override string ToString() => $"({X}, {Y})";
}

/// <summary>
/// Record de Produto
/// </summary>
public record ProdutoRecord(string Nome, decimal Preco, string Categoria);

// ==================== EXTENSION METHODS ====================

/// <summary>
/// Extension methods para String
/// </summary>
public static class StringExtensions
{
    public static string Inverter(this string texto)
    {
        return new string(texto.Reverse().ToArray());
    }

    public static string Capitalizar(this string texto)
    {
        if (string.IsNullOrEmpty(texto)) return texto;
        return char.ToUpper(texto[0]) + texto.Substring(1).ToLower();
    }

    public static string Primeiras(this string texto, int quantidade)
    {
        return texto.Substring(0, Math.Min(quantidade, texto.Length));
    }
}

/// <summary>
/// Extension methods para Coleções
/// </summary>
public static class CollectionExtensions
{
    public static double Media(this IEnumerable<int> numeros)
    {
        return numeros.Average();
    }

    public static double Variancia(this IEnumerable<int> numeros)
    {
        var lista = numeros.ToList();
        var media = lista.Average();
        return lista.Select(x => Math.Pow(x - media, 2)).Average();
    }

    public static double DesvioPadrao(this IEnumerable<int> numeros)
    {
        return Math.Sqrt(numeros.Variancia());
    }
}

/// <summary>
/// Extension methods para Object
/// </summary>
public static class ObjectExtensions
{
    public static string ParaJson(this object obj)
    {
        // Simples ToString para demonstração
        return $"{{ {string.Join(", ", obj.GetType().GetProperties().Select(p => $"\"{p.Name}\": {p.GetValue(obj)}"))} }}";
    }
}
