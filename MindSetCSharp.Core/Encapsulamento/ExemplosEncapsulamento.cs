namespace MindSetCSharp.Core.Encapsulamento;

/// <summary>
/// Exemplos práticos demonstrando encapsulamento em C#.
/// </summary>
public static class ExemplosEncapsulamento
{
    /// <summary>
    /// Exemplo 1: Comparação entre código com e sem encapsulamento
    /// </summary>
    public static void ExemploComparacao()
    {
        ComparacaoEncapsulamento.DemonstrarDiferenca();
    }

    /// <summary>
    /// Exemplo 2: Níveis de acesso e propriedades
    /// </summary>
    public static void ExemploNiveisAcesso()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║        EXEMPLO 2: Níveis de Acesso                  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var pessoa = new Pessoa("Carlos Silva", "12345678900", new DateTime(1990, 5, 15));
        pessoa.Email = "carlos@email.com";

        Console.WriteLine("✅ Acessando propriedades públicas:");
        pessoa.ExibirInformacoes();

        Console.WriteLine("\n--- Tentando modificar CPF ---");
        pessoa.DefinirCPF("987.654.321-00");
        pessoa.DefinirCPF("123456"); // CPF inválido

        Console.WriteLine("\n--- Verificando e-mail ---");
        pessoa.VerificarEmail("123456"); // Código correto
        pessoa.VerificarEmail("000000"); // Código incorreto

        Console.WriteLine("\n💡 Demonstração de encapsulamento:");
        Console.WriteLine("   • Não podemos acessar: pessoa._cpf (campo privado)");
        Console.WriteLine("   • Não podemos modificar: pessoa.CPF = ... (set privado)");
        Console.WriteLine("   • Podemos ler: pessoa.CPF (get público)");
        Console.WriteLine("   • Não podemos modificar: pessoa.Id (init apenas)");
        Console.WriteLine("   • Idade é calculada automaticamente (somente get)");

        // Classe derivada
        Console.WriteLine("\n\n📋 PESSOA FÍSICA (classe derivada):");
        var pf = new PessoaFisica("Ana Paula", "11122233344", new DateTime(1985, 10, 20), "Engenheira");
        pf.Email = "ana@email.com";
        pf.DefinirRenda(8500m);
        pf.ExibirInformacoes();
        pf.ExibirImpostos();
    }

    /// <summary>
    /// Exemplo 3: Encapsulamento de regras de negócio
    /// </summary>
    public static void ExemploCarrinhoCompras()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 3: Encapsulamento de Regras de Negócio    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var carrinho = new CarrinhoCompras();

        Console.WriteLine("🛒 Adicionando produtos ao carrinho:\n");
        carrinho.AdicionarProduto("Notebook Dell", 3500m, 1);
        carrinho.AdicionarProduto("Mouse Logitech", 150m, 2);
        carrinho.AdicionarProduto("Teclado Mecânico", 450m, 1);
        carrinho.AdicionarProduto("Mouse Logitech", 150m, 1); // Atualiza quantidade

        carrinho.ExibirResumo();

        Console.WriteLine("\n--- Tentando aplicar cupons ---\n");
        carrinho.AplicarCupom("DESC20");
        carrinho.AplicarCupom("DESC30"); // Já tem cupom
        
        carrinho.ExibirResumo();

        Console.WriteLine("\n--- Removendo cupom e aplicando outro ---\n");
        carrinho.RemoverCupom();
        carrinho.AplicarCupom("NATAL25");

        carrinho.ExibirResumo();

        Console.WriteLine("\n--- Removendo produto ---\n");
        carrinho.RemoverProduto("Mouse Logitech");

        carrinho.ExibirResumo();

        Console.WriteLine("\n💡 Observações sobre encapsulamento:");
        Console.WriteLine("   • Não podemos acessar diretamente a lista de itens");
        Console.WriteLine("   • Não podemos modificar valores diretamente");
        Console.WriteLine("   • Todas as regras são validadas internamente");
        Console.WriteLine("   • Descontos são recalculados automaticamente");
        Console.WriteLine("   • Lógica de negócio está protegida e centralizada");
    }

    /// <summary>
    /// Exemplo 4: Validações e proteção de dados
    /// </summary>
    public static void ExemploValidacoes()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 4: Validações e Proteção de Dados       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("✅ Criando conta bancária com validações:\n");
        var conta = new ContaBancariaComEncapsulamento("Roberto Lima", "98765-4", 1000m);

        Console.WriteLine("\n--- Operações válidas ---\n");
        conta.Depositar(500m);
        conta.Sacar(200m);

        Console.WriteLine("\n--- Tentativas de operações inválidas ---\n");
        conta.Depositar(-100m);  // Valor negativo
        conta.Sacar(0m);         // Valor zero
        conta.Sacar(5000m);      // Saldo insuficiente

        Console.WriteLine("\n--- Extrato completo (com histórico protegido) ---");
        conta.ExibirExtrato();

        Console.WriteLine("\n💡 Vantagens do encapsulamento demonstradas:");
        Console.WriteLine("   ✓ Validação automática de todas as operações");
        Console.WriteLine("   ✓ Histórico de transações mantido automaticamente");
        Console.WriteLine("   ✓ Impossível criar saldo negativo");
        Console.WriteLine("   ✓ Impossível modificar dados sem validação");
        Console.WriteLine("   ✓ Lógica de negócio centralizada e consistente");
    }

    /// <summary>
    /// Exemplo 5: Propriedades somente leitura e calculadas
    /// </summary>
    public static void ExemploPropriedadesEspeciais()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║  EXEMPLO 5: Propriedades Somente Leitura/Calculadas ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📋 Criando pessoas para demonstrar propriedades:\n");

        var p1 = new Pessoa("João Silva", "11111111111", new DateTime(1990, 3, 15));
        var p2 = new Pessoa("Maria Santos", "22222222222", new DateTime(1985, 8, 20));
        var p3 = new Pessoa("Pedro Costa", "33333333333", new DateTime(2000, 12, 10));

        Console.WriteLine($"{"Nome",-20} {"CPF (formatado)",20} {"Idade",8} {"ID",6}");
        Console.WriteLine(new string('─', 55));
        Console.WriteLine($"{p1.Nome,-20} {p1.CPF,20} {p1.Idade,8} {p1.Id,6}");
        Console.WriteLine($"{p2.Nome,-20} {p2.CPF,20} {p2.Idade,8} {p2.Id,6}");
        Console.WriteLine($"{p3.Nome,-20} {p3.CPF,20} {p3.Idade,8} {p3.Id,6}");

        Console.WriteLine("\n💡 Tipos de propriedades demonstradas:\n");
        Console.WriteLine("1. Propriedade somente leitura (CPF):");
        Console.WriteLine("   • Get público, set privado");
        Console.WriteLine("   • Formatação automática na leitura");
        Console.WriteLine("   • Não pode ser modificada externamente");

        Console.WriteLine("\n2. Propriedade calculada (Idade):");
        Console.WriteLine("   • Calculada dinamicamente");
        Console.WriteLine("   • Sempre atualizada");
        Console.WriteLine("   • Não ocupa espaço adicional");

        Console.WriteLine("\n3. Propriedade init-only (Id):");
        Console.WriteLine("   • Pode ser definida apenas no construtor");
        Console.WriteLine("   • Imutável após criação");
        Console.WriteLine("   • Incremento automático");

        Console.WriteLine("\n4. Propriedade com validação (DataNascimento):");
        try
        {
            var p4 = new Pessoa("Teste", "44444444444", DateTime.Now.AddDays(1));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"   ✓ Validação funcionou: {ex.Message}");
        }
    }
}
