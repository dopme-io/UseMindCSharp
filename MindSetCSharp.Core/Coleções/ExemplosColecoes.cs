namespace MindSetCSharp.Core.Colecoes;

/// <summary>
/// Exemplos práticos demonstrando os conceitos de coleções em C#.
/// </summary>
public static class ExemplosColecoes
{
    /// <summary>
    /// Exemplo 1: Trabalhando com Arrays
    /// Arrays são coleções de tamanho fixo e tipo único
    /// </summary>
    public static void ExemploArrays()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║         EXEMPLO 1: Arrays - Coleção Fixa            ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Array unidimensional
        int[] numeros = { 10, 20, 30, 40, 50 };
        Console.WriteLine("📊 Array de números:");
        Console.WriteLine($"Tamanho: {numeros.Length}");
        Console.WriteLine($"Primeiro elemento: {numeros[0]}");
        Console.WriteLine($"Último elemento: {numeros[^1]}"); // Índice do fim

        // Iterando pelo array
        Console.WriteLine("\nPercorrendo o array:");
        foreach (var numero in numeros)
        {
            Console.WriteLine($"  • {numero}");
        }

        // Array de strings
        string[] frutas = new string[3];
        frutas[0] = "Maçã";
        frutas[1] = "Banana";
        frutas[2] = "Laranja";

        Console.WriteLine("\n🍎 Array de frutas:");
        for (int i = 0; i < frutas.Length; i++)
        {
            Console.WriteLine($"  [{i}] = {frutas[i]}");
        }

