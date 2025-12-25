namespace MindSetCSharp.Core.Interface;

/// <summary>
/// Interface para processamento de pagamentos
/// </summary>
public interface IProcessadorPagamento
{
    string NomeProcessador { get; }
    bool ProcessarPagamento(decimal valor, string dadosPagamento);
    bool ValidarDados(string dadosPagamento);
    decimal CalcularTaxa(decimal valor);
}

/// <summary>
/// Interface para reembolsos
/// </summary>
public interface IReembolsavel
{
    bool ProcessarReembolso(string transacaoId, decimal valor);
    bool ValidarReembolso(string transacaoId);
}

/// <summary>
/// Interface para parcelamento
/// </summary>
public interface IParcelavel
{
    decimal CalcularValorParcela(decimal valorTotal, int numeroParcelas);
    int MaximoParcelas { get; }
    bool AceitaParcelas(int numeroParcelas);
}

/// <summary>
/// Implementação para pagamento com cartão de crédito
/// </summary>
public class PagamentoCartaoCredito : IProcessadorPagamento, IReembolsavel, IParcelavel
{
    public string NomeProcessador => "Cartão de Crédito";
    public int MaximoParcelas => 12;

    public bool ProcessarPagamento(decimal valor, string dadosPagamento)
    {
        if (!ValidarDados(dadosPagamento))
        {
            Console.WriteLine($"❌ Dados de cartão inválidos");
            return false;
        }

        var taxa = CalcularTaxa(valor);
        var valorTotal = valor + taxa;

        Console.WriteLine($"💳 Processando pagamento com {NomeProcessador}:");
        Console.WriteLine($"   Valor: R$ {valor:F2}");
        Console.WriteLine($"   Taxa: R$ {taxa:F2}");
        Console.WriteLine($"   Total: R$ {valorTotal:F2}");
        Console.WriteLine($"   ✅ Pagamento aprovado!");

        return true;
    }

    public bool ValidarDados(string dadosPagamento)
    {
        // Simula validação de número de cartão (deve ter 16 dígitos)
        var numeros = new string(dadosPagamento.Where(char.IsDigit).ToArray());
        return numeros.Length == 16;
    }

    public decimal CalcularTaxa(decimal valor)
    {
        // Taxa de 2.5%
        return valor * 0.025m;
    }

    public bool ProcessarReembolso(string transacaoId, decimal valor)
    {
        if (!ValidarReembolso(transacaoId))
        {
            Console.WriteLine($"❌ Reembolso inválido para transação: {transacaoId}");
            return false;
        }

        Console.WriteLine($"↩️  Reembolso processado:");
        Console.WriteLine($"   Transação: {transacaoId}");
        Console.WriteLine($"   Valor: R$ {valor:F2}");
        Console.WriteLine($"   Estorno em até 2 dias úteis");

        return true;
    }

    public bool ValidarReembolso(string transacaoId)
    {
        return !string.IsNullOrWhiteSpace(transacaoId) && transacaoId.Length > 5;
    }

    public decimal CalcularValorParcela(decimal valorTotal, int numeroParcelas)
    {
        if (!AceitaParcelas(numeroParcelas))
        {
            return 0;
        }

        // Juros de 1.5% ao mês a partir de 3 parcelas
        var juros = numeroParcelas > 2 ? 1.015m : 1.0m;
        var valorComJuros = valorTotal * (decimal)Math.Pow((double)juros, numeroParcelas - 1);
        return valorComJuros / numeroParcelas;
    }

    public bool AceitaParcelas(int numeroParcelas)
    {
        return numeroParcelas >= 1 && numeroParcelas <= MaximoParcelas;
    }
}

/// <summary>
/// Implementação para PIX
/// </summary>
public class PagamentoPix : IProcessadorPagamento, IReembolsavel
{
    public string NomeProcessador => "PIX";

