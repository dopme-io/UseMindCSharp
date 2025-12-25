# Módulo Classes - Estruturas de Dados em C#

## 📖 Visão Geral

Este módulo explora em profundidade a criação e uso de classes em C#, demonstrando propriedades, métodos, construtores, campos, validações, composição e relacionamentos entre classes.

## 🎯 Objetivos de Aprendizado

- Criar classes com diferentes tipos de membros
- Trabalhar com propriedades auto-implementadas e com lógica
- Implementar construtores e sobrecarga
- Usar campos privados e encapsulamento
- Entender membros estáticos vs instância
- Praticar composição de classes
- Implementar validações e regras de negócio

## 📁 Arquivos do Módulo

### `Produto.cs`
Classe demonstrando diversos conceitos fundamentais:
- **Campos privados**: `_precoBase`, `_quantidadeEstoque`
- **Propriedades auto-implementadas**: `Nome`, `Codigo`, `Categoria`
- **Propriedades com validação**: `Preco`, `QuantidadeEstoque`
- **Propriedades calculadas**: `PrecoComImposto`, `EmEstoque`, `EstoqueBaixo`
- **Múltiplos construtores**: padrão, com 3 parâmetros, com 5 parâmetros
- **Métodos de negócio**: `Vender()`, `Repor()`, `AplicarDesconto()`
- **Métodos de apresentação**: `ExibirDetalhes()`, `ToString()`

### `Cliente.cs`
Classe com validações e formatações:
- **Validação de CPF**: formato e quantidade de dígitos
- **Validação de data**: data de nascimento não pode ser futura
- **Propriedade calculada**: `Idade` baseada em data de nascimento
- **Coleção de telefones**: gerenciamento de lista
- **Contador estático**: geração automática de IDs únicos
- **Métodos auxiliares privados**: formatação de CPF e telefone
- **Gerenciamento de status**: ativar/desativar cliente

### `Pedido.cs`
Classe demonstrando composição e relacionamentos:
- **Classe aninhada**: `ItemPedido` dentro de `Pedido`
- **Enum**: `StatusPedido` com diferentes estados
- **Composição**: `Pedido` contém `Cliente` e lista de `ItemPedido`
- **Relacionamento**: `ItemPedido` referencia `Produto`
- **Máquina de estados**: fluxo de status do pedido
- **Métodos de gerenciamento**: adicionar/remover itens
- **Métodos de fluxo**: processar, enviar, entregar, cancelar
- **Agregações**: cálculo de totais

### `ExemplosClasses.cs`
Cinco exemplos práticos e progressivos:

1. **ExemploProduto()** - Operações com produtos
2. **ExemploCliente()** - Gerenciamento de clientes
3. **ExemploPedido()** - Sistema completo de pedidos
4. **ExemploMultiplosPedidos()** - Análises e agregações
5. **ExemploMembrosEstaticos()** - Demonstração de membros estáticos

## 🚀 Como Executar

### Executar todos os exemplos:
```powershell
dotnet run --project MindSetCSharp.Console
```

### Executar apenas este módulo:
```csharp
using MindSetCSharp.Core.Classes;

ClassesModule.Run();
```

## 💡 Conceitos-Chave

### 1. Campos vs Propriedades
```csharp
// Campo privado (convenção: _camelCase)
private decimal _precoBase;

// Propriedade pública
public decimal Preco 
{ 
    get => _precoBase;
    set => _precoBase = value;
}

// Propriedade auto-implementada (campo gerado automaticamente)
public string Nome { get; set; }
```

### 2. Tipos de Propriedades

**Auto-implementadas:**
```csharp
public string Nome { get; set; }
```

**Com validação:**
```csharp
public decimal Preco
{
    get => _precoBase;
    set
    {
        if (value < 0)
            throw new ArgumentException("Preço não pode ser negativo.");
        _precoBase = value;
    }
}
```

**Somente leitura:**
```csharp
public DateTime DataCadastro { get; }  // Set apenas no construtor
public string NumeroConta => numeroConta;  // Expression-bodied
```

**Calculadas:**
```csharp
public decimal PrecoComImposto => _precoBase * 1.15m;
public int Idade => CalcularIdade(_dataNascimento);
```

### 3. Construtores

**Construtor padrão:**
```csharp
public Produto()
{
    Nome = "Produto Sem Nome";
    _precoBase = 0;
}
```

**Sobrecarga de construtores:**
```csharp
public Produto(string nome, decimal preco, int quantidade)
{
    Nome = nome;
    Preco = preco;
    QuantidadeEstoque = quantidade;
}
```

