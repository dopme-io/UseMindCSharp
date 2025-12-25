# Módulo Encapsulamento - Proteção e Abstração de Dados

## 📖 Visão Geral

Este módulo explora em profundidade o conceito de encapsulamento em C#, demonstrando como proteger dados, validar entradas, controlar acesso e abstrair complexidade através de propriedades e métodos.

## 🎯 Objetivos de Aprendizado

- Entender a importância do encapsulamento
- Usar campos privados e propriedades públicas
- Implementar validações em propriedades
- Trabalhar com diferentes níveis de acesso
- Criar propriedades somente leitura e calculadas
- Encapsular regras de negócio
- Comparar código com e sem encapsulamento

## 📁 Arquivos do Módulo

### `ContaBancaria.cs`
Demonstração comparativa de encapsulamento:

**Classe Ruim: `ContaBancariaSemEncapsulamento`**
- ❌ Campos públicos expostos
- ❌ Sem validação
- ❌ Sem controle de acesso
- ❌ Vulnerável a modificações incorretas

**Classe Boa: `ContaBancariaComEncapsulamento`**
- ✅ Campos privados protegidos
- ✅ Propriedades com validação
- ✅ Métodos controlam modificações
- ✅ Histórico de transações automático
- ✅ Dados protegidos e consistentes

### `Pessoa.cs`
Demonstra níveis de acesso e proteção:

**Níveis de Acesso:**
- `private` - só acessível na própria classe
- `protected` - acessível em classes derivadas
- `internal` - acessível no mesmo assembly
- `public` - acessível de qualquer lugar

**Tipos de Propriedades:**
- Auto-implementadas: `public string Nome { get; set; }`
- Com validação: setter com lógica de validação
- Somente leitura: `public string CPF { get; private set; }`
- Init-only: `public int Id { get; init; }`
- Calculadas: `public int Idade => CalcularIdade();`

**Classe Derivada: `PessoaFisica`**
- Acessa membros `protected` da classe base
- Adiciona funcionalidades específicas

### `CarrinhoCompras.cs`
Encapsulamento de regras de negócio complexas:

**Características:**
- Classe interna privada (`ItemCarrinho`)
- Coleção privada (lista não exposta)
- Métodos públicos controlam acesso
- Validações em todas as operações
- Recálculo automático de descontos
- Regras de negócio encapsuladas

### `ExemplosEncapsulamento.cs`
Cinco exemplos práticos progressivos:

1. **ExemploComparacao()** - Com vs sem encapsulamento
2. **ExemploNiveisAcesso()** - Public, private, protected
3. **ExemploCarrinhoCompras()** - Regras de negócio
4. **ExemploValidacoes()** - Proteção de dados
5. **ExemploPropriedadesEspeciais()** - Propriedades avançadas

## 🚀 Como Executar

### Executar todos os exemplos:
```powershell
dotnet run --project MindSetCSharp.Console
```

### Executar apenas este módulo:
```csharp
using MindSetCSharp.Core.Encapsulamento;

EncapsulamentoModule.Run();
```

## 💡 Conceitos-Chave

### 1. Princípio Fundamental

**Ocultação de Informação:**
```csharp
// ❌ SEM ENCAPSULAMENTO
public class ContaRuim
{
    public decimal Saldo;  // Qualquer um pode modificar!
}

var conta = new ContaRuim();
conta.Saldo = -1000m;  // ⚠️ Saldo negativo sem controle!

// ✅ COM ENCAPSULAMENTO
public class ContaBoa
{
    private decimal _saldo;  // Protegido
    
    public decimal Saldo => _saldo;  // Somente leitura
    
    public bool Sacar(decimal valor)  // Controle total
    {
        if (valor > _saldo) return false;
        _saldo -= valor;
        return true;
    }
}
```

### 2. Níveis de Acesso

```csharp
public class Exemplo
{
    // Privado - só esta classe
    private int _campoPrivado;
    
    // Protegido - esta classe e derivadas
    protected int _campoProtegido;
    
    // Interno - mesmo assembly
    internal int _campoInterno;
    
    // Público - todos
    public int CampoPublico;
    
    // Protegido interno - derivadas OU mesmo assembly
    protected internal int _campoProtegidomInterno;
    
    // Privado protegido - derivadas E mesmo assembly
    private protected int _campoPrivadoProtegido;
}
```

### 3. Propriedades Auto-implementadas

```csharp
// Propriedade simples
public string Nome { get; set; }

// Somente leitura externa
public string CPF { get; private set; }

// Init-only (apenas no construtor)
public int Id { get; init; }

// Somente leitura total
public DateTime DataCriacao { get; }

// Calculada
public int Idade => CalcularIdade();
```

### 4. Propriedades com Validação

```csharp
private decimal _saldo;

public decimal Saldo
{
    get => _saldo;
    set
    {
        if (value < 0)
            throw new ArgumentException("Saldo não pode ser negativo");
        _saldo = value;
    }
}
```

