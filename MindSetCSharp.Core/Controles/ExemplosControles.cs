namespace MindSetCSharp.Core.Controles;

/// <summary>
/// Exemplos práticos simulando Controllers (API) em .NET
/// </summary>
public static class ExemplosControles
{
    /// <summary>
    /// Exemplo 1: Controller básico com retorno de recurso
    /// </summary>
    public static void ExemploBasico()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 1: Controller Básico                       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var controller = CriarControllerComDados();
        var resultado = controller.Listar();
        ImprimirResultado(resultado);
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 2: Injeção de dependência (repo + logger)
    /// </summary>
    public static void ExemploDI()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 2: DI em Controllers                       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        IProdutoRepositorio repo = new ProdutoRepositorioMemoria();
        IAppLogger logger = new ConsoleLogger();
        var controller = new ProdutosController(repo, logger);

        controller.Criar(new CriarProdutoRequest("Mouse", 120m));
        var item = controller.ObterPorId(1);
        ImprimirResultado(item);
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 3: Action Results (Ok/NotFound/BadRequest)
    /// </summary>
    public static void ExemploActionResults()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 3: Action Results                          ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var controller = CriarControllerComDados();

        ImprimirResultado(controller.ObterPorId(1)); // Ok
        ImprimirResultado(controller.ObterPorId(99)); // NotFound

        var invalido = controller.Criar(new CriarProdutoRequest("", -5));
        ImprimirResultado(invalido); // BadRequest
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 4: Validação de entrada (DTO)
    /// </summary>
    public static void ExemploValidacao()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 4: Validação de DTO                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var controller = CriarControllerComDados();
        var req = new CriarProdutoRequest("  ", 0);
        var resultado = controller.Criar(req);
        ImprimirResultado(resultado);
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 5: Separação de comandos e queries
    /// </summary>
    public static void ExemploComandosQueries()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 5: Commands vs Queries                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var controller = CriarControllerComDados();

        ImprimirResultado(controller.Listar()); // Query
        ImprimirResultado(controller.Criar(new CriarProdutoRequest("Teclado", 200m))); // Command
        ImprimirResultado(controller.Listar()); // Query novamente
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 6: Paginação e filtros simples
    /// </summary>
    public static void ExemploPaginacaoFiltros()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 6: Paginação / Filtros                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var controller = CriarControllerComDados();

        var pagina1 = controller.Listar(pagina: 1, tamanho: 2, nomeContem: "a");
        var pagina2 = controller.Listar(pagina: 2, tamanho: 2, nomeContem: "a");

        Console.WriteLine("  Página 1:");
        ImprimirResultado(pagina1);
        Console.WriteLine("  Página 2:");
        ImprimirResultado(pagina2);
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 7: Logging em ações
    /// </summary>
    public static void ExemploLogging()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 7: Logging                                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        IAppLogger logger = new ConsoleLogger();
        var controller = new ProdutosController(new ProdutoRepositorioMemoria(), logger);

        controller.Criar(new CriarProdutoRequest("Monitor", 900m));
        controller.Criar(new CriarProdutoRequest("SSD", 450m));
        var todos = controller.Listar();

