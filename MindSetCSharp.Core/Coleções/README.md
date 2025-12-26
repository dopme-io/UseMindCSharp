# 📚 Módulo de Coleções em C#

## 📌 Visão Geral

Este módulo explora as principais estruturas de dados para armazenar e manipular grupos de objetos em C#. As coleções são fundamentais para organizar e gerenciar dados de forma eficiente.

## 🎯 Objetivos de Aprendizado

- Compreender as diferenças entre os tipos de coleções
- Saber quando usar cada tipo de coleção
- Dominar operações comuns em coleções
- Entender conceitos de performance
- Aplicar coleções em cenários práticos

## 📖 Conteúdo

### 1️⃣ Arrays
**Descrição**: Coleções de tamanho fixo e tipo único.

**Características**:
- Tamanho fixo definido na criação
- Acesso por índice super rápido (O(1))
- Podem ser unidimensionais, multidimensionais ou jagged
- Tipo mais básico de coleção

**Quando usar**:
- Quantidade de elementos conhecida e fixa
- Necessidade de acesso rápido por índice
- Operações com matriz de dados

**Exemplo**:
```csharp
int[] numeros = { 1, 2, 3, 4, 5 };
string[] nomes = new string[10];
int[,] matriz = new int[3, 3];
```

### 2️⃣ List\<T\>
**Descrição**: Lista dinâmica que pode crescer ou diminuir.

**Características**:
- Tamanho dinâmico
- Acesso por índice
- Permite duplicatas
- Mantém a ordem de inserção
- Tipo genérico (type-safe)

**Quando usar**:
- Quantidade de elementos desconhecida ou variável
- Necessidade de adicionar/remover elementos frequentemente
- Ordem dos elementos importa
- Acesso por índice necessário

**Exemplo**:
```csharp
var lista = new List<string>();
lista.Add("Item 1");
lista.Remove("Item 1");
bool contem = lista.Contains("Item 1");
```

### 3️⃣ Dictionary<TKey, TValue>
**Descrição**: Coleção de pares chave-valor para acesso rápido.

**Características**:
- Acesso por chave (O(1) em média)
- Chaves únicas
- Valores podem ser duplicados
- Não mantém ordem específica

**Quando usar**:
- Necessidade de busca rápida por chave
- Associação de dados (como cache)
- Mapeamento de valores

**Exemplo**:
```csharp
var dict = new Dictionary<int, string>();
dict[1] = "Um";
dict.Add(2, "Dois");
string valor = dict[1];
bool existe = dict.ContainsKey(1);
```

### 4️⃣ HashSet\<T\>
**Descrição**: Conjunto de valores únicos sem ordem.

**Características**:
- Não permite duplicatas
- Verificação de existência muito rápida (O(1))
- Suporta operações de conjunto (união, interseção, diferença)
- Não mantém ordem

**Quando usar**:
- Necessidade de garantir valores únicos
- Verificação rápida de existência
- Operações de teoria de conjuntos
- Remover duplicatas

**Exemplo**:
```csharp
var conjunto = new HashSet<int> { 1, 2, 3 };
conjunto.Add(4); // true
conjunto.Add(1); // false (já existe)
conjunto.UnionWith(outroConjunto);
conjunto.IntersectWith(outroConjunto);
```

### 5️⃣ Queue\<T\>
**Descrição**: Fila que segue o princípio FIFO (First In, First Out).

**Características**:
- Primeiro a entrar, primeiro a sair
- Enqueue para adicionar
- Dequeue para remover
- Peek para visualizar sem remover

**Quando usar**:
- Processamento em ordem de chegada
- Sistemas de filas de atendimento
- Buffer de tarefas
- Breadth-First Search (BFS)

**Exemplo**:
```csharp
var fila = new Queue<string>();
fila.Enqueue("Primeiro");
fila.Enqueue("Segundo");
string proximo = fila.Peek(); // "Primeiro"
string atendido = fila.Dequeue(); // "Primeiro"
```

### 6️⃣ Stack\<T\>
**Descrição**: Pilha que segue o princípio LIFO (Last In, First Out).

**Características**:
- Último a entrar, primeiro a sair
- Push para adicionar
- Pop para remover
- Peek para visualizar sem remover

**Quando usar**:
- Operações de desfazer/refazer
- Avaliação de expressões
- Navegação de histórico
- Depth-First Search (DFS)
- Verificação de sintaxe (parênteses balanceados)

**Exemplo**:
```csharp
var pilha = new Stack<int>();
pilha.Push(1);
pilha.Push(2);
int topo = pilha.Peek(); // 2
int removido = pilha.Pop(); // 2
```

### 7️⃣ LinkedList\<T\>
**Descrição**: Lista duplamente encadeada.

**Características**:
- Inserção/remoção eficiente em qualquer posição (O(1))
- Navegação bidirecional (frente e trás)
- Sem acesso por índice
- Mais memória que List<T>

