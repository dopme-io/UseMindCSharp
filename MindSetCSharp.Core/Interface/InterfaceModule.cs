namespace MindSetCSharp.Core.Interface;

/// <summary>
/// Módulo de Interface: Contratos e abstração
/// Explora definição de contratos, polimorfismo e design desacoplado
/// </summary>
public static class InterfaceModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║        MÓDULO: INTERFACE - Contratos e Abstração     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Conceitos de Interface em C#:");
        Console.WriteLine("  • Contrato: define O QUE fazer, não COMO fazer");
        Console.WriteLine("  • Múltiplas interfaces: uma classe pode implementar várias");
        Console.WriteLine("  • Polimorfismo: código genérico com comportamento específico");
        Console.WriteLine("  • Desacoplamento: dependências de abstrações, não implementações");
        Console.WriteLine("  • Herança de interface: interfaces podem herdar de outras");
        Console.WriteLine("  • Apenas assinaturas: métodos, propriedades, eventos, indexadores");

        // Executar todos os exemplos
        ExemplosInterface.ExemploRepositorio();
        ExemplosInterface.ExemploRepositorioComCache();
        ExemplosInterface.ExemploMultiplasInterfaces();
        ExemplosInterface.ExemploPolimorfismo();
        ExemplosInterface.ExemploPagamentos();
        ExemplosInterface.ExemploComparacao();

        Console.WriteLine("\n✅ Módulo Interface concluído!\n");
    }
}