**Encadeamento de construtores:**
```csharp
public Cliente(string nome, string cpf) : this()
{
    Nome = nome;
    CPF = cpf;
}
```

### 4. Membros Estáticos

**Contador estático:**
```csharp
private static int _proximoId = 1;

public Cliente()
{
    Id = _proximoId++;  // Cada instância recebe ID único
}
```

### 5. Composição de Classes

**Relacionamento "tem um":**
```csharp
public class Pedido
{
    public Cliente Cliente { get; set; }  // Pedido TEM UM Cliente
    private List<ItemPedido> _itens;      // Pedido TEM Itens
}
```

### 6. Classes Aninhadas (Nested)

```csharp
public class Pedido
{
    public class ItemPedido  // Classe dentro de classe
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
```

### 7. Enums Relacionados

```csharp
public class Pedido
{
    public enum StatusPedido
    {
        Pendente,
        Processando,
        Enviado,
        Entregue,
        Cancelado
    }
    
    public StatusPedido Status { get; private set; }
}
```

## 📊 Exemplos de Saída

```
╔════════════════════════════════════════════╗
  Produto: Notebook Dell
  Código: 3A4B5C6D
  Categoria: Geral
  Preço: R$ 3500,00
  Preço c/ Imposto: R$ 4025,00
  Estoque: 10 unidades
  Valor Total: R$ 35000,00
  Status: ✅ Em estoque
╚════════════════════════════════════════════╝
```

```
╔═══════════════════════════════════════════════════════╗
║  PEDIDO #1000
╠═══════════════════════════════════════════════════════╣
  Cliente: Carlos Oliveira
  Data: 25/12/2025 14:30
  Status: ✅ Entregue
├───────────────────────────────────────────────────────┤
  ITENS:
    • 1x Notebook Lenovo              R$   4200,00
    • 3x Mouse Gamer                  R$    750,00
    • 1x Teclado RGB                  R$    380,00
    • 2x Monitor 27"                  R$   3000,00
├───────────────────────────────────────────────────────┤
  Total de Itens: 7
  VALOR TOTAL: R$ 8330,00
╚═══════════════════════════════════════════════════════╝
```

## 🔧 Exercícios Sugeridos

### Nível Básico
1. **Criar classe `Livro`**
   - Propriedades: Título, Autor, ISBN, Preço, AnoPublicacao
   - Métodos: ExibirDetalhes(), AplicarDesconto()

2. **Criar classe `Funcionario`**
   - Propriedades: Nome, CPF, Salario, Cargo, DataAdmissao
   - Métodos: CalcularTempoEmpresa(), AumentarSalario(percentual)

### Nível Intermediário
3. **Estender sistema de Produtos**
   - Adicionar categorias hierárquicas
   - Implementar histórico de alterações de preço
   - Adicionar imagens (URLs)

4. **Sistema de Biblioteca**
   - Classes: Livro, Autor, Membro, Emprestimo
   - Gerenciar empréstimos e devoluções
   - Calcular multas por atraso

### Nível Avançado
5. **E-commerce Completo**
   - Carrinho de compras
   - Cupons de desconto
   - Múltiplas formas de pagamento
   - Sistema de avaliações

6. **Sistema Bancário Expandido**
   - Diferentes tipos de conta (Corrente, Poupança, Investimento)
   - Histórico de transações
   - Extratos por período
   - Transferências entre contas

## 🎓 Conceitos Avançados Demonstrados

- ✅ Encapsulamento e proteção de dados
- ✅ Validação de entrada
- ✅ Propriedades calculadas e derivadas
- ✅ Composição e agregação
- ✅ Relacionamentos entre classes
- ✅ Máquinas de estado
- ✅ Métodos auxiliares privados
- ✅ Formatação e apresentação de dados
- ✅ Coleções imutáveis (ReadOnly)
- ✅ Expression-bodied members
- ✅ Pattern matching com switch expressions

## 📚 Recursos Adicionais

- [Classes - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/types/classes)
- [Propriedades](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/properties)
- [Construtores](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/constructors)
- [Membros Estáticos](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members)

## ✅ Checklist de Aprendizado

- [ ] Sei criar classes com propriedades e métodos
- [ ] Entendo a diferença entre campos e propriedades
- [ ] Consigo implementar validações em propriedades
- [ ] Sei usar construtores e sobrecarga
- [ ] Compreendo membros estáticos
- [ ] Sei trabalhar com composição de classes
- [ ] Consigo implementar regras de negócio
- [ ] Entendo classes aninhadas e enums relacionados

---

**Próximo módulo:** [Encapsulamento](../Encapsulamento/) - Aprofundando proteção de dados e abstração.
