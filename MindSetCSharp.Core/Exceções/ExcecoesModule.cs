namespace MindSetCSharp.Core.Excecoes;

/// <summary>
/// Módulo de Exceções: Tratamento de Erros em C#
/// Explora como capturar, lançar e gerenciar exceções efetivamente
/// </summary>
public static class ExcecoesModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     MÓDULO: EXCEÇÕES - Tratamento de Erros           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Conceitos de Exceções em C#:");
        Console.WriteLine("  • Try-Catch: capturar exceções");
        Console.WriteLine("  • Finally: executar sempre");
        Console.WriteLine("  • Throw: lançar exceções");
        Console.WriteLine("  • Tipos de Exceções: built-in e customizadas");
        Console.WriteLine("  • Tratamento de Múltiplas Exceções");
        Console.WriteLine("  • Stack Trace: rastrear origem do erro");
        Console.WriteLine("  • Best Practices: quando e como usar");

        // Executar todos os exemplos
        ExemplosExcecoes.ExemploTryCatch();
        ExemplosExcecoes.ExemploFinally();
        ExemplosExcecoes.ExemploTiposExcecoes();
        ExemplosExcecoes.ExemploMultiplasExcecoes();
        ExemplosExcecoes.ExemploThrow();
        ExemplosExcecoes.ExemploCustomizadas();
        ExemplosExcecoes.ExemploStackTrace();
        ExemplosExcecoes.ExemploUsing();

        Console.WriteLine("\n✅ Módulo Exceções concluído!\n");
    }
}
