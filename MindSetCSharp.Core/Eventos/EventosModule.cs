namespace MindSetCSharp.Core.Eventos;

/// <summary>
/// Módulo de Eventos em C#
/// Comunicação entre objetos por publicação/assinatura
/// </summary>
public static class EventosModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   MÓDULO: EVENTOS - Notificação e Comunicação        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

        Console.WriteLine("\n📚 Técnicas e padrões de eventos em C#:\n");

        ExemplosEventos.ExemploBasico();
        ExemplosEventos.ExemploEventHandler();
        ExemplosEventos.ExemploArgsCustomizados();
        ExemplosEventos.ExemploMulticast();
        ExemplosEventos.ExemploInscricaoDesinscricao();
        ExemplosEventos.ExemploAssincrono();
        ExemplosEventos.ExemploEventosEmCadeia();
        ExemplosEventos.ExemploBoasPraticas();

        Console.WriteLine("\n✅ Módulo Eventos concluído!\n");
    }
}
