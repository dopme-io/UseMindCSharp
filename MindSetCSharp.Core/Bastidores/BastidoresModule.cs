using System;

namespace MindSetCSharp.Core.Bastidores;

public static class BastidoresModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   MÓDULO: BASTIDORES - Como o .NET Executa           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

        Console.WriteLine("\n📚 Bastidores do .NET: memória, JIT, GC e eficiência\n");

        ExemplosBastidores.ExemploValorReferencia();
        ExemplosBastidores.ExemploBoxing();
        ExemplosBastidores.ExemploStringsImutaveis();
        ExemplosBastidores.ExemploCopiasColecoes();
        ExemplosBastidores.ExemploStructVsClass();
        ExemplosBastidores.ExemploSpan();
        ExemplosBastidores.ExemploGC();
        ExemplosBastidores.ExemploBoasPraticas();

        Console.WriteLine("\n✅ Módulo Bastidores concluído!\n");
    }
}
