namespace MindSetCSharp.Core.Interface;

/// <summary>
/// Interface para envio de e-mail
/// </summary>
public interface IEnviadorEmail
{
    void EnviarEmail(string destinatario, string assunto, string mensagem);
    bool ValidarEmail(string email);
}

/// <summary>
/// Interface para envio de SMS
/// </summary>
public interface IEnviadorSms
{
    void EnviarSms(string telefone, string mensagem);
    bool ValidarTelefone(string telefone);
}

/// <summary>
/// Interface para notificações push
/// </summary>
public interface IEnviadorPush
{
    void EnviarNotificacao(string dispositivo, string titulo, string mensagem);
    bool DispositivoRegistrado(string dispositivo);
}

/// <summary>
/// Interface base para todos os notificadores
/// </summary>
public interface INotificador
{
    string TipoNotificacao { get; }
    bool Enviar(string destinatario, string mensagem);
}

/// <summary>
/// Classe que implementa MÚLTIPLAS interfaces
/// Demonstra como uma classe pode ter múltiplos "contratos"
/// </summary>
public class ServicoNotificacaoCompleto : IEnviadorEmail, IEnviadorSms, IEnviadorPush
{
    // Implementação de IEnviadorEmail
    public void EnviarEmail(string destinatario, string assunto, string mensagem)
    {
        if (ValidarEmail(destinatario))
        {
            Console.WriteLine($"📧 E-mail enviado para: {destinatario}");
            Console.WriteLine($"   Assunto: {assunto}");
            Console.WriteLine($"   Mensagem: {mensagem}");
        }
        else
        {
            Console.WriteLine($"❌ E-mail inválido: {destinatario}");
        }
    }

    public bool ValidarEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && email.Contains('@');
    }

    // Implementação de IEnviadorSms
    public void EnviarSms(string telefone, string mensagem)
    {
        if (ValidarTelefone(telefone))
        {
            Console.WriteLine($"📱 SMS enviado para: {telefone}");
            Console.WriteLine($"   Mensagem: {mensagem}");
        }
        else
        {
            Console.WriteLine($"❌ Telefone inválido: {telefone}");
        }
    }

    public bool ValidarTelefone(string telefone)
    {
        var numeros = new string(telefone.Where(char.IsDigit).ToArray());
        return numeros.Length >= 10 && numeros.Length <= 11;
    }

    // Implementação de IEnviadorPush
    public void EnviarNotificacao(string dispositivo, string titulo, string mensagem)
    {
        if (DispositivoRegistrado(dispositivo))
        {
            Console.WriteLine($"🔔 Push enviado para dispositivo: {dispositivo}");
            Console.WriteLine($"   Título: {titulo}");
            Console.WriteLine($"   Mensagem: {mensagem}");
        }
        else
        {
            Console.WriteLine($"❌ Dispositivo não registrado: {dispositivo}");
        }
    }

    public bool DispositivoRegistrado(string dispositivo)
    {
        // Simulação
        return !string.IsNullOrWhiteSpace(dispositivo) && dispositivo.Length > 10;
    }
}

/// <summary>
/// Implementação especializada apenas para e-mail
/// </summary>
public class NotificadorEmail : INotificador, IEnviadorEmail
{
    public string TipoNotificacao => "E-mail";

    public bool Enviar(string destinatario, string mensagem)
    {
        EnviarEmail(destinatario, "Notificação", mensagem);
        return ValidarEmail(destinatario);
    }

    public void EnviarEmail(string destinatario, string assunto, string mensagem)
    {
        Console.WriteLine($"📧 [{TipoNotificacao}] Para: {destinatario} | {mensagem}");
    }

    public bool ValidarEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && email.Contains('@');
    }
}

/// <summary>
/// Implementação especializada apenas para SMS
/// </summary>
public class NotificadorSms : INotificador, IEnviadorSms
{
    public string TipoNotificacao => "SMS";

    public bool Enviar(string destinatario, string mensagem)
    {
        EnviarSms(destinatario, mensagem);
        return ValidarTelefone(destinatario);
    }

    public void EnviarSms(string telefone, string mensagem)
    {
        Console.WriteLine($"📱 [{TipoNotificacao}] Para: {telefone} | {mensagem}");
    }

    public bool ValidarTelefone(string telefone)
    {
        return !string.IsNullOrWhiteSpace(telefone) && telefone.Length >= 10;
    }
}

/// <summary>
/// Implementação especializada para notificações push
/// </summary>
public class NotificadorPush : INotificador, IEnviadorPush
{
    public string TipoNotificacao => "Push Notification";

    public bool Enviar(string destinatario, string mensagem)
    {
        EnviarNotificacao(destinatario, "Alerta", mensagem);
        return DispositivoRegistrado(destinatario);
    }

    public void EnviarNotificacao(string dispositivo, string titulo, string mensagem)
    {
        Console.WriteLine($"🔔 [{TipoNotificacao}] Dispositivo: {dispositivo} | {mensagem}");
    }

    public bool DispositivoRegistrado(string dispositivo)
    {
        return !string.IsNullOrWhiteSpace(dispositivo);
    }
}

/// <summary>
/// Gerenciador que trabalha com qualquer INotificador
/// Demonstra polimorfismo através de interfaces
/// </summary>
public class GerenciadorNotificacoes
{
    private readonly List<INotificador> _notificadores;

    public GerenciadorNotificacoes()
    {
        _notificadores = new List<INotificador>();
    }

    public void AdicionarNotificador(INotificador notificador)
    {
        _notificadores.Add(notificador);
        Console.WriteLine($"✅ Notificador adicionado: {notificador.TipoNotificacao}");
    }

    public void EnviarParaTodos(string destinatario, string mensagem)
    {
        Console.WriteLine($"\n📢 Enviando para todos os canais:");
        Console.WriteLine($"   Destinatário: {destinatario}");
        Console.WriteLine($"   Mensagem: {mensagem}\n");

        foreach (var notificador in _notificadores)
        {
            notificador.Enviar(destinatario, mensagem);
        }
    }

    public void ListarNotificadores()
    {
        Console.WriteLine("\n📋 Notificadores registrados:");
        foreach (var notificador in _notificadores)
        {
            Console.WriteLine($"   • {notificador.TipoNotificacao}");
        }
    }
}
