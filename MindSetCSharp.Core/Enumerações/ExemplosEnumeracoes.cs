namespace MindSetCSharp.Core.Enumeracoes;
using System.ComponentModel;

/// <summary>
/// Exemplos práticos de enumerações em C#
/// </summary>
public static class ExemplosEnumeracoes
{
    /// <summary>
    /// Exemplo 1: Enum básico
    /// </summary>
    public static void ExemploBasico()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 1: Enum Básico                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var nivel = NivelAcesso.Administrador;
        Console.WriteLine($"  Nível selecionado: {nivel} (int={(int)nivel})\n");

        Console.WriteLine("📌 Iterando valores:");
        foreach (NivelAcesso n in Enum.GetValues(typeof(NivelAcesso)))
        {
            Console.WriteLine($"  • {n} = {(int)n}");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 2: Enum com Flags (bitwise)
    /// </summary>
    public static void ExemploFlags()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 2: Flags (bitwise)                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Permissoes permissoes = Permissoes.Ler | Permissoes.Escrever;
        Console.WriteLine($"  Permissões: {permissoes} (int={(int)permissoes})");

        Console.WriteLine("📌 Verificando com HasFlag:");
        Console.WriteLine($"  Ler?        {permissoes.HasFlag(Permissoes.Ler)}");
        Console.WriteLine($"  Escrever?   {permissoes.HasFlag(Permissoes.Escrever)}");
        Console.WriteLine($"  Executar?   {permissoes.HasFlag(Permissoes.Executar)}\n");

        // Adicionando flag
        permissoes |= Permissoes.Executar;
        Console.WriteLine($"  Após adicionar Executar: {permissoes}\n");
    }

    /// <summary>
    /// Exemplo 3: Utilitários de Enum (GetValues, GetNames, Description)
    /// </summary>
    public static void ExemploUtilitarios()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 3: Utilitários de Enum                   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📌 GetNames / GetValues:");
        var nomes = Enum.GetNames<TipoDocumento>();
        var valores = Enum.GetValues<TipoDocumento>();
        Console.WriteLine($"  Nomes: {string.Join(", ", nomes)}");
        Console.WriteLine($"  Valores: {string.Join(", ", valores.Cast<int>())}\n");

        Console.WriteLine("📌 Description attribute:");
        foreach (TipoDocumento doc in valores)
        {
            Console.WriteLine($"  • {doc} -> {doc.GetDescription()}");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 4: Parse e TryParse
    /// </summary>
    public static void ExemploParseTryParse()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 4: Parse e TryParse                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        string inputValido = "Aprovado";
        string inputInvalido = "Indefinido";

        var status = Enum.Parse<StatusPedido>(inputValido);
        Console.WriteLine($"  Parse válido: '{inputValido}' -> {status}");

        if (Enum.TryParse<StatusPedido>(inputInvalido, ignoreCase: true, out var status2))
            Console.WriteLine($"  TryParse OK: {status2}");
        else
            Console.WriteLine($"  TryParse falhou para '{inputInvalido}'\n");
    }

    /// <summary>
    /// Exemplo 5: Enum em dicionários / mapeamentos
    /// </summary>
    public static void ExemploEnumComDicionario()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 5: Enum com Dicionário                   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var precos = new Dictionary<Plano, decimal>
        {
            { Plano.Basico, 49.90m },
            { Plano.Pro, 99.90m },
            { Plano.Empresarial, 199.90m }
        };

        foreach (var (plano, preco) in precos)
            Console.WriteLine($"  • {plano,-12} = R$ {preco:F2}");

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 6: Switch expression com enum
    /// </summary>
    public static void ExemploSwitchExpression()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 6: Switch Expression                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var cor = Cor.Semaforo.Amarelo;
        var acao = cor switch
        {
            Cor.Semaforo.Verde => "Siga",
            Cor.Semaforo.Amarelo => "Atenção",
            Cor.Semaforo.Vermelho => "Pare",
            _ => "Desconhecido"
        };

        Console.WriteLine($"  Cor: {cor} -> Ação: {acao}\n");
    }

    /// <summary>
    /// Exemplo 7: Validação de enum (IsDefined)
    /// </summary>
    public static void ExemploValidacao()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 7: Validação de Enum                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        int valor = 5; // fora do range de Prioridade
        Console.WriteLine($"  Validando valor {valor} em Prioridade...");

        if (!Enum.IsDefined(typeof(Prioridade), valor))
            Console.WriteLine("  ⚠️ Valor inválido para Prioridade");
        else
            Console.WriteLine("  ✓ Valor válido");

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 8: Boas práticas e helpers
    /// </summary>
    public static void ExemploBoasPraticas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 8: Boas Práticas                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📌 Dicas rápidas:");
        Console.WriteLine("  • Prefira nomes no singular (StatusPedido)");
        Console.WriteLine("  • Use Flags para combinações (Permissoes)");
        Console.WriteLine("  • Forneça descrição amigável (Description attribute)");
        Console.WriteLine("  • Valide valores antes de usar (Enum.IsDefined)");
        Console.WriteLine("  • Evite converter direto de usuário sem TryParse");
        Console.WriteLine();
    }
}

// ==================== TIPOS AUXILIARES ====================

public enum NivelAcesso
{
    Visitante = 0,
    Usuario = 1,
    Moderador = 2,
    Administrador = 3
}

[Flags]
public enum Permissoes
{
    Nenhuma = 0,
    Ler = 1 << 0,
    Escrever = 1 << 1,
    Executar = 1 << 2,
    Admin = Ler | Escrever | Executar
}

public enum StatusPedido
{
    Pendente = 0,
    Aprovado = 1,
    Rejeitado = 2
}

public enum TipoDocumento
{
    [Description("CPF - Pessoa Física")]
    CPF = 1,
    [Description("CNPJ - Pessoa Jurídica")]
    CNPJ = 2,
    [Description("Passaporte Internacional")]
    Passaporte = 3
}

public enum Plano
{
    Basico = 1,
    Pro = 2,
    Empresarial = 3
}

public enum Prioridade
{
    Baixa = 0,
    Media = 1,
    Alta = 2,
    Critica = 3
}

public static class Cor
{
    public enum Semaforo
    {
        Verde = 1,
        Amarelo = 2,
        Vermelho = 3
    }
}

// ==================== EXTENSIONS ====================

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name is null) return value.ToString();

        var field = type.GetField(name);
        if (field is null) return value.ToString();

        var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
        return attr?.Description ?? value.ToString();
    }
}
