namespace MindSetCSharp.Core.Interface;

/// <summary>
/// Exemplos práticos demonstrando interfaces em C#.
/// </summary>
public static class ExemplosInterface
{
    /// <summary>
    /// Exemplo 1: Repositório genérico com interface
    /// </summary>
    public static void ExemploRepositorio()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 1: Repositório Genérico com Interface   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Repositório de produtos
        Console.WriteLine("📦 REPOSITÓRIO DE PRODUTOS:\n");
        IRepositorio<Produto> repoProdutos = new RepositorioMemoria<Produto>();

        repoProdutos.Adicionar(new Produto { Nome = "Notebook", Preco = 3500m, Estoque = 10 });
        repoProdutos.Adicionar(new Produto { Nome = "Mouse", Preco = 150m, Estoque = 50 });
        repoProdutos.Adicionar(new Produto { Nome = "Teclado", Preco = 450m, Estoque = 30 });

        Console.WriteLine($"\n📊 Total de produtos: {repoProdutos.Contar()}");
        Console.WriteLine("\n📋 Todos os produtos:");
        foreach (var produto in repoProdutos.ObterTodos())
        {
            Console.WriteLine($"   {produto}");
        }

        // Repositório de clientes
        Console.WriteLine("\n\n👥 REPOSITÓRIO DE CLIENTES:\n");
        IRepositorio<Cliente> repoClientes = new RepositorioMemoria<Cliente>();

        repoClientes.Adicionar(new Cliente { Nome = "João Silva", Email = "joao@email.com", Telefone = "11987654321" });
        repoClientes.Adicionar(new Cliente { Nome = "Maria Santos", Email = "maria@email.com", Telefone = "11876543210" });

        Console.WriteLine($"\n📊 Total de clientes: {repoClientes.Contar()}");
        Console.WriteLine("\n📋 Todos os clientes:");
        foreach (var cliente in repoClientes.ObterTodos())
        {
            Console.WriteLine($"   {cliente}");
        }