        // Array multidimensional
        int[,] matriz = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Console.WriteLine("\n📐 Matriz 3x3:");
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            Console.Write("  ");
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write($"{matriz[i, j],3} ");
            }
            Console.WriteLine();
        }

        // Array jagged (array de arrays)
        int[][] arrayJagged = new int[3][];
        arrayJagged[0] = new int[] { 1, 2 };
        arrayJagged[1] = new int[] { 3, 4, 5 };
        arrayJagged[2] = new int[] { 6, 7, 8, 9 };

        Console.WriteLine("\n🔢 Array Jagged (tamanhos diferentes):");
        for (int i = 0; i < arrayJagged.Length; i++)
        {
            Console.Write($"  Linha {i}: ");
            foreach (var num in arrayJagged[i])
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Exemplo 2: Trabalhando com List<T>
    /// Listas são coleções dinâmicas que podem crescer ou diminuir
    /// </summary>
    public static void ExemploListas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 2: List<T> - Coleção Dinâmica          ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando uma lista
        var nomes = new List<string> { "Ana", "Bruno", "Carlos" };
        Console.WriteLine("📝 Lista inicial de nomes:");
        ExibirLista(nomes);

        // Adicionando elementos
        nomes.Add("Diana");
        nomes.Add("Eduardo");
        Console.WriteLine("\n➕ Após adicionar Diana e Eduardo:");
        ExibirLista(nomes);

        // Inserindo em posição específica
        nomes.Insert(2, "Beatriz");
        Console.WriteLine("\n📌 Após inserir Beatriz na posição 2:");
        ExibirLista(nomes);

        // Removendo elementos
        nomes.Remove("Carlos");
        Console.WriteLine("\n➖ Após remover Carlos:");
        ExibirLista(nomes);

        // Removendo por índice
        nomes.RemoveAt(0);
        Console.WriteLine("\n🗑️ Após remover elemento no índice 0:");
        ExibirLista(nomes);

        // Verificando existência
        bool contemDiana = nomes.Contains("Diana");
        Console.WriteLine($"\n🔍 Contém 'Diana'? {contemDiana}");

        // Encontrando índice
        int indiceBruno = nomes.IndexOf("Bruno");
        Console.WriteLine($"📍 Índice de 'Bruno': {indiceBruno}");

        // Ordenando
        nomes.Sort();
        Console.WriteLine("\n🔤 Lista ordenada alfabeticamente:");
        ExibirLista(nomes);

        // Lista de objetos
        var produtos = new List<Produto>
        {
            new Produto("Notebook", 3500m),
            new Produto("Mouse", 80m),
            new Produto("Teclado", 250m)
        };

        Console.WriteLine("\n💼 Lista de produtos:");
        produtos.ForEach(p => Console.WriteLine($"  • {p.Nome}: R$ {p.Preco:F2}"));

        // Filtrando com LINQ
        var produtosCaros = produtos.Where(p => p.Preco > 100).ToList();
        Console.WriteLine("\n💰 Produtos acima de R$ 100:");
        produtosCaros.ForEach(p => Console.WriteLine($"  • {p.Nome}: R$ {p.Preco:F2}"));
    }

    /// <summary>
    /// Exemplo 3: Trabalhando com Dictionary<TKey, TValue>
    /// Dicionários armazenam pares chave-valor para acesso rápido
    /// </summary>
    public static void ExemploDicionarios()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║    EXEMPLO 3: Dictionary - Pares Chave-Valor        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando um dicionário
        var capitais = new Dictionary<string, string>
        {
            { "Brasil", "Brasília" },
            { "Argentina", "Buenos Aires" },
            { "Chile", "Santiago" }
        };

        Console.WriteLine("🌍 Dicionário de capitais:");
        foreach (var kvp in capitais)
        {
            Console.WriteLine($"  • {kvp.Key}: {kvp.Value}");
        }

        // Adicionando elementos
        capitais.Add("Uruguai", "Montevidéu");
        capitais["Paraguai"] = "Assunção"; // Outra forma de adicionar

        Console.WriteLine("\n➕ Após adicionar Uruguai e Paraguai:");
        foreach (var (pais, capital) in capitais)
        {
            Console.WriteLine($"  • {pais}: {capital}");
        }

        // Acessando valores
        Console.WriteLine($"\n📍 Capital do Brasil: {capitais["Brasil"]}");

        // Verificando existência de chave
        bool temPeru = capitais.ContainsKey("Peru");
        Console.WriteLine($"🔍 Contém 'Peru'? {temPeru}");

        // Tentando obter valor com segurança
        if (capitais.TryGetValue("Chile", out string? capitalChile))
        {
            Console.WriteLine($"✅ Capital do Chile encontrada: {capitalChile}");
        }

        // Removendo elemento
        capitais.Remove("Argentina");
        Console.WriteLine("\n➖ Após remover Argentina:");
        Console.WriteLine($"Total de países: {capitais.Count}");

        // Dicionário com objetos
        var estoque = new Dictionary<int, ProdutoEstoque>
        {
            { 1, new ProdutoEstoque("Notebook", 10) },
            { 2, new ProdutoEstoque("Mouse", 50) },
            { 3, new ProdutoEstoque("Teclado", 30) }
        };

        Console.WriteLine("\n📦 Dicionário de estoque (ID → Produto):");
        foreach (var (id, produto) in estoque)
        {
            Console.WriteLine($"  • ID {id}: {produto.Nome} - Qtd: {produto.Quantidade}");
        }

        // Atualizando valor
        estoque[1].AdicionarEstoque(5);
        Console.WriteLine($"\n📈 Estoque do produto ID 1 após adicionar 5 unidades: {estoque[1].Quantidade}");
    }

    /// <summary>
    /// Exemplo 4: Trabalhando com HashSet<T>
    /// HashSet armazena valores únicos sem ordem específica
    /// </summary>
    public static void ExemploHashSet()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 4: HashSet - Valores Únicos           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando um HashSet
        var numeros = new HashSet<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine("🔢 HashSet inicial:");
        ExibirHashSet(numeros);

        // Tentando adicionar duplicata
        bool adicionado = numeros.Add(3); // Já existe
        Console.WriteLine($"\n➕ Tentou adicionar 3 (já existe): {adicionado}");

        adicionado = numeros.Add(6); // Não existe
        Console.WriteLine($"➕ Tentou adicionar 6 (novo): {adicionado}");
        ExibirHashSet(numeros);

        // Operações de conjunto
        var pares = new HashSet<int> { 2, 4, 6, 8, 10 };
        var impares = new HashSet<int> { 1, 3, 5, 7, 9 };

        Console.WriteLine("\n📊 Conjunto de pares:");
        ExibirHashSet(pares);
        Console.WriteLine("\n📊 Conjunto de ímpares:");
        ExibirHashSet(impares);

        // União
        var todos = new HashSet<int>(pares);
        todos.UnionWith(impares);
        Console.WriteLine("\n🔗 União (pares + ímpares):");
        ExibirHashSet(todos);

        // Interseção
        var conjunto1 = new HashSet<int> { 1, 2, 3, 4, 5 };
        var conjunto2 = new HashSet<int> { 4, 5, 6, 7, 8 };
        Console.WriteLine("\n📊 Conjunto 1:");
        ExibirHashSet(conjunto1);
        Console.WriteLine("\n📊 Conjunto 2:");
        ExibirHashSet(conjunto2);

        var intersecao = new HashSet<int>(conjunto1);
        intersecao.IntersectWith(conjunto2);
        Console.WriteLine("\n⚡ Interseção (elementos comuns):");
        ExibirHashSet(intersecao);

        // Diferença
        var diferenca = new HashSet<int>(conjunto1);
        diferenca.ExceptWith(conjunto2);
        Console.WriteLine("\n➖ Diferença (conjunto1 - conjunto2):");
        ExibirHashSet(diferenca);

        // Diferença simétrica
        var diferencaSimetrica = new HashSet<int>(conjunto1);
        diferencaSimetrica.SymmetricExceptWith(conjunto2);
        Console.WriteLine("\n🔄 Diferença simétrica (elementos não comuns):");
        ExibirHashSet(diferencaSimetrica);

        // Exemplo prático: remover duplicatas
        var listaComDuplicatas = new List<string> { "Ana", "Bruno", "Ana", "Carlos", "Bruno", "Diana" };
        Console.WriteLine("\n📝 Lista com duplicatas:");
        Console.WriteLine($"  {string.Join(", ", listaComDuplicatas)}");

        var semDuplicatas = new HashSet<string>(listaComDuplicatas);
        Console.WriteLine("\n✨ Após remover duplicatas com HashSet:");
        Console.WriteLine($"  {string.Join(", ", semDuplicatas)}");
    }

    /// <summary>
    /// Exemplo 5: Trabalhando com Queue<T>
    /// Queue implementa FIFO (First In, First Out) - o primeiro a entrar é o primeiro a sair
    /// </summary>
    public static void ExemploQueue()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 5: Queue - Fila (FIFO)                   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando uma fila
        var fila = new Queue<string>();

        // Enfileirando (Enqueue)
        Console.WriteLine("➕ Adicionando pessoas na fila:");
        fila.Enqueue("Ana");
        Console.WriteLine("  • Ana entrou na fila");
        fila.Enqueue("Bruno");
        Console.WriteLine("  • Bruno entrou na fila");
        fila.Enqueue("Carlos");
        Console.WriteLine("  • Carlos entrou na fila");
        fila.Enqueue("Diana");
        Console.WriteLine("  • Diana entrou na fila");

        Console.WriteLine($"\n📊 Total de pessoas na fila: {fila.Count}");
        Console.WriteLine($"👀 Próximo a ser atendido (Peek): {fila.Peek()}");

        // Desenfileirando (Dequeue)
        Console.WriteLine("\n➖ Atendendo pessoas:");
        while (fila.Count > 0)
        {
            var pessoa = fila.Dequeue();
            Console.WriteLine($"  • {pessoa} foi atendido(a) e saiu da fila");
            if (fila.Count > 0)
            {
                Console.WriteLine($"    Próximo: {fila.Peek()}");
            }
        }

        Console.WriteLine($"\n✅ Fila vazia. Total restante: {fila.Count}");

        // Exemplo prático: Sistema de atendimento
        Console.WriteLine("\n🏪 Simulação de Sistema de Atendimento:");
        var atendimento = new Queue<Atendimento>();

        atendimento.Enqueue(new Atendimento(1, "João Silva", "Suporte Técnico"));
        atendimento.Enqueue(new Atendimento(2, "Maria Santos", "Vendas"));
        atendimento.Enqueue(new Atendimento(3, "Pedro Souza", "Financeiro"));

        Console.WriteLine($"\n📋 {atendimento.Count} pessoas aguardando atendimento:");
        int posicao = 1;
        foreach (var item in atendimento)
        {
            Console.WriteLine($"  {posicao}. Ticket #{item.Ticket} - {item.Cliente} ({item.Departamento})");
            posicao++;
        }

        Console.WriteLine("\n🎫 Atendendo próximo ticket:");
        var proximo = atendimento.Dequeue();
        Console.WriteLine($"  • Ticket #{proximo.Ticket}: {proximo.Cliente} - {proximo.Departamento}");
        Console.WriteLine($"  • Restam {atendimento.Count} pessoas na fila");
    }

    /// <summary>
    /// Exemplo 6: Trabalhando com Stack<T>
    /// Stack implementa LIFO (Last In, First Out) - o último a entrar é o primeiro a sair
    /// </summary>
    public static void ExemploStack()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 6: Stack - Pilha (LIFO)                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando uma pilha
        var pilha = new Stack<string>();

        // Empilhando (Push)
        Console.WriteLine("➕ Empilhando livros:");
        pilha.Push("Livro 1: C# Fundamentals");
        Console.WriteLine("  • Adicionado: C# Fundamentals");
        pilha.Push("Livro 2: ASP.NET Core");
        Console.WriteLine("  • Adicionado: ASP.NET Core");
        pilha.Push("Livro 3: Entity Framework");
        Console.WriteLine("  • Adicionado: Entity Framework");
        pilha.Push("Livro 4: Design Patterns");
        Console.WriteLine("  • Adicionado: Design Patterns");

        Console.WriteLine($"\n📚 Total de livros na pilha: {pilha.Count}");
        Console.WriteLine($"👀 Livro no topo (Peek): {pilha.Peek()}");

        // Desempilhando (Pop)
        Console.WriteLine("\n➖ Retirando livros do topo:");
        while (pilha.Count > 0)
        {
            var livro = pilha.Pop();
            Console.WriteLine($"  • Retirado: {livro}");
            if (pilha.Count > 0)
            {
                Console.WriteLine($"    Novo topo: {pilha.Peek()}");
            }
        }

        Console.WriteLine($"\n✅ Pilha vazia. Total restante: {pilha.Count}");

        // Exemplo prático: Histórico de navegação
        Console.WriteLine("\n🌐 Simulação de Histórico de Navegação:");
        var historico = new Stack<PaginaWeb>();

        historico.Push(new PaginaWeb("https://google.com", "Google"));
        historico.Push(new PaginaWeb("https://github.com", "GitHub"));
        historico.Push(new PaginaWeb("https://stackoverflow.com", "Stack Overflow"));
        historico.Push(new PaginaWeb("https://microsoft.com", "Microsoft"));

        Console.WriteLine($"\n📜 Histórico ({historico.Count} páginas):");
        int nivel = historico.Count;
        foreach (var pagina in historico)
        {
            Console.WriteLine($"  {nivel}. {pagina.Titulo} - {pagina.Url}");
            nivel--;
        }

        Console.WriteLine("\n⬅️ Voltando na navegação (Pop):");
        var paginaAtual = historico.Pop();
        Console.WriteLine($"  • Saindo de: {paginaAtual.Titulo}");
        Console.WriteLine($"  • Página atual: {historico.Peek().Titulo}");

        // Exemplo: Verificação de parênteses balanceados
        Console.WriteLine("\n🔍 Verificação de Parênteses Balanceados:");
        string[] expressoes = { "(())", "(()", "())(", "(()())" };

        foreach (var expr in expressoes)
        {
            bool balanceado = VerificarParentesesBalanceados(expr);
            Console.WriteLine($"  • '{expr}' → {(balanceado ? "✅ Balanceado" : "❌ Não balanceado")}");
        }
    }

    /// <summary>
    /// Exemplo 7: Trabalhando com LinkedList<T>
    /// LinkedList é uma lista duplamente encadeada para inserções/remoções eficientes
    /// </summary>
    public static void ExemploLinkedList()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 7: LinkedList - Lista Encadeada            ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando uma LinkedList
        var lista = new LinkedList<string>();

        // Adicionando elementos
        lista.AddLast("Primeiro");
        lista.AddLast("Segundo");
        lista.AddLast("Terceiro");

        Console.WriteLine("📝 Lista inicial:");
        ExibirLinkedList(lista);

        // Adicionando no início
        lista.AddFirst("Novo Primeiro");
        Console.WriteLine("\n➕ Após adicionar no início:");
        ExibirLinkedList(lista);

        // Adicionando no final
        lista.AddLast("Novo Último");
        Console.WriteLine("\n➕ Após adicionar no final:");
        ExibirLinkedList(lista);

        // Encontrando um nó
        var noSegundo = lista.Find("Segundo");
        if (noSegundo != null)
        {
            // Adicionando antes de um nó específico
            lista.AddBefore(noSegundo, "Antes do Segundo");
            Console.WriteLine("\n📌 Após adicionar antes do 'Segundo':");
            ExibirLinkedList(lista);

            // Adicionando depois de um nó específico
            lista.AddAfter(noSegundo, "Depois do Segundo");
            Console.WriteLine("\n📌 Após adicionar depois do 'Segundo':");
            ExibirLinkedList(lista);
        }

        // Removendo elementos
        lista.RemoveFirst();
        Console.WriteLine("\n➖ Após remover primeiro:");
        ExibirLinkedList(lista);

        lista.RemoveLast();
        Console.WriteLine("\n➖ Após remover último:");
        ExibirLinkedList(lista);

        // Navegando pela lista
        Console.WriteLine("\n🔄 Navegando do início ao fim:");
        var noAtual = lista.First;
        int posicao = 1;
        while (noAtual != null)
        {
            Console.WriteLine($"  Posição {posicao}: {noAtual.Value}");
            noAtual = noAtual.Next;
            posicao++;
        }

        Console.WriteLine("\n🔄 Navegando do fim ao início:");
        noAtual = lista.Last;
        posicao = lista.Count;
        while (noAtual != null)
        {
            Console.WriteLine($"  Posição {posicao}: {noAtual.Value}");
            noAtual = noAtual.Previous;
            posicao--;
        }
    }

    /// <summary>
    /// Exemplo 8: Comparação de Performance entre Coleções
    /// </summary>
    public static void ExemploComparacaoPerformance()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 8: Comparação de Performance               ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        const int quantidade = 100000;
        var random = new Random();

        Console.WriteLine($"📊 Testando com {quantidade:N0} elementos\n");

        // Teste com List
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var lista = new List<int>();
        for (int i = 0; i < quantidade; i++)
        {
            lista.Add(random.Next(1000));
        }
        stopwatch.Stop();
        Console.WriteLine($"List<T> - Inserção: {stopwatch.ElapsedMilliseconds}ms");

        stopwatch.Restart();
        bool contemList = lista.Contains(500);
        stopwatch.Stop();
        Console.WriteLine($"List<T> - Busca: {stopwatch.ElapsedMilliseconds}ms");

        // Teste com HashSet
        stopwatch.Restart();
        var hashSet = new HashSet<int>();
        for (int i = 0; i < quantidade; i++)
        {
            hashSet.Add(random.Next(1000));
        }
        stopwatch.Stop();
        Console.WriteLine($"\nHashSet<T> - Inserção: {stopwatch.ElapsedMilliseconds}ms");

        stopwatch.Restart();
        bool contemHashSet = hashSet.Contains(500);
        stopwatch.Stop();
        Console.WriteLine($"HashSet<T> - Busca: {stopwatch.ElapsedMilliseconds}ms");

        // Teste com Dictionary
        stopwatch.Restart();
        var dicionario = new Dictionary<int, int>();
        for (int i = 0; i < quantidade; i++)
        {
            int key = random.Next(1000000);
            if (!dicionario.ContainsKey(key))
            {
                dicionario[key] = i;
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"\nDictionary<K,V> - Inserção: {stopwatch.ElapsedMilliseconds}ms");

        stopwatch.Restart();
        bool contemDictionary = dicionario.ContainsKey(500);
        stopwatch.Stop();
        Console.WriteLine($"Dictionary<K,V> - Busca: {stopwatch.ElapsedMilliseconds}ms");

        Console.WriteLine("\n💡 Dicas de Performance:");
        Console.WriteLine("  • List<T>: melhor para acesso sequencial e por índice");
        Console.WriteLine("  • HashSet<T>: melhor para verificar existência rapidamente");
        Console.WriteLine("  • Dictionary<K,V>: melhor para acesso por chave");
        Console.WriteLine("  • LinkedList<T>: melhor para inserções/remoções frequentes no meio");
        Console.WriteLine("  • Queue<T>: melhor para processamento FIFO");
        Console.WriteLine("  • Stack<T>: melhor para processamento LIFO");
    }

    // Métodos auxiliares
    private static void ExibirLista<T>(List<T> lista)
    {
        Console.WriteLine($"  Total: {lista.Count} elementos");
        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine($"  [{i}] {lista[i]}");
        }
    }

    private static void ExibirHashSet<T>(HashSet<T> conjunto)
    {
        Console.WriteLine($"  Total: {conjunto.Count} elementos");
        Console.WriteLine($"  {{ {string.Join(", ", conjunto)} }}");
    }

    private static void ExibirLinkedList<T>(LinkedList<T> lista)
    {
        Console.WriteLine($"  Total: {lista.Count} elementos");
        var node = lista.First;
        int posicao = 1;
        while (node != null)
        {
            Console.WriteLine($"  [{posicao}] {node.Value}");
            node = node.Next;
            posicao++;
        }
    }

    private static bool VerificarParentesesBalanceados(string expressao)
    {
        var pilha = new Stack<char>();
        foreach (char c in expressao)
        {
            if (c == '(')
            {
                pilha.Push(c);
            }
            else if (c == ')')
            {
                if (pilha.Count == 0)
                    return false;
                pilha.Pop();
            }
        }
        return pilha.Count == 0;
    }
}

// Classes auxiliares
public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
}

public class ProdutoEstoque
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }

    public ProdutoEstoque(string nome, int quantidade)
    {
        Nome = nome;
        Quantidade = quantidade;
    }

    public void AdicionarEstoque(int qtd)
    {
        Quantidade += qtd;
    }

    public void RemoverEstoque(int qtd)
    {
        Quantidade -= qtd;
    }
}

public class Atendimento
{
    public int Ticket { get; set; }
    public string Cliente { get; set; }
    public string Departamento { get; set; }

    public Atendimento(int ticket, string cliente, string departamento)
    {
        Ticket = ticket;
        Cliente = cliente;
        Departamento = departamento;
    }
}

public class PaginaWeb
{
    public string Url { get; set; }
    public string Titulo { get; set; }

    public PaginaWeb(string url, string titulo)
    {
        Url = url;
        Titulo = titulo;
    }
}
