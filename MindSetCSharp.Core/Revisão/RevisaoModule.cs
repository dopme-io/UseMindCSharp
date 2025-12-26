namespace MindSetCSharp.Core.Revisao;

/// <summary>
/// Módulo de Revisão: Exercícios e Desafios Práticos
/// Consolida conceitos fundamentais de C# através de problemas práticos
/// </summary>
public static class RevisaoModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      MÓDULO: REVISÃO - Exercícios e Desafios         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Conteúdo do Módulo de Revisão:");
        Console.WriteLine("  • Desafios de Manipulação de Dados");
        Console.WriteLine("  • Problemas de Lógica de Programação");
        Console.WriteLine("  • Exercícios com Orientação a Objetos");
        Console.WriteLine("  • Desafios de Algoritmos");
        Console.WriteLine("  • Problemas com Coleções");
        Console.WriteLine("  • Casos de Uso Práticos do Mundo Real");

        // Executar todos os desafios
        ExerciciosManipulacaoDados.Run();
        ExerciciosLogicaProgramacao.Run();
        ExerciciosOrientacaoObjetos.Run();
        ExerciciosAlgoritmos.Run();
        ExerciciosColeções.Run();
        DesafiosPraticos.Run();

        Console.WriteLine("\n✅ Módulo de Revisão concluído!\n");
    }
}
