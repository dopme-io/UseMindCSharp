namespace MindSetCSharp.Core.Encapsulamento;

/// <summary>
/// Classe demonstrando diferentes níveis de acesso e encapsulamento.
/// </summary>
public class Pessoa
{
    // Campo privado - só acessível dentro desta classe
    private string _cpf = string.Empty;
    private DateTime _dataNascimento;
    
    // Campo protected - acessível nesta classe e classes derivadas
    protected decimal _rendaMensal;
    
    // Campo interno (internal) - acessível apenas neste assembly
    internal string _codigoInterno = string.Empty;

    // Propriedade pública com validação
    public string Nome { get; set; } = string.Empty;

    // Propriedade com get público e set privado
    public string CPF 
    { 
        get => FormatarCPF(_cpf);
        private set => _cpf = LimparCPF(value);
    }

    // Propriedade somente leitura (init apenas no construtor)
    public int Id { get; init; }

    // Propriedade calculada (somente get)
    public int Idade
    {
        get
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - _dataNascimento.Year;
            if (_dataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }
    }

    // Propriedade com validação no setter
    public DateTime DataNascimento
    {
        get => _dataNascimento;
        set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Data de nascimento não pode ser futura.");
            
            if (value < new DateTime(1900, 1, 1))
                throw new ArgumentException("Data de nascimento inválida.");
            
            _dataNascimento = value;
        }
    }

    // Propriedade com lógica de encapsulamento
    public string Email { get; set; } = string.Empty;
    
    public bool EmailVerificado { get; private set; }

    // Contador estático privado
    private static int _proximoId = 1;

    // Construtor
    public Pessoa(string nome, string cpf, DateTime dataNascimento)
    {
        Id = _proximoId++;
        Nome = nome;
        CPF = cpf; // Usa o setter privado
        DataNascimento = dataNascimento;
    }

    // Método público que usa método privado
    public void DefinirCPF(string cpf)
    {
        if (ValidarCPF(cpf))
        {
            _cpf = LimparCPF(cpf);
            Console.WriteLine($"✅ CPF definido com sucesso: {FormatarCPF(_cpf)}");
        }
        else
        {
            Console.WriteLine("❌ CPF inválido!");
        }
    }

    // Método público para verificar email
    public void VerificarEmail(string codigo)
    {
        // Simulação de verificação
        if (codigo == "123456")
        {
            EmailVerificado = true;
            Console.WriteLine("✅ E-mail verificado com sucesso!");
        }
        else
        {
            Console.WriteLine("❌ Código de verificação inválido.");
        }
    }

    // Método privado - encapsula lógica de validação
    private bool ValidarCPF(string cpf)
    {
        var cpfLimpo = LimparCPF(cpf);
        return cpfLimpo.Length == 11 && cpfLimpo.All(char.IsDigit);
    }

    // Método privado - encapsula formatação
    private string FormatarCPF(string cpf)
    {
        if (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
            return cpf;
        
        return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
    }

    // Método privado - encapsula limpeza
    private string LimparCPF(string cpf)
    {
        return new string(cpf.Where(char.IsDigit).ToArray());
    }

    // Método protected - pode ser usado por classes derivadas
    protected virtual decimal CalcularImpostoRenda()
    {
        if (_rendaMensal < 1903.98m) return 0;
        if (_rendaMensal < 2826.65m) return _rendaMensal * 0.075m;
        if (_rendaMensal < 3751.05m) return _rendaMensal * 0.15m;
        if (_rendaMensal < 4664.68m) return _rendaMensal * 0.225m;
        return _rendaMensal * 0.275m;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine("\n╔════════════════════════════════════════════╗");
        Console.WriteLine($"  ID: {Id}");
        Console.WriteLine($"  Nome: {Nome}");
        Console.WriteLine($"  CPF: {CPF}");
        Console.WriteLine($"  Data Nascimento: {_dataNascimento:dd/MM/yyyy}");
        Console.WriteLine($"  Idade: {Idade} anos");
        Console.WriteLine($"  Email: {Email} {(EmailVerificado ? "✅" : "❌")}");
        Console.WriteLine("╚════════════════════════════════════════════╝");
    }
}

/// <summary>
/// Classe derivada demonstrando acesso a membros protected.
/// </summary>
public class PessoaFisica : Pessoa
{
    private string _profissao = string.Empty;

    public string Profissao
    {
        get => _profissao;
        set => _profissao = value;
    }

    public PessoaFisica(string nome, string cpf, DateTime dataNascimento, string profissao)
        : base(nome, cpf, dataNascimento)
    {
        _profissao = profissao;
    }

    // Pode acessar membros protected da classe base
    public void DefinirRenda(decimal renda)
    {
        if (renda < 0)
        {
            Console.WriteLine("❌ Renda não pode ser negativa.");
            return;
        }

        _rendaMensal = renda; // Acessa campo protected da classe base
        Console.WriteLine($"✅ Renda mensal definida: R$ {_rendaMensal:F2}");
    }

    // Pode chamar métodos protected
    public void ExibirImpostos()
    {
        var imposto = CalcularImpostoRenda(); // Método protected da classe base
        Console.WriteLine($"\n💰 Renda Mensal: R$ {_rendaMensal:F2}");
        Console.WriteLine($"💸 Imposto de Renda: R$ {imposto:F2}");
        Console.WriteLine($"💵 Renda Líquida: R$ {(_rendaMensal - imposto):F2}");
    }

    public new void ExibirInformacoes()
    {
        base.ExibirInformacoes();
        Console.WriteLine($"  Profissão: {_profissao}");
        Console.WriteLine($"  Renda Mensal: R$ {_rendaMensal:F2}");
    }
}
