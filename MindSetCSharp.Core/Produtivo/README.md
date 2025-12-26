# 📚 Módulo: Produtivo

## Sobre Produtividade em C#

Produtividade não é apenas escrever mais código, é escrever **melhor código, mais rápido**. Este módulo cobre técnicas avançadas e padrões modernos do C# para maximizar sua eficiência e qualidade de desenvolvimento.

Estas técnicas permitem:
- ✅ Escrever código mais limpo e conciso
- ✅ Resolver problemas complexos com elegância
- ✅ Melhorar performance com processamento paralelo
- ✅ Aproveitar recursos modernos do C#

---

## 🎯 Conceitos Fundamentais

### LINQ (Language Integrated Query)
```csharp
// Filtrar, ordenar e transformar em uma expressão
var maiores20 = numeros
    .Where(n => n > 20)
    .OrderBy(n => n)
    .Select(n => n * 2)
    .ToList();
```

### Lambda Expressions
```csharp
// Funções anônimas concisas
Func<int, int> dobrar = x => x * 2;
var resultado = numeros.Select(dobrar).ToList();
```

### Extension Methods
```csharp
public static string Capitalizar(this string texto)
{
    return char.ToUpper(texto[0]) + texto.Substring(1).ToLower();
}

// Uso: "olá".Capitalizar() => "Olá"
```

### Pattern Matching
```csharp
var mensagem = valor switch
{
    int i => $"É um inteiro: {i}",
    string s => $"É texto: {s}",
    _ => "Desconhecido"
};
```

---

## 📋 Oito Técnicas Essenciais

### 1️⃣ LINQ Avançado

#### Group By (Agrupamento)
```csharp
var porCategoria = produtos
    .GroupBy(p => p.Categoria)
    .Select(g => new
    {
        Categoria = g.Key,
        Quantidade = g.Count(),
        PreçoTotal = g.Sum(p => p.Preco)
    });
```

#### Join (Junção)
```csharp
var vendas = produtos
    .Join(pedidos,
        p => p.Id,
        pd => pd.ProdutoId,
        (p, pd) => new { p.Nome, pd.Quantidade });
```

#### SelectMany (Achatamento)
```csharp
var todosItens = pedidos
    .SelectMany(p => p.Itens) // Flatten
    .ToList();
```

---

### 2️⃣ Lambda Expressions

#### Func e Action
```csharp
// Func retorna valor
Func<int, int, int> somar = (a, b) => a + b;
somar(5, 3); // => 8

// Action não retorna
Action<string> escrever = msg => Console.WriteLine(msg);
escrever("Olá"); // Imprime "Olá"
```

#### Predicados
```csharp
Func<int, bool> éPar = n => n % 2 == 0;
var pares = numeros.Where(éPar);
```

---

### 3️⃣ Extension Methods

#### Criar Extensions
```csharp
public static class StringExtensions
{
    public static int ContarPalavras(this string texto)
    {
        return texto.Split(' ').Length;
    }
}

// Uso
"Hello World".ContarPalavras(); // => 2
```

#### Vantagens
- Estende tipos existentes sem herança
- Torna código mais legível
- Funciona como métodos nativos

---

### 4️⃣ Pattern Matching (C# 7+)

#### Type Patterns
```csharp
object valor = 42;
var resultado = valor switch
{
    int i => $"Inteiro: {i}",
    string s => $"Texto: {s}",
    null => "Nulo",
    _ => "Outro"
};
```

#### Property Patterns
```csharp
var categoria = pessoa switch
{
    { Idade: >= 30, Salario: >= 5000 } => "Senior bem pago",
    { Idade: >= 30 } => "Senior",
    _ => "Junior"
};
```

#### Relational Patterns
```csharp
var faixa = idade switch
{
    < 13 => "Criança",
    < 18 => "Adolescente",
    < 60 => "Adulto",
    _ => "Idoso"
};
```

---

### 5️⃣ Task Parallel Library (TPL)

#### Parallel.For
```csharp
Parallel.For(0, 1000, i =>
{
    Processar(i); // Executa em paralelo
});
```

#### PLINQ
```csharp
var quadrados = numeros
    .AsParallel()
    .Select(n => n * n)
    .OrderBy(n => n)
    .ToList();
```

#### Task.WaitAll
```csharp
var tarefas = new[]
{
    Task.Run(() => Operacao1()),
    Task.Run(() => Operacao2()),
    Task.Run(() => Operacao3())
};

Task.WaitAll(tarefas);
```

---

### 6️⃣ Async/Await

#### Operações Assíncronas
```csharp
public async Task<string> FetchDadosAsync()
{
    var resposta = await httpClient.GetAsync("api/dados");
    return await resposta.Content.ReadAsStringAsync();
}

// Usar
var resultado = await FetchDadosAsync();
```

#### Task.WhenAll (Múltiplas operações)
```csharp
var tarefas = urls.Select(url => FetchAsync(url));
var resultados = await Task.WhenAll(tarefas);
```

---

### 7️⃣ Records (C# 9+)

#### Definição
```csharp
public record Pessoa(string Nome, int Idade);

// Uso
var p1 = new Pessoa("Alice", 30);
var p2 = p1 with { Idade = 31 }; // Cópia com modificação
```

#### Benefícios
- Imutabilidade por padrão
- Value equality automática
- With expressions para cópias
- ToString melhorado

---

### 8️⃣ Programação Funcional

#### Composição
```csharp
Func<int, int> dobrar = x => x * 2;
Func<int, int> adicionar5 = x => x + 5;
Func<int, int> composta = x => adicionar5(dobrar(x));

composta(10); // => 25
```

#### Pipeline
```csharp
var resultado = dados
    .Where(x => x > 0)
    .Select(x => x * 2)
    .OrderBy(x => x)
    .Take(10)
    .ToList();
```