        ImprimirResultado(todos);
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 8: Boas práticas de controllers
    /// </summary>
    public static void ExemploBoasPraticas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║   EXEMPLO 8: Boas Práticas                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📌 Dicas rápidas:");
        Console.WriteLine("  • Separe comandos (mutações) de queries (leituras)");
        Console.WriteLine("  • Valide DTOs e retorne erros claros (BadRequest)");
        Console.WriteLine("  • Use Action Results padronizados (Ok/NotFound)");
        Console.WriteLine("  • Injete dependências (repo/logger) em vez de new espalhado");
        Console.WriteLine("  • Mantenha controllers finos: delegue para serviços/domínio");
        Console.WriteLine();
    }

    // ========= Helpers =========
    private static ProdutosController CriarControllerComDados()
    {
        var repo = new ProdutoRepositorioMemoria();
        repo.Adicionar(new Produto(1, "Caderno", 15m));
        repo.Adicionar(new Produto(2, "Caneta", 5m));
        repo.Adicionar(new Produto(3, "Lapis", 3m));
        repo.Adicionar(new Produto(4, "Apontador", 7m));
        return new ProdutosController(repo, new ConsoleLogger());
    }

    private static void ImprimirResultado(ActionResult resultado)
    {
        switch (resultado)
        {
            case OkResult ok:
                Console.WriteLine($"  OK: {ok.Value}");
                break;
            case OkResult<IEnumerable<Produto>> okList:
                Console.WriteLine("  OK (lista): " + string.Join(", ", okList.Value.Select(p => $"{p.Nome} R${p.Preco}")));
                break;
            case NotFoundResult nf:
                Console.WriteLine($"  NotFound: {nf.Message}");
                break;
            case BadRequestResult br:
                Console.WriteLine($"  BadRequest: {br.Error}");
                break;
            default:
                Console.WriteLine("  Resultado desconhecido");
                break;
        }
    }
}

// ==================== TIPOS AUXILIARES ====================

public abstract record ActionResult;
public record OkResult(object Value) : ActionResult;
public record OkResult<T>(T Value) : ActionResult;
public record NotFoundResult(string Message) : ActionResult;
public record BadRequestResult(string Error) : ActionResult;

public interface IAppLogger
{
    void Info(string message);
}

public class ConsoleLogger : IAppLogger
{
    public void Info(string message) => Console.WriteLine($"  [log] {message}");
}

public record Produto(int Id, string Nome, decimal Preco);

public interface IProdutoRepositorio
{
    IEnumerable<Produto> Todos();
    Produto? Obter(int id);
    void Adicionar(Produto produto);
}

public class ProdutoRepositorioMemoria : IProdutoRepositorio
{
    private readonly List<Produto> _dados = new();

    public IEnumerable<Produto> Todos() => _dados.OrderBy(p => p.Id);

    public Produto? Obter(int id) => _dados.FirstOrDefault(p => p.Id == id);

    public void Adicionar(Produto produto)
    {
        // Id simples se não vier preenchido
        if (produto.Id == 0)
        {
            int novoId = _dados.Count == 0 ? 1 : _dados.Max(p => p.Id) + 1;
            _dados.Add(produto with { Id = novoId });
        }
        else
        {
            _dados.Add(produto);
        }
    }
}

public record CriarProdutoRequest(string Nome, decimal Preco);

public class ProdutosController
{
    private readonly IProdutoRepositorio _repo;
    private readonly IAppLogger _logger;

    public ProdutosController(IProdutoRepositorio repo, IAppLogger logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public ActionResult Listar(int pagina = 1, int tamanho = int.MaxValue, string? nomeContem = null)
    {
        var dados = _repo.Todos();
        if (!string.IsNullOrWhiteSpace(nomeContem))
            dados = dados.Where(p => p.Nome.Contains(nomeContem, StringComparison.OrdinalIgnoreCase));

        var paginados = dados
            .Skip((pagina - 1) * tamanho)
            .Take(tamanho)
            .ToList();

        return new OkResult<IEnumerable<Produto>>(paginados);
    }

    public ActionResult ObterPorId(int id)
    {
        var produto = _repo.Obter(id);
        return produto is null
            ? new NotFoundResult($"Produto {id} não encontrado")
            : new OkResult<Produto>(produto);
    }

    public ActionResult Criar(CriarProdutoRequest request)
    {
        var erros = Validar(request);
        if (erros.Any())
            return new BadRequestResult(string.Join("; ", erros));

        var produto = new Produto(0, request.Nome.Trim(), request.Preco);
        _repo.Adicionar(produto);
        _logger.Info($"Criado produto {produto.Nome} por R${produto.Preco}");
        return new OkResult<Produto>(produto);
    }

    private static List<string> Validar(CriarProdutoRequest request)
    {
        var erros = new List<string>();
        if (string.IsNullOrWhiteSpace(request.Nome)) erros.Add("Nome é obrigatório");
        if (request.Preco <= 0) erros.Add("Preço deve ser positivo");
        return erros;
    }
}