**Quando usar**:
- Inserções/remoções frequentes no meio da lista
- Implementação de outras estruturas (fila, pilha)
- Quando acesso por índice não é necessário

**Exemplo**:
```csharp
var lista = new LinkedList<string>();
lista.AddFirst("Primeiro");
lista.AddLast("Último");
var no = lista.Find("Primeiro");
lista.AddAfter(no, "Novo");
```

## 🎯 Tabela Comparativa

| Coleção | Ordem | Duplicatas | Acesso | Busca | Inserção | Uso Principal |
|---------|-------|------------|--------|-------|----------|---------------|
| Array | ✅ | ✅ | O(1) | O(n) | N/A | Tamanho fixo |
| List<T> | ✅ | ✅ | O(1) | O(n) | O(1)* | Lista dinâmica |
| Dictionary | ❌ | Chaves ❌, Valores ✅ | O(1) | O(1) | O(1) | Busca por chave |
| HashSet | ❌ | ❌ | N/A | O(1) | O(1) | Valores únicos |
| Queue | ✅ | ✅ | O(n) | O(n) | O(1) | FIFO |
| Stack | ✅ | ✅ | O(n) | O(n) | O(1) | LIFO |
| LinkedList | ✅ | ✅ | O(n) | O(n) | O(1) | Inserção eficiente |

*List<T>: O(1) amortizado no final, O(n) no início/meio

## 💡 Melhores Práticas

### 1. Escolha a Coleção Certa
```csharp
// ✅ Bom: HashSet para verificar duplicatas
var emails = new HashSet<string>();
bool jaExiste = emails.Contains("user@email.com");

// ❌ Ruim: List para verificar duplicatas (lento)
var emails = new List<string>();
bool jaExiste = emails.Contains("user@email.com"); // O(n)
```

### 2. Use Capacidade Inicial Quando Conhecido
```csharp
// ✅ Bom: Define capacidade inicial
var lista = new List<int>(1000);

// ❌ Menos eficiente: Vai redimensionar várias vezes
var lista = new List<int>();
```

### 3. Use LINQ com Sabedoria
```csharp
// ✅ Bom: Filtra antes de converter
var resultado = lista
    .Where(x => x > 10)
    .ToList();

// ❌ Ruim: Converte tudo antes de filtrar
var resultado = lista
    .ToList()
    .Where(x => x > 10);
```

### 4. Dictionary vs List para Buscas
```csharp
// ✅ Bom: Dictionary para buscas frequentes por chave
var usuarios = new Dictionary<int, Usuario>();
var usuario = usuarios[123]; // O(1)

// ❌ Ruim: List para buscas frequentes
var usuarios = new List<Usuario>();
var usuario = usuarios.Find(u => u.Id == 123); // O(n)
```

### 5. Inicialização de Coleções
```csharp
// ✅ Bom: Inicialização concisa
var numeros = new List<int> { 1, 2, 3, 4, 5 };
var dict = new Dictionary<string, int>
{
    ["Um"] = 1,
    ["Dois"] = 2
};

// Collection Expression (C# 12+)
int[] numeros = [1, 2, 3, 4, 5];
```

## 🔍 Cenários Práticos

### Cache de Dados
```csharp
// Dictionary para cache rápido
var cache = new Dictionary<string, object>();
```

### Remover Duplicatas
```csharp
// HashSet para valores únicos
var unicos = new HashSet<string>(listaComDuplicatas);
```

### Fila de Processamento
```csharp
// Queue para tarefas
var filaTrabalho = new Queue<Tarefa>();
```

### Histórico de Navegação
```csharp
// Stack para histórico
var historico = new Stack<Pagina>();
```

### Lista de Tarefas Ordenada
```csharp
// List com ordenação
var tarefas = new List<Tarefa>();
tarefas.Sort((a, b) => a.Prioridade.CompareTo(b.Prioridade));
```

## 📚 Recursos Adicionais

- [Collections (C#) - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections)
- [System.Collections.Generic Namespace](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic)
- [Big-O Complexity Chart](https://www.bigocheatsheet.com/)

## ✅ Checklist de Aprendizado

- [ ] Entendo a diferença entre Array e List<T>
- [ ] Sei quando usar Dictionary vs List
- [ ] Compreendo o conceito de HashSet e suas operações
- [ ] Conheço a diferença entre Queue (FIFO) e Stack (LIFO)
- [ ] Sei quando usar LinkedList<T>
- [ ] Entendo complexidade de operações (Big-O)
- [ ] Consigo escolher a coleção adequada para cada cenário
- [ ] Domino operações comuns (Add, Remove, Contains, etc.)
- [ ] Sei usar LINQ com coleções
- [ ] Compreendo questões de performance

---

**Próximos Passos**: Explore o módulo LINQ para manipulação avançada de coleções!