#### Currying
```csharp
Func<int, Func<int, int>> adicionarCurryfied = 
    a => b => a + b;

var add5 = adicionarCurryfied(5);
var resultado = add5(3); // => 8
```

---

## 💡 Boas Práticas

### ✅ O QUE FAZER

1. **Use LINQ para operações em coleções**
```csharp
// ✅ Bom
var resultado = lista.Where(x => x > 10).OrderBy(x => x).ToList();
```

2. **Prefira lambdas para callbacks**
```csharp
// ✅ Bom
numeros.ForEach(n => Console.WriteLine(n));
```

3. **Crie extension methods úteis**
```csharp
// ✅ Bom
public static string Truncar(this string texto, int comprimento) => 
    texto.Length > comprimento ? texto.Substring(0, comprimento) + "..." : texto;
```

4. **Use pattern matching para lógica complexa**
```csharp
// ✅ Bom
var descricao = pessoa switch
{
    { Idade: < 18 } => "Menor",
    { Salario: > 10000 } => "Bem remunerado",
    _ => "Outro"
};
```

5. **Paralelizar operações pesadas**
```csharp
// ✅ Bom
var resultado = lista.AsParallel().Select(ProcessarPesado).ToList();
```

---

### ❌ O QUE EVITAR

1. **Loops simples quando LINQ é mais limpo**
```csharp
// ❌ Ruim
var maiores = new List<int>();
foreach (var n in numeros)
    if (n > 10) maiores.Add(n);

// ✅ Bom
var maiores = numeros.Where(n => n > 10).ToList();
```

2. **Lambdas muito complexas (extract método)**
```csharp
// ❌ Ruim
numeros.Where(n => {
    var temp = n * 2;
    var resultado = temp > 20 && temp < 100;
    return resultado;
}).ToList();

// ✅ Bom
bool Filtro(int n) => (n * 2) > 20 && (n * 2) < 100;
var resultado = numeros.Where(Filtro).ToList();
```

3. **ToList() desnecessário**
```csharp
// ❌ Ruim
var maiores = numeros.Where(n => n > 10).ToList();
foreach (var n in maiores) { } // Materializa desnecessário

// ✅ Bom
foreach (var n in numeros.Where(n => n > 10)) { } // Lazy evaluation
```

4. **Paralelizar quando sequencial é melhor**
```csharp
// ❌ Ruim
var quadrados = numeros.AsParallel().Select(n => n * n).ToList(); // Overhead de paralelismo

// ✅ Bom
var quadrados = numeros.Select(n => n * n).ToList(); // Simples e rápido
```

---

## 📊 Comparação de Técnicas

| Situação | Técnica | Motivo |
|----------|--------|--------|
| Filtrar coleção | LINQ Where() | Sintaxe limpa, legível |
| Transformar dados | LINQ Select() | Composição funcional |
| Agrupar dados | LINQ GroupBy() | Query-like syntax |
| Callback simples | Lambda | Conciso, inline |
| Lógica complexa | Pattern matching | Mais legível que if/else |
| Múltiplas threads | Task/Async | Não bloqueia |
| Processamento pesado | PLINQ | Paraleliza automático |

---

## 🚀 Padrões Avançados

### 1. Maybe Pattern (Null Safety)
```csharp
public static class Maybe
{
    public static T? Apply<T>(this T? value, Func<T, T> func) =>
        value != null ? func(value) : default;
}

// Uso
var resultado = pessoa?.Nome
    .Apply(n => n.ToUpper())
    .Apply(n => n + "!");
```

### 2. Builder Pattern com Records
```csharp
var config = new ConfigBuilder()
    .ComHost("localhost")
    .ComPort(8080)
    .Build();
```

### 3. Repository Pattern com LINQ
```csharp
public class Repository<T> where T : class
{
    public IEnumerable<T> Find(Func<T, bool> predicate) =>
        dbContext.Set<T>().Where(predicate);
}
```

---

## 📚 Recursos Adicionais

- 📖 [Microsoft - LINQ](https://docs.microsoft.com/pt-br/dotnet/csharp/linq/)
- 📖 [C# Pattern Matching](https://docs.microsoft.com/pt-br/dotnet/csharp/fundamentals/functional/pattern-matching)
- 📖 [Async Programming](https://docs.microsoft.com/pt-br/dotnet/csharp/async)
- 📖 [Records (C# 9)](https://docs.microsoft.com/pt-br/dotnet/csharp/fundamentals/types/records)

---

## ✅ Checklist de Aprendizado

- [ ] Entendo LINQ e sua sintaxe
- [ ] Consigo usar GroupBy e Join
- [ ] Sei criar lambda expressions
- [ ] Implementei extension methods
- [ ] Uso pattern matching corretamente
- [ ] Entendo Parallel e PLINQ
- [ ] Consigo usar async/await
- [ ] Criei records com properties
- [ ] Entendo composição funcional
- [ ] Sei quando usar cada técnica

---

## 🎓 Próximos Passos

Após dominar produtividade, explore:
1. **Reflection** - Análise de tipos em runtime
2. **Expression Trees** - Consultas dinâmicas
3. **Source Generators** - Código gerado em compile-time
4. **IAsyncEnumerable** - Streams assíncronos

---

## 📝 Dicas Finais

1. **LINQ é preguiçoso** - Use `.ToList()` quando precisar materializar
2. **Teste performance** - O parallelismo nem sempre é mais rápido
3. **Lambdas complexas** - Extract método para melhor legibilidade
4. **Records imutáveis** - Prefer records para DTOs e dados
5. **Async por padrão** - Use async/await para I/O

---

**Última atualização:** 2024
**Versão:** 1.0
