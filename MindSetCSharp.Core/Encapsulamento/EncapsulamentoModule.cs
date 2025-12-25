namespace MindSetCSharp.Core.Encapsulamento;

/// <summary>
/// Módulo de Encapsulamento: Proteção e abstração de dados
/// Explora ocultação de dados, validações e controle de acesso
/// </summary>
public static class EncapsulamentoModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   MÓDULO: ENCAPSULAMENTO - Proteção e Abstração     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Conceitos de Encapsulamento em C#:");
        Console.WriteLine("  • Ocultação de dados: campos privados protegem informações");
        Console.WriteLine("  • Propriedades: interface pública controlada");
        Console.WriteLine("  • Validações: garantem consistência dos dados");
        Console.WriteLine("  • Níveis de acesso: public, private, protected, internal");
        Console.WriteLine("  • Abstração: esconder complexidade, expor simplicidade");
        Console.WriteLine("  • Imutabilidade: readonly, init, propriedades somente leitura");

        // Executar todos os exemplos
        ExemplosEncapsulamento.ExemploComparacao();
        ExemplosEncapsulamento.ExemploNiveisAcesso();
        ExemplosEncapsulamento.ExemploCarrinhoCompras();
        ExemplosEncapsulamento.ExemploValidacoes();
        ExemplosEncapsulamento.ExemploPropriedadesEspeciais();

        Console.WriteLine("\n✅ Módulo Encapsulamento concluído!\n");
    }
}
