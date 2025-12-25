# Módulo Tipos - Sistema de Tipos do C#

## 📖 Visão Geral

Este módulo explora o **sistema de tipos** do C#, abordando tipos de valor vs referência, tipos primitivos, nullable, conversões, boxing/unboxing, dynamic e muito mais.

## 🎯 Objetivos de Aprendizado

- Compreender tipos de valor vs tipos de referência
- Conhecer todos os tipos primitivos e seus limites
- Trabalhar com tipos nullable (anuláveis)
- Realizar conversões seguras entre tipos
- Entender boxing e unboxing
- Usar tipo dynamic apropriadamente
- Aplicar tuplas para retornos múltiplos
- Escolher entre struct e class

## 📁 Arquivos do Módulo

### `TiposBasicos.cs`
Fundamentos do sistema de tipos:

**`TiposValorReferencia`**
- Demonstração visual da diferença entre struct e class
- Cópia por valor vs cópia por referência
- Comportamento na stack vs heap

**`TiposPrimitivos`**
- Todos os tipos primitivos com seus limites
- Inteiros: sbyte, byte, short, ushort, int, uint, long, ulong
- Ponto flutuante: float, double, decimal
- Outros: bool, char, string
- Tipo object como base universal

### `TiposNullable.cs`
Tipos que aceitam valores null:

