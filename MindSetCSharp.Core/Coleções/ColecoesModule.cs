namespace MindSetCSharp.Core.Colecoes;

/// <summary>
/// Módulo de Coleções: Trabalhando com Arrays, Listas, Dicionários e Conjuntos
/// Explora as principais estruturas de dados para armazenar e manipular grupos de objetos
/// </summary>
public static class ColecoesModule
{
    public static void Run()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     MÓDULO: COLEÇÕES - Estruturas de Dados           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        Console.WriteLine("\n📚 Tipos de Coleções em C#:");
        Console.WriteLine("  • Arrays: coleção de tamanho fixo");
        Console.WriteLine("  • List<T>: lista dinâmica e flexível");
        Console.WriteLine("  • Dictionary<TKey, TValue>: pares chave-valor");
        Console.WriteLine("  • HashSet<T>: conjunto de valores únicos");
        Console.WriteLine("  • Queue<T>: fila (FIFO - First In, First Out)");
        Console.WriteLine("  • Stack<T>: pilha (LIFO - Last In, First Out)");
        Console.WriteLine("  • LinkedList<T>: lista duplamente encadeada");

        // Executar todos os exemplos
        ExemplosColecoes.ExemploArrays();
        ExemplosColecoes.ExemploListas();
        ExemplosColecoes.ExemploDicionarios();
        ExemplosColecoes.ExemploHashSet();
        ExemplosColecoes.ExemploQueue();
        ExemplosColecoes.ExemploStack();
        ExemplosColecoes.ExemploLinkedList();
        ExemplosColecoes.ExemploComparacaoPerformance();

        Console.WriteLine("\n✅ Módulo Coleções concluído!\n");
    }
}
