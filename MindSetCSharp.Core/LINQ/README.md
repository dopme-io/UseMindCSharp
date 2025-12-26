# 📚 Módulo: LINQ

## Sobre LINQ

LINQ (**Language Integrated Query**) é um framework que oferece uma forma uniforme de consultar e manipular dados, independentemente da fonte (arrays, listas, bancos de dados, XML). É fundamental para programação funcional e manipulação de coleções em C#.

LINQ permite:
- ✅ Escrever consultas type-safe
- ✅ Repensar problemas de forma declarativa
- ✅ Código mais limpo e legível
- ✅ Melhor performance com lazy evaluation

---

## 🎯 Conceitos Fundamentais

### Sintaxe LINQ

#### Query Syntax (Sintaxe de Consulta)
```csharp
var resultado = from pessoa in pessoas
                where pessoa.Idade > 25
                orderby pessoa.Salario descending
                select new { pessoa.Nome, pessoa.Salario };
```

#### Method Syntax (Sintaxe de Método)
```csharp
var resultado = pessoas
    .Where(p => p.Idade > 25)
    .OrderByDescending(p => p.Salario)
    .Select(p => new { p.Nome, p.Salario });
```

### Lazy vs Eager Evaluation

```csharp
// Lazy (IEnumerable) - executa quando iterado
var lazy = numeros.Where(n => n > 10);
// Nada executa ainda!

var primeiro = lazy.First();  // Agora executa

// Eager (ToList) - executa imediatamente
var eager = numeros.Where(n => n > 10).ToList();
// Tudo executado agora!
```

---

## 📋 Operadores LINQ

### 1️⃣ Where (Filtro)

Seleciona elementos que atendem a uma condição.

```csharp
var pares = numeros.Where(n => n % 2 == 0);

// Múltiplos Where
var resultado = numeros
    .Where(n => n > 5)
    .Where(n => n < 20)
    .Where(n => n % 3 == 0);

// Com índice
var indices = numeros.Where((n, i) => i % 2 == 0);
```

---

### 2️⃣ Select (Projeção)

Transforma cada elemento em um novo formato.

```csharp
// Transformação simples
var quadrados = numeros.Select(n => n * n);

// Com índice
var comIndice = numeros.Select((n, i) => $"[{i}] = {n}");

// Tipo anônimo
var resumo = pessoas.Select(p => new { p.Nome, p.Idade });

// SelectMany (Flatten)
var todosItens = pedidos.SelectMany(p => p.Itens);
```

---

### 3️⃣ Ordenação

Organiza elementos segundo critério.

```csharp
// Crescente
var crescente = pessoas.OrderBy(p => p.Idade);

// Decrescente
var decrescente = pessoas.OrderByDescending(p => p.Salario);

// Múltiplos critérios
var multiplo = pessoas
    .OrderBy(p => p.Idade)
    .ThenBy(p => p.Salario);

// Inverter
var invertido = numeros.Reverse();
```

---

### 4️⃣ Agregação

Calcula valor baseado em todos elementos.

```csharp
var count = numeros.Count();
var countCond = numeros.Count(n => n > 10);

var soma = numeros.Sum();
var media = numeros.Average();

var minimo = numeros.Min();
var maximo = numeros.Max();

// Aggregate (Redução)
var produto = numeros.Aggregate(1, (acc, n) => acc * n);
var texto = palavras.Aggregate((a, b) => a + " " + b);
```

---

### 5️⃣ GroupBy (Agrupamento)

Agrupa elementos por chave.

```csharp
// Agrupamento simples
var porIdade = pessoas.GroupBy(p => p.Idade);

foreach (var grupo in porIdade)
{
    Console.WriteLine($"Idade {grupo.Key}:");
    foreach (var pessoa in grupo)
        Console.WriteLine($"  {pessoa.Nome}");
}

// Com agregação
var resumo = pessoas
    .GroupBy(p => p.Idade)
    .Select(g => new
    {
        Idade = g.Key,
        Quantidade = g.Count(),
        SalarioTotal = g.Sum(p => p.Salario)
    });

// Múltiplas chaves
var multiKey = pessoas.GroupBy(p => new { p.Idade, p.Departamento });
```

