namespace MindSetCSharp.Core.Objetos;

/// <summary>
/// Exemplo de classe ContaBancaria demonstrando estado e comportamento.
/// Mostra como objetos mantêm estado (saldo) e possuem comportamentos (sacar, depositar).
/// </summary>
public class ContaBancaria
{
    // Campos privados (estado interno)
    private decimal saldo;
    private readonly string numeroConta;

    // Propriedades
    public string Titular { get; set; }
    public string NumeroConta => numeroConta; // Propriedade somente leitura
    public decimal Saldo => saldo; // Exposição controlada do saldo

    // Construtor
    public ContaBancaria(string titular, string numeroConta, decimal saldoInicial = 0)
    {
        Titular = titular;
        this.numeroConta = numeroConta;
        saldo = saldoInicial;
    }

    // Método para depositar
    public bool Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("❌ Erro: Valor de depósito deve ser positivo.");
            return false;
        }

        saldo += valor;
        Console.WriteLine($"✅ Depósito de R$ {valor:F2} realizado com sucesso!");
        Console.WriteLine($"   Novo saldo: R$ {saldo:F2}");
        return true;
    }

    // Método para sacar
    public bool Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("❌ Erro: Valor de saque deve ser positivo.");
            return false;
        }

        if (valor > saldo)
        {
            Console.WriteLine($"❌ Erro: Saldo insuficiente. Saldo disponível: R$ {saldo:F2}");
            return false;
        }

        saldo -= valor;
        Console.WriteLine($"✅ Saque de R$ {valor:F2} realizado com sucesso!");
        Console.WriteLine($"   Novo saldo: R$ {saldo:F2}");
        return true;
    }

    // Método para transferir
    public bool Transferir(ContaBancaria contaDestino, decimal valor)
    {
        if (contaDestino == null)
        {
            Console.WriteLine("❌ Erro: Conta de destino inválida.");
            return false;
        }

        Console.WriteLine($"\n🔄 Iniciando transferência de R$ {valor:F2}...");
        
        if (Sacar(valor))
        {
            contaDestino.Depositar(valor);
            Console.WriteLine($"✅ Transferência concluída para {contaDestino.Titular}!");
            return true;
        }

        return false;
    }

    // Método para exibir extrato
    public void ExibirExtrato()
    {
        Console.WriteLine("\n════════════════════════════════");
        Console.WriteLine("        EXTRATO BANCÁRIO         ");
        Console.WriteLine("════════════════════════════════");
        Console.WriteLine($"Conta: {numeroConta}");
        Console.WriteLine($"Titular: {Titular}");
        Console.WriteLine($"Saldo Atual: R$ {saldo:F2}");
        Console.WriteLine("════════════════════════════════\n");
    }
}
