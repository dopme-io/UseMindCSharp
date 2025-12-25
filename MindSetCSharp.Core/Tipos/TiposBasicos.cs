namespace MindSetCSharp.Core.Tipos;

/// <summary>
/// Demonstra diferenças entre tipos de valor (struct) e tipos de referência (class)
/// </summary>
public static class TiposValorReferencia
{
    // TIPO DE VALOR - Struct
    public struct PontoStruct
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PontoStruct(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"Ponto({X}, {Y})";
    }

    // TIPO DE REFERÊNCIA - Class
    public class PontoClasse
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PontoClasse(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"Ponto({X}, {Y})";
    }

    /// <summary>
    /// Demonstra a diferença de comportamento entre struct e class
    /// </summary>
    public static void DemonstrarDiferencas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   TIPOS DE VALOR (STRUCT) vs TIPOS DE REFERÊNCIA     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // ===== STRUCT (Tipo de Valor) =====
        Console.WriteLine("📦 STRUCT (Tipo de Valor):\n");
        
        var pontoStruct1 = new PontoStruct(10, 20);
        var pontoStruct2 = pontoStruct1; // COPIA o valor
        
        Console.WriteLine($"pontoStruct1: {pontoStruct1}");
        Console.WriteLine($"pontoStruct2: {pontoStruct2}");
        
        // Modificar pontoStruct2
        pontoStruct2.X = 999;
        
        Console.WriteLine("\n--- Após modificar pontoStruct2.X = 999 ---");
        Console.WriteLine($"pontoStruct1: {pontoStruct1}  ✅ NÃO mudou!");
        Console.WriteLine($"pontoStruct2: {pontoStruct2}  ← Mudou apenas este");

        // ===== CLASS (Tipo de Referência) =====
        Console.WriteLine("\n\n📦 CLASS (Tipo de Referência):\n");
        
        var pontoClasse1 = new PontoClasse(10, 20);
        var pontoClasse2 = pontoClasse1; // COPIA a referência (aponta para o mesmo objeto)
        
        Console.WriteLine($"pontoClasse1: {pontoClasse1}");
        Console.WriteLine($"pontoClasse2: {pontoClasse2}");
        
        // Modificar pontoClasse2
        pontoClasse2.X = 999;
        
        Console.WriteLine("\n--- Após modificar pontoClasse2.X = 999 ---");
        Console.WriteLine($"pontoClasse1: {pontoClasse1}  ⚠️  Mudou também!");
        Console.WriteLine($"pontoClasse2: {pontoClasse2}  ← Ambos apontam para o mesmo objeto");

        // Comparações
        Console.WriteLine("\n\n💡 EXPLICAÇÃO:\n");
        Console.WriteLine("STRUCT (Tipo de Valor):");
        Console.WriteLine("  • Armazenado na STACK (pilha)");
        Console.WriteLine("  • Cópia cria NOVA instância independente");
        Console.WriteLine("  • Modificar cópia NÃO afeta original");
        Console.WriteLine("  • Não pode ser null (a menos que seja Nullable)");
        Console.WriteLine("  • Sem herança (exceto interfaces)");
        Console.WriteLine("  • Melhor performance para dados pequenos");

        Console.WriteLine("\nCLASS (Tipo de Referência):");
        Console.WriteLine("  • Objeto armazenado na HEAP");
        Console.WriteLine("  • Variável armazena REFERÊNCIA (endereço)");
        Console.WriteLine("  • Cópia compartilha o MESMO objeto");
        Console.WriteLine("  • Modificar qualquer referência afeta todas");
        Console.WriteLine("  • Pode ser null");
        Console.WriteLine("  • Suporta herança");
    }
}

