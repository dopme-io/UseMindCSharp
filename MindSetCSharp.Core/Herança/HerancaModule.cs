namespace MindSetCSharp.Core.Heranca;

/// <summary>
/// Módulo de Herança: Conceitos e práticas de herança em C#
/// Explora reutilização, extensão de código e polimorfismo
/// </summary>
public static class HerancaModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║    MÓDULO: HERANÇA - Reutilização e Extensão        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Conceitos de Herança em C#:");
        Console.WriteLine("  • Classe Base (pai/superclasse): define membros comuns");
        Console.WriteLine("  • Classe Derivada (filho/subclasse): herda e estende");
        Console.WriteLine("  • Palavra 'base': acessa membros da classe pai");
        Console.WriteLine("  • virtual/override: permite sobrescrever métodos");
        Console.WriteLine("  • Classes abstratas: templates que não podem ser instanciados");
        Console.WriteLine("  • Polimorfismo: objetos de tipos diferentes respondem diferentemente");

        // Executar todos os exemplos
        ExemplosHeranca.ExemploFuncionarios();
        ExemplosHeranca.ExemploPolimorfismo();
        ExemplosHeranca.ExemploVeiculos();
        ExemplosHeranca.ExemploPolimorfismoVeiculos();
        ExemplosHeranca.ExemploUsoDaClasseBase();

        Console.WriteLine("\n✅ Módulo Herança concluído!\n");
    }
}
