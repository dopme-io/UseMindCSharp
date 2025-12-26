using System.Text;
using System.Text.Json;

namespace MindSetCSharp.Core.Arquivos;

/// <summary>
/// Exemplos práticos de leitura e escrita de arquivos no .NET
/// </summary>
public static class ExemplosArquivos
{
    /// <summary>
    /// Exemplo 1: Leitura de texto (linha a linha)
    /// </summary>
    public static void ExemploLeituraTexto()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 1: Leitura de Texto                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var caminho = Path.Combine(Path.GetTempPath(), "mindset_leitura.txt");
        File.WriteAllLines(caminho, new[] { "linha 1", "linha 2" }, Encoding.UTF8);

        var linhas = File.ReadAllLines(caminho, Encoding.UTF8);
        foreach (var linha in linhas)
        {
            Console.WriteLine($"  > {linha}");
        }

        File.Delete(caminho);
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 2: Escrita e append
    /// </summary>
    public static void ExemploEscritaAppend()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 2: Escrita e Append                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var caminho = Path.Combine(Path.GetTempPath(), "mindset_append.txt");
        File.WriteAllText(caminho, "primeira linha\n", Encoding.UTF8);
        File.AppendAllText(caminho, "segunda linha\n", Encoding.UTF8);

        Console.WriteLine(File.ReadAllText(caminho, Encoding.UTF8));
        File.Delete(caminho);
    }

    /// <summary>
    /// Exemplo 3: File x FileInfo
    /// </summary>
    public static void ExemploFileVsFileInfo()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 3: File vs FileInfo                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var caminho = Path.Combine(Path.GetTempPath(), "mindset_fileinfo.txt");
        File.WriteAllText(caminho, "dados", Encoding.UTF8);

        var fi = new FileInfo(caminho);
        Console.WriteLine($"  Nome: {fi.Name}");
        Console.WriteLine($"  Tamanho: {fi.Length} bytes");
        Console.WriteLine($"  Último acesso: {fi.LastAccessTime}");

        fi.Delete();
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 4: Streams e buffer
    /// </summary>
    public static void ExemploStreamsBuffer()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 4: Streams com Buffer                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var dados = Encoding.UTF8.GetBytes("streaming de dados");
        using var origem = new MemoryStream(dados);
        using var destino = new MemoryStream();

        Span<byte> buffer = stackalloc byte[8];
        int lidos;
        while ((lidos = origem.Read(buffer)) > 0)
        {
            destino.Write(buffer[..lidos]);
        }

        Console.WriteLine($"  Copiado via buffer: {Encoding.UTF8.GetString(destino.ToArray())}\n");
    }

    /// <summary>
    /// Exemplo 5: I/O assíncrono
    /// </summary>
    public static async Task ExemploAsyncIO()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 5: I/O Assíncrono                          ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var caminho = Path.Combine(Path.GetTempPath(), "mindset_async.bin");
        var bytes = Enumerable.Range(0, 256).Select(b => (byte)b).ToArray();

        await File.WriteAllBytesAsync(caminho, bytes);
        var lidos = await File.ReadAllBytesAsync(caminho);

        Console.WriteLine($"  Lidos {lidos.Length} bytes de forma assíncrona");
        File.Delete(caminho);
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 6: JSON com System.Text.Json
    /// </summary>
    public static void ExemploJson()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 6: JSON (System.Text.Json)                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var pessoa = new Pessoa("Ana", 30);
        var json = JsonSerializer.Serialize(pessoa, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);

        var pessoa2 = JsonSerializer.Deserialize<Pessoa>(json);
        Console.WriteLine($"  Nome desserializado: {pessoa2?.Nome}\n");
    }

    /// <summary>
    /// Exemplo 7: CSV simples
    /// </summary>
    public static void ExemploCsvSimples()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 7: CSV Simples                             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var linhas = new[] { "nome;idade", "Ana;30", "Bob;25" };
        var caminho = Path.Combine(Path.GetTempPath(), "mindset.csv");
        File.WriteAllLines(caminho, linhas, Encoding.UTF8);

        var lidas = File.ReadAllLines(caminho, Encoding.UTF8)
                        .Skip(1)
                        .Select(l => l.Split(';'))
                        .Select(p => new { Nome = p[0], Idade = int.Parse(p[1]) });

        foreach (var p in lidas)
        {
            Console.WriteLine($"  {p.Nome} - {p.Idade} anos");
        }

        File.Delete(caminho);
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 8: Boas práticas
    /// </summary>
    public static void ExemploBoasPraticas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 8: Boas Práticas                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📌 Dicas rápidas:");
        Console.WriteLine("  • Sempre feche/dispense streams com using/await using");
        Console.WriteLine("  • Prefira métodos Async em I/O para não bloquear threads");
        Console.WriteLine("  • Use Encoding explícito para evitar surpresas");
        Console.WriteLine("  • Para volumes grandes, leia/grave em buffers (stream)");
        Console.WriteLine("  • Evite concatenar caminhos manualmente: use Path.Combine");
        Console.WriteLine();
    }
}

// ==================== TIPOS AUXILIARES ====================

public record Pessoa(string Nome, int Idade);
