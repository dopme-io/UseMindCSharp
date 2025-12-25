namespace MindSetCSharp.Core.Classes;

/// <summary>
/// Exemplos práticos demonstrando os conceitos de classes em C#.
/// </summary>
public static class ExemplosClasses
{
    /// <summary>
    /// Exemplo 1: Trabalhando com a classe Produto
    /// </summary>
    public static void ExemploProduto()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║         EXEMPLO 1: Classe Produto                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando produtos
        var produto1 = new Produto("Notebook Dell", 3500.00m, 10);
        var produto2 = new Produto("Mouse Logitech", "MOUSE001", "Periféricos", 150.00m, 50);
        var produto3 = new Produto("Teclado Mecânico", 450.00m, 3);

        Console.WriteLine("📦 Produtos criados:\n");
        produto1.ExibirDetalhes();
        Console.WriteLine();
        produto2.ExibirDetalhes();
        Console.WriteLine();
        produto3.ExibirDetalhes();

        // Operações com produtos
        Console.WriteLine("\n--- OPERAÇÕES DE VENDA ---\n");
        produto1.Vender(2);
        Console.WriteLine();
        produto3.Vender(2); // Vai disparar alerta de estoque baixo
        Console.WriteLine();

        // Reposição
        Console.WriteLine("\n--- REPOSIÇÃO DE ESTOQUE ---\n");
        produto3.Repor(10);
        Console.WriteLine();

        // Aplicar desconto
        Console.WriteLine("\n--- APLICANDO DESCONTOS ---\n");
        produto2.AplicarDesconto(20);
        Console.WriteLine();