---

### 6️⃣ Join (Junção)

Combina dados de múltiplas coleções.

```csharp
// Inner Join
var vendas = departamentos
    .Join(
        funcionarios,
        d => d.Id,
        f => f.DepartamentoId,
        (d, f) => new { d.Nome, f.Nome }
    );

// Left Join (GroupJoin)
var todosDepart = departamentos
    .GroupJoin(
        funcionarios,
        d => d.Id,
        f => f.DepartamentoId,
        (d, fs) => new { Departamento = d, Funcionarios = fs }
    );

// Zip (Combinar dois arrays)
var nomes = new[] { "Alice", "Bob" };
var idades = new[] { 25, 30 };
var zipped = nomes.Zip(idades, (n, i) => $"{n} ({i})");
```

---

### 7️⃣ Adicionais

```csharp
// Distinct (Remover duplicatas)
var unicos = numeros.Distinct();

// OfType (Filtrar por tipo)
var apenasStrings = objetos.OfType<string>();

// Skip e Take (Paginação)
var pagina = pessoas.Skip(10).Take(5);

// First, FirstOrDefault, Last, Single
var primeiro = numeros.First();
var firstOr = numeros.FirstOrDefault(-1);
var ultimo = numeros.Last();
var unico = numeros.Single();

// Any e All
var temMaiores = numeros.Any(n => n > 100);
var todosMaiores = numeros.All(n => n > 0);

// Contains
var contem = numeros.Contains(5);

// Concat
var combinado = lista1.Concat(lista2);
```

---

## 💡 Boas Práticas

### ✅ O QUE FAZER

1. **Use query syntax para consultas complexas**
```csharp
// ✅ Bom - Fácil leitura
var resultado = from p in pessoas
                where p.Idade > 25
                orderby p.Salario
                group p by p.Departamento into g
                select new { g.Key, Count = g.Count() };
```

2. **Prefira method syntax para operações simples**
```csharp
// ✅ Bom - Conciso
var maiores = pessoas.Where(p => p.Idade > 25);
```

3. **Materialize quando necessário**
```csharp
// ✅ Bom - Se vai iterar múltiplas vezes
var lista = pessoas.Where(p => p.Idade > 25).ToList();
foreach (var p in lista) { /* ... */ }
foreach (var p in lista) { /* ... */ }  // Reutiliza lista
```

4. **Use lazy evaluation para dados grandes**
```csharp
// ✅ Bom - Processa sob demanda
var primeiros = pessoas
    .Where(p => p.Idade > 25)
    .Take(10);  // Só processa 10 elementos
```

5. **Combine Where antes de Select**
```csharp
// ✅ Bom - Filtra antes de projetar
var resultado = pessoas
    .Where(p => p.Idade > 25)
    .Select(p => new { p.Nome });
```

---

### ❌ O QUE EVITAR

1. **ToList desnecessário**
```csharp
// ❌ Ruim - Materializa tudo
var resultado = pessoas.Where(p => p.Idade > 25).ToList();
foreach (var p in resultado) { }  // Usa materializado

// ✅ Bom
foreach (var p in pessoas.Where(p => p.Idade > 25)) { }
```

2. **Múltiplos Where quando pode ser um**
```csharp
// ❌ Ruim
var resultado = pessoas.Where(p => p.Idade > 25).Where(p => p.Salario > 3000);

// ✅ Bom
var resultado = pessoas.Where(p => p.Idade > 25 && p.Salario > 3000);
```

3. **Select antes de Where**
```csharp
// ❌ Ruim - Projeta tudo depois filtra
var resultado = pessoas.Select(p => new { p.Nome, p.Idade }).Where(x => x.Idade > 25);

// ✅ Bom - Filtra depois projeta
var resultado = pessoas.Where(p => p.Idade > 25).Select(p => new { p.Nome, p.Idade });
```

4. **AsParallel para pequenas coleções**
```csharp
// ❌ Ruim - Overhead supera ganho
var resultado = pequenaLista.AsParallel().Select(ProcessarPesado).ToList();

// ✅ Bom - Use para coleções > 1000 elementos
var resultado = grandeLista.AsParallel().Select(ProcessarPesado).ToList();
```

