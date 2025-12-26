namespace MindSetCSharp.Core.Referencias;

/// <summary>
/// Exemplos práticos demonstrando conceitos de referências e tipos em C#.
/// </summary>
public static class ExemplosReferencias
{
    /// <summary>
    /// Exemplo 1: Tipos de Valor vs Tipos de Referência
    /// Compreender a diferença fundamental entre eles
    /// </summary>
    public static void ExemploTiposValorVsReferencia()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║    EXEMPLO 1: Tipos de Valor vs Referência           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // TIPO DE VALOR
        Console.WriteLine("📦 TIPO DE VALOR (Value Type):");
        int numero1 = 10;
        int numero2 = numero1; // Cópia do valor

        numero2 = 20;
        Console.WriteLine($"numero1 = {numero1}");
        Console.WriteLine($"numero2 = {numero2}");
        Console.WriteLine("✓ Mudança em numero2 não afetou numero1");

        // TIPO DE REFERÊNCIA
        Console.WriteLine("\n🔗 TIPO DE REFERÊNCIA (Reference Type):");
        var pessoa1 = new PessoaReferencia("João", 30);
        var pessoa2 = pessoa1; // Cópia da referência (aponta para o mesmo objeto)

        pessoa2.Nome = "Maria";
        Console.WriteLine($"pessoa1.Nome = {pessoa1.Nome}");
        Console.WriteLine($"pessoa2.Nome = {pessoa2.Nome}");
        Console.WriteLine("✓ Mudança em pessoa2 também afetou pessoa1 (mesma referência)");

        // Tipos de valor comuns
        Console.WriteLine("\n📋 TIPOS DE VALOR:");
        Console.WriteLine("  • Tipos Inteiros: byte, sbyte, short, ushort, int, uint, long, ulong");
        Console.WriteLine("  • Tipos Ponto Flutuante: float, double, decimal");
        Console.WriteLine("  • bool: true ou false");
        Console.WriteLine("  • char: caractere único");
        Console.WriteLine("  • Struct: tipo de valor customizado");
        Console.WriteLine("  • Enum: enumeração");

