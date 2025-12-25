namespace MindSetCSharp.Core.Heranca;

/// <summary>
/// Exemplos práticos demonstrando herança em C#.
/// </summary>
public static class ExemplosHeranca
{
    /// <summary>
    /// Exemplo 1: Hierarquia de Funcionários
    /// </summary>
    public static void ExemploFuncionarios()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 1: Hierarquia de Funcionários           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Criando funcionários de diferentes tipos
        var funcionario = new Funcionario("João Silva", "111.111.111-11", 3000m);
        
        var gerente = new Gerente("Maria Santos", "222.222.222-22", 5000m, "TI");
        gerente.NumeroSubordinados = 10;
        
        var dev = new Desenvolvedor("Carlos Souza", "333.333.333-33", 4000m, "C#", "Senior");
        dev.ProjetosCompletos = 5;
        
        var estagiario = new Estagiario("Ana Paula", "444.444.444-44", 1500m, "Ciência da Computação", "USP");

        Console.WriteLine("📋 LISTA DE FUNCIONÁRIOS:\n");
        funcionario.ExibirInformacoes();
        Console.WriteLine();
        gerente.ExibirInformacoes();
        Console.WriteLine();
        dev.ExibirInformacoes();
        Console.WriteLine();
        estagiario.ExibirInformacoes();

        // Demonstrando métodos específicos
        Console.WriteLine("\n--- AÇÕES ESPECÍFICAS ---\n");
        gerente.AdicionarSubordinado();
        gerente.AdicionarSubordinado();
        Console.WriteLine();
        
        dev.CompletarProjeto();
        Console.WriteLine();
        
