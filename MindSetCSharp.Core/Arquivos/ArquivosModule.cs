using System;

namespace MindSetCSharp.Core.Arquivos;

public static class ArquivosModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   MÓDULO: ARQUIVOS - I/O em .NET                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

        Console.WriteLine("\n📚 Leitura, escrita, streams, async I/O e formatos\n");

        ExemplosArquivos.ExemploLeituraTexto();
        ExemplosArquivos.ExemploEscritaAppend();
        ExemplosArquivos.ExemploFileVsFileInfo();
        ExemplosArquivos.ExemploStreamsBuffer();
        ExemplosArquivos.ExemploAsyncIO();
        ExemplosArquivos.ExemploJson();
        ExemplosArquivos.ExemploCsvSimples();
        ExemplosArquivos.ExemploBoasPraticas();

        Console.WriteLine("\n✅ Módulo Arquivos concluído!\n");
    }
}
