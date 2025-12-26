using System;

namespace MindSetCSharp.Core.Controles;

public static class ControlesModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   MÓDULO: CONTROLES (Controllers) em .NET            ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

        Console.WriteLine("\n📚 Controllers: resultados, validação e DI\n");

        ExemplosControles.ExemploBasico();
        ExemplosControles.ExemploDI();
        ExemplosControles.ExemploActionResults();
        ExemplosControles.ExemploValidacao();
        ExemplosControles.ExemploComandosQueries();
        ExemplosControles.ExemploPaginacaoFiltros();
        ExemplosControles.ExemploLogging();
        ExemplosControles.ExemploBoasPraticas();

        Console.WriteLine("\n✅ Módulo Controles concluído!\n");
    }
}
