namespace MindSetCSharp.Core.Tipos;

/// <summary>
/// Módulo de Tipos: Sistema de tipos do C#
/// Explora tipos de valor, referência, nullable, conversões e mais
/// </summary>
public static class TiposModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║          MÓDULO: TIPOS - Sistema de Tipos C#         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Conceitos de Tipos em C#:");
        Console.WriteLine("  • Tipos de valor (struct): stack, cópia por valor");
        Console.WriteLine("  • Tipos de referência (class): heap, cópia por referência");
        Console.WriteLine("  • Tipos primitivos: int, string, bool, double, etc");
        Console.WriteLine("  • Tipos nullable: permitem valores null em tipos de valor");
        Console.WriteLine("  • Conversões: implícitas, explícitas, boxing/unboxing");
        Console.WriteLine("  • Tipo dynamic: verificação em runtime");
        Console.WriteLine("  • Tipo object: base universal de todos os tipos");

        // Executar todos os exemplos
        ExemplosTipos.ExemploStructVsClass();
        ExemplosTipos.ExemploTiposPrimitivos();
        ExemplosTipos.ExemploNullable();
        ExemplosTipos.ExemploConversoes();
        ExemplosTipos.ExemploDynamic();
        ExemplosTipos.ExemploTuplas();
        ExemplosTipos.ExemploPerformance();
        ExemplosTipos.ExemploTipoObject();

        Console.WriteLine("\n✅ Módulo Tipos concluído!\n");
    }
}