### 5. Campos Readonly

```csharp
public class Exemplo
{
    // Só pode ser definido no construtor
    private readonly string _numeroConta;
    
    public Exemplo(string numeroConta)
    {
        _numeroConta = numeroConta;
    }
    
    // Depois disso, não pode mais mudar!
}
```

### 6. Encapsulamento de Lógica

```csharp
public class Carrinho
{
    private List<Item> _itens = new();
    private decimal _desconto;
    
    // Método público simples
    public void AdicionarItem(string produto, decimal preco)
    {
        ValidarProduto(produto);  // Privado
        ValidarPreco(preco);      // Privado
        AtualizarDesconto();      // Privado
        
        _itens.Add(new Item(produto, preco));
    }
    
    // Lógica complexa encapsulada
    private void ValidarProduto(string produto) { }
    private void ValidarPreco(decimal preco) { }
    private void AtualizarDesconto() { }
}
```

## 📊 Comparação Visual

### SEM Encapsulamento:
```
┌─────────────────┐
│  Dados Públicos │ ← Qualquer um pode modificar
│  nome           │
│  saldo          │
│  cpf            │
└─────────────────┘
     ⚠️ Vulnerável!
```

### COM Encapsulamento:
```
┌─────────────────────────────┐
│  Interface Pública          │
│  • Nome (get/set)           │
│  • Saldo (get apenas)       │
│  • Depositar(valor)         │
│  • Sacar(valor)             │
├─────────────────────────────┤
│  Dados Privados (protegidos)│
│  • _saldo                   │
│  • _cpf                     │
│  • _historico               │
└─────────────────────────────┘
     ✅ Protegido!
```

## 🎓 Benefícios do Encapsulamento

### 1. Validação Centralizada
```csharp
// Todos os acessos passam pela validação
conta.Depositar(500m);  // ✓ Validado
conta.Sacar(200m);      // ✓ Validado
// conta._saldo = -100;  // ❌ Impossível (privado)
```

### 2. Manutenção Facilitada
```csharp
// Mudanças internas não afetam código externo
private decimal _saldo;  // Pode mudar implementação

public decimal Saldo => _saldo * _taxaCambio;  // Novo cálculo
// Código externo continua funcionando!
```

### 3. Segurança de Dados
```csharp
// Dados críticos protegidos
private string _cpf;
private string _senha;
private decimal _saldo;

// Acesso controlado
public string CPFFormatado => FormatarCPF(_cpf);
```

### 4. Abstração de Complexidade
```csharp
// Interface simples
carrinho.AdicionarProduto("Notebook", 3500m);

// Complexidade oculta
private void AdicionarProduto(...)
{
    ValidarProduto();
    VerificarEstoque();
    AplicarPromocoes();
    RecalcularFrete();
    AtualizarTotal();
    SalvarHistorico();
}
```

## 🔧 Exercícios Sugeridos

### Nível Básico
1. **Classe Produto com Validação**
   - Campos privados para preço e estoque
   - Validações: preço >= 0, estoque >= 0
   - Métodos: VenderUnidades(), ReporEstoque()

2. **Classe Estudante**
   - CPF privado, somente leitura
   - Notas privadas com validação (0-10)
   - Média calculada automaticamente

### Nível Intermediário
3. **Sistema de Autenticação**
   - Senha encriptada (campo privado)
   - Validação de força da senha
   - Tentativas de login limitadas
   - Bloqueio após tentativas falhas

4. **Classe Agenda**
   - Lista de compromissos privada
   - Validação de conflitos de horário
   - Métodos para adicionar/remover
   - Impossível criar conflitos

### Nível Avançado
5. **Sistema Bancário Completo**
   - Múltiplos tipos de conta
   - Histórico imutável
   - Regras de saque/depósito complexas
   - Cálculo de juros encapsulado

6. **Cache com Expiração**
   - Dados privados com TTL
   - Limpeza automática
   - Thread-safe
   - Estatísticas encapsuladas

## 📚 Recursos Adicionais

- [Encapsulamento - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/object-oriented/encapsulation)
- [Modificadores de Acesso](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)
- [Propriedades](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/properties)

## ✅ Checklist de Aprendizado

- [ ] Entendo por que encapsulamento é importante
- [ ] Sei usar campos privados e propriedades públicas
- [ ] Compreendo os níveis de acesso (public, private, etc)
- [ ] Sei implementar validações em propriedades
- [ ] Conheço propriedades somente leitura e calculadas
- [ ] Sei encapsular regras de negócio
- [ ] Compreendo readonly, init e imutabilidade
- [ ] Consigo comparar código com e sem encapsulamento

---

**Módulo anterior:** [Referências](../Referencias/)  
**Próximo módulo:** [Herança](../Herança/) - Reutilização e extensão de código.