        // Exibir detalhes atualizados
        Console.WriteLine("\n--- SITUAÇÃO ATUAL ---\n");
        Console.WriteLine($"  • {produto1}");
        Console.WriteLine($"  • {produto2}");
        Console.WriteLine($"  • {produto3}");
    }

    /// <summary>
    /// Exemplo 2: Trabalhando com a classe Cliente
    /// </summary>
    public static void ExemploCliente()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║         EXEMPLO 2: Classe Cliente                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando clientes
        var cliente1 = new Cliente(
            "Maria Santos",
            "123.456.789-00",
            new DateTime(1990, 5, 15),
            "maria.santos@email.com"
        );

        var cliente2 = new Cliente(
            "João Silva",
            "98765432100", // CPF sem formatação
            new DateTime(1985, 10, 20),
            "joao.silva@email.com"
        );

        // Adicionando telefones
        Console.WriteLine("📱 Adicionando telefones:\n");
        cliente1.AdicionarTelefone("(11) 98765-4321");
        cliente1.AdicionarTelefone("11987654321"); // Mesmo número - não será adicionado
        cliente1.AdicionarTelefone("(11) 3456-7890");
        Console.WriteLine();

        cliente2.AdicionarTelefone("21987654321");
        Console.WriteLine();

        // Exibir informações
        Console.WriteLine("\n--- INFORMAÇÕES DOS CLIENTES ---");
        cliente1.ExibirInformacoes();
        cliente2.ExibirInformacoes();

        // Remover telefone
        Console.WriteLine("\n--- REMOVENDO TELEFONE ---\n");
        cliente1.RemoverTelefone("(11) 3456-7890");
        Console.WriteLine();

        // Desativar/Ativar cliente
        Console.WriteLine("\n--- GERENCIANDO STATUS ---\n");
        cliente2.Desativar();
        cliente2.Ativar();
        Console.WriteLine();

        // Listar clientes
        Console.WriteLine("\n--- LISTA DE CLIENTES ---\n");
        var clientes = new List<Cliente> { cliente1, cliente2 };
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"  • {cliente}");
        }
    }

    /// <summary>
    /// Exemplo 3: Sistema de Pedidos (Composição de Classes)
    /// </summary>
    public static void ExemploPedido()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 3: Sistema de Pedidos (Composição)      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criar cliente
        var cliente = new Cliente(
            "Carlos Oliveira",
            "111.222.333-44",
            new DateTime(1992, 3, 25),
            "carlos@email.com"
        );

        // Criar produtos
        var notebook = new Produto("Notebook Lenovo", 4200.00m, 5);
        var mouse = new Produto("Mouse Gamer", 250.00m, 20);
        var teclado = new Produto("Teclado RGB", 380.00m, 15);
        var monitor = new Produto("Monitor 27\"", 1500.00m, 8);

        // Criar pedido
        Console.WriteLine("🛒 Criando novo pedido...\n");
        var pedido = new Pedido(cliente);

        // Adicionar itens
        Console.WriteLine("--- ADICIONANDO ITENS AO PEDIDO ---\n");
        pedido.AdicionarItem(notebook, 1);
        pedido.AdicionarItem(mouse, 2);
        pedido.AdicionarItem(teclado, 1);
        pedido.AdicionarItem(monitor, 2);
        Console.WriteLine();

        // Adicionar mais do mesmo produto
        Console.WriteLine("--- ADICIONANDO MAIS DO MESMO PRODUTO ---\n");
        pedido.AdicionarItem(mouse, 1); // Vai atualizar quantidade
        Console.WriteLine();

        // Exibir resumo
        pedido.ExibirResumo();

        // Processar pedido
        Console.WriteLine("\n--- FLUXO DE PROCESSAMENTO ---\n");
        pedido.Processar();
        Console.WriteLine();
        
        pedido.Enviar();
        Console.WriteLine();
        
        pedido.Entregar();
        Console.WriteLine();

        // Exibir resumo final
        pedido.ExibirResumo();
    }

    /// <summary>
    /// Exemplo 4: Múltiplos pedidos e análises
    /// </summary>
    public static void ExemploMultiplosPedidos()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║    EXEMPLO 4: Análise de Múltiplos Pedidos          ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criar clientes
        var cliente1 = new Cliente("Ana Paula", "11111111111", new DateTime(1988, 7, 10), "ana@email.com");
        var cliente2 = new Cliente("Bruno Costa", "22222222222", new DateTime(1995, 2, 20), "bruno@email.com");
        var cliente3 = new Cliente("Carla Lima", "33333333333", new DateTime(1990, 11, 5), "carla@email.com");

        // Criar produtos
        var produtos = new List<Produto>
        {
            new Produto("Produto A", 100.00m, 50),
            new Produto("Produto B", 200.00m, 30),
            new Produto("Produto C", 150.00m, 40),
            new Produto("Produto D", 300.00m, 20)
        };

        // Criar pedidos
        var pedido1 = new Pedido(cliente1);
        pedido1.AdicionarItem(produtos[0], 2);
        pedido1.AdicionarItem(produtos[1], 1);
        pedido1.Processar();
        pedido1.Enviar();
        pedido1.Entregar();

        var pedido2 = new Pedido(cliente2);
        pedido2.AdicionarItem(produtos[2], 3);
        pedido2.AdicionarItem(produtos[3], 2);
        pedido2.Processar();
        pedido2.Enviar();

        var pedido3 = new Pedido(cliente3);
        pedido3.AdicionarItem(produtos[0], 5);
        pedido3.AdicionarItem(produtos[2], 2);
        pedido3.Processar();

        var pedido4 = new Pedido(cliente1);
        pedido4.AdicionarItem(produtos[1], 1);
        pedido4.Cancelar();

        // Lista de pedidos
        var pedidos = new List<Pedido> { pedido1, pedido2, pedido3, pedido4 };

        // Análises
        Console.WriteLine("📊 ANÁLISE DE PEDIDOS\n");
        Console.WriteLine($"  Total de Pedidos: {pedidos.Count}");
        Console.WriteLine($"  Pedidos Entregues: {pedidos.Count(p => p.Status == Pedido.StatusPedido.Entregue)}");
        Console.WriteLine($"  Pedidos em Trânsito: {pedidos.Count(p => p.Status == Pedido.StatusPedido.Enviado)}");
        Console.WriteLine($"  Pedidos em Processamento: {pedidos.Count(p => p.Status == Pedido.StatusPedido.Processando)}");
        Console.WriteLine($"  Pedidos Cancelados: {pedidos.Count(p => p.Status == Pedido.StatusPedido.Cancelado)}");
        Console.WriteLine($"\n  Valor Total Vendido: R$ {pedidos.Where(p => p.Status != Pedido.StatusPedido.Cancelado).Sum(p => p.ValorTotal):F2}");
        Console.WriteLine($"  Ticket Médio: R$ {pedidos.Where(p => p.Status != Pedido.StatusPedido.Cancelado).Average(p => p.ValorTotal):F2}");

        // Listar pedidos
        Console.WriteLine("\n--- LISTA DE PEDIDOS ---\n");
        foreach (var pedido in pedidos)
        {
            Console.WriteLine($"  • {pedido}");
        }

        // Pedido de maior valor
        var maiorPedido = pedidos.OrderByDescending(p => p.ValorTotal).First();
        Console.WriteLine($"\n💰 Maior Pedido: #{maiorPedido.Numero} - R$ {maiorPedido.ValorTotal:F2} ({maiorPedido.Cliente.Nome})");
    }

    /// <summary>
    /// Exemplo 5: Demonstrando membros estáticos
    /// </summary>
    public static void ExemploMembrosEstaticos()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 5: Membros Estáticos e Contadores      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("🔢 Criando múltiplos clientes e observando IDs automáticos:\n");

        for (int i = 1; i <= 5; i++)
        {
            var cliente = new Cliente($"Cliente {i}", $"{i:D11}", DateTime.Now.AddYears(-20), $"cliente{i}@email.com");
            Console.WriteLine($"  ✅ {cliente}");
        }

        Console.WriteLine("\n💡 Observação: Os IDs são gerados automaticamente por um contador estático!");
        Console.WriteLine("   Cada instância recebe um ID único sequencial.");
    }
}