        Console.WriteLine("\n💡 Vantagens da interface:");
        Console.WriteLine("   • Mesmo contrato para diferentes tipos");
        Console.WriteLine("   • Código genérico reutilizável");
        Console.WriteLine("   • Fácil trocar implementação");
    }

    /// <summary>
    /// Exemplo 2: Repositório com cache (Decorator Pattern)
    /// </summary>
    public static void ExemploRepositorioComCache()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║    EXEMPLO 2: Repositório com Cache (Decorator)      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criar repositório base
        var repoBase = new RepositorioMemoria<Produto>();
        
        // Decorar com cache
        IRepositorio<Produto> repo = new RepositorioComCache<Produto>(repoBase);

        // Adicionar produtos
        repo.Adicionar(new Produto { Nome = "Notebook", Preco = 3500m, Estoque = 10 });
        repo.Adicionar(new Produto { Nome = "Mouse", Preco = 150m, Estoque = 50 });

        Console.WriteLine("\n--- Primeira busca (sem cache) ---\n");
        var produto1 = repo.ObterPorId(1);

        Console.WriteLine("\n--- Segunda busca (com cache) ---\n");
        var produto2 = repo.ObterPorId(1);

        Console.WriteLine("\n--- Terceira busca (com cache) ---\n");
        var produto3 = repo.ObterPorId(1);

        Console.WriteLine("\n💡 Padrão Decorator com interfaces:");
        Console.WriteLine("   • Adiciona funcionalidade sem alterar código original");
        Console.WriteLine("   • Mantém o mesmo contrato (interface)");
        Console.WriteLine("   • Pode empilhar múltiplos decorators");
    }

    /// <summary>
    /// Exemplo 3: Múltiplas interfaces em uma classe
    /// </summary>
    public static void ExemploMultiplasInterfaces()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 3: Múltiplas Interfaces em Uma Classe    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Serviço que implementa 3 interfaces
        var servico = new ServicoNotificacaoCompleto();

        Console.WriteLine("📧 Usando como IEnviadorEmail:");
        IEnviadorEmail enviadorEmail = servico;
        enviadorEmail.EnviarEmail("usuario@email.com", "Bem-vindo!", "Obrigado por se cadastrar!");

        Console.WriteLine("\n📱 Usando como IEnviadorSms:");
        IEnviadorSms enviadorSms = servico;
        enviadorSms.EnviarSms("11987654321", "Seu código de verificação é: 123456");

        Console.WriteLine("\n🔔 Usando como IEnviadorPush:");
        IEnviadorPush enviadorPush = servico;
        enviadorPush.EnviarNotificacao("device-id-12345678", "Nova mensagem", "Você tem uma nova mensagem!");

        Console.WriteLine("\n💡 Vantagens de múltiplas interfaces:");
        Console.WriteLine("   • Uma classe pode ter múltiplos 'contratos'");
        Console.WriteLine("   • Interface Segregation Principle");
        Console.WriteLine("   • Cliente usa apenas o que precisa");
        Console.WriteLine("   • Flexibilidade no design");
    }

    /// <summary>
    /// Exemplo 4: Polimorfismo através de interfaces
    /// </summary>
    public static void ExemploPolimorfismo()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 4: Polimorfismo Através de Interfaces   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var gerenciador = new GerenciadorNotificacoes();

        // Adicionar diferentes implementações da mesma interface
        gerenciador.AdicionarNotificador(new NotificadorEmail());
        gerenciador.AdicionarNotificador(new NotificadorSms());
        gerenciador.AdicionarNotificador(new NotificadorPush());

        gerenciador.ListarNotificadores();

        // Enviar para todos de uma vez
        gerenciador.EnviarParaTodos("usuario@email.com", "Seu pedido foi confirmado!");

        Console.WriteLine("\n💡 Polimorfismo com interfaces:");
        Console.WriteLine("   • Código genérico trabalha com interface");
        Console.WriteLine("   • Comportamento específico em cada implementação");
        Console.WriteLine("   • Fácil adicionar novos tipos");
        Console.WriteLine("   • Desacoplamento entre classes");
    }

    /// <summary>
    /// Exemplo 5: Sistema de pagamentos com múltiplas interfaces
    /// </summary>
    public static void ExemploPagamentos()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 5: Sistema de Pagamentos (Múltiplas APIs)  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var checkout = new SistemaCheckout();

        // Pagamento com cartão (implementa 3 interfaces)
        Console.WriteLine("💳 PAGAMENTO COM CARTÃO:\n");
        var cartao = new PagamentoCartaoCredito();
        checkout.ProcessarCompra(cartao, 1000m, "1234567812345678");

        // Simular reembolso
        Console.WriteLine("\n--- Reembolso ---\n");
        if (cartao is IReembolsavel reembolsavel)
        {
            reembolsavel.ProcessarReembolso("TXN-12345", 1000m);
        }

        // Pagamento com PIX
        Console.WriteLine("\n\n⚡ PAGAMENTO COM PIX:\n");
        var pix = new PagamentoPix();
        checkout.ProcessarCompra(pix, 1000m, "usuario@email.com");

        // Pagamento com Boleto
        Console.WriteLine("\n\n🧾 PAGAMENTO COM BOLETO:\n");
        var boleto = new PagamentoBoleto();
        checkout.ProcessarCompra(boleto, 1000m, "12345678900");

        Console.WriteLine("\n\n💡 Design com interfaces:");
        Console.WriteLine("   • IProcessadorPagamento: todos implementam");
        Console.WriteLine("   • IReembolsavel: apenas alguns implementam");
        Console.WriteLine("   • IParcelavel: apenas cartão implementa");
        Console.WriteLine("   • Código verifica suporte em runtime (is/as)");
        Console.WriteLine("   • Flexível e extensível");
    }

    /// <summary>
    /// Exemplo 6: Comparação entre classe abstrata e interface
    /// </summary>
    public static void ExemploComparacao()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║  EXEMPLO 6: Interface vs Classe Abstrata - Quando Usar║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📋 INTERFACES:");
        Console.WriteLine("   ✅ Use quando:");
        Console.WriteLine("      • Definir um CONTRATO que classes não relacionadas devem seguir");
        Console.WriteLine("      • Permitir múltipla herança de comportamento");
        Console.WriteLine("      • Criar arquiteturas plugáveis (Strategy, Adapter, etc)");
        Console.WriteLine("      • Desacoplar completamente a implementação");
        Console.WriteLine("\n   ❌ NÃO contém:");
        Console.WriteLine("      • Implementação de métodos (apenas assinatura)*");
        Console.WriteLine("      • Campos ou construtores");
        Console.WriteLine("      • Estado (variáveis de instância)");
        Console.WriteLine("\n   📝 Exemplo:");
        Console.WriteLine("      IRepositorio, INotificador, IProcessadorPagamento");

        Console.WriteLine("\n\n📋 CLASSES ABSTRATAS:");
        Console.WriteLine("   ✅ Use quando:");
        Console.WriteLine("      • Compartilhar código entre classes RELACIONADAS");
        Console.WriteLine("      • Fornecer implementação base/padrão");
        Console.WriteLine("      • Necessitar de campos, construtores, estado");
        Console.WriteLine("      • Definir uma hierarquia é-um (Animal → Cachorro)");
        Console.WriteLine("\n   ✅ CONTÉM:");
        Console.WriteLine("      • Métodos abstratos E concretos");
        Console.WriteLine("      • Campos, propriedades, construtores");
        Console.WriteLine("      • Estado compartilhado");
        Console.WriteLine("\n   📝 Exemplo:");
        Console.WriteLine("      Funcionario, Veiculo, Forma");

        Console.WriteLine("\n\n🎯 REGRA GERAL:");
        Console.WriteLine("   • Interface: CONTRATO de comportamento (\"pode fazer\")");
        Console.WriteLine("   • Classe Abstrata: BASE para herança (\"é um tipo de\")");
        Console.WriteLine("   • Use AMBOS quando apropriado!");
        Console.WriteLine("\n   Exemplo: class CartaoCredito : ProcessadorBase, IReembolsavel, IParcelavel");
        Console.WriteLine("            ↑ herança         ↑ contratos de comportamento");

        Console.WriteLine("\n\n*C# 8+ permite métodos com implementação padrão em interfaces");
    }
}
