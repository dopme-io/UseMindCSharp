namespace MindSetCSharp.Core.Classes;

/// <summary>
/// Módulo de Classes: Criação e uso de classes em C#
/// Explora propriedades, métodos, construtores e composição
/// </summary>
public static class ClassesModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║        MÓDULO: CLASSES - Estruturas de Dados         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Conceitos de Classes em C#:");
        Console.WriteLine("  • Propriedades: armazenam dados do objeto");
        Console.WriteLine("  • Métodos: definem comportamentos");
        Console.WriteLine("  • Construtores: inicializam objetos");
        Console.WriteLine("  • Campos: armazenamento interno privado");
        Console.WriteLine("  • Membros estáticos: compartilhados entre todas as instâncias");
        Console.WriteLine("  • Composição: classes contendo outras classes");

        // Executar todos os exemplos
        ExemplosClasses.ExemploProduto();
        ExemplosClasses.ExemploCliente();
        ExemplosClasses.ExemploPedido();
        ExemplosClasses.ExemploMultiplosPedidos();
        ExemplosClasses.ExemploMembrosEstaticos();

        Console.WriteLine("\n✅ Módulo Classes concluído!\n");
    }
}
