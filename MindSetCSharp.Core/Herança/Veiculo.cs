namespace MindSetCSharp.Core.Heranca;

/// <summary>
/// Classe abstrata - não pode ser instanciada diretamente.
/// Serve como template para classes derivadas.
/// </summary>
public abstract class Veiculo
{
    // Propriedades comuns a todos os veículos
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }
    protected decimal VelocidadeAtual { get; set; }

    // Construtor
    protected Veiculo(string marca, string modelo, int ano, string cor)
    {
        Marca = marca;
        Modelo = modelo;
        Ano = ano;
        Cor = cor;
        VelocidadeAtual = 0;
    }

    // Método abstrato - DEVE ser implementado nas classes derivadas
    public abstract void Acelerar(decimal incremento);

    // Método abstrato
    public abstract void Frear(decimal decremento);

    // Método abstrato
    public abstract string ObterTipo();

    // Método virtual - pode ser sobrescrito (mas tem implementação padrão)
    public virtual void Buzinar()
    {
        Console.WriteLine("🔊 Beep beep!");
    }

    // Método concreto - não pode ser sobrescrito
    public void ExibirVelocidade()
    {
        Console.WriteLine($"Velocidade atual: {VelocidadeAtual:F1} km/h");
    }

    public virtual void ExibirInformacoes()
    {
        Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        Console.WriteLine($"🚗 {ObterTipo()}");
        Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Ano: {Ano}");
        Console.WriteLine($"Cor: {Cor}");
        Console.WriteLine($"Velocidade: {VelocidadeAtual:F1} km/h");
        Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    }
}

/// <summary>
/// Classe derivada de Veiculo - implementa métodos abstratos.
/// </summary>
public class Carro : Veiculo
{
    public int NumeroPortas { get; set; }
    public string TipoCombustivel { get; set; }
    private const decimal VelocidadeMaxima = 220m;

    public Carro(string marca, string modelo, int ano, string cor, int numeroPortas, string tipoCombustivel)
        : base(marca, modelo, ano, cor)
    {
        NumeroPortas = numeroPortas;
        TipoCombustivel = tipoCombustivel;
    }

    // Implementação obrigatória do método abstrato
    public override void Acelerar(decimal incremento)
    {
        VelocidadeAtual += incremento;
        
        if (VelocidadeAtual > VelocidadeMaxima)
        {
            VelocidadeAtual = VelocidadeMaxima;
            Console.WriteLine($"⚠️  Velocidade máxima atingida! ({VelocidadeMaxima} km/h)");
        }
        else
        {
            Console.WriteLine($"🚗 Acelerando... {VelocidadeAtual:F1} km/h");
        }
    }

    public override void Frear(decimal decremento)
    {
        VelocidadeAtual -= decremento;
        
        if (VelocidadeAtual < 0)
        {
            VelocidadeAtual = 0;
            Console.WriteLine("🛑 Carro parado.");
        }
        else
        {
            Console.WriteLine($"🚗 Freando... {VelocidadeAtual:F1} km/h");
        }
    }

    public override string ObterTipo()
    {
        return "Carro";
    }

    public override void ExibirInformacoes()
    {
        base.ExibirInformacoes();
        Console.WriteLine($"Portas: {NumeroPortas}");
        Console.WriteLine($"Combustível: {TipoCombustivel}");
        Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n");
    }
}

/// <summary>
/// Outra classe derivada de Veiculo.
/// </summary>
public class Moto : Veiculo
{
    public int Cilindradas { get; set; }
    public bool TemCarenagem { get; set; }
    private const decimal VelocidadeMaxima = 180m;

    public Moto(string marca, string modelo, int ano, string cor, int cilindradas, bool temCarenagem)
        : base(marca, modelo, ano, cor)
    {
        Cilindradas = cilindradas;
        TemCarenagem = temCarenagem;
    }

