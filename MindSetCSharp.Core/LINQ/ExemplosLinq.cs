namespace MindSetCSharp.Core.LINQ;
using System.Diagnostics;

/// <summary>
/// Exemplos práticos de LINQ (Language Integrated Query)
/// </summary>
public static class ExemplosLinq
{
    /// <summary>
    /// Exemplo 1: Where (Filtro)
    /// Selecionar elementos que atendem a condição
    /// </summary>
    public static void ExemploFiltroWhere()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 1: Where (Filtro)                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var numeros = Enumerable.Range(1, 20).ToList();

        // Filtro simples
        Console.WriteLine("📌 Filtro Simples:\n");
        var pares = numeros.Where(n => n % 2 == 0).ToList();
        Console.WriteLine($"  Números pares de 1 a 20: {string.Join(", ", pares)}\n");

        // Múltiplas condições
        Console.WriteLine("📌 Múltiplas Condições:\n");
        var condicionados = numeros
            .Where(n => n > 5)
            .Where(n => n < 15)
            .Where(n => n % 2 == 0)
            .ToList();
        Console.WriteLine($"  Pares entre 5 e 15: {string.Join(", ", condicionados)}\n");

        // Filtro com índice
        Console.WriteLine("📌 Filtro com Índice:\n");
        var comIndice = numeros
            .Where((n, i) => i % 2 == 0)  // Índices pares
            .ToList();
        Console.WriteLine($"  Elementos nos índices pares: {string.Join(", ", comIndice)}\n");

