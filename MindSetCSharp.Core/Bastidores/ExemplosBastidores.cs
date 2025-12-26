using System.Diagnostics;
using System.IO;
using System.Text;

namespace MindSetCSharp.Core.Bastidores;

/// <summary>
/// Exemplos práticos sobre o que acontece nos bastidores do .NET
/// </summary>
public static class ExemplosBastidores
{
    /// <summary>
    /// Exemplo 1: Tipos de valor x referência e impacto em memória
    /// </summary>
    public static void ExemploValorReferencia()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 1: Valor x Referência                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var structA = new PontoStruct(1, 1);
        var structB = structA; // cópia de valor
        structB.X = 99;

        var classeA = new PontoClasse(1, 1);
        var classeB = classeA; // mesma referência
        classeB.X = 99;

        Console.WriteLine($"  Struct A.X: {structA.X} (não alterou)");
        Console.WriteLine($"  Struct B.X: {structB.X}");
        Console.WriteLine($"  Classe A.X: {classeA.X} (alterou)");
        Console.WriteLine($"  Classe B.X: {classeB.X}\n");
    }

    /// <summary>
    /// Exemplo 2: Boxing e unboxing
    /// </summary>
    public static void ExemploBoxing()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 2: Boxing / Unboxing                       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        int numero = 42;
        object boxed = numero;           // boxing: valor -> objeto
        int unboxed = (int)boxed;        // unboxing: objeto -> valor

        Console.WriteLine($"  Numero: {numero}, boxed type: {boxed.GetType().Name}, unboxed: {unboxed}");

        object[] itens = { 1, 2, 3, "ok" };
        int soma = 0;
        foreach (var item in itens)
        {
            if (item is int valor)
            {
                soma += valor; // pattern matching faz unboxing uma vez
            }
        }

        Console.WriteLine($"  Soma de ints (evitando casts repetidos): {soma}\n");
    }

    /// <summary>
    /// Exemplo 3: Imutabilidade de strings e uso de StringBuilder
    /// </summary>
    public static void ExemploStringsImutaveis()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 3: Strings Imutáveis                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        string original = "MindSet";
        string alterada = original.Replace("Set", "Sharp");

        Console.WriteLine($"  Original: {original}");
        Console.WriteLine($"  Nova: {alterada}");

        var sb = new StringBuilder();
        for (int i = 0; i < 3; i++)
        {
            sb.Append("log-").Append(i).Append(';');
        }

        Console.WriteLine($"  StringBuilder evita várias alocações: {sb}\n");
    }

    /// <summary>
    /// Exemplo 4: Cópia defensiva de coleções
    /// </summary>
    public static void ExemploCopiasColecoes()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 4: Cópias de Coleções                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var original = new List<string> { "A", "B" };
        var referencia = original;                 // mesma lista
        var copiaDefensiva = new List<string>(original); // nova lista

        referencia.Add("C");
        copiaDefensiva.Add("D");

        Console.WriteLine($"  Original (afetado pela ref): {string.Join(", ", original)}");
        Console.WriteLine($"  Cópia defensiva (isolada): {string.Join(", ", copiaDefensiva)}\n");
    }

    /// <summary>
    /// Exemplo 5: Struct vs Class (alocação e custo)
    /// </summary>
    public static void ExemploStructVsClass()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 5: Struct vs Class                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        const int total = 50_000;

        var sw = Stopwatch.StartNew();
        var structs = new PontoStruct[total];
        for (int i = 0; i < total; i++)
        {
            structs[i] = new PontoStruct(i, i);
        }
        sw.Stop();
        var tempoStruct = sw.ElapsedMilliseconds;

        sw.Restart();
        var classes = new PontoClasse[total];
        for (int i = 0; i < total; i++)
        {
            classes[i] = new PontoClasse(i, i);
        }
        sw.Stop();
        var tempoClasse = sw.ElapsedMilliseconds;

        Console.WriteLine($"  Structs: {tempoStruct} ms | Classes: {tempoClasse} ms (alocação no heap)");
        Console.WriteLine("  🚩 Use BenchmarkDotNet para medições confiáveis, este é ilustrativo.\n");
    }

    /// <summary>
    /// Exemplo 6: Span para evitar alocações
    /// </summary>
    public static void ExemploSpan()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 6: Span / Slice                            ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var texto = "MindSetCSharp";
        ReadOnlySpan<char> prefixo = texto.AsSpan(0, 5);
        Console.WriteLine($"  Prefixo via Span (sem substring): {prefixo.ToString()}");

        var numeros = new[] { 1, 2, 3, 4, 5 };
        Span<int> janela = numeros.AsSpan(1, 3);
        janela[0] = 99; // altera o array original

        Console.WriteLine($"  Array após slice: {string.Join(", ", numeros)}");
        Console.WriteLine("  Span evita alocar novas fatias de memória.\n");
    }

    /// <summary>
    /// Exemplo 7: GC, IDisposable e pressão de memória
    /// </summary>
    public static void ExemploGC()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 7: GC e IDisposable                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        long antes = GC.GetTotalMemory(false);
        using (var ms = new MemoryStream(new byte[1024]))
        {
            ms.WriteByte(1);
        } // liberado com using

        GC.Collect();
        long depois = GC.GetTotalMemory(false);

        Console.WriteLine($"  Memória aprox.: {antes:N0} -> {depois:N0} bytes");
        Console.WriteLine("  Sempre feche IDisposable (using/await using) para aliviar o GC.\n");
    }

    /// <summary>
    /// Exemplo 8: Boas práticas de bastidores
    /// </summary>
    public static void ExemploBoasPraticas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 8: Boas Práticas                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📌 Dicas rápidas:");
        Console.WriteLine("  • Prefira tipos valor imutáveis para structs pequenos");
        Console.WriteLine("  • Evite boxing: use generics ou pattern matching moderado");
        Console.WriteLine("  • Para strings, prefira StringBuilder em loops concatenando");
        Console.WriteLine("  • Faça cópias defensivas ao expor coleções mutáveis");
        Console.WriteLine("  • Só meça performance com ferramentas (BenchmarkDotNet)");
        Console.WriteLine("  • Libere recursos com using e reduza pressão no GC");
        Console.WriteLine("  • Use Span/Memory quando precisar evitar alocações transitórias");
        Console.WriteLine();
    }
}

// ==================== TIPOS AUXILIARES ====================

public record struct PontoStruct(int X, int Y);

public class PontoClasse
{
    public int X { get; set; }
    public int Y { get; set; }

    public PontoClasse(int x, int y)
    {
        X = x;
        Y = y;
    }
}
