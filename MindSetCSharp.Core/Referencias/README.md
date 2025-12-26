# 📚 Módulo de Referências em C#

## 📌 Visão Geral

Este módulo explora um dos conceitos mais fundamentais de C#: a diferença entre tipos de valor e tipos de referência. Compreender como C# gerencia memória é essencial para escrever código eficiente e evitar bugs sutis.

## 🎯 Objetivos de Aprendizado

- Compreender tipos de valor vs tipos de referência
- Entender Stack e Heap
- Dominar comparações de referências
- Trabalhar com parâmetros ref, out, in
- Lidar com valores nulos corretamente
- Gerenciar recursos e Garbage Collection
- Realizar cloning de objetos

## 📖 Conteúdo

### 1️⃣ Tipos de Valor vs Tipos de Referência

#### Tipos de Valor (Value Types)
**Características**:
- Armazenados no Stack
- Copiam o valor, não a referência
- Cada variável tem sua própria cópia
- Mudanças em uma cópia não afetam outras
- Mais eficientes em memória (tamanho fixo)

**Exemplos**:
```csharp
int numero = 10;
double preco = 19.99;
bool ativo = true;
char letra = 'A';
struct Ponto { int X; int Y; }
enum Status { Ativo, Inativo }
```

#### Tipos de Referência (Reference Types)
**Características**:
- Armazenados no Heap
- Copiam a referência, não o objeto
- Múltiplas variáveis podem apontar para o mesmo objeto
- Mudanças afetam todas as referências
- Gerenciados por Garbage Collection

**Exemplos**:
```csharp
class Pessoa { string Nome; }
string texto = "Hello";
int[] numeros = { 1, 2, 3 };
List<int> lista = new();
object obj = new();
```

#### Comparação
```
┌──────────────────┬──────────────────────────────────────────┐
│  Tipo de Valor   │       Tipo de Referência                 │
├──────────────────┼──────────────────────────────────────────┤
│ int a = 5;       │ var p = new Pessoa("João");              │
│ int b = a;       │ var p2 = p;                              │
│                  │                                          │
│ a: 5             │ p:  0xABC123 ──→ [Nome: "João"]         │
│ b: 5             │ p2: 0xABC123 ──┘  [Idade: 30]           │
│                  │                                          │
│ b = 10;          │ p2.Nome = "Maria";                       │
│ a: 5 (inalterado)│ p.Nome = "Maria" (mudou também!)        │
│ b: 10            │                                          │
└──────────────────┴──────────────────────────────────────────┘
```

### 2️⃣ Stack vs Heap

#### Stack (Pilha)
- **Localização**: Memória linear, LIFO
- **Conteúdo**: Tipos de valor + referências
- **Gerenciamento**: Automático (removido ao sair do escopo)
- **Velocidade**: Muito rápido
- **Tamanho**: Limitado
- **Ordem**: Remove em ordem reversa (LIFO)

**Exemplo**:
```csharp
void Exemplo() {
    int x = 10;      // [Stack] x: 10
    double y = 5.5;  // [Stack] y: 5.5
    string nome = "João"; // [Stack] nome: 0xABC123
                     //     [Heap] "João"
} // Stack é limpo automaticamente
```

#### Heap (Montículo)
- **Localização**: Memória dinâmica
- **Conteúdo**: Objetos (tipos de referência)
- **Gerenciamento**: Garbage Collection
- **Velocidade**: Mais lento que Stack
- **Tamanho**: Maior quantidade de memória
- **Ordem**: Não ordenado

**Visualização**:
```
Stack                    Heap
┌────────────┐        ┌──────────────┐
│ idade: 25  │        │ Pessoa       │
│ nome: 0x1  │───────→│ Nome: "Ana"  │
│ lista: 0x2 │───┐    │ Idade: 25    │
└────────────┘   │    └──────────────┘
                 │
                 │    ┌──────────────┐
                 └───→│ [1, 2, 3]    │
                      │ Capacity: 10 │
                      └──────────────┘
```

### 3️⃣ Comparação de Objetos

#### == (Igualdade de Referência)
```csharp
var p1 = new Pessoa("João");
var p2 = new Pessoa("João");
var p3 = p1;

p1 == p2  // false - referências diferentes
p1 == p3  // true - mesma referência
```

#### Equals() (Igualdade de Valor)
```csharp
p1.Equals(p2) // true - mesmo conteúdo (se implementado)
p1.Equals(p3) // true - mesmo objeto
```

#### ReferenceEquals() (Identidade)
```csharp
ReferenceEquals(p1, p2) // false
ReferenceEquals(p1, p3) // true
```

### 4️⃣ Parâmetros de Método

#### Parâmetro Normal (por Valor)
```csharp
void Duplicar(int numero) {
    numero *= 2; // Não afeta a variável original
}

int x = 10;
Duplicar(x);
Console.WriteLine(x); // 10 (inalterado)
```

#### Parâmetro ref (por Referência)
```csharp
void DuplicarRef(ref int numero) {
    numero *= 2; // Afeta a variável original
}

int x = 10;
DuplicarRef(ref x);
Console.WriteLine(x); // 20 (foi alterado)
```

#### Parâmetro out (Saída)
```csharp
bool Dividir(int a, int b, out int resultado) {
    resultado = 0;
    if (b == 0) return false;
    resultado = a / b;
    return true;
}

Dividir(10, 2, out int res); // res = 5
```

#### Parâmetro in (Somente Leitura)
```csharp
void Exibir(in Pessoa pessoa) {
    Console.WriteLine(pessoa.Nome);
    // pessoa = new Pessoa(...); // Erro!
}
```

### 5️⃣ Null e Null Coalescing

