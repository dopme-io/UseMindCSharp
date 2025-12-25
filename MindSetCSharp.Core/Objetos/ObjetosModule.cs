namespace MindSetCSharp.Core.Objetos;

/// <summary>
/// Módulo de Objetos: Fundamentos da Programação Orientada a Objetos em C#
/// Explora criação, manipulação e interação de objetos
/// </summary>
public static class ObjetosModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║             MÓDULO: OBJETOS (POO em C#)             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Conceitos Fundamentais:");
        Console.WriteLine("  • Objetos são instâncias de classes");
        Console.WriteLine("  • Possuem ESTADO (propriedades) e COMPORTAMENTO (métodos)");
        Console.WriteLine("  • Permitem criar sistemas modulares e reutilizáveis");
        Console.WriteLine("  • São tipos de referência em C#");

        // Executar todos os exemplos
        ExemplosObjetos.ExemploPessoa();
        ExemplosObjetos.ExemploContaBancaria();
        ExemplosObjetos.ExemploMultiplosObjetos();
        ExemplosObjetos.ExemploReferencias();

        Console.WriteLine("\n✅ Módulo Objetos concluído!\n");
    }
}
