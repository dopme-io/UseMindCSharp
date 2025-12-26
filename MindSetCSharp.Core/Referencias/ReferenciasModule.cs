namespace MindSetCSharp.Core.Referencias;

/// <summary>
/// Módulo de Referências: Trabalho com Referências de Objetos em C#
/// Explora o conceito fundamental de tipos de referência vs tipos de valor
/// </summary>
public static class ReferenciasModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      MÓDULO: REFERÊNCIAS - Objetos e Memória         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Conceitos de Referências em C#:");
        Console.WriteLine("  • Tipos de Valor (Value Types): int, double, bool, struct");
        Console.WriteLine("  • Tipos de Referência (Reference Types): class, interface, array");
        Console.WriteLine("  • Stack vs Heap: localização na memória");
        Console.WriteLine("  • Cópia de Valores vs Cópia de Referências");
        Console.WriteLine("  • Comparação: == vs Equals() vs ReferenceEquals()");
        Console.WriteLine("  • Garbage Collection: gerenciamento de memória");
        Console.WriteLine("  • Null e Null Coalescing");

        // Executar todos os exemplos
        ExemplosReferencias.ExemploTiposValorVsReferencia();
        ExemplosReferencias.ExemploStackVsHeap();
        ExemplosReferencias.ExemploComparacaoReferencias();
        ExemplosReferencias.ExemploMutabilidade();
        ExemplosReferencias.ExemploParametrosRef();
        ExemplosReferencias.ExemploNullCoalescing();
        ExemplosReferencias.ExemploCloning();
        ExemplosReferencias.ExemploGarbageCollection();

        Console.WriteLine("\n✅ Módulo Referências concluído!\n");
    }
}
