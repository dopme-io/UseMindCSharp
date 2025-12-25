namespace MindSetCSharp.Core.Heranca;

/// <summary>
/// Classe base (superclasse) representando um Funcionário genérico.
/// Demonstra membros que serão herdados por classes derivadas.
/// </summary>
public class Funcionario
{
    // Propriedades herdadas por todas as classes derivadas
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataAdmissao { get; set; }
    public decimal SalarioBase { get; set; }

    // Propriedade calculada
    public int TempoEmpresa
    {
        get
        {
            var tempo = DateTime.Now - DataAdmissao;
            return (int)(tempo.Days / 365.25);
        }
    }

    // Construtor
    public Funcionario(string nome, string cpf, decimal salarioBase)
    {
        Nome = nome;
        CPF = cpf;
        SalarioBase = salarioBase;
        DataAdmissao = DateTime.Now;
    }

    // Método virtual - pode ser sobrescrito (override) nas classes derivadas
    public virtual decimal CalcularSalario()
    {
        return SalarioBase;
    }

    // Método virtual para bônus
    public virtual decimal CalcularBonus()
    {
        // Bônus padrão: 5% do salário base
        return SalarioBase * 0.05m;
    }

    // Método virtual para exibir informações
    public virtual void ExibirInformacoes()
    {
        Console.WriteLine($"╔════════════════════════════════════════════╗");
        Console.WriteLine($"  Funcionário: {Nome}");
        Console.WriteLine($"  CPF: {CPF}");
        Console.WriteLine($"  Data Admissão: {DataAdmissao:dd/MM/yyyy}");
        Console.WriteLine($"  Tempo de Empresa: {TempoEmpresa} ano(s)");
        Console.WriteLine($"  Salário Base: R$ {SalarioBase:F2}");
        Console.WriteLine($"  Salário Total: R$ {CalcularSalario():F2}");
        Console.WriteLine($"  Bônus: R$ {CalcularBonus():F2}");
        Console.WriteLine($"╚════════════════════════════════════════════╝");
    }

    public override string ToString()
    {
        return $"{Nome} - R$ {CalcularSalario():F2}";
    }
}

/// <summary>
/// Classe derivada (subclasse) - Gerente herda de Funcionario.
/// Adiciona novos membros e sobrescreve comportamentos.
/// </summary>
public class Gerente : Funcionario
{
    // Propriedades específicas do Gerente
    public string Departamento { get; set; }
    public int NumeroSubordinados { get; set; }

    // Construtor - usa 'base' para chamar construtor da classe pai
    public Gerente(string nome, string cpf, decimal salarioBase, string departamento)
        : base(nome, cpf, salarioBase)
    {
        Departamento = departamento;
        NumeroSubordinados = 0;
    }

    // Override - substitui o método da classe base
    public override decimal CalcularSalario()
    {
        // Gerente ganha 50% a mais que o salário base
        return SalarioBase * 1.5m;
    }

    // Override do bônus
    public override decimal CalcularBonus()
    {
        // Gerente recebe 15% do salário base + R$ 100 por subordinado
        return (SalarioBase * 0.15m) + (NumeroSubordinados * 100m);
    }

    // Override para adicionar informações específicas
    public override void ExibirInformacoes()
    {
        Console.WriteLine($"╔════════════════════════════════════════════╗");
        Console.WriteLine($"  👔 GERENTE: {Nome}");
        Console.WriteLine($"  CPF: {CPF}");
        Console.WriteLine($"  Departamento: {Departamento}");
        Console.WriteLine($"  Subordinados: {NumeroSubordinados}");
        Console.WriteLine($"  Data Admissão: {DataAdmissao:dd/MM/yyyy}");
        Console.WriteLine($"  Tempo de Empresa: {TempoEmpresa} ano(s)");
        Console.WriteLine($"  Salário Base: R$ {SalarioBase:F2}");
        Console.WriteLine($"  Salário Total: R$ {CalcularSalario():F2}");
        Console.WriteLine($"  Bônus: R$ {CalcularBonus():F2}");
        Console.WriteLine($"╚════════════════════════════════════════════╝");
    }

    // Método específico do Gerente
    public void AdicionarSubordinado()
    {
        NumeroSubordinados++;
        Console.WriteLine($"✅ Subordinado adicionado. Total: {NumeroSubordinados}");
    }
}