        // Tipos de referência comuns
        Console.WriteLine("\n📋 TIPOS DE REFERÊNCIA:");
        Console.WriteLine("  • class: tipo de referência customizado");
        Console.WriteLine("  • interface: contrato");
        Console.WriteLine("  • array: coleção");
        Console.WriteLine("  • string: cadeia de caracteres (tipo de referência!)");
        Console.WriteLine("  • object: classe base de todos os tipos");
        Console.WriteLine("  • delegate: referência a método");
    }

    /// <summary>
    /// Exemplo 2: Stack vs Heap
    /// Compreender onde os dados são armazenados
    /// </summary>
    public static void ExemploStackVsHeap()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║        EXEMPLO 2: Stack vs Heap (Memória)            ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📚 STACK (Pilha):");
        Console.WriteLine("  • Armazena tipos de valor (int, bool, double, etc)");
        Console.WriteLine("  • Armazena referências para tipos de referência");
        Console.WriteLine("  • Gerenciamento automático (removido ao sair do escopo)");
        Console.WriteLine("  • Acesso LIFO (Last In, First Out)");
        Console.WriteLine("  • Mais rápido");

        Console.WriteLine("\n🗄️  HEAP (Montículo):");
        Console.WriteLine("  • Armazena tipos de referência (objects, arrays, strings)");
        Console.WriteLine("  • Gerenciado por Garbage Collection");
        Console.WriteLine("  • Acesso mais lento que stack");
        Console.WriteLine("  • Maior quantidade de memória");

        Console.WriteLine("\n🔍 Visualização de Memória:\n");

        // Tipo de Valor no Stack
        int idade = 25;
        Console.WriteLine($"int idade = 25;");
        Console.WriteLine($"  [Stack] idade: 25");

        // Tipo de Referência (Stack + Heap)
        var pessoa = new PessoaReferencia("Ana", 28);
        Console.WriteLine($"\nvar pessoa = new PessoaReferencia(\"Ana\", 28);");
        Console.WriteLine($"  [Stack] pessoa: 0xABCD1234 (endereço)");
        Console.WriteLine($"  [Heap]  objeto em 0xABCD1234:");
        Console.WriteLine($"          - Nome: \"Ana\"");
        Console.WriteLine($"          - Idade: 28");

        // Array
        int[] numeros = { 1, 2, 3 };
        Console.WriteLine($"\nint[] numeros = {{ 1, 2, 3 }};");
        Console.WriteLine($"  [Stack] numeros: 0xDEF56789 (endereço)");
        Console.WriteLine($"  [Heap]  array em 0xDEF56789:");
        Console.WriteLine($"          - [0]: 1");
        Console.WriteLine($"          - [1]: 2");
        Console.WriteLine($"          - [2]: 3");
    }

    /// <summary>
    /// Exemplo 3: Comparação de Referências
    /// Diferentes formas de comparar objetos
    /// </summary>
    public static void ExemploComparacaoReferencias()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 3: Comparação de Referências             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var pessoa1 = new PessoaReferencia("João", 30);
        var pessoa2 = new PessoaReferencia("João", 30);
        var pessoa3 = pessoa1;

        Console.WriteLine("📊 Objetos para comparação:");
        Console.WriteLine($"pessoa1 = PessoaReferencia(\"João\", 30)  [Endereço: {pessoa1.GetHashCode()}]");
        Console.WriteLine($"pessoa2 = PessoaReferencia(\"João\", 30)  [Endereço: {pessoa2.GetHashCode()}]");
        Console.WriteLine($"pessoa3 = pessoa1                        [Endereço: {pessoa3.GetHashCode()}]\n");

        // == Comparação de referência
        Console.WriteLine("🔍 Comparação com == (referência):");
        Console.WriteLine($"pessoa1 == pessoa2: {pessoa1 == pessoa2} (referências diferentes)");
        Console.WriteLine($"pessoa1 == pessoa3: {pessoa1 == pessoa3} (mesma referência)");

        // Equals comparação de valor
        Console.WriteLine("\n🔍 Comparação com Equals() (valor):");
        Console.WriteLine($"pessoa1.Equals(pessoa2): {pessoa1.Equals(pessoa2)} (valores iguais)");
        Console.WriteLine($"pessoa1.Equals(pessoa3): {pessoa1.Equals(pessoa3)} (mesmo objeto)");

        // ReferenceEquals
        Console.WriteLine("\n🔍 Comparação com ReferenceEquals() (identidade):");
        Console.WriteLine($"ReferenceEquals(pessoa1, pessoa2): {ReferenceEquals(pessoa1, pessoa2)}");
        Console.WriteLine($"ReferenceEquals(pessoa1, pessoa3): {ReferenceEquals(pessoa1, pessoa3)}");

        // String comparison (caso especial)
        Console.WriteLine("\n📝 Caso Especial: Strings (Interning):");
        string str1 = "Hello";
        string str2 = "Hello";
        string str3 = new string(new char[] { 'H', 'e', 'l', 'l', 'o' });

        Console.WriteLine($"str1 = \"Hello\"");
        Console.WriteLine($"str2 = \"Hello\"");
        Console.WriteLine($"str3 = new string(...)\n");

        Console.WriteLine($"str1 == str2: {str1 == str2} (mesmo valor interned)");
        Console.WriteLine($"ReferenceEquals(str1, str2): {ReferenceEquals(str1, str2)} (pode ser true por interning)");
        Console.WriteLine($"str1 == str3: {str1 == str3} (mesmo valor)");
        Console.WriteLine($"ReferenceEquals(str1, str3): {ReferenceEquals(str1, str3)} (referências diferentes)");
    }

    /// <summary>
    /// Exemplo 4: Mutabilidade de Tipos
    /// Como tipos de valor e referência se comportam quando modificados
    /// </summary>
    public static void ExemploMutabilidade()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║       EXEMPLO 4: Mutabilidade de Tipos               ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Tipo mutável (classe)
        Console.WriteLine("🔄 TIPO MUTÁVEL (Classe):");
        var conta1 = new ContaBancaria(1000);
        var conta2 = conta1;

        Console.WriteLine($"conta1.Saldo = {conta1.Saldo}");
        Console.WriteLine($"conta2.Saldo = {conta2.Saldo}");

        conta2.Depositar(500);
        Console.WriteLine($"\nApós conta2.Depositar(500):");
        Console.WriteLine($"conta1.Saldo = {conta1.Saldo} (foi alterado também!)");
        Console.WriteLine($"conta2.Saldo = {conta2.Saldo}");

        // Tipo imutável (string)
        Console.WriteLine("\n❄️  TIPO IMUTÁVEL (String):");
        string texto1 = "Hello";
        string texto2 = texto1;

        Console.WriteLine($"texto1 = \"{texto1}\"");
        Console.WriteLine($"texto2 = \"{texto2}\"");

        texto2 = texto2 + " World";
        Console.WriteLine($"\nApós texto2 = texto2 + \" World\":");
        Console.WriteLine($"texto1 = \"{texto1}\" (não foi alterado)");
        Console.WriteLine($"texto2 = \"{texto2}\" (nova string criada)");

        // Struct (tipo de valor)
        Console.WriteLine("\n📦 TIPO DE VALOR (Struct):");
        var ponto1 = new Ponto(10, 20);
        var ponto2 = ponto1;

        Console.WriteLine($"ponto1 = ({ponto1.X}, {ponto1.Y})");
        Console.WriteLine($"ponto2 = ({ponto2.X}, {ponto2.Y})");

        ponto2.X = 30;
        Console.WriteLine($"\nApós ponto2.X = 30:");
        Console.WriteLine($"ponto1 = ({ponto1.X}, {ponto1.Y}) (não foi alterado)");
        Console.WriteLine($"ponto2 = ({ponto2.X}, {ponto2.Y})");
    }

    /// <summary>
    /// Exemplo 5: Parâmetros ref, out, in
    /// Passar referências a métodos
    /// </summary>
    public static void ExemploParametrosRef()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║    EXEMPLO 5: Parâmetros ref, out e in               ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Parâmetro normal (por valor)
        Console.WriteLine("📌 PARÂMETRO NORMAL (por valor):");
        int numero = 10;
        Console.WriteLine($"Antes: numero = {numero}");
        DuplicarValor(numero);
        Console.WriteLine($"Depois: numero = {numero} (não mudou)");

        // Parâmetro ref
        Console.WriteLine("\n🔗 PARÂMETRO REF (por referência):");
        int numero2 = 10;
        Console.WriteLine($"Antes: numero2 = {numero2}");
        DuplicarComRef(ref numero2);
        Console.WriteLine($"Depois: numero2 = {numero2} (mudou!)");

        // Parâmetro out
        Console.WriteLine("\n⬅️  PARÂMETRO OUT (saída):");
        bool sucesso = DividirComOut(10, 2, out int resultado);
        Console.WriteLine($"10 / 2 = {resultado}, Sucesso: {sucesso}");

        sucesso = DividirComOut(10, 0, out resultado);
        Console.WriteLine($"10 / 0 = {resultado}, Sucesso: {sucesso}");

        // Parâmetro in
        Console.WriteLine("\n🔒 PARÂMETRO IN (somente leitura):");
        var pessoa = new PessoaReferencia("Ana", 28);
        ExibirPessoaSomenteLeitura(in pessoa);
        Console.WriteLine($"Pessoa ainda é: {pessoa.Nome}, {pessoa.Idade}");
    }

    private static void DuplicarValor(int numero)
    {
        numero *= 2;
        Console.WriteLine($"  Dentro do método: numero = {numero}");
    }

    private static void DuplicarComRef(ref int numero)
    {
        numero *= 2;
        Console.WriteLine($"  Dentro do método: numero = {numero}");
    }

    private static bool DividirComOut(int dividendo, int divisor, out int resultado)
    {
        resultado = 0;
        if (divisor == 0)
            return false;

        resultado = dividendo / divisor;
        return true;
    }

    private static void ExibirPessoaSomenteLeitura(in PessoaReferencia pessoa)
    {
        Console.WriteLine($"  Exibindo: {pessoa.Nome}, {pessoa.Idade}");
        // pessoa = new PessoaReferencia("Outro", 20); // Erro! in impede reatribuição
    }

    /// <summary>
    /// Exemplo 6: Null Coalescing e Operador ?
    /// Trabalhar com valores nulos
    /// </summary>
    public static void ExemploNullCoalescing()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 6: Null Coalescing e ?                   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Null coalescing operator ??
        Console.WriteLine("⚡ NULL COALESCING OPERATOR (??):");
        string? nome = null;
        string nomeExibicao = nome ?? "Anônimo";
        Console.WriteLine($"Nome: {nomeExibicao}");

        nome = "João";
        nomeExibicao = nome ?? "Anônimo";
        Console.WriteLine($"Nome: {nomeExibicao}");

        // Null coalescing assignment ??=
        Console.WriteLine("\n⚡ NULL COALESCING ASSIGNMENT (??=):");
        string? valor = null;
        Console.WriteLine($"Antes: valor = {(valor == null ? "null" : valor)}");

        valor ??= "Valor padrão";
        Console.WriteLine($"Depois: valor = {valor}");

        valor ??= "Outro valor";
        Console.WriteLine($"Depois novo assign: valor = {valor}");

        // Null conditional operator ?.
        Console.WriteLine("\n❓ NULL CONDITIONAL OPERATOR (?):");
        PessoaReferencia? pessoa = null;
        string? nomeOuNull = pessoa?.Nome;
        Console.WriteLine($"Pessoa é null, Nome: {(nomeOuNull == null ? "null" : nomeOuNull)}");

        pessoa = new PessoaReferencia("Maria", 30);
        nomeOuNull = pessoa?.Nome;
        Console.WriteLine($"Pessoa existe, Nome: {nomeOuNull}");

        // Null conditional com array
        Console.WriteLine("\n❓ NULL CONDITIONAL COM ARRAY:");
        int[]? numeros = null;
        int? primeiroOuNull = numeros?[0];
        Console.WriteLine($"Array é null, Primeiro: {(primeiroOuNull == null ? "null" : primeiroOuNull)}");

        numeros = new int[] { 1, 2, 3 };
        primeiroOuNull = numeros?[0];
        Console.WriteLine($"Array existe, Primeiro: {primeiroOuNull}");

        // Null-forgiving operator !
        Console.WriteLine("\n⚠️  NULL-FORGIVING OPERATOR (!):");
        string? texto = null;
        // string textoSemNull = texto; // Erro! Nullable reference
        string textoSemNull = texto!; // Dizemos que temos certeza que não é null
        Console.WriteLine($"Texto: {(textoSemNull == null ? "null" : textoSemNull)}");
    }

    /// <summary>
    /// Exemplo 7: Cloning de Objetos
    /// Criar cópias independentes de objetos
    /// </summary>
    public static void ExemploCloning()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║        EXEMPLO 7: Cloning de Objetos                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Shallow copy (cópia rasa)
        Console.WriteLine("📋 SHALLOW COPY (Cópia da Referência):");
        var contaOriginal = new ContaBancaria(1000);
        var contaCopia = contaOriginal;

        Console.WriteLine($"contaOriginal.Saldo = {contaOriginal.Saldo}");
        Console.WriteLine($"contaCopia.Saldo = {contaCopia.Saldo}");

        contaCopia.Depositar(500);
        Console.WriteLine($"\nApós contaCopia.Depositar(500):");
        Console.WriteLine($"contaOriginal.Saldo = {contaOriginal.Saldo} (foi alterado!)");
        Console.WriteLine($"contaCopia.Saldo = {contaCopia.Saldo}");

        // Deep copy (cópia profunda)
        Console.WriteLine("\n🔄 DEEP COPY (Cópia Independente):");
        var contaOriginal2 = new ContaBancaria(2000);
        var contaCopiaIndependente = new ContaBancaria(contaOriginal2.Saldo);

        Console.WriteLine($"contaOriginal2.Saldo = {contaOriginal2.Saldo}");
        Console.WriteLine($"contaCopiaIndependente.Saldo = {contaCopiaIndependente.Saldo}");

        contaCopiaIndependente.Depositar(300);
        Console.WriteLine($"\nApós contaCopiaIndependente.Depositar(300):");
        Console.WriteLine($"contaOriginal2.Saldo = {contaOriginal2.Saldo} (não foi alterado)");
        Console.WriteLine($"contaCopiaIndependente.Saldo = {contaCopiaIndependente.Saldo}");

        // Object.MemberwiseClone()
        Console.WriteLine("\n🖇️  MEMBERWISECLONE:");
        var pessoaOriginal = new PessoaReferencia("Pedro", 35);
        var pessoaCopia = pessoaOriginal.ClonarRaso();

        Console.WriteLine($"pessoaOriginal: {pessoaOriginal.Nome}, {pessoaOriginal.Idade}");
        Console.WriteLine($"pessoaCopia: {pessoaCopia.Nome}, {pessoaCopia.Idade}");

        pessoaCopia.Nome = "Paulo";
        Console.WriteLine($"\nApós pessoaCopia.Nome = \"Paulo\":");
        Console.WriteLine($"pessoaOriginal: {pessoaOriginal.Nome} (não foi alterado)");
        Console.WriteLine($"pessoaCopia: {pessoaCopia.Nome}");
    }

    /// <summary>
    /// Exemplo 8: Garbage Collection
    /// Como C# gerencia memória
    /// </summary>
    public static void ExemploGarbageCollection()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 8: Garbage Collection (GC)              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("🗑️  GARBAGE COLLECTION:");
        Console.WriteLine("  • Remove objetos que não têm mais referências");
        Console.WriteLine("  • Executa automaticamente");
        Console.WriteLine("  • Libera memória no Heap");
        Console.WriteLine("  • Pode ser forçado (não recomendado)\n");

        // Objetos sem referência
        Console.WriteLine("📊 Objetos sem Referência (candidatos a GC):");
        CriarObjetoTemporario();
        Console.WriteLine("  Objeto criado foi descartado (sem referência)");

        // Rastreando GC
        Console.WriteLine("\n📈 Informações de GC:");
        long memoriaAntes = GC.GetTotalMemory(false) / 1024;
        Console.WriteLine($"Memória antes: {memoriaAntes} KB");

        // Criar muitos objetos
        var lista = new List<PessoaReferencia>();
        for (int i = 0; i < 1000; i++)
        {
            lista.Add(new PessoaReferencia($"Pessoa {i}", 20 + (i % 50)));
        }

        long memoriaDepois = GC.GetTotalMemory(false) / 1024;
        Console.WriteLine($"Memória após criar 1000 objetos: {memoriaDepois} KB");
        Console.WriteLine($"Diferença: {memoriaDepois - memoriaAntes} KB");

        // Limpar lista
        lista.Clear();
        Console.WriteLine($"\nApós limpar lista:");
        Console.WriteLine($"  Objetos agora são candidatos a coleta");

        // Forçar GC (não recomendado em produção)
        Console.WriteLine("\n⚠️  Forçando Garbage Collection:");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        long memoriaAposGC = GC.GetTotalMemory(true) / 1024;
        Console.WriteLine($"Memória após GC: {memoriaAposGC} KB");

        // Usando statement
        Console.WriteLine("\n🔐 USING STATEMENT (IDisposable):");
        using (var recurso = new RecursoGerenciado("Recurso de teste"))
        {
            recurso.Usar();
        } // Automaticamente chama Dispose()
        Console.WriteLine("  Recurso foi liberado automaticamente");
    }

    private static void CriarObjetoTemporario()
    {
        var pessoa = new PessoaReferencia("Temporário", 25);
        // pessoa sai do escopo aqui - sem referência
    }
}

