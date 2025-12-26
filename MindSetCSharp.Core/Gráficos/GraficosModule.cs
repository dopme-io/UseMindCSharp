namespace MindSetCSharp.Core.Graficos;

/// <summary>
/// Módulo de Gráficos: Visualização de Dados em C#
/// Explora técnicas de desenho ASCII e conceitos de visualização
/// </summary>
public static class GraficosModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      MÓDULO: GRÁFICOS - Visualização de Dados        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Conteúdo do Módulo de Gráficos:");
        Console.WriteLine("  • Gráficos ASCII (barras, linhas)");
        Console.WriteLine("  • Tabelas de Dados");
        Console.WriteLine("  • Diagramas de Dispersão");
        Console.WriteLine("  • Histogramas");
        Console.WriteLine("  • Plotagem de Funções");
        Console.WriteLine("  • Análise Visual de Dados");
        Console.WriteLine("  • Cores e Formatação no Console");

        // Executar todos os exemplos
        ExemplosGraficos.ExemploGraficoBarras();
        ExemplosGraficos.ExemploGraficoLinhas();
        ExemplosGraficos.ExemploTabela();
        ExemplosGraficos.ExemploHistograma();
        ExemplosGraficos.ExemploDiagramaDispersao();
        ExemplosGraficos.ExemploFuncaoMatematica();
        ExemplosGraficos.ExemploGraficoSetor();
        ExemplosGraficos.ExemploVisualizacaoCores();

        Console.WriteLine("\n✅ Módulo Gráficos concluído!\n");
    }
}
