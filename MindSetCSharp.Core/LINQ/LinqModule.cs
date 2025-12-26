namespace MindSetCSharp.Core.LINQ;

/// <summary>
/// Módulo de LINQ (Language Integrated Query)
/// Consultas e manipulação de dados de forma funcional
/// </summary>
public static class LINQModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   MÓDULO: LINQ - Consultas de Dados Integradas       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

        Console.WriteLine("\n📚 Técnicas para consultas e manipulação de dados:\n");

        ExemplosLinq.ExemploFiltroWhere();
        ExemplosLinq.ExemploProjecaoSelect();
        ExemplosLinq.ExemploOrdenacao();
        ExemplosLinq.ExemploAgregacao();
        ExemplosLinq.ExemploGroupBy();
        ExemplosLinq.ExemploJoin();
        ExemplosLinq.ExemploMethodChaining();
        ExemplosLinq.ExemploPerformance();

        Console.WriteLine("\n✅ Módulo LINQ concluído!\n");
    }
}
