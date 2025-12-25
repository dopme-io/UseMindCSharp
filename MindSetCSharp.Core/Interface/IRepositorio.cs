namespace MindSetCSharp.Core.Interface;

/// <summary>
/// Interface genérica de repositório - define contrato de operações CRUD
/// </summary>
public interface IRepositorio<T> where T : class
{
    // Métodos que devem ser implementados
    void Adicionar(T entidade);
    void Atualizar(T entidade);
    void Remover(int id);
    T? ObterPorId(int id);
    List<T> ObterTodos();
    int Contar();
}

/// <summary>
/// Interface para entidades que possuem ID
/// </summary>
public interface IEntidade
{
    int Id { get; set; }
    string Nome { get; set; }
}

/// <summary>
/// Classe de domínio - Produto
/// </summary>
public class Produto : IEntidade
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }

    public override string ToString() => 
        $"[{Id}] {Nome} - R$ {Preco:F2} (Estoque: {Estoque})";
}

/// <summary>
/// Classe de domínio - Cliente
/// </summary>
public class Cliente : IEntidade
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    public override string ToString() => 
        $"[{Id}] {Nome} - {Email}";
}

/// <summary>
/// Implementação concreta de repositório em memória
/// </summary>
public class RepositorioMemoria<T> : IRepositorio<T> where T : class, IEntidade
{
    private readonly List<T> _dados;
    private int _proximoId;

    public RepositorioMemoria()
    {
        _dados = new List<T>();
        _proximoId = 1;
    }

    public void Adicionar(T entidade)
    {
        entidade.Id = _proximoId++;
        _dados.Add(entidade);
        Console.WriteLine($"✅ Adicionado: {entidade}");
    }

    public void Atualizar(T entidade)
    {
        var existente = ObterPorId(entidade.Id);
        if (existente != null)
        {
            var index = _dados.IndexOf(existente);
            _dados[index] = entidade;
            Console.WriteLine($"✅ Atualizado: {entidade}");
        }
        else
        {
            Console.WriteLine($"❌ Entidade com ID {entidade.Id} não encontrada.");
        }
    }

    public void Remover(int id)
    {
        var entidade = ObterPorId(id);
        if (entidade != null)
        {
            _dados.Remove(entidade);
            Console.WriteLine($"✅ Removido: {entidade}");
        }
        else
        {
            Console.WriteLine($"❌ Entidade com ID {id} não encontrada.");
        }
    }

    public T? ObterPorId(int id)
    {
        return _dados.FirstOrDefault(e => e.Id == id);
    }

    public List<T> ObterTodos()
    {
        return new List<T>(_dados);
    }

    public int Contar()
    {
        return _dados.Count;
    }
}

/// <summary>
/// Implementação alternativa com cache
/// </summary>
public class RepositorioComCache<T> : IRepositorio<T> where T : class, IEntidade
{
    private readonly IRepositorio<T> _repositorioBase;
    private readonly Dictionary<int, T> _cache;

    public RepositorioComCache(IRepositorio<T> repositorioBase)
    {
        _repositorioBase = repositorioBase;
        _cache = new Dictionary<int, T>();
    }

    public void Adicionar(T entidade)
    {
        _repositorioBase.Adicionar(entidade);
        _cache[entidade.Id] = entidade;
    }

    public void Atualizar(T entidade)
    {
        _repositorioBase.Atualizar(entidade);
        _cache[entidade.Id] = entidade;
    }

    public void Remover(int id)
    {
        _repositorioBase.Remover(id);
        _cache.Remove(id);
    }

    public T? ObterPorId(int id)
    {
        // Verifica cache primeiro
        if (_cache.TryGetValue(id, out var entidadeCache))
        {
            Console.WriteLine($"🔥 Cache HIT: {entidadeCache}");
            return entidadeCache;
        }

        // Se não está no cache, busca do repositório
        var entidade = _repositorioBase.ObterPorId(id);
        if (entidade != null)
        {
            _cache[id] = entidade;
            Console.WriteLine($"💾 Cache MISS - Carregado: {entidade}");
        }

        return entidade;
    }

    public List<T> ObterTodos()
    {
        return _repositorioBase.ObterTodos();
    }

    public int Contar()
    {
        return _repositorioBase.Contar();
    }
}