**Características:**
- Sintaxe: `int?` ou `Nullable<int>`
- Propriedades: HasValue, Value, GetValueOrDefault
- Operadores: `??` (null-coalescing), `?.` (null-conditional)
- Nullable reference types (C# 8+)

**Classe `Usuario`:**
- Exemplo prático com campos opcionais
- Demonstra quando usar nullable

### `ConversoesCasting.cs`
Conversões entre tipos:

**Tipos de conversão:**
- **Implícita**: automática, sem perda de dados
- **Explícita**: manual (cast), pode haver perda
- **Métodos**: ToString, Parse, TryParse, Convert
- **Boxing/Unboxing**: valor ↔ object

**Classes `Celsius` e `Fahrenheit`:**
- Operadores de conversão personalizados
- explicit operator e implicit operator

**`TipoDynamic`:**
- Tipo determinado em runtime
- Vantagens e desvantagens
- Quando (não) usar

### `ExemplosTipos.cs`
Oito exemplos práticos:

1. **ExemploStructVsClass()** - Comportamento diferente
2. **ExemploTiposPrimitivos()** - Todos os tipos básicos
3. **ExemploNullable()** - Valores opcionais
4. **ExemploConversoes()** - Casting e conversões
5. **ExemploDynamic()** - Tipo dinâmico
6. **ExemploTuplas()** - Retornos múltiplos
7. **ExemploPerformance()** - Benchmark struct vs class
8. **ExemploTipoObject()** - Base universal

## 🚀 Como Executar

### Executar todos os exemplos:
```powershell
dotnet run --project MindSetCSharp.Console
```

### Executar apenas este módulo:
```csharp
using MindSetCSharp.Core.Tipos;

TiposModule.Run();
```

## 💡 Conceitos-Chave

### 1. Tipos de Valor vs Tipos de Referência

#### Tipos de Valor (Value Types - struct)
```csharp
// STRUCT - Tipo de valor
public struct Ponto
{
    public int X { get; set; }
    public int Y { get; set; }
}

var p1 = new Ponto { X = 10, Y = 20 };
var p2 = p1;  // COPIA os valores

p2.X = 999;   // Muda apenas p2
Console.WriteLine(p1.X);  // 10 ✅ p1 não mudou!
```

**Características:**
- Armazenado na **stack** (pilha)
- Cópia cria **nova instância independente**
- **Não pode ser null** (exceto Nullable)
- Sem herança (apenas interfaces)
- Melhor performance para dados pequenos
- Exemplos: int, bool, DateTime, structs customizados

#### Tipos de Referência (Reference Types - class)
```csharp
// CLASS - Tipo de referência
public class Pessoa
{
    public string Nome { get; set; }
}

var p1 = new Pessoa { Nome = "João" };
var p2 = p1;  // COPIA a referência

p2.Nome = "Maria";  // Muda o objeto
Console.WriteLine(p1.Nome);  // "Maria" ⚠️ p1 também mudou!
```

**Características:**
- Objeto na **heap**, variável tem referência
- Cópia compartilha o **mesmo objeto**
- **Pode ser null**
- Suporta herança
- Maioria dos tipos
- Exemplos: string, arrays, classes, delegates

### 2. Tipos Primitivos

```csharp
// Inteiros com sinal
sbyte   tiny   = -128;           // -128 a 127 (8-bit)
short   small  = -32768;         // -32,768 a 32,767 (16-bit)
int     normal = -2_147_483_648; // ~-2.1bi a ~2.1bi (32-bit)
long    big    = long.MaxValue;  // muito grande (64-bit)

// Inteiros sem sinal
byte    uTiny  = 255;            // 0 a 255 (8-bit)
ushort  uSmall = 65535;          // 0 a 65,535 (16-bit)
uint    uInt   = uint.MaxValue;  // 0 a ~4.2bi (32-bit)
ulong   uBig   = ulong.MaxValue; // muito grande (64-bit)

// Ponto flutuante
float   f = 3.14f;               // ~7 dígitos precisão (32-bit)
double  d = 3.14159265359;       // ~15-16 dígitos (64-bit)
decimal m = 3.14159265359m;      // ~28-29 dígitos (128-bit) ← Use para dinheiro!

// Outros
bool    flag  = true;            // true ou false
char    letra = 'A';             // Caractere Unicode (16-bit)
string  texto = "Olá!";          // Sequência de caracteres
```

### 3. Tipos Nullable

```csharp
// Tipos de valor não podem ser null normalmente
// int idade = null;  ❌ ERRO!

// Nullable permite null em tipos de valor
int? idade = null;  // ✅ OK!

// Verificando se tem valor
if (idade.HasValue)
{
    Console.WriteLine(idade.Value);
}

// Valor padrão se for null
int idadeReal = idade.GetValueOrDefault(18);

// Null-coalescing operator
int valor = idade ?? 0;  // Se null, usa 0

// Null-conditional operator
string? texto = null;
int? tamanho = texto?.Length;  // null (não lança exceção!)
```

#### Nullable Reference Types (C# 8+)
```csharp
// Com nullable reference types habilitado
string  nome1 = "João";   // Não pode ser null
string? nome2 = null;     // Pode ser null

// Compilador avisa sobre possível NullReferenceException
string? busca = BuscarUsuario();
Console.WriteLine(busca.Length);  // ⚠️ Warning: pode ser null!

// Correto:
if (busca != null)
{
    Console.WriteLine(busca.Length);  // ✅ Sem warning
}
```

### 4. Conversões de Tipos

#### Conversão Implícita (Automática)
```csharp
int x = 42;
long y = x;        // int → long (OK, sem perda)
double z = x;      // int → double (OK)

// Hierarquia: byte → short → int → long → float → double
```

#### Conversão Explícita (Cast)
```csharp
double d = 123.456;
int i = (int)d;     // 123 (perde decimal!)

long big = 1000;
int small = (int)big;  // OK se caber

// ⚠️ Cuidado com overflow!
int maxInt = int.MaxValue;
byte b = (byte)maxInt;  // ❌ Overflow!
```

#### Conversão com Métodos
```csharp
// ToString - qualquer tipo → string
int numero = 42;
string texto = numero.ToString();

// Parse - string → tipo (lança exceção se falhar)
int n = int.Parse("123");

// TryParse - conversão segura (retorna bool)
if (int.TryParse("456", out int resultado))
{
    Console.WriteLine(resultado);
}

// Convert - biblioteca de conversões
int x = Convert.ToInt32("789");
double d = Convert.ToDouble("3.14");
```

### 5. Boxing e Unboxing

```csharp
// BOXING - tipo de valor → object
int valor = 123;
object obj = valor;  // Boxing (copia para heap)

// UNBOXING - object → tipo de valor
object objetoComInt = 456;
int numero = (int)objetoComInt;  // Unboxing

// ⚠️ Custo de performance!
// Evite: ArrayList, Hashtable (usam object)
// Prefira: List<T>, Dictionary<K,V> (genéricos)
```

### 6. Tipo Dynamic

```csharp
// Dynamic - tipo determinado em RUNTIME
dynamic variavel = 42;        // int
variavel = "texto";           // agora string
variavel = 3.14;              // agora double

// Sem verificação em compilação!
dynamic x = 10;
dynamic y = "texto";
dynamic z = x + y;  // ✅ Compila, ❌ Erro em runtime!
```

**Quando usar:**
- ✅ Interop COM
- ✅ JSON dinâmico
- ✅ Reflection avançada

**Quando NÃO usar:**
- ❌ Código normal (prefira tipos fortes)
- ❌ APIs públicas
- ❌ Quando performance importa

### 7. Tuplas (Tuples)

```csharp
// Criar tupla
var pessoa = (Nome: "João", Idade: 30);
Console.WriteLine(pessoa.Nome);

// Retornar múltiplos valores
(int Quociente, int Resto) Dividir(int a, int b)
{
    return (a / b, a % b);
}

var resultado = Dividir(17, 5);
Console.WriteLine($"{resultado.Quociente} resto {resultado.Resto}");

// Desconstrução
var (quociente, resto) = Dividir(23, 7);
Console.WriteLine($"{quociente} resto {resto}");
```

**Quando usar tuplas:**
- ✅ Retornos múltiplos temporários
- ✅ Métodos privados/internos
- ✅ Agrupamento simples de dados

**Quando NÃO usar:**
- ❌ APIs públicas (prefira classes)
- ❌ Dados complexos com lógica
- ❌ Quando precisa de métodos

### 8. Tipo Object

```csharp
// object - base de TODOS os tipos
object obj1 = 42;           // int
object obj2 = "texto";      // string
object obj3 = new Pessoa(); // classe customizada

// Métodos de System.Object (todos os tipos têm):
obj1.ToString();     // Representação em string
obj1.GetType();      // Tipo em runtime
obj1.GetHashCode();  // Hash code
obj1.Equals(obj2);   // Comparação
```

## 📊 Quando Usar Struct vs Class

| Critério | STRUCT | CLASS |
|----------|--------|-------|
| Tamanho | Pequeno (< 16 bytes) | Qualquer |
| Mutabilidade | Imutável (recomendado) | Mutável OK |
| Herança | ❌ Não | ✅ Sim |
| Identidade | Valor | Referência |
| Performance | Melhor para muitas cópias | Melhor para grandes objetos |
| Null | ❌ Não (exceto Nullable) | ✅ Sim |
| Uso | Dados simples/coordenadas | Maioria dos casos |

**Exemplos de Struct:** Point, Rectangle, Color, Complex, DateTime  
**Exemplos de Class:** Cliente, Produto, Pedido, List<T>, Stream

## 🎓 Tabela de Conversões

| De → Para | Conversão | Exemplo |
|-----------|-----------|---------|
| int → long | Implícita | `long x = 42;` |
| long → int | Explícita | `int x = (int)42L;` |
| double → int | Explícita | `int x = (int)3.14;` |
| int → string | ToString | `"42".ToString()` |
| string → int | Parse | `int.Parse("42")` |
| string → int (safe) | TryParse | `int.TryParse("42", out int x)` |
| valor → object | Boxing | `object o = 42;` |
| object → valor | Unboxing | `int x = (int)o;` |

## 🔧 Exercícios Sugeridos

### Nível Básico
1. **Estrutura Coordenada**
   - Criar struct `Coordenada` (X, Y, Z)
   - Método para calcular distância
   - Comparar com versão class

2. **Calculadora de Tipos**
   - Criar métodos que demonstrem conversões
   - Tratar overflows e exceções

### Nível Intermediário
3. **Sistema de Produtos com Nullable**
   - Campos opcionais: desconto, categoria, dataValidade
   - Validações para nullable
   - Métodos com valores padrão

4. **Conversor Genérico**
   - Classe para converter entre tipos
   - Suporte a múltiplos formatos
   - TryConvert pattern

### Nível Avançado
5. **Sistema de Unidades**
   - Structs: Metro, Quilômetro, Milha
   - Operadores de conversão personalizados
   - Operadores aritméticos

6. **Dynamic JSON Parser**
   - Parse JSON para dynamic
   - Navegação segura
   - Conversão para tipos fortes

## 📚 Recursos Adicionais

- [Tipos - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/types/)
- [Tipos de Valor](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/builtin-types/value-types)
- [Nullable Reference Types](https://learn.microsoft.com/pt-br/dotnet/csharp/nullable-references)

## ✅ Checklist de Aprendizado

- [ ] Entendo diferença entre tipo de valor e referência
- [ ] Conheço todos os tipos primitivos e seus limites
- [ ] Sei usar tipos nullable e operadores ??, ?.
- [ ] Compreendo conversões implícitas vs explícitas
- [ ] Conheço métodos de conversão (Parse, TryParse, Convert)
- [ ] Entendo boxing e unboxing
- [ ] Sei quando (não) usar tipo dynamic
- [ ] Aplico tuplas para retornos múltiplos
- [ ] Consigo escolher entre struct e class

---

**Módulo anterior:** [Objetos](../Objetos/)  
**Próximo módulo:** [Referências](../Referencias/) - Passagem por valor e referência.
