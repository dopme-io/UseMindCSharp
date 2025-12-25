namespace MindSetCSharp.Core.Encapsulamento;

/// <summary>
/// Classe demonstrando encapsulamento RUIM (sem proteção de dados).
/// Exemplo de como NÃO fazer - todos os campos são públicos.
/// </summary>
public class ContaBancariaSemEncapsulamento
{
    // ❌ RUIM: Campos públicos permitem acesso direto sem controle
    public string Titular;
    public decimal Saldo;
    public string NumeroConta;

    public ContaBancariaSemEncapsulamento(string titular, string numeroConta, decimal saldoInicial)
    {
        Titular = titular;
        NumeroConta = numeroConta;
        Saldo = saldoInicial;
    }
}

/// <summary>
/// Classe demonstrando encapsulamento BOM (proteção adequada).
/// Exemplo de como fazer corretamente - dados protegidos, acesso controlado.
/// </summary>
public class ContaBancariaComEncapsulamento
{
    // ✅ BOM: Campos privados protegem os dados
    private decimal _saldo;
    private readonly string _numeroConta;
    private readonly DateTime _dataCriacao;
    private readonly List<string> _historicoTransacoes;

    // Propriedades públicas controlam o acesso
    public string Titular { get; set; }
    
    // Propriedade somente leitura (get apenas)
    public string NumeroConta => _numeroConta;
    
    // Propriedade somente leitura calculada
    public decimal Saldo => _saldo;
    
    public DateTime DataCriacao => _dataCriacao;
    
    // Exposição somente leitura da coleção
    public IReadOnlyList<string> HistoricoTransacoes => _historicoTransacoes.AsReadOnly();

    // Construtor
    public ContaBancariaComEncapsulamento(string titular, string numeroConta, decimal saldoInicial)
    {
        Titular = titular;
        _numeroConta = numeroConta;
        _saldo = saldoInicial;
        _dataCriacao = DateTime.Now;
        _historicoTransacoes = new List<string>();
        
        RegistrarTransacao($"Conta criada com saldo inicial de R$ {saldoInicial:F2}");
    }

    // ✅ Métodos públicos controlam como o saldo pode ser modificado
    public bool Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("❌ Erro: Valor de depósito deve ser positivo.");
            return false;
        }

        _saldo += valor;
        RegistrarTransacao($"Depósito: +R$ {valor:F2} | Saldo: R$ {_saldo:F2}");
        Console.WriteLine($"✅ Depósito de R$ {valor:F2} realizado com sucesso!");
        return true;
    }

    public bool Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("❌ Erro: Valor de saque deve ser positivo.");
            return false;
        }

        if (valor > _saldo)
        {
            Console.WriteLine($"❌ Erro: Saldo insuficiente. Disponível: R$ {_saldo:F2}");
            return false;
        }

        _saldo -= valor;
        RegistrarTransacao($"Saque: -R$ {valor:F2} | Saldo: R$ {_saldo:F2}");
        Console.WriteLine($"✅ Saque de R$ {valor:F2} realizado com sucesso!");
        return true;
    }

    // Método privado - só pode ser chamado internamente
    private void RegistrarTransacao(string descricao)
    {
        var registro = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] {descricao}";
        _historicoTransacoes.Add(registro);
    }

    public void ExibirExtrato()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine($"║  EXTRATO BANCÁRIO - Conta: {_numeroConta}");
        Console.WriteLine("╠═══════════════════════════════════════════════════════╣");
        Console.WriteLine($"  Titular: {Titular}");
        Console.WriteLine($"  Data de Criação: {_dataCriacao:dd/MM/yyyy}");
        Console.WriteLine($"  Saldo Atual: R$ {_saldo:F2}");
        Console.WriteLine("├───────────────────────────────────────────────────────┤");
        Console.WriteLine("  HISTÓRICO DE TRANSAÇÕES:");
        
        if (_historicoTransacoes.Count == 0)
        {
            Console.WriteLine("    (Nenhuma transação)");
        }
        else
        {
            foreach (var transacao in _historicoTransacoes)
            {
                Console.WriteLine($"    {transacao}");
            }
        }
        
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
    }
}

/// <summary>
/// Demonstra a diferença entre encapsulamento bom e ruim.
/// </summary>
public static class ComparacaoEncapsulamento
{
    public static void DemonstrarDiferenca()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   COMPARAÇÃO: Com e Sem Encapsulamento              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // ❌ SEM ENCAPSULAMENTO
        Console.WriteLine("❌ SEM ENCAPSULAMENTO (Ruim):\n");
        var contaRuim = new ContaBancariaSemEncapsulamento("João", "12345", 1000m);
        
        Console.WriteLine($"Saldo inicial: R$ {contaRuim.Saldo:F2}");
        
        // Problema: Qualquer um pode modificar diretamente!
        contaRuim.Saldo = -500m;  // ⚠️ Saldo negativo sem controle!
        Console.WriteLine($"⚠️  Alguém alterou diretamente: R$ {contaRuim.Saldo:F2}");
        
        contaRuim.Saldo = 999999m;  // ⚠️ Valor absurdo sem validação!
        Console.WriteLine($"⚠️  Alguém colocou valor absurdo: R$ {contaRuim.Saldo:F2}");
        
        Console.WriteLine("\n❗ Problemas:");
        Console.WriteLine("   • Sem validação de valores");
        Console.WriteLine("   • Sem controle de acesso");
        Console.WriteLine("   • Sem histórico de alterações");
        Console.WriteLine("   • Dados vulneráveis a modificações incorretas");

        // ✅ COM ENCAPSULAMENTO
        Console.WriteLine("\n\n✅ COM ENCAPSULAMENTO (Bom):\n");
        var contaBoa = new ContaBancariaComEncapsulamento("Maria", "54321", 1000m);
        
        Console.WriteLine($"Saldo inicial: R$ {contaBoa.Saldo:F2}");
        
        // Tentativas controladas
        contaBoa.Depositar(500m);
        contaBoa.Sacar(200m);
        contaBoa.Sacar(2000m); // Vai falhar - saldo insuficiente
        
        // Não podemos modificar diretamente o saldo!
        // contaBoa.Saldo = -500m;  // ❌ ERRO DE COMPILAÇÃO - não tem setter!
        // contaBoa._saldo = 999999m;  // ❌ ERRO DE COMPILAÇÃO - campo privado!
        
        Console.WriteLine("\n✅ Vantagens:");
        Console.WriteLine("   • Validação automática");
        Console.WriteLine("   • Controle total sobre modificações");
        Console.WriteLine("   • Histórico de transações");
        Console.WriteLine("   • Dados protegidos contra alterações indevidas");
        
        contaBoa.ExibirExtrato();
    }
}
