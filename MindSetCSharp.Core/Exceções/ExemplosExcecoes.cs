namespace MindSetCSharp.Core.Excecoes;

/// <summary>
/// Exemplos práticos demonstrando o tratamento de exceções em C#.
/// </summary>
public static class ExemplosExcecoes
{
    /// <summary>
    /// Exemplo 1: Try-Catch Básico
    /// Capturar e tratar exceções
    /// </summary>
    public static void ExemploTryCatch()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 1: Try-Catch Básico                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Exemplo 1: DivideByZeroException
        Console.WriteLine("📌 Tentando dividir por zero:\n");
        try
        {
            int numerador = 10;
            int denominador = 0;
            int resultado = numerador / denominador;
            Console.WriteLine($"Resultado: {resultado}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"❌ Erro capturado: {ex.Message}");
            Console.WriteLine("✓ Divisão por zero não é permitida!");
        }

        // Exemplo 2: FormatException
        Console.WriteLine("\n📌 Convertendo string inválida para número:\n");
        try
        {
            string texto = "abc123";
            int numero = int.Parse(texto);
            Console.WriteLine($"Número: {numero}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"❌ Erro capturado: {ex.Message}");
            Console.WriteLine("✓ Formato inválido para conversão!");
        }

        // Exemplo 3: IndexOutOfRangeException
        Console.WriteLine("\n📌 Acessando índice inválido:\n");
        try
        {
            int[] numeros = { 1, 2, 3 };
            int valor = numeros[10]; // Índice fora do alcance
            Console.WriteLine($"Valor: {valor}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"❌ Erro capturado: {ex.Message}");
            Console.WriteLine("✓ Índice fora do alcance do array!");
        }

        // Exemplo 4: NullReferenceException
        Console.WriteLine("\n📌 Acessando objeto nulo:\n");
        try
        {
            string? texto = null;
            int comprimento = texto.Length; // Null reference
            Console.WriteLine($"Comprimento: {comprimento}");
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"❌ Erro capturado: {ex.Message}");
            Console.WriteLine("✓ Referência nula detectada!");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 2: Finally
    /// Código que sempre executa
    /// </summary>
    public static void ExemploFinally()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 2: Finally                             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📌 Try-Catch-Finally com sucesso:\n");
        try
        {
            Console.WriteLine("  1. Executando bloco try...");
            int resultado = 10 / 2;
            Console.WriteLine($"  2. Resultado: {resultado}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"  ❌ Erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("  3. Bloco finally (sempre executa)");
        }

        Console.WriteLine("\n📌 Try-Catch-Finally com exceção:\n");
        try
        {
            Console.WriteLine("  1. Executando bloco try...");
            int divisor = 0;
            int resultado = 10 / divisor;
            Console.WriteLine($"  2. Resultado: {resultado}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"  ❌ Erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("  3. Bloco finally (ainda assim executa)");
        }

        // Aplicação prática: Fechar recurso
        Console.WriteLine("\n📌 Aplicação Prática: Garantir limpeza de recurso:\n");
        string arquivo = "dados.txt";
        try
        {
            Console.WriteLine($"  ✓ Abrindo arquivo: {arquivo}");
            // Simular processamento
            bool erro = false;
            if (erro)
                throw new IOException("Erro ao ler arquivo");
            Console.WriteLine("  ✓ Processando arquivo...");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"  ❌ Erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine($"  ✓ Fechando arquivo: {arquivo}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 3: Tipos de Exceções Comuns
    /// Conhecer as principais exceções do .NET
    /// </summary>
    public static void ExemploTiposExcecoes()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 3: Tipos de Exceções Comuns              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📋 Exceções Comuns do .NET:\n");

        var excecoes = new List<(string Tipo, string Descrição, Action Demonstrar)>
        {
            ("ArgumentNullException", "Argumento é nulo", () => {
                try {
                    string? valor = null;
                    ValidarNaoNulo(valor);
                } catch (ArgumentNullException ex) {
                    Console.WriteLine($"  ✓ Capturado: {ex.GetType().Name}");
                }
            }),
            ("ArgumentOutOfRangeException", "Argumento fora do intervalo", () => {
                try {
                    var idade = -5;
                    if (idade < 0) throw new ArgumentOutOfRangeException(nameof(idade));
                } catch (ArgumentOutOfRangeException ex) {
                    Console.WriteLine($"  ✓ Capturado: {ex.GetType().Name}");
                }
            }),
            ("InvalidOperationException", "Operação inválida", () => {
                try {
                    var lista = new List<int>();
                    var primeiro = lista.First(); // Lista vazia
                } catch (InvalidOperationException ex) {
                    Console.WriteLine($"  ✓ Capturado: {ex.GetType().Name}");
                }
            }),
            ("NotImplementedException", "Não implementado", () => {
                try {
                    throw new NotImplementedException("Este método ainda não foi implementado");
                } catch (NotImplementedException ex) {
                    Console.WriteLine($"  ✓ Capturado: {ex.GetType().Name}");
                }
            }),
            ("TimeoutException", "Operação expirou", () => {
                try {
                    throw new TimeoutException("Requisição expirou após 30 segundos");
                } catch (TimeoutException ex) {
                    Console.WriteLine($"  ✓ Capturado: {ex.GetType().Name}");
                }
            }),
            ("FileNotFoundException", "Arquivo não encontrado", () => {
                try {
                    if (!File.Exists("arquivo_inexistente.txt")) {
                        throw new FileNotFoundException("arquivo_inexistente.txt");
                    }
                } catch (FileNotFoundException ex) {
                    Console.WriteLine($"  ✓ Capturado: {ex.GetType().Name}");
                }
            })
        };

        foreach (var (tipo, descricao, demonstrar) in excecoes)
        {
            Console.Write($"• {tipo,-30} - {descricao}");
            demonstrar();
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 4: Múltiplas Exceções
    /// Tratar diferentes tipos de exceção
    /// </summary>
    public static void ExemploMultiplasExcecoes()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 4: Múltiplas Exceções                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📌 Tratando diferentes tipos de exceção:\n");

        int[] cenarios = { 0, 1, 2, 3 };

        foreach (int cenario in cenarios)
        {
            try
            {
                Console.WriteLine($"Cenário {cenario}:");
                ProcessarCenario(cenario);
                Console.WriteLine("  ✓ Sucesso!\n");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("  ❌ Capturado: Divisão por zero\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("  ❌ Capturado: Formato inválido\n");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("  ❌ Capturado: Índice fora do alcance\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ❌ Capturado: {ex.GetType().Name} - {ex.Message}\n");
            }
        }
    }

    private static string ProcessarCenario(int cenario)
    {
        return cenario switch
        {
            0 => throw new DivideByZeroException(),
            1 => throw new FormatException(),
            2 => throw new IndexOutOfRangeException(),
            // 3 => Console.WriteLine("  → Nenhum erro"),
            _ => throw new InvalidOperationException()
        };
    }

    /// <summary>
    /// Exemplo 5: Throw e Relançamento
    /// Lançar exceções intencionalmente
    /// </summary>
    public static void ExemploThrow()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 5: Throw e Relançamento                ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Exemplo 1: Validar entrada
        Console.WriteLine("📌 Validação com throw:\n");
        try
        {
            int idade = -5;
            if (idade < 0)
                throw new ArgumentException("Idade não pode ser negativa", nameof(idade));

            if (idade > 150)
                throw new ArgumentException("Idade não pode ser maior que 150", nameof(idade));

            Console.WriteLine($"  ✓ Idade válida: {idade}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"  ❌ Erro: {ex.Message}");
        }

        // Exemplo 2: Relançar exceção
        Console.WriteLine("\n📌 Relançar exceção (re-throw):\n");
        try
        {
            try
            {
                Console.WriteLine("  → Bloco try interno: lançando exceção");
                throw new InvalidOperationException("Erro original");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"  → Capturado: {ex.Message}");
                Console.WriteLine("  → Relançando para bloco externo...");
                throw; // Relança a mesma exceção
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"  → Capturado novamente: {ex.Message}");
        }

        // Exemplo 3: Envolver em nova exceção
        Console.WriteLine("\n📌 Envolver exceção (throw ... from):\n");
        try
        {
            try
            {
                int divisor = 0;
                int resultado = 10 / divisor;
            }
            catch (DivideByZeroException ex)
            {
                throw new InvalidOperationException("Erro ao processar cálculo", ex);
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"  → Exceção envolvida: {ex.Message}");
            Console.WriteLine($"  → Exceção interna: {ex.InnerException?.GetType().Name}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 6: Exceções Customizadas
    /// Criar exceções específicas da aplicação
    /// </summary>
    public static void ExemploCustomizadas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 6: Exceções Customizadas                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Exemplo 1: ContaBancária com exceção customizada
        Console.WriteLine("📌 Exceção customizada - ContaBancária:\n");
        try
        {
            var conta = new ContaBancariaEx("12345", 1000);
            Console.WriteLine($"  → Saldo inicial: R$ {conta.Saldo:F2}");

            conta.Sacar(500);
            Console.WriteLine($"  → Após sacar R$ 500: R$ {conta.Saldo:F2}");

            conta.Sacar(700); // Saldo insuficiente
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine($"  ❌ {ex.Message}");
            Console.WriteLine($"     Saldo: R$ {ex.SaldoAtual:F2}");
            Console.WriteLine($"     Solicitado: R$ {ex.ValorSolicitado:F2}");
        }

        // Exemplo 2: Usuário inválido
        Console.WriteLine("\n📌 Exceção customizada - Validação de Usuário:\n");
        try
        {
            var usuario = new Usuario("", "senha123");
        }
        catch (UsuarioInvalidoException ex)
        {
            Console.WriteLine($"  ❌ {ex.Message}");
            Console.WriteLine($"     Motivo: {ex.Motivo}");
        }

        // Exemplo 3: Operação não autorizada
        Console.WriteLine("\n📌 Exceção customizada - Autorização:\n");
        try
        {
            var operacao = new Operacao(TipoOperacao.Deletar);
            var usuario = new Usuario("João", "senha");
            operacao.Executar(usuario); // Usuário não tem permissão
        }
        catch (OperacaoNaoAutorizadaException ex)
        {
            Console.WriteLine($"  ❌ {ex.Message}");
            Console.WriteLine($"     Usuário: {ex.Usuario}");
            Console.WriteLine($"     Operação: {ex.Operacao}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 7: Stack Trace
    /// Rastrear a origem do erro
    /// </summary>
    public static void ExemploStackTrace()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 7: Stack Trace                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        try
        {
            Console.WriteLine("📌 Simulando chamadas de métodos aninhados:\n");
            MetodoA();
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Exceção capturada!\n");
            Console.WriteLine("📋 Stack Trace (rastreamento):\n");
            Console.WriteLine(ex.StackTrace);
        }
    }

    private static void MetodoA()
    {
        Console.WriteLine("  → MetodoA chamado");
        MetodoB();
    }

    private static void MetodoB()
    {
        Console.WriteLine("  → MetodoB chamado");
        MetodoC();
    }

    private static void MetodoC()
    {
        Console.WriteLine("  → MetodoC chamado");
        throw new Exception("Erro em MetodoC!");
    }

    /// <summary>
    /// Exemplo 8: Using Statement
    /// Garantir limpeza de recursos
    /// </summary>
    public static void ExemploUsing()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 8: Using Statement                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Using clássico
        Console.WriteLine("📌 Using clássico (IDisposable):\n");
        try
        {
            using (var recurso = new RecursoGerenciado("Recurso 1"))
            {
                Console.WriteLine("  → Usando recurso...");
                recurso.Processar();
            } // Dispose() é chamado automaticamente aqui
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  ❌ Erro: {ex.Message}");
        }

        // Using declaration (C# 8+)
        Console.WriteLine("\n📌 Using declaration (C# 8+):\n");
        using var recurso2 = new RecursoGerenciado("Recurso 2");
        Console.WriteLine("  → Usando recurso declarado com using...");
        recurso2.Processar();
        // Dispose() será chamado automaticamente ao fim do escopo

        Console.WriteLine("\n✓ Todos os recursos foram liberados corretamente");
        Console.WriteLine();
    }

    private static void ValidarNaoNulo(string? valor)
    {
        if (valor == null)
            throw new ArgumentNullException(nameof(valor));
    }
}

// ==================== EXCEÇÕES CUSTOMIZADAS ====================

/// <summary>
/// Exceção para saldo insuficiente
/// </summary>
public class SaldoInsuficienteException : Exception
{
    public decimal SaldoAtual { get; set; }
    public decimal ValorSolicitado { get; set; }

    public SaldoInsuficienteException(decimal saldoAtual, decimal valorSolicitado)
        : base($"Saldo insuficiente. Saldo: R$ {saldoAtual:F2}, Solicitado: R$ {valorSolicitado:F2}")
    {
        SaldoAtual = saldoAtual;
        ValorSolicitado = valorSolicitado;
    }
}

/// <summary>
/// Exceção para usuário inválido
/// </summary>
public class UsuarioInvalidoException : Exception
{
    public string Motivo { get; set; }

    public UsuarioInvalidoException(string mensagem, string motivo)
        : base(mensagem)
    {
        Motivo = motivo;
    }
}

/// <summary>
/// Exceção para operação não autorizada
/// </summary>
public class OperacaoNaoAutorizadaException : Exception
{
    public string Usuario { get; set; }
    public string Operacao { get; set; }

    public OperacaoNaoAutorizadaException(string usuario, string operacao)
        : base($"Usuário '{usuario}' não tem permissão para executar '{operacao}'")
    {
        Usuario = usuario;
        Operacao = operacao;
    }
}

// ==================== CLASSES AUXILIARES ====================

/// <summary>
/// Classe para demonstrar exceções customizadas
/// </summary>
public class ContaBancariaEx
{
    public string Numero { get; set; }
    public decimal Saldo { get; private set; }

    public ContaBancariaEx(string numero, decimal saldoInicial)
    {
        Numero = numero;
        Saldo = saldoInicial;
    }

    public void Sacar(decimal valor)
    {
        if (valor > Saldo)
            throw new SaldoInsuficienteException(Saldo, valor);

        Saldo -= valor;
    }

    public void Depositar(decimal valor)
    {
        Saldo += valor;
    }
}

/// <summary>
/// Classe de usuário com validação
/// </summary>
public class Usuario
{
    public string Nome { get; set; }
    public string Senha { get; set; }

    public Usuario(string nome, string senha)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new UsuarioInvalidoException("Nome não pode estar vazio", "Nome vazio");

        if (senha.Length < 6)
            throw new UsuarioInvalidoException("Senha deve ter no mínimo 6 caracteres", "Senha fraca");

        Nome = nome;
        Senha = senha;
    }

    public bool TemPermissao(TipoOperacao operacao)
    {
        // Simples lógica: apenas admins podem deletar
        return operacao != TipoOperacao.Deletar;
    }
}

/// <summary>
/// Tipo de operação
/// </summary>
public enum TipoOperacao
{
    Ler,
    Criar,
    Editar,
    Deletar
}

/// <summary>
/// Classe de operação com verificação de autorização
/// </summary>
public class Operacao
{
    public TipoOperacao Tipo { get; set; }

    public Operacao(TipoOperacao tipo)
    {
        Tipo = tipo;
    }

    public void Executar(Usuario usuario)
    {
        if (!usuario.TemPermissao(Tipo))
            throw new OperacaoNaoAutorizadaException(usuario.Nome, Tipo.ToString());

        Console.WriteLine($"  ✓ Operação '{Tipo}' executada por '{usuario.Nome}'");
    }
}

/// <summary>
/// Classe que implementa IDisposable para gerenciamento de recursos
/// </summary>
public class RecursoGerenciado : IDisposable
{
    private string _nome;
    private bool _descartado = false;

    public RecursoGerenciado(string nome)
    {
        _nome = nome;
        Console.WriteLine($"  ✓ Recurso '{_nome}' criado");
    }

    public void Processar()
    {
        if (_descartado)
            throw new ObjectDisposedException("RecursoGerenciado");

        Console.WriteLine($"  → Processando com '{_nome}'");
    }

    public void Dispose()
    {
        if (!_descartado)
        {
            Console.WriteLine($"  ✓ Recurso '{_nome}' liberado");
            _descartado = true;
            GC.SuppressFinalize(this);
        }
    }

    ~RecursoGerenciado()
    {
        Dispose();
    }
}