// ==================== CLASSES AUXILIARES ====================

/// <summary>
/// Classe para demonstrar tipos de referência
/// </summary>
public class PessoaReferencia
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public PessoaReferencia(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not PessoaReferencia outra)
            return false;

        return Nome == outra.Nome && Idade == outra.Idade;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nome, Idade);
    }

    public PessoaReferencia ClonarRaso()
    {
        return (PessoaReferencia)MemberwiseClone();
    }
}

/// <summary>
/// Struct para demonstrar tipos de valor
/// </summary>
public struct Ponto
{
    public int X { get; set; }
    public int Y { get; set; }

    public Ponto(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

/// <summary>
/// Classe mutável para demonstrar comportamento
/// </summary>
public class ContaBancaria
{
    public decimal Saldo { get; private set; }

    public ContaBancaria(decimal saldoInicial)
    {
        Saldo = saldoInicial;
    }

    public void Depositar(decimal valor)
    {
        Saldo += valor;
    }

    public bool Sacar(decimal valor)
    {
        if (Saldo >= valor)
        {
            Saldo -= valor;
            return true;
        }
        return false;
    }
}

/// <summary>
/// Classe que implementa IDisposable para demonstrar gerenciamento de recursos
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

    public void Usar()
    {
        if (_descartado)
            throw new ObjectDisposedException("RecursoGerenciado");

        Console.WriteLine($"  → Usando recurso '{_nome}'");
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