#### Null Coalescing (??)
```csharp
string nome = null;
string exibicao = nome ?? "Anônimo"; // "Anônimo"

nome = "João";
exibicao = nome ?? "Anônimo"; // "João"
```

#### Null Conditional (?.)
```csharp
Pessoa? pessoa = null;
string? nome = pessoa?.Nome; // null (não lança exceção)

pessoa = new Pessoa("João");
nome = pessoa?.Nome; // "João"
```

#### Null Coalescing Assignment (??=)
```csharp
string nome = null;
nome ??= "Padrão"; // nome = "Padrão"

nome ??= "Outro"; // nome mantém "Padrão"
```

### 6️⃣ Cloning de Objetos

#### Shallow Copy (Cópia Rasa)
- Copia apenas a referência
- Ambas as variáveis apontam para o mesmo objeto
- Mudanças afetam ambas

```csharp
var original = new Pessoa("João");
var copia = original; // Shallow copy

copia.Nome = "Maria";
Console.WriteLine(original.Nome); // "Maria" (mudou!)
```

#### Deep Copy (Cópia Profunda)
- Cria um novo objeto com os mesmos valores
- Variáveis são independentes
- Mudanças não afetam o original

```csharp
var original = new Pessoa("João");
var copia = new Pessoa(original.Nome); // Deep copy

copia.Nome = "Maria";
Console.WriteLine(original.Nome); // "João" (inalterado)
```

#### MemberwiseClone()
```csharp
public Pessoa Clonar() {
    return (Pessoa)MemberwiseClone();
}
```

### 7️⃣ Garbage Collection

#### Como Funciona
1. **Alocação**: Objetos são criados no Heap
2. **Rastreamento**: GC monitora referências
3. **Coleta**: Objetos sem referências são removidos
4. **Compactação**: Memória é reorganizada

#### Gerações
```
┌─────────────────────────────────┐
│  Geração 0: Objetos novos       │ ← Coletados frequentemente
├─────────────────────────────────┤
│  Geração 1: Objetos sobreviventes│
├─────────────────────────────────┤
│  Geração 2: Objetos antigos     │ ← Coletados raramente
└─────────────────────────────────┘
```

#### IDisposable
```csharp
public class Recurso : IDisposable {
    public void Dispose() {
        // Liberar recursos (arquivos, conexões)
        GC.SuppressFinalize(this);
    }
    
    ~Recurso() {
        Dispose();
    }
}

// Uso
using (var recurso = new Recurso()) {
    // Usar recurso
} // Dispose() é chamado automaticamente
```

### 8️⃣ Mutabilidade

#### Tipos Mutáveis
- Podem ser modificados após criação
- Exemplo: class, List<T>, Dictionary<K,V>

```csharp
var lista = new List<int> { 1, 2 };
lista.Add(3); // Modifica
```

#### Tipos Imutáveis
- Não podem ser modificados após criação
- Exemplo: string, int, DateTime

```csharp
string texto = "Hello";
string novo = texto + " World"; // Cria nova string
// texto ainda é "Hello"
```

## 💡 Melhores Práticas

### 1. Use ref/out com Cuidado
```csharp
// ✅ Bom: Métodos retornam valores
int Calcular() => 10 * 20;

// ❌ Ruim: Modificar parâmetro ref confunde
void Processar(ref int valor) { valor = -1; }
```

### 2. Prefira Null Conditional a Null Check
```csharp
// ✅ Bom
int? idade = pessoa?.Idade;

// ❌ Menos elegante
int? idade = null;
if (pessoa != null) {
    idade = pessoa.Idade;
}
```

### 3. Use using para Recursos
```csharp
// ✅ Bom
using (var arquivo = new StreamReader("file.txt")) {
    string conteudo = arquivo.ReadToEnd();
}

// ❌ Ruim: Pode não liberar recurso
var arquivo = new StreamReader("file.txt");
string conteudo = arquivo.ReadToEnd();
```

### 4. Implemente IDisposable Corretamente
```csharp
public class MinhaClasse : IDisposable {
    private bool _disposed = false;
    
    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing) {
        if (!_disposed) {
            if (disposing) {
                // Liberar recursos gerenciados
            }
            // Liberar recursos não gerenciados
            _disposed = true;
        }
    }
    
    ~MinhaClasse() {
        Dispose(false);
    }
}
```

## 🔗 Comparação Rápida

```
Conceito              Tipo de Valor    Tipo de Referência
───────────────────────────────────────────────────────
Localização           Stack            Heap
Cópia                 Valor            Referência
Velocidade            Rápida           Mais lenta
Tamanho Fixo          Sim              Não
Garbage Collection    Não              Sim
Pode ser null         Não (exceto ?)   Sim
Exemplo               int, struct      class, string
```

## ✅ Checklist de Aprendizado

- [ ] Entendo a diferença entre Stack e Heap
- [ ] Sei quando usar tipos de valor vs referência
- [ ] Consigo comparar objetos corretamente
- [ ] Entendo ref, out, in
- [ ] Domino null coalescing e conditional
- [ ] Consigo fazer cloning corretamente
- [ ] Entendo Garbage Collection
- [ ] Implemento IDisposable quando necessário
- [ ] Sei quando objetos precisam de mutabilidade
- [ ] Consigo evitar memory leaks

## 📚 Recursos Adicionais

- [Reference Types - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types)
- [Value Types - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types)
- [Garbage Collection - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/)
- [Memory in C# - YouTube Tutorial](https://www.youtube.com/watch?v=qG6I56eajKU)

---

**Próximos Passos**: Compreenda bem este módulo antes de avançar para tópicos mais avançados. Referencias e gerenciamento de memória são fundamentais!