---

## 🚀 Padrões Avançados

### 1. Query Syntax + Method Syntax
```csharp
var resultado = (from p in pessoas
                 where p.Idade > 25
                 select p)
                .OrderByDescending(p => p.Salario)
                .Take(10);
```

### 2. Aninhamento de SelectMany
```csharp
var todosItens = pedidos
    .SelectMany(p => p.Itens)
    .SelectMany(i => i.Detalhes);
```

### 3. Composição de Lambdas
```csharp
Func<IEnumerable<Pessoa>, IEnumerable<Pessoa>> filtroSenior = 
    p => p.Where(x => x.Idade > 30);

var resultado = filtroSenior(pessoas);
```

### 4. LINQ com Recursão
```csharp
public IEnumerable<T> Flatten<T>(IEnumerable<T> items, Func<T, IEnumerable<T>> children)
{
    foreach (var item in items)
    {
        yield return item;
        foreach (var child in Flatten(children(item), children))
            yield return child;
    }
}
```

---

## 📊 Comparação de Operadores

| Operador | Retorna | Uso | Exemplo |
|----------|---------|-----|---------|
| **Where** | IEnumerable | Filtrar | `Where(p => p.Idade > 25)` |
| **Select** | IEnumerable | Transformar | `Select(p => p.Nome)` |
| **OrderBy** | IOrderedEnumerable | Ordenar | `OrderBy(p => p.Idade)` |
| **GroupBy** | IEnumerable<IGrouping> | Agrupar | `GroupBy(p => p.Departamento)` |
| **Join** | IEnumerable | Juntar coleções | `Join(outra, ...)` |
| **Count** | int | Contar | `Count()` ou `Count(p => ...)` |
| **Sum** | número | Somar | `Sum(p => p.Salario)` |
| **First** | elemento | Primeiro | `First()` ou `FirstOrDefault()` |
| **Any** | bool | Existe algum | `Any(p => p.Idade > 30)` |
| **All** | bool | Todos | `All(p => p.Idade > 0)` |

---

## 🔍 Performance Tips

### Lazy vs Eager
```
Lazy (IEnumerable):  Executa sob demanda, economiza memória
Eager (ToList):      Materializa tudo, usa mais memória mas é rápido
```

### OrderBy Placement
```
Bom:    Where() → Select() → OrderBy() → Take()
Ruim:   OrderBy() → Where() → Select() → Take()
```

### AsParallel Usage
```
Bom:    Coleções > 1000 elementos
Ruim:   Coleções pequenas
Cuidado: Overhead pode ser maior que ganho
```

---

## 📚 Recursos Adicionais

- 📖 [Microsoft - LINQ](https://docs.microsoft.com/pt-br/dotnet/csharp/linq/)
- 📖 [LINQ Operators](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable)
- 📖 [Query Syntax](https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq)

---

## ✅ Checklist de Aprendizado

- [ ] Entendo a diferença entre Query e Method syntax
- [ ] Consigo usar Where para filtrar coleções
- [ ] Domino Select para transformações
- [ ] Aplico OrderBy e ThenBy
- [ ] Uso GroupBy para agrupamentos
- [ ] Implemento Join corretamente
- [ ] Entendo lazy evaluation
- [ ] Consigo otimizar queries LINQ
- [ ] Uso AsParallel quando apropriado
- [ ] Combino múltiplos operadores

---

## 🎓 Próximos Passos

Após dominar LINQ, explore:
1. **LINQ to SQL** - Consultas em bancos de dados
2. **Entity Framework** - ORM com LINQ
3. **LINQ to XML** - Manipulação de XML
4. **IAsyncEnumerable** - Streams assíncronos
5. **Expression Trees** - Consultas dinâmicas

---

## 📝 Dicas Finais

1. **Sempre pense em transformações de dados** - LINQ é sobre mudança de forma
2. **Lazy evaluation economiza recursos** - Não materialize sem necessidade
3. **OrderBy é caro** - Faça-o o mais tarde possível
4. **GroupBy retorna grupos** - Use Select após para transformar
5. **Join é eficiente** - Melhor que nested loops

---

**Última atualização:** 2024
**Versão:** 1.0
