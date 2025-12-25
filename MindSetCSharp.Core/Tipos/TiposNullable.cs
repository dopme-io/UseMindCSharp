namespace MindSetCSharp.Core.Tipos;

/// <summary>
/// Demonstra tipos nullable (que podem conter null)
/// </summary>
public static class TiposNullable
{
    public static void DemonstrarNullable()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║              TIPOS NULLABLE (Anuláveis)              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Tipos de valor não podem ser null normalmente
        // int idade = null;  ❌ ERRO DE COMPILAÇÃO!

        // Nullable permite que tipos de valor aceitem null
        Console.WriteLine("📦 DECLARAÇÃO DE NULLABLE:\n");
        
        int? idadeNullable1 = null;        // Sintaxe 1: ?
        Nullable<int> idadeNullable2 = null; // Sintaxe 2: Nullable<T>
        
        int? numero = 42;
        
        Console.WriteLine($"idadeNullable1: {idadeNullable1?.ToString() ?? "null"}");
        Console.WriteLine($"idadeNullable2: {idadeNullable2?.ToString() ?? "null"}");
        Console.WriteLine($"numero: {numero}");

        // Propriedades de Nullable
        Console.WriteLine("\n\n🔍 PROPRIEDADES DE NULLABLE:\n");
        
        int? valor1 = 100;
        int? valor2 = null;
        
        Console.WriteLine($"valor1 = {valor1}");
        Console.WriteLine($"  HasValue: {valor1.HasValue}  ✅ Tem valor");
        Console.WriteLine($"  Value: {valor1.Value}");
        Console.WriteLine($"  GetValueOrDefault(): {valor1.GetValueOrDefault()}");
        Console.WriteLine($"  GetValueOrDefault(999): {valor1.GetValueOrDefault(999)}");
        
        Console.WriteLine($"\nvalor2 = null");
        Console.WriteLine($"  HasValue: {valor2.HasValue}  ❌ Não tem valor");
        // Console.WriteLine($"  Value: {valor2.Value}");  ⚠️ ERRO se chamar Value quando é null!
        Console.WriteLine($"  GetValueOrDefault(): {valor2.GetValueOrDefault()}  (retorna 0)");
        Console.WriteLine($"  GetValueOrDefault(999): {valor2.GetValueOrDefault(999)}  (retorna 999)");

        // Operações com nullable
        Console.WriteLine("\n\n🔢 OPERAÇÕES COM NULLABLE:\n");
        
        int? a = 10;
        int? b = 20;
        int? c = null;
        
        int? soma1 = a + b;      // 30
        int? soma2 = a + c;      // null (qualquer operação com null resulta em null)
        int? soma3 = c + c;      // null
        
        Console.WriteLine($"a = {a}, b = {b}, c = {c}");
        Console.WriteLine($"a + b = {soma1}");
        Console.WriteLine($"a + c = {soma2?.ToString() ?? "null"}  ⚠️ Operação com null resulta em null");
        Console.WriteLine($"c + c = {soma3?.ToString() ?? "null"}");

        // Null-coalescing operator (??)
        Console.WriteLine("\n\n❓ OPERADOR NULL-COALESCING (??):\n");
        
        int? valorNullable = null;
        int valorPadrao = valorNullable ?? 999;  // Se null, usa 999
        
        Console.WriteLine($"valorNullable: {valorNullable?.ToString() ?? "null"}");
        Console.WriteLine($"valorPadrao = valorNullable ?? 999: {valorPadrao}");
        
        valorNullable = 50;
        valorPadrao = valorNullable ?? 999;
        
        Console.WriteLine($"\nvalorNullable: {valorNullable}");
        Console.WriteLine($"valorPadrao = valorNullable ?? 999: {valorPadrao}  (usa o valor, não o padrão)");

        // Null-conditional operator (?.)
        Console.WriteLine("\n\n🔗 OPERADOR NULL-CONDITIONAL (?.):\n");
        
        string? texto1 = "Olá, Mundo!";
        string? texto2 = null;
        
        int? tamanho1 = texto1?.Length;  // 12
        int? tamanho2 = texto2?.Length;  // null (não lança exceção!)
        
        Console.WriteLine($"texto1 = \"{texto1}\"");
        Console.WriteLine($"texto1?.Length = {tamanho1}");
        
        Console.WriteLine($"\ntexto2 = null");
        Console.WriteLine($"texto2?.Length = {tamanho2?.ToString() ?? "null"}  ✅ Não lança exceção!");
        
        // Sem ?. lançaria NullReferenceException:
        // int tamanho = texto2.Length;  ❌ ERRO em runtime!

        // Nullable Reference Types (C# 8+)
        Console.WriteLine("\n\n📝 NULLABLE REFERENCE TYPES (C# 8+):\n");
        
        Console.WriteLine("Com nullable reference types habilitado:");
        Console.WriteLine("  • string nome;     → não pode ser null");
        Console.WriteLine("  • string? nome;    → pode ser null");
        Console.WriteLine("  • Avisos do compilador ajudam prevenir NullReferenceException");

        string nome1 = "João";     // Não-nullable
        string? nome2 = null;      // Nullable
        
        Console.WriteLine($"\nnome1 (não-nullable): \"{nome1}\"");
        Console.WriteLine($"nome2 (nullable): {nome2 ?? "null"}");
    }

    /// <summary>
    /// Exemplo prático: Sistema com valores opcionais
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Apelido { get; set; }        // Opcional
        public int? Idade { get; set; }             // Opcional
        public DateTime? DataNascimento { get; set; } // Opcional
        public decimal? Salario { get; set; }       // Opcional (privado)

        public void ExibirInformacoes()
        {
            Console.WriteLine($"\n👤 ID: {Id} | Nome: {Nome}");
            Console.WriteLine($"   Apelido: {Apelido ?? "(não informado)"}");
            Console.WriteLine($"   Idade: {Idade?.ToString() ?? "(não informada)"}");
            Console.WriteLine($"   Data Nascimento: {DataNascimento?.ToString("dd/MM/yyyy") ?? "(não informada)"}");
            Console.WriteLine($"   Salário: {(Salario.HasValue ? $"R$ {Salario.Value:F2}" : "(não informado)")}");
        }
    }

    public static void ExemploUsuarioComNullable()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO PRÁTICO: Dados Opcionais                ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

        var usuario1 = new Usuario
        {
            Id = 1,
            Nome = "Maria Silva",
            Apelido = "Mari",
            Idade = 28,
            DataNascimento = new DateTime(1996, 5, 15),
            Salario = 5500m
        };

        var usuario2 = new Usuario
        {
            Id = 2,
            Nome = "João Santos",
            // Apelido, Idade, DataNascimento e Salario não informados (null)
        };

        usuario1.ExibirInformacoes();
        usuario2.ExibirInformacoes();

        Console.WriteLine("\n💡 Vantagens de Nullable:");
        Console.WriteLine("   • Expressa claramente valores opcionais");
        Console.WriteLine("   • Evita valores 'mágicos' (0, -1, etc)");
        Console.WriteLine("   • Compilador ajuda a tratar casos null");
        Console.WriteLine("   • Código mais seguro e legível");
    }
}
