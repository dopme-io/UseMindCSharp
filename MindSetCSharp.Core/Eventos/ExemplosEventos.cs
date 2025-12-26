namespace MindSetCSharp.Core.Eventos;

/// <summary>
/// Exemplos práticos de uso de eventos em C#
/// </summary>
public static class ExemplosEventos
{
    /// <summary>
    /// Exemplo 1: Evento básico com Action
    /// </summary>
    public static void ExemploBasico()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 1: Evento Básico (Action)              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var botao = new BotaoSimples("Salvar");

        // Assinando o evento
        botao.Clicado += () => Console.WriteLine("  → Handler 1: Salvando dados...");
        botao.Clicado += () => Console.WriteLine("  → Handler 2: Atualizando UI...");

        // Disparando evento
        botao.Clicar();

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 2: EventHandler padrão com EventArgs.Empty
    /// </summary>
    public static void ExemploEventHandler()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 2: EventHandler (padrão .NET)            ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var processador = new ProcessadorTarefas();
        processador.Processado += (_, _) => Console.WriteLine("  ✓ Tarefa processada com sucesso");

        processador.Executar("Importar clientes");
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 3: EventHandler com EventArgs customizado
    /// </summary>
    public static void ExemploArgsCustomizados()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 3: EventArgs Customizados                ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var download = new DownloadService();
        download.ProgressoAlterado += (_, args) =>
        {
            Console.WriteLine($"  → {args.Arquivo}: {args.Porcentagem}%");
            if (args.Finalizado)
                Console.WriteLine("  ✓ Download concluído!");
        };

        download.Iniciar("relatorio.pdf");
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 4: Multicast e ordem de handlers
    /// </summary>
    public static void ExemploMulticast()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 4: Multicast de Eventos                  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var notificacoes = new NotificadorEventos();

        notificacoes.Notificado += (_, msg) => Console.WriteLine($"  Handler A: {msg}");
        notificacoes.Notificado += (_, msg) => Console.WriteLine($"  Handler B: {msg.ToUpper()}");
        notificacoes.Notificado += (_, msg) => Console.WriteLine($"  Handler C: len={msg.Length}");

        notificacoes.Disparar("Evento importante");
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 5: Assinar e desassinar eventos
    /// </summary>
    public static void ExemploInscricaoDesinscricao()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 5: Assinatura e Desinscrição             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var sensor = new SensorTemperatura();

        EventHandler<TemperaturaEventArgs> alerta = (_, args) =>
            Console.WriteLine($"  🔥 Alerta! Temperatura {args.Temperatura}°C");

        sensor.TemperaturaAlterada += alerta;
        sensor.TemperaturaAlterada += (_, args) => Console.WriteLine($"  Log: {args.Temperatura}°C");

        sensor.AtualizarTemperatura(30);
        sensor.AtualizarTemperatura(42);

        // Desinscrevendo alerta para evitar spam
        sensor.TemperaturaAlterada -= alerta;
        sensor.AtualizarTemperatura(45);

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 6: Eventos assíncronos (async handlers)
    /// </summary>
    public static void ExemploAssincrono()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 6: Eventos Assíncronos                   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var emissor = new EmissorEventoAssincrono();

        emissor.AoProcessarAsync += async (_, msg) =>
        {
            await Task.Delay(200);
            Console.WriteLine($"  Handler async A: {msg}");
        };

        emissor.AoProcessarAsync += async (_, msg) =>
        {
            await Task.Delay(100);
            Console.WriteLine($"  Handler async B: {msg} (rápido)");
        };

        emissor.DispararAsync("Processando pedido #123").Wait();
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 7: Eventos em cadeia (um evento dispara outro)
    /// </summary>
    public static void ExemploEventosEmCadeia()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 7: Eventos em Cadeia                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var pipeline = new PipelineEventos();
        pipeline.PrimeiraEtapaConcluida += (_, _) => Console.WriteLine("  → Etapa 1 concluída");
        pipeline.SegundaEtapaConcluida += (_, _) => Console.WriteLine("  → Etapa 2 concluída");
        pipeline.PipelineFinalizada += (_, _) => Console.WriteLine("  ✓ Pipeline completo");

        pipeline.Iniciar();
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 8: Boas práticas de eventos
    /// </summary>
    public static void ExemploBoasPraticas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 8: Boas Práticas                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var contador = new ContadorSeguro();

        contador.ValorAlterado += (_, valor) => Console.WriteLine($"  Novo valor: {valor}");

        contador.Incrementar();
        contador.Incrementar();

        Console.WriteLine("\nℹ️ Padrões aplicados:");
        Console.WriteLine("  • Uso de '?.Invoke' para evitar NullReference");
        Console.WriteLine("  • Método protegido OnValorAlterado para disparar evento");
        Console.WriteLine("  • EventHandler<T> para assinatura consistente");
        Console.WriteLine();
    }
}

