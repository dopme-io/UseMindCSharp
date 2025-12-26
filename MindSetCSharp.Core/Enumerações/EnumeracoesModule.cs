namespace MindSetCSharp.Core.Enumeracoes;

/// <summary>
/// Módulo de Enumerações em C#
/// Definição de conjuntos de valores nomeados (constantes simbólicas)
/// </summary>
public static class EnumeracoesModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   MÓDULO: ENUMERAÇÕES - Valores Nomeados             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

        Console.WriteLine("\n📚 Exemplos práticos de enums em C#:\n");

        ExemplosEnumeracoes.ExemploBasico();
        ExemplosEnumeracoes.ExemploFlags();
        ExemplosEnumeracoes.ExemploUtilitarios();
        ExemplosEnumeracoes.ExemploParseTryParse();
        ExemplosEnumeracoes.ExemploEnumComDicionario();
        ExemplosEnumeracoes.ExemploSwitchExpression();
        ExemplosEnumeracoes.ExemploValidacao();
        ExemplosEnumeracoes.ExemploBoasPraticas();

        Console.WriteLine("\n✅ Módulo Enumerações concluído!\n");
    }
}