    public override void Acelerar(decimal incremento)
    {
        // Motos aceleram mais rápido
        VelocidadeAtual += incremento * 1.3m;
        
        if (VelocidadeAtual > VelocidadeMaxima)
        {
            VelocidadeAtual = VelocidadeMaxima;
            Console.WriteLine($"⚠️  Velocidade máxima atingida! ({VelocidadeMaxima} km/h)");
        }
        else
        {
            Console.WriteLine($"🏍️  Acelerando rapidamente... {VelocidadeAtual:F1} km/h");
        }
    }

    public override void Frear(decimal decremento)
    {
        VelocidadeAtual -= decremento * 1.2m; // Freios mais eficientes
        
        if (VelocidadeAtual < 0)
        {
            VelocidadeAtual = 0;
            Console.WriteLine("🛑 Moto parada.");
        }
        else
        {
            Console.WriteLine($"🏍️  Freando... {VelocidadeAtual:F1} km/h");
        }
    }

    public override string ObterTipo()
    {
        return "Motocicleta";
    }

    // Override da buzina
    public override void Buzinar()
    {
        Console.WriteLine("🔊 Beep! (som de moto)");
    }

    public override void ExibirInformacoes()
    {
        base.ExibirInformacoes();
        Console.WriteLine($"Cilindradas: {Cilindradas}cc");
        Console.WriteLine($"Carenagem: {(TemCarenagem ? "Sim" : "Não")}");
        Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n");
    }

    public void Empinar()
    {
        if (VelocidadeAtual > 0 && VelocidadeAtual < 50)
        {
            Console.WriteLine("🏍️  Empinando a moto! 🤘");
        }
        else if (VelocidadeAtual == 0)
        {
            Console.WriteLine("⚠️  Moto parada. Não é possível empinar.");
        }
        else
        {
            Console.WriteLine("⚠️  Velocidade muito alta para empinar com segurança!");
        }
    }
}

/// <summary>
/// Classe derivada de Veiculo.
/// </summary>
public class Caminhao : Veiculo
{
    public decimal CapacidadeCarga { get; set; } // Em toneladas
    public int NumeroEixos { get; set; }
    private const decimal VelocidadeMaxima = 120m;

    public Caminhao(string marca, string modelo, int ano, string cor, decimal capacidadeCarga, int numeroEixos)
        : base(marca, modelo, ano, cor)
    {
        CapacidadeCarga = capacidadeCarga;
        NumeroEixos = numeroEixos;
    }

    public override void Acelerar(decimal incremento)
    {
        // Caminhões aceleram mais devagar
        VelocidadeAtual += incremento * 0.6m;
        
        if (VelocidadeAtual > VelocidadeMaxima)
        {
            VelocidadeAtual = VelocidadeMaxima;
            Console.WriteLine($"⚠️  Velocidade máxima atingida! ({VelocidadeMaxima} km/h)");
        }
        else
        {
            Console.WriteLine($"🚚 Acelerando lentamente... {VelocidadeAtual:F1} km/h");
        }
    }

    public override void Frear(decimal decremento)
    {
        // Caminhões precisam de mais distância para frear
        VelocidadeAtual -= decremento * 0.7m;
        
        if (VelocidadeAtual < 0)
        {
            VelocidadeAtual = 0;
            Console.WriteLine("🛑 Caminhão parado.");
        }
        else
        {
            Console.WriteLine($"🚚 Freando... {VelocidadeAtual:F1} km/h");
        }
    }

    public override string ObterTipo()
    {
        return "Caminhão";
    }

    public override void Buzinar()
    {
        Console.WriteLine("🔊 HONK HONK! (buzina grave de caminhão)");
    }

    public override void ExibirInformacoes()
    {
        base.ExibirInformacoes();
        Console.WriteLine($"Capacidade de Carga: {CapacidadeCarga} toneladas");
        Console.WriteLine($"Número de Eixos: {NumeroEixos}");
        Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n");
    }

    public void Carregar(decimal carga)
    {
        if (carga <= CapacidadeCarga)
        {
            Console.WriteLine($"✅ Carga de {carga}t carregada com sucesso!");
        }
        else
        {
            Console.WriteLine($"❌ Carga excede capacidade máxima de {CapacidadeCarga}t!");
        }
    }
}