// ==================== TIPOS AUXILIARES ====================

/// <summary>
/// Botão simples com evento Action
/// </summary>
public class BotaoSimples
{
    public string Rotulo { get; }
    public event Action? Clicado;

    public BotaoSimples(string rotulo) => Rotulo = rotulo;

    public void Clicar()
    {
        Console.WriteLine($"  Botão '{Rotulo}' clicado");
        Clicado?.Invoke(); // Chamada segura
    }
}

/// <summary>
/// Processador usando EventHandler padrão
/// </summary>
public class ProcessadorTarefas
{
    public event EventHandler? Processado;

    public void Executar(string nome)
    {
        Console.WriteLine($"  Executando tarefa: {nome}");
        Thread.Sleep(100); // simular trabalho
        OnProcessado();
    }

    protected virtual void OnProcessado() => Processado?.Invoke(this, EventArgs.Empty);
}

/// <summary>
/// EventArgs customizado para progresso de download
/// </summary>
public class DownloadEventArgs : EventArgs
{
    public string Arquivo { get; }
    public int Porcentagem { get; }
    public bool Finalizado => Porcentagem >= 100;

    public DownloadEventArgs(string arquivo, int porcentagem)
    {
        Arquivo = arquivo;
        Porcentagem = porcentagem;
    }
}

/// <summary>
/// Serviço de download que publica progresso
/// </summary>
public class DownloadService
{
    public event EventHandler<DownloadEventArgs>? ProgressoAlterado;

    public void Iniciar(string arquivo)
    {
        for (int p = 0; p <= 100; p += 25)
        {
            Thread.Sleep(50);
            OnProgressoAlterado(new DownloadEventArgs(arquivo, p));
        }
    }

    protected virtual void OnProgressoAlterado(DownloadEventArgs args)
        => ProgressoAlterado?.Invoke(this, args);
}

/// <summary>
/// Classe que demonstra multicast de eventos
/// </summary>
public class NotificadorEventos
{
    public event EventHandler<string>? Notificado;

    public void Disparar(string mensagem)
    {
        Console.WriteLine("  Disparando evento...");
        Notificado?.Invoke(this, mensagem);
    }
}

/// <summary>
/// Evento com subscribe/unsubscribe
/// </summary>
public class SensorTemperatura
{
    public event EventHandler<TemperaturaEventArgs>? TemperaturaAlterada;

    public void AtualizarTemperatura(int temperatura)
    {
        OnTemperaturaAlterada(new TemperaturaEventArgs(temperatura));
    }

    protected virtual void OnTemperaturaAlterada(TemperaturaEventArgs args)
        => TemperaturaAlterada?.Invoke(this, args);
}

public class TemperaturaEventArgs : EventArgs
{
    public int Temperatura { get; }
    public TemperaturaEventArgs(int temperatura) => Temperatura = temperatura;
}

/// <summary>
/// Evento assíncrono com handlers async
/// </summary>
public class EmissorEventoAssincrono
{
    public event Func<object?, string, Task>? AoProcessarAsync;

    public async Task DispararAsync(string mensagem)
    {
        if (AoProcessarAsync is null)
            return;

        var handlers = AoProcessarAsync.GetInvocationList()
            .Cast<Func<object?, string, Task>>();

        await Task.WhenAll(handlers.Select(h => h(this, mensagem)));
    }
}

/// <summary>
/// Pipeline que encadeia eventos
/// </summary>
public class PipelineEventos
{
    public event EventHandler? PrimeiraEtapaConcluida;
    public event EventHandler? SegundaEtapaConcluida;
    public event EventHandler? PipelineFinalizada;

    public void Iniciar()
    {
        Console.WriteLine("  Iniciando pipeline...");
        OnPrimeiraEtapaConcluida();
        OnSegundaEtapaConcluida();
        OnPipelineFinalizada();
    }

    protected virtual void OnPrimeiraEtapaConcluida() => PrimeiraEtapaConcluida?.Invoke(this, EventArgs.Empty);
    protected virtual void OnSegundaEtapaConcluida() => SegundaEtapaConcluida?.Invoke(this, EventArgs.Empty);
    protected virtual void OnPipelineFinalizada() => PipelineFinalizada?.Invoke(this, EventArgs.Empty);
}

/// <summary>
/// Exemplo de padrão seguro para eventos
/// </summary>
public class ContadorSeguro
{
    public event EventHandler<int>? ValorAlterado;
    private int _valor;

    public void Incrementar()
    {
        _valor++;
        OnValorAlterado(_valor);
    }

    protected virtual void OnValorAlterado(int novoValor)
        => ValorAlterado?.Invoke(this, novoValor);
}