        // Tipo seguro
        Console.WriteLine("📌 Filtro Type-Safe:\n");
        object[] objetos = { 1, "texto", 2, 3.14, "outro", 4 };
        var apenasInteiros = objetos.OfType<int>().ToList();
        Console.WriteLine($"  Apenas inteiros: {string.Join(", ", apenasInteiros)}\n");
    }

    /// <summary>
    /// Exemplo 2: Select (Projeção)
    /// Transformar elementos
    /// </summary>
    public static void ExemploProjecaoSelect()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 2: Select (Projeção)                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var numeros = Enumerable.Range(1, 5).ToList();

        // Transformação simples
        Console.WriteLine("📌 Transformação Simples:\n");
        var quadrados = numeros.Select(n => n * n).ToList();
        Console.WriteLine($"  Entrada: {string.Join(", ", numeros)}");
        Console.WriteLine($"  Quadrados: {string.Join(", ", quadrados)}\n");

        // Select com índice
        Console.WriteLine("📌 Select com Índice:\n");
        var comIndice = numeros
            .Select((n, i) => $"[{i}] = {n}")
            .ToList();
        foreach (var item in comIndice)
            Console.WriteLine($"  {item}");
        Console.WriteLine();

        // Select anônimo
        Console.WriteLine("📌 Select para Tipo Anônimo:\n");
        var pessoas = new List<Pessoa>
        {
            new("Alice", 25, 3000),
            new("Bob", 30, 4000),
            new("Charlie", 28, 3500)
        };

        var resumo = pessoas
            .Select(p => new { p.Nome, p.Idade, Faixa = p.Salario > 3500 ? "Senior" : "Junior" })
            .ToList();

        foreach (var p in resumo)
            Console.WriteLine($"  • {p.Nome}, {p.Idade} anos - {p.Faixa}");
        Console.WriteLine();

        // SelectMany (Flatten)
        Console.WriteLine("📌 SelectMany (Achatamento):\n");
        var pedidos = new List<Pedido>
        {
            new("Pedido 1", new[] { "Item A", "Item B", "Item C" }),
            new("Pedido 2", new[] { "Item D", "Item E" }),
            new("Pedido 3", new[] { "Item F" })
        };

        var todosItens = pedidos
            .SelectMany(p => p.Itens, (p, i) => $"{p.Nome} - {i}")
            .ToList();

        foreach (var item in todosItens)
            Console.WriteLine($"  • {item}");
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 3: Ordenação
    /// OrderBy, ThenBy, Reverse
    /// </summary>
    public static void ExemploOrdenacao()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 3: Ordenação                             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var pessoas = new List<Pessoa>
        {
            new("Alice", 25, 3000),
            new("Bob", 30, 2500),
            new("Charlie", 25, 3500),
            new("Diana", 28, 3000),
            new("Eve", 30, 4000)
        };

        // OrderBy simples
        Console.WriteLine("📌 OrderBy (Ordem Crescente):\n");
        var porIdade = pessoas.OrderBy(p => p.Idade).ToList();
        foreach (var p in porIdade)
            Console.WriteLine($"  • {p.Nome}: {p.Idade} anos");
        Console.WriteLine();

        // OrderByDescending
        Console.WriteLine("📌 OrderByDescending (Ordem Decrescente):\n");
        var porSalario = pessoas.OrderByDescending(p => p.Salario).ToList();
        foreach (var p in porSalario)
            Console.WriteLine($"  • {p.Nome}: R$ {p.Salario:F2}");
        Console.WriteLine();

        // ThenBy (Ordenação secundária)
        Console.WriteLine("📌 ThenBy (Múltiplos Critérios):\n");
        var ordenado = pessoas
            .OrderBy(p => p.Idade)
            .ThenBy(p => p.Salario)
            .ToList();

        foreach (var p in ordenado)
            Console.WriteLine($"  • {p.Nome}: {p.Idade} anos, R$ {p.Salario:F2}");
        Console.WriteLine();

        // Reverse
        Console.WriteLine("📌 Reverse (Inverter):\n");
        var invertido = pessoas.AsEnumerable().Reverse().ToList();
        Console.WriteLine($"  Primeira (original): {pessoas.First().Nome}");
        Console.WriteLine($"  Primeira (invertido): {invertido.First().Nome}\n");
    }

    /// <summary>
    /// Exemplo 4: Agregação
    /// Count, Sum, Average, Min, Max
    /// </summary>
    public static void ExemploAgregacao()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 4: Agregação                             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var numeros = Enumerable.Range(1, 100).ToList();
        var pessoas = new List<Pessoa>
        {
            new("Alice", 25, 3000),
            new("Bob", 30, 4000),
            new("Charlie", 28, 3500)
        };

        // Count
        Console.WriteLine("📌 Count (Contagem):\n");
        var total = numeros.Count();
        var pares = numeros.Count(n => n % 2 == 0);
        Console.WriteLine($"  Total de números: {total}");
        Console.WriteLine($"  Números pares: {pares}\n");

        // Sum e Average
        Console.WriteLine("📌 Sum e Average (Soma e Média):\n");
        var soma = numeros.Sum();
        var media = numeros.Average();
        Console.WriteLine($"  Soma: {soma}");
        Console.WriteLine($"  Média: {media:F2}\n");

        // Min e Max
        Console.WriteLine("📌 Min e Max (Mínimo e Máximo):\n");
        var minimo = numeros.Min();
        var maximo = numeros.Max();
        Console.WriteLine($"  Mínimo: {minimo}");
        Console.WriteLine($"  Máximo: {maximo}\n");

        // Aggregate (Redução)
        Console.WriteLine("📌 Aggregate (Redução):\n");
        var produto = numeros.Take(5).Aggregate(1, (acc, n) => acc * n);
        Console.WriteLine($"  Produto dos 5 primeiros: {produto}");

        var texto = new[] { "Hello", "World", "LINQ" }.Aggregate((a, b) => a + " " + b);
        Console.WriteLine($"  Concatenação: \"{texto}\"\n");

        // Aggregate com formatação
        var salariosFormatados = pessoas
            .OrderByDescending(p => p.Salario)
            .Aggregate(
                "Salários (maior → menor):\n",
                (acc, p) => acc + $"  • {p.Nome}: R$ {p.Salario:F2}\n"
            );
        Console.WriteLine("📌 Aggregate com String:\n");
        Console.WriteLine(salariosFormatados);
    }

    /// <summary>
    /// Exemplo 5: GroupBy (Agrupamento)
    /// Agrupar elementos por critério
    /// </summary>
    public static void ExemploGroupBy()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 5: GroupBy (Agrupamento)                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var pessoas = new List<Pessoa>
        {
            new("Alice", 25, 3000),
            new("Bob", 30, 4000),
            new("Charlie", 25, 3500),
            new("Diana", 28, 3000),
            new("Eve", 30, 4500)
        };

        // GroupBy simples
        Console.WriteLine("📌 GroupBy Simples:\n");
        var porIdade = pessoas.GroupBy(p => p.Idade);

        foreach (var grupo in porIdade)
        {
            Console.WriteLine($"  {grupo.Key} anos:");
            foreach (var pessoa in grupo)
                Console.WriteLine($"    • {pessoa.Nome} - R$ {pessoa.Salario:F2}");
        }
        Console.WriteLine();

        // GroupBy com Select
        Console.WriteLine("📌 GroupBy com Agregação:\n");
        var resumoPorIdade = pessoas
            .GroupBy(p => p.Idade)
            .Select(g => new
            {
                Idade = g.Key,
                Quantidade = g.Count(),
                SalarioTotal = g.Sum(p => p.Salario),
                SalarioMedio = g.Average(p => p.Salario)
            })
            .OrderBy(x => x.Idade);

        foreach (var grupo in resumoPorIdade)
        {
            Console.WriteLine($"  {grupo.Idade} anos: {grupo.Quantidade} pessoa(s)");
            Console.WriteLine($"    - Total: R$ {grupo.SalarioTotal:F2}");
            Console.WriteLine($"    - Média: R$ {grupo.SalarioMedio:F2}\n");
        }

        // GroupBy multi-chave
        Console.WriteLine("📌 GroupBy com Múltiplas Chaves:\n");
        var faixas = pessoas
            .GroupBy(p => new { Idade = p.Idade, FaixaSalarial = p.Salario > 3500 ? "Alto" : "Baixo" })
            .Select(g => new
            {
                g.Key.Idade,
                g.Key.FaixaSalarial,
                Nomes = string.Join(", ", g.Select(p => p.Nome))
            });

        foreach (var grupo in faixas)
        {
            Console.WriteLine($"  {grupo.Idade} anos, Salário {grupo.FaixaSalarial}: {grupo.Nomes}");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 6: Join (Junção)
    /// Combinar dados de múltiplas coleções
    /// </summary>
    public static void ExemploJoin()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 6: Join (Junção)                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var departamentos = new List<Departamento>
        {
            new(1, "TI"),
            new(2, "RH"),
            new(3, "Vendas")
        };

        var funcionarios = new List<Funcionario>
        {
            new("Alice", 1),
            new("Bob", 1),
            new("Charlie", 2),
            new("Diana", 3),
            new("Eve", 3)
        };

        // Inner Join
        Console.WriteLine("📌 Inner Join:\n");
        var join = departamentos
            .Join(
                funcionarios,
                d => d.Id,
                f => f.DepartamentoId,
                (d, f) => new { Departamento = d.Nome, Funcionario = f.Nome }
            );

        foreach (var item in join)
            Console.WriteLine($"  • {item.Funcionario} - {item.Departamento}");
        Console.WriteLine();

        // Left Join (usando DefaultIfEmpty)
        Console.WriteLine("📌 Left Join (Todos Departamentos):\n");
        var leftJoin = departamentos
            .GroupJoin(
                funcionarios,
                d => d.Id,
                f => f.DepartamentoId,
                (d, fs) => new { Departamento = d.Nome, Funcionarios = fs }
            );

        foreach (var grupo in leftJoin)
        {
            Console.WriteLine($"  {grupo.Departamento}:");
            var funcs = grupo.Funcionarios.Count() > 0
                ? string.Join(", ", grupo.Funcionarios.Select(f => f.Nome))
                : "(vazio)";
            Console.WriteLine($"    {funcs}\n");
        }

        // Zip (Combinar dois arrays)
        Console.WriteLine("📌 Zip (Combinar Sequências):\n");
        var nomes = new[] { "Alice", "Bob", "Charlie" };
        var idades = new[] { 25, 30, 28 };

        var zipped = nomes.Zip(idades, (n, i) => $"{n} ({i} anos)");
        foreach (var item in zipped)
            Console.WriteLine($"  • {item}");
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 7: Method Chaining
    /// Combinar múltiplas operações
    /// </summary>
    public static void ExemploMethodChaining()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 7: Method Chaining                       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var pessoas = new List<Pessoa>
        {
            new("Alice", 25, 3000),
            new("Bob", 30, 4000),
            new("Charlie", 28, 3500),
            new("Diana", 35, 5000),
            new("Eve", 26, 2500)
        };

        // Pipeline complexo
        Console.WriteLine("📌 Pipeline Complexo:\n");
        var resultado = pessoas
            .Where(p => p.Idade >= 25)                           // Filtrar
            .OrderByDescending(p => p.Salario)                   // Ordenar
            .Take(3)                                              // Top 3
            .Select(p => new
            {
                p.Nome,
                p.Idade,
                p.Salario,
                Categoria = p.Salario > 3500 ? "Senior" : "Junior"
            })
            .ToList();

        foreach (var p in resultado)
            Console.WriteLine($"  • {p.Nome} ({p.Idade}): R$ {p.Salario:F2} - {p.Categoria}");
        Console.WriteLine();

        // Combinação com Distinct
        Console.WriteLine("📌 Distinct (Remover Duplicatas):\n");
        var salarios = new[] { 3000, 4000, 3500, 3000, 5000, 3500 };
        var unicos = salarios.Distinct().OrderBy(s => s).ToList();
        Console.WriteLine($"  Salários únicos: {string.Join(", ", unicos)}\n");

        // Skip e Take (Paginação)
        Console.WriteLine("📌 Skip e Take (Paginação):\n");
        int pageSize = 2;
        for (int page = 0; page < 3; page++)
        {
            var pagina = pessoas
                .OrderBy(p => p.Nome)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();

            Console.WriteLine($"  Página {page + 1}:");
            foreach (var p in pagina)
                Console.WriteLine($"    • {p.Nome}");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 8: Performance e Otimizações
    /// Diferenças entre evaluated e lazy evaluation
    /// </summary>
    public static void ExemploPerformance()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 8: Performance e Otimizações             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var numeros = Enumerable.Range(1, 1000000).ToList();

        // Lazy evaluation (IEnumerable)
        Console.WriteLine("📌 Lazy Evaluation (IEnumerable):\n");
        var sw = Stopwatch.StartNew();
        var lazzy = numeros
            .Where(n => n % 2 == 0)
            .Select(n => n * 2)
            .Where(n => n > 1000);
        sw.Stop();
        Console.WriteLine($"  Tempo para criar (sem materializar): {sw.ElapsedMilliseconds}ms");

        sw.Restart();
        var primeiroLazy = lazzy.First();  // Só processa o necessário
        sw.Stop();
        Console.WriteLine($"  Tempo para pegar primeiro elemento: {sw.ElapsedMilliseconds}ms\n");

        // Eager evaluation (ToList)
        Console.WriteLine("📌 Eager Evaluation (ToList):\n");
        sw.Restart();
        var eager = numeros
            .Where(n => n % 2 == 0)
            .Select(n => n * 2)
            .Where(n => n > 1000)
            .ToList();
        sw.Stop();
        Console.WriteLine($"  Tempo para criar (materializar tudo): {sw.ElapsedMilliseconds}ms");

        sw.Restart();
        var primeiroEager = eager.First();  // Já está na memória
        sw.Stop();
        Console.WriteLine($"  Tempo para pegar primeiro elemento: {sw.ElapsedMilliseconds}ms\n");

        // AsParallel para operações pesadas
        Console.WriteLine("📌 AsParallel (Processamento Paralelo):\n");
        var numeros2 = Enumerable.Range(1, 100000).ToList();

        sw.Restart();
        var sequencial = numeros2
            .Where(n => EhPrimo(n))
            .Count();
        sw.Stop();
        var tempoSeq = sw.ElapsedMilliseconds;

        sw.Restart();
        var paralelo = numeros2
            .AsParallel()
            .Where(n => EhPrimo(n))
            .Count();
        sw.Stop();
        var tempoParallel = sw.ElapsedMilliseconds;

        Console.WriteLine($"  Sequencial: {tempoSeq}ms");
        Console.WriteLine($"  Paralelo: {tempoParallel}ms");
        Console.WriteLine($"  Resultado: {sequencial} primos encontrados\n");
    }

    // Métodos auxiliares
    private static bool EhPrimo(int numero)
    {
        if (numero < 2) return false;
        if (numero == 2) return true;
        if (numero % 2 == 0) return false;

        for (int i = 3; i * i <= numero; i += 2)
            if (numero % i == 0) return false;

        return true;
    }
}

// ==================== TIPOS AUXILIARES ====================

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public decimal Salario { get; set; }

    public Pessoa(string nome, int idade, decimal salario)
    {
        Nome = nome;
        Idade = idade;
        Salario = salario;
    }
}

public class Pedido
{
    public string Nome { get; set; }
    public string[] Itens { get; set; }

    public Pedido(string nome, string[] itens)
    {
        Nome = nome;
        Itens = itens;
    }
}

public class Departamento
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public Departamento(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class Funcionario
{
    public string Nome { get; set; }
    public int DepartamentoId { get; set; }

    public Funcionario(string nome, int departamentoId)
    {
        Nome = nome;
        DepartamentoId = departamentoId;
    }
}
