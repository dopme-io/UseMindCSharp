namespace MindSetCSharp.Core.Objetos;

/// <summary>
/// Exemplo básico de classe representando uma Pessoa.
/// Demonstra os conceitos fundamentais de POO: propriedades, métodos e construtores.
/// </summary>
public class Pessoa
{
    // Propriedades auto-implementadas
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }

    // Construtor padrão
    public Pessoa()
    {
        Nome = "Sem Nome";
        Idade = 0;
        Email = string.Empty;
    }

    // Construtor com parâmetros
    public Pessoa(string nome, int idade, string email)
    {
        Nome = nome;
        Idade = idade;
        Email = email;
    }

    // Construtor alternativo (sobrecarga)
    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
        Email = string.Empty;
    }

    // Método de instância
    public void ApresentarSe()
    {
        Console.WriteLine($"Olá! Meu nome é {Nome}, tenho {Idade} anos.");
        if (!string.IsNullOrEmpty(Email))
        {
            Console.WriteLine($"Meu e-mail é: {Email}");
        }
    }

    // Método para fazer aniversário
    public void FazerAniversario()
    {
        Idade++;
        Console.WriteLine($"{Nome} fez aniversário! Agora tem {Idade} anos.");
    }

    // Método que retorna valor booleano
    public bool EhMaiorDeIdade()
    {
        return Idade >= 18;
    }

    // Override do método ToString para representação textual
    public override string ToString()
    {
        return $"Pessoa: {Nome}, {Idade} anos, E-mail: {(string.IsNullOrEmpty(Email) ? "Não informado" : Email)}";
    }
}
