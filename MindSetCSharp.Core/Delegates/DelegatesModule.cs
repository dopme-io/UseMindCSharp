namespace MindSetCSharp.Core.Delegates;

/// <summary>
/// Módulo de Delegates em C#
/// Funções como cidadãos de primeira classe
/// </summary>
public static class DelegatesModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   MÓDULO: DELEGATES - Funções como Dados             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

        Console.WriteLine("\n📚 Exemplos práticos de delegates em C#:\n");

        ExemplosDelegates.ExemploBasico();
        ExemplosDelegates.ExemploMulticast();
        ExemplosDelegates.ExemploFuncActionPredicate();
        ExemplosDelegates.ExemploCallbacks();
        ExemplosDelegates.ExemploEstrategia();
        ExemplosDelegates.ExemploCovarianciaContravariancia();
        ExemplosDelegates.ExemploDelegatesEventos();
        ExemplosDelegates.ExemploBoasPraticas();

        Console.WriteLine("\n✅ Módulo Delegates concluído!\n");
    }
}