    public bool ProcessarPagamento(decimal valor, string dadosPagamento)
    {
        if (!ValidarDados(dadosPagamento))
        {
            Console.WriteLine($"❌ Chave PIX inválida");
            return false;
        }

        var taxa = CalcularTaxa(valor);
        var valorTotal = valor + taxa;

        Console.WriteLine($"⚡ Processando pagamento com {NomeProcessador}:");
        Console.WriteLine($"   Chave: {dadosPagamento}");
        Console.WriteLine($"   Valor: R$ {valor:F2}");
        Console.WriteLine($"   Taxa: R$ {taxa:F2}");
        Console.WriteLine($"   Total: R$ {valorTotal:F2}");
        Console.WriteLine($"   ✅ Pagamento instantâneo confirmado!");

        return true;
    }

    public bool ValidarDados(string dadosPagamento)
    {
        // Simula validação de chave PIX
        return !string.IsNullOrWhiteSpace(dadosPagamento) && 
               (dadosPagamento.Contains('@') || dadosPagamento.Length >= 11);
    }

    public decimal CalcularTaxa(decimal valor)
    {
        // PIX tem taxa menor - 0.5%
        return valor * 0.005m;
    }

    public bool ProcessarReembolso(string transacaoId, decimal valor)
    {
        Console.WriteLine($"↩️  Reembolso PIX instantâneo:");
        Console.WriteLine($"   Transação: {transacaoId}");
        Console.WriteLine($"   Valor: R$ {valor:F2}");
        Console.WriteLine($"   ✅ Reembolso concluído!");

        return true;
    }

    public bool ValidarReembolso(string transacaoId)
    {
        return !string.IsNullOrWhiteSpace(transacaoId);
    }
}

/// <summary>
/// Implementação para boleto bancário
/// </summary>
public class PagamentoBoleto : IProcessadorPagamento
{
    public string NomeProcessador => "Boleto Bancário";

    public bool ProcessarPagamento(decimal valor, string dadosPagamento)
    {
        if (!ValidarDados(dadosPagamento))
        {
            Console.WriteLine($"❌ CPF/CNPJ inválido");
            return false;
        }

        var taxa = CalcularTaxa(valor);
        var valorTotal = valor + taxa;

        Console.WriteLine($"🧾 Gerando boleto bancário:");
        Console.WriteLine($"   Pagador: {dadosPagamento}");
        Console.WriteLine($"   Valor: R$ {valor:F2}");
        Console.WriteLine($"   Taxa: R$ {taxa:F2}");
        Console.WriteLine($"   Total: R$ {valorTotal:F2}");
        Console.WriteLine($"   Vencimento: {DateTime.Now.AddDays(3):dd/MM/yyyy}");
        Console.WriteLine($"   ✅ Boleto gerado com sucesso!");

        return true;
    }

    public bool ValidarDados(string dadosPagamento)
    {
        var numeros = new string(dadosPagamento.Where(char.IsDigit).ToArray());
        return numeros.Length == 11 || numeros.Length == 14; // CPF ou CNPJ
    }

    public decimal CalcularTaxa(decimal valor)
    {
        // Taxa fixa de R$ 3,50
        return 3.50m;
    }
}

/// <summary>
/// Sistema de checkout que trabalha com qualquer processador
/// </summary>
public class SistemaCheckout
{
    public void ProcessarCompra(IProcessadorPagamento processador, decimal valor, string dados)
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║              PROCESSANDO PAGAMENTO                   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var sucesso = processador.ProcessarPagamento(valor, dados);

        if (sucesso)
        {
            // Verifica se suporta parcelamento
            if (processador is IParcelavel parcelavel)
            {
                Console.WriteLine($"\n💰 Opções de parcelamento disponíveis:");
                Console.WriteLine($"   Máximo de {parcelavel.MaximoParcelas}x");
                
                for (int i = 1; i <= Math.Min(6, parcelavel.MaximoParcelas); i++)
                {
                    var valorParcela = parcelavel.CalcularValorParcela(valor, i);
                    Console.WriteLine($"   {i}x de R$ {valorParcela:F2}");
                }
            }

            // Verifica se suporta reembolso
            if (processador is IReembolsavel)
            {
                Console.WriteLine($"\n✅ Este método aceita reembolsos");
            }
        }
    }
}