        estagiario.VerificarTermino();
    }

    /// <summary>
    /// Exemplo 2: Polimorfismo - tratando objetos de classes derivadas
    /// através de referências da classe base.
    /// </summary>
    public static void ExemploPolimorfismo()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║        EXEMPLO 2: Polimorfismo em Ação              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Lista de Funcionarios que contém objetos de classes derivadas
        List<Funcionario> equipe = new List<Funcionario>
        {
            new Gerente("Roberto Lima", "111.111.111-11", 6000m, "Vendas") { NumeroSubordinados = 15 },
            new Desenvolvedor("Juliana Costa", "222.222.222-22", 4500m, "Python", "Pleno") { ProjetosCompletos = 3 },
            new Desenvolvedor("Pedro Alves", "333.333.333-33", 3500m, "Java", "Junior"),
            new Estagiario("Lucas Martins", "444.444.444-44", 1800m, "Engenharia", "UNICAMP"),
            new Gerente("Fernanda Rocha", "555.555.555-55", 7000m, "Marketing") { NumeroSubordinados = 8 }
        };

        Console.WriteLine("💰 FOLHA DE PAGAMENTO DA EMPRESA\n");
        Console.WriteLine($"{"Funcionário",-25} {"Tipo",-15} {"Salário",15} {"Bônus",15}");
        Console.WriteLine(new string('─', 70));

        decimal totalSalarios = 0;
        decimal totalBonus = 0;

        foreach (var funcionario in equipe)
        {
            var tipo = funcionario switch
            {
                Gerente => "Gerente",
                Desenvolvedor => "Desenvolvedor",
                Estagiario => "Estagiário",
                _ => "Funcionário"
            };

            var salario = funcionario.CalcularSalario();
            var bonus = funcionario.CalcularBonus();

            Console.WriteLine($"{funcionario.Nome,-25} {tipo,-15} R$ {salario,11:F2} R$ {bonus,11:F2}");

            totalSalarios += salario;
            totalBonus += bonus;
        }

        Console.WriteLine(new string('─', 70));
        Console.WriteLine($"{"TOTAL:",-40} R$ {totalSalarios,11:F2} R$ {totalBonus,11:F2}");
        Console.WriteLine($"\n💵 Total Geral: R$ {(totalSalarios + totalBonus):F2}");

        // Demonstrando que cada tipo calcula diferentemente
        Console.WriteLine("\n--- DEMONSTRAÇÃO DE POLIMORFISMO ---\n");
        Console.WriteLine("Mesmo método (CalcularSalario), comportamentos diferentes:\n");
        
        foreach (var f in equipe)
        {
            Console.WriteLine($"  • {f.Nome}: R$ {f.CalcularSalario():F2}");
        }
    }

    /// <summary>
    /// Exemplo 3: Classes Abstratas - Veículos
    /// </summary>
    public static void ExemploVeiculos()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 3: Classes Abstratas (Veículos)        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Não podemos instanciar Veiculo diretamente (é abstrata)
        // var veiculo = new Veiculo(); // ❌ ERRO!

        // Mas podemos criar instâncias das classes derivadas
        var carro = new Carro("Toyota", "Corolla", 2023, "Prata", 4, "Flex");
        var moto = new Moto("Honda", "CB 500", 2023, "Vermelha", 500, true);
        var caminhao = new Caminhao("Scania", "R450", 2022, "Branco", 25m, 6);

        Console.WriteLine("🚗 DEMONSTRAÇÃO DO CARRO:\n");
        carro.ExibirInformacoes();
        carro.Buzinar();
        carro.Acelerar(30);
        carro.Acelerar(50);
        carro.Acelerar(80);
        carro.Acelerar(100); // Vai atingir velocidade máxima
        carro.ExibirVelocidade();
        carro.Frear(50);
        carro.Frear(200); // Vai parar
        Console.WriteLine();

        Console.WriteLine("\n🏍️  DEMONSTRAÇÃO DA MOTO:\n");
        moto.ExibirInformacoes();
        moto.Buzinar();
        moto.Acelerar(20);
        moto.Empinar();
        moto.Acelerar(30);
        moto.Empinar(); // Velocidade alta demais
        moto.ExibirVelocidade();
        Console.WriteLine();

        Console.WriteLine("\n🚚 DEMONSTRAÇÃO DO CAMINHÃO:\n");
        caminhao.ExibirInformacoes();
        caminhao.Buzinar();
        caminhao.Carregar(20);
        caminhao.Carregar(30); // Excede capacidade
        caminhao.Acelerar(50);
        caminhao.Acelerar(50);
        caminhao.ExibirVelocidade();
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 4: Polimorfismo com Veículos
    /// </summary>
    public static void ExemploPolimorfismoVeiculos()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 4: Polimorfismo com Lista de Veículos     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Lista de veículos (classe base) contendo diferentes tipos
        List<Veiculo> veiculos = new List<Veiculo>
        {
            new Carro("Ford", "Fiesta", 2020, "Azul", 4, "Gasolina"),
            new Moto("Yamaha", "MT-07", 2021, "Preta", 700, true),
            new Caminhao("Mercedes", "Actros", 2019, "Branco", 30m, 7),
            new Carro("Chevrolet", "Onix", 2022, "Vermelho", 4, "Flex"),
            new Moto("Kawasaki", "Ninja 400", 2023, "Verde", 400, true)
        };

        Console.WriteLine("🚦 SIMULAÇÃO DE TRÂNSITO\n");
        Console.WriteLine("Todos os veículos vão acelerar e buzinar:\n");

        foreach (var veiculo in veiculos)
        {
            Console.WriteLine($"\n{veiculo.ObterTipo()}: {veiculo.Marca} {veiculo.Modelo}");
            veiculo.Buzinar();
            veiculo.Acelerar(40);
            veiculo.ExibirVelocidade();
        }

        Console.WriteLine("\n\n--- ESTATÍSTICAS DA FROTA ---\n");
        var totalCarros = veiculos.OfType<Carro>().Count();
        var totalMotos = veiculos.OfType<Moto>().Count();
        var totalCaminhoes = veiculos.OfType<Caminhao>().Count();

        Console.WriteLine($"🚗 Carros: {totalCarros}");
        Console.WriteLine($"🏍️  Motos: {totalMotos}");
        Console.WriteLine($"🚚 Caminhões: {totalCaminhoes}");
        Console.WriteLine($"📊 Total: {veiculos.Count} veículos");
    }

    /// <summary>
    /// Exemplo 5: Demonstrando uso de 'base' e chamadas à classe pai
    /// </summary>
    public static void ExemploUsoDaClasseBase()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║    EXEMPLO 5: Palavra-chave 'base' e Herança        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("💡 Demonstração de como classes derivadas podem:");
        Console.WriteLine("   • Chamar construtores da classe base (base(...))");
        Console.WriteLine("   • Usar métodos da classe base (base.Metodo())");
        Console.WriteLine("   • Estender comportamento sem reescrever tudo\n");

        var dev = new Desenvolvedor("Ricardo Moura", "777.777.777-77", 5000m, "C#", "Senior");
        dev.ProjetosCompletos = 8;

        Console.WriteLine("Quando criamos um Desenvolvedor:");
        Console.WriteLine("1. O construtor chama 'base(nome, cpf, salarioBase)'");
        Console.WriteLine("2. Isso inicializa as propriedades da classe Funcionario");
        Console.WriteLine("3. Depois adiciona as propriedades específicas\n");

        dev.ExibirInformacoes();

        Console.WriteLine("\n📋 Propriedades herdadas de Funcionario:");
        Console.WriteLine($"   • Nome: {dev.Nome}");
        Console.WriteLine($"   • CPF: {dev.CPF}");
        Console.WriteLine($"   • DataAdmissao: {dev.DataAdmissao:dd/MM/yyyy}");
        Console.WriteLine($"   • SalarioBase: R$ {dev.SalarioBase:F2}");
        Console.WriteLine($"   • TempoEmpresa: {dev.TempoEmpresa} ano(s)");

        Console.WriteLine("\n🔧 Propriedades específicas de Desenvolvedor:");
        Console.WriteLine($"   • Linguagem: {dev.Linguagem}");
        Console.WriteLine($"   • Nivel: {dev.Nivel}");
        Console.WriteLine($"   • ProjetosCompletos: {dev.ProjetosCompletos}");

        Console.WriteLine("\n⚙️  Métodos sobrescritos (override):");
        Console.WriteLine($"   • CalcularSalario(): R$ {dev.CalcularSalario():F2}");
        Console.WriteLine($"   • CalcularBonus(): R$ {dev.CalcularBonus():F2}");
    }
}