/// <summary>
/// Classe derivada - Desenvolvedor herda de Funcionario.
/// </summary>
public class Desenvolvedor : Funcionario
{
    // Propriedades específicas
    public string Linguagem { get; set; }
    public string Nivel { get; set; } // Junior, Pleno, Senior
    public int ProjetosCompletos { get; set; }

    public Desenvolvedor(string nome, string cpf, decimal salarioBase, string linguagem, string nivel)
        : base(nome, cpf, salarioBase)
    {
        Linguagem = linguagem;
        Nivel = nivel;
        ProjetosCompletos = 0;
    }

    // Override do cálculo de salário baseado no nível
    public override decimal CalcularSalario()
    {
        decimal multiplicador = Nivel switch
        {
            "Junior" => 1.0m,
            "Pleno" => 1.3m,
            "Senior" => 1.6m,
            _ => 1.0m
        };

        return SalarioBase * multiplicador;
    }

    // Override do bônus baseado em projetos
    public override decimal CalcularBonus()
    {
        // 10% do salário base + R$ 500 por projeto completo
        return (SalarioBase * 0.10m) + (ProjetosCompletos * 500m);
    }

    public override void ExibirInformacoes()
    {
        Console.WriteLine($"╔════════════════════════════════════════════╗");
        Console.WriteLine($"  💻 DESENVOLVEDOR: {Nome}");
        Console.WriteLine($"  CPF: {CPF}");
        Console.WriteLine($"  Linguagem: {Linguagem}");
        Console.WriteLine($"  Nível: {Nivel}");
        Console.WriteLine($"  Projetos Completos: {ProjetosCompletos}");
        Console.WriteLine($"  Data Admissão: {DataAdmissao:dd/MM/yyyy}");
        Console.WriteLine($"  Tempo de Empresa: {TempoEmpresa} ano(s)");
        Console.WriteLine($"  Salário Base: R$ {SalarioBase:F2}");
        Console.WriteLine($"  Salário Total: R$ {CalcularSalario():F2}");
        Console.WriteLine($"  Bônus: R$ {CalcularBonus():F2}");
        Console.WriteLine($"╚════════════════════════════════════════════╝");
    }

    public void CompletarProjeto()
    {
        ProjetosCompletos++;
        Console.WriteLine($"✅ Projeto completo! Total: {ProjetosCompletos}");
    }
}

/// <summary>
/// Classe derivada - Estagiario herda de Funcionario.
/// </summary>
public class Estagiario : Funcionario
{
    public string Curso { get; set; }
    public string Universidade { get; set; }
    public DateTime DataTermino { get; set; }

    public Estagiario(string nome, string cpf, decimal salarioBase, string curso, string universidade)
        : base(nome, cpf, salarioBase)
    {
        Curso = curso;
        Universidade = universidade;
        DataTermino = DateTime.Now.AddMonths(6); // Estágio de 6 meses
    }

    // Estagiário não recebe multiplicadores
    public override decimal CalcularSalario()
    {
        return SalarioBase; // Recebe apenas o salário base
    }

    // Estagiário recebe bônus menor
    public override decimal CalcularBonus()
    {
        return SalarioBase * 0.03m; // 3% apenas
    }

    public override void ExibirInformacoes()
    {
        Console.WriteLine($"╔════════════════════════════════════════════╗");
        Console.WriteLine($"  🎓 ESTAGIÁRIO: {Nome}");
        Console.WriteLine($"  CPF: {CPF}");
        Console.WriteLine($"  Curso: {Curso}");
        Console.WriteLine($"  Universidade: {Universidade}");
        Console.WriteLine($"  Data Admissão: {DataAdmissao:dd/MM/yyyy}");
        Console.WriteLine($"  Data Término: {DataTermino:dd/MM/yyyy}");
        Console.WriteLine($"  Salário: R$ {SalarioBase:F2}");
        Console.WriteLine($"  Bônus: R$ {CalcularBonus():F2}");
        Console.WriteLine($"╚════════════════════════════════════════════╝");
    }

    public void VerificarTermino()
    {
        var diasRestantes = (DataTermino - DateTime.Now).Days;
        if (diasRestantes > 0)
        {
            Console.WriteLine($"⏳ Faltam {diasRestantes} dias para o término do estágio.");
        }
        else
        {
            Console.WriteLine($"✅ Estágio concluído!");
        }
    }
}
