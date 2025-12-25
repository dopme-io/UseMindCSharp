namespace MindSetCSharp.Core.Classes;

/// <summary>
/// Classe Cliente demonstrando diferentes tipos de propriedades e validações.
/// Mostra como criar classes para modelar entidades de domínio.
/// </summary>
public class Cliente
{
    // Campos privados
    private string _cpf = string.Empty;
    private DateTime _dataNascimento;
    private List<string> _telefones;

    // Propriedades
    public int Id { get; private set; } // Somente leitura externamente
    public string Nome { get; set; } = string.Empty;
    
    public string CPF
    {
        get => _cpf;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CPF não pode ser vazio.");
            
            // Remove caracteres especiais
            _cpf = new string(value.Where(char.IsDigit).ToArray());
            
            if (_cpf.Length != 11)
                throw new ArgumentException("CPF deve conter 11 dígitos.");
        }
    }

    public string Email { get; set; } = string.Empty;

    public DateTime DataNascimento
    {
        get => _dataNascimento;
        set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Data de nascimento não pode ser futura.");
            _dataNascimento = value;
        }
    }

    // Propriedade calculada - Idade
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

    // Propriedade somente leitura
    public DateTime DataCadastro { get; }

    // Propriedade com coleção
    public IReadOnlyList<string> Telefones => _telefones.AsReadOnly();

    // Propriedade indicadora
    public bool Ativo { get; set; }

    // Contador estático
    private static int _proximoId = 1;

    // Construtores
    public Cliente()
    {
        Id = _proximoId++;
        _telefones = new List<string>();
        DataCadastro = DateTime.Now;
        Ativo = true;
    }

    public Cliente(string nome, string cpf, DateTime dataNascimento, string email) : this()
    {
        Nome = nome;
        CPF = cpf;
        DataNascimento = dataNascimento;
        Email = email;
    }

    // Métodos
    public void AdicionarTelefone(string telefone)
    {
        if (string.IsNullOrWhiteSpace(telefone))
        {
            Console.WriteLine("❌ Telefone inválido.");
            return;
        }

        // Remove caracteres especiais
        string telefoneFormatado = new string(telefone.Where(char.IsDigit).ToArray());

        if (telefoneFormatado.Length < 10 || telefoneFormatado.Length > 11)
        {
            Console.WriteLine("❌ Telefone deve ter 10 ou 11 dígitos.");
            return;
        }

        if (_telefones.Contains(telefoneFormatado))
        {
            Console.WriteLine("⚠️  Telefone já cadastrado.");
            return;
        }

        _telefones.Add(telefoneFormatado);
        Console.WriteLine($"✅ Telefone {FormatarTelefone(telefoneFormatado)} adicionado.");
    }

    public void RemoverTelefone(string telefone)
    {
        string telefoneFormatado = new string(telefone.Where(char.IsDigit).ToArray());
        
        if (_telefones.Remove(telefoneFormatado))
        {
            Console.WriteLine($"✅ Telefone {FormatarTelefone(telefoneFormatado)} removido.");
        }
        else
        {
            Console.WriteLine("❌ Telefone não encontrado.");
        }
    }

    public void Desativar()
    {
        Ativo = false;
        Console.WriteLine($"🚫 Cliente {Nome} desativado.");
    }

    public void Ativar()
    {
        Ativo = true;
        Console.WriteLine($"✅ Cliente {Nome} ativado.");
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine("\n╔════════════════════════════════════════════╗");
        Console.WriteLine($"  ID: {Id}");
        Console.WriteLine($"  Nome: {Nome}");
        Console.WriteLine($"  CPF: {FormatarCPF(_cpf)}");
        Console.WriteLine($"  Email: {Email}");
        Console.WriteLine($"  Data Nascimento: {_dataNascimento:dd/MM/yyyy}");
        Console.WriteLine($"  Idade: {Idade} anos");
        Console.WriteLine($"  Data Cadastro: {DataCadastro:dd/MM/yyyy}");
        Console.WriteLine($"  Status: {(Ativo ? "✅ Ativo" : "🚫 Inativo")}");
        
        if (_telefones.Count > 0)
        {
            Console.WriteLine($"  Telefones:");
            foreach (var tel in _telefones)
            {
                Console.WriteLine($"    • {FormatarTelefone(tel)}");
            }
        }
        else
        {
            Console.WriteLine("  Telefones: Nenhum cadastrado");
        }
        
        Console.WriteLine("╚════════════════════════════════════════════╝");
    }

    // Métodos auxiliares privados
    private static string FormatarCPF(string cpf)
    {
        if (cpf.Length != 11) return cpf;
        return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
    }

    private static string FormatarTelefone(string telefone)
    {
        if (telefone.Length == 11)
            return $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 5)}-{telefone.Substring(7, 4)}";
        if (telefone.Length == 10)
            return $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 4)}-{telefone.Substring(6, 4)}";
        return telefone;
    }

    public override string ToString()
    {
        return $"Cliente #{Id}: {Nome} - {FormatarCPF(_cpf)} ({(Ativo ? "Ativo" : "Inativo")})";
    }
}