/// <summary>
/// Demonstra tipos primitivos do C#
/// </summary>
public static class TiposPrimitivos
{
    public static void DemonstrarTipos()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║              TIPOS PRIMITIVOS EM C#                  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Inteiros
        Console.WriteLine("🔢 TIPOS INTEIROS:\n");
        sbyte  num8bits  = -128;              // -128 a 127
        byte   numByte   = 255;               // 0 a 255
        short  num16bits = -32768;            // -32,768 a 32,767
        ushort numU16    = 65535;             // 0 a 65,535
        int    num32bits = -2_147_483_648;    // -2.1bi a 2.1bi
        uint   numU32    = 4_294_967_295;     // 0 a 4.2bi
        long   num64bits = -9_223_372_036_854_775_808; // muito grande
        ulong  numU64    = 18_446_744_073_709_551_615; // muito maior ainda

        Console.WriteLine($"sbyte  (8-bit):  {num8bits,25}  | Min: {sbyte.MinValue,25} | Max: {sbyte.MaxValue,25}");
        Console.WriteLine($"byte   (8-bit):  {numByte,25}  | Min: {byte.MinValue,25} | Max: {byte.MaxValue,25}");
        Console.WriteLine($"short  (16-bit): {num16bits,25}  | Min: {short.MinValue,25} | Max: {short.MaxValue,25}");
        Console.WriteLine($"ushort (16-bit): {numU16,25}  | Min: {ushort.MinValue,25} | Max: {ushort.MaxValue,25}");
        Console.WriteLine($"int    (32-bit): {num32bits,25}  | Min: {int.MinValue,25} | Max: {int.MaxValue,25}");
        Console.WriteLine($"uint   (32-bit): {numU32,25}  | Min: {uint.MinValue,25} | Max: {uint.MaxValue,25}");
        Console.WriteLine($"long   (64-bit): {num64bits,25}  | Min: {long.MinValue,25} | Max: {long.MaxValue,25}");

        // Ponto Flutuante
        Console.WriteLine("\n\n💰 TIPOS DE PONTO FLUTUANTE:\n");
        float   numFloat   = 3.14159f;        // ~7 dígitos de precisão
        double  numDouble  = 3.141592653589;  // ~15-16 dígitos de precisão
        decimal numDecimal = 3.141592653589793238462643383279m; // ~28-29 dígitos de precisão

        Console.WriteLine($"float   (32-bit): {numFloat}         | Precisão: ~7 dígitos");
        Console.WriteLine($"double  (64-bit): {numDouble}    | Precisão: ~15-16 dígitos");
        Console.WriteLine($"decimal (128-bit): {numDecimal} | Precisão: ~28-29 dígitos");
        
        Console.WriteLine("\n⚠️  Use 'decimal' para valores monetários!");
        decimal preco = 19.99m;
        decimal imposto = preco * 0.15m;
        Console.WriteLine($"   Preço: R$ {preco:F2} | Imposto: R$ {imposto:F2} | Total: R$ {preco + imposto:F2}");

        // Outros tipos
        Console.WriteLine("\n\n📋 OUTROS TIPOS:\n");
        bool   verdadeiro = true;
        char   letra      = 'A';
        string texto      = "Olá, C#!";
        
        Console.WriteLine($"bool:   {verdadeiro}  (valores: true ou false)");
        Console.WriteLine($"char:   '{letra}'    (caractere Unicode 16-bit)");
        Console.WriteLine($"string: \"{texto}\" (sequência de caracteres)");

        // Tipo object
        Console.WriteLine("\n\n📦 TIPO OBJECT (base de todos os tipos):\n");
        object obj1 = 42;           // int
        object obj2 = "texto";      // string
        object obj3 = 3.14;         // double
        object obj4 = true;         // bool
        
        Console.WriteLine($"obj1: {obj1} (tipo: {obj1.GetType().Name})");
        Console.WriteLine($"obj2: {obj2} (tipo: {obj2.GetType().Name})");
        Console.WriteLine($"obj3: {obj3} (tipo: {obj3.GetType().Name})");
        Console.WriteLine($"obj4: {obj4} (tipo: {obj4.GetType().Name})");
    }
}
