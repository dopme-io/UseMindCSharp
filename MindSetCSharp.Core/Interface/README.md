# Módulo Interface - Contratos e Abstração

## 📖 Visão Geral

Este módulo explora o conceito de **interfaces** em C#, demonstrando como definir contratos, implementar polimorfismo, criar arquiteturas desacopladas e trabalhar com múltiplas abstrações.

## 🎯 Objetivos de Aprendizado

- Entender o que são interfaces e quando usá-las
- Criar e implementar interfaces
- Trabalhar com múltiplas interfaces em uma classe
- Aplicar polimorfismo através de interfaces
- Compreender Interface Segregation Principle
- Comparar interfaces com classes abstratas
- Implementar padrões de design com interfaces

## 📁 Arquivos do Módulo

### `IRepositorio.cs`
Interface genérica de repositório:

**Interface `IRepositorio<T>`**
- Contrato CRUD genérico
- Métodos: Adicionar, Atualizar, Remover, ObterPorId, ObterTodos, Contar

**Implementações:**
- `RepositorioMemoria<T>` - armazenamento em memória
- `RepositorioComCache<T>` - decorator com cache

**Entidades:**
- `Produto` e `Cliente` implementam `IEntidade`
- Demonstra código genérico reutilizável

### `Notificacoes.cs`
Múltiplas interfaces para notificações:

**Interfaces:**
- `IEnviadorEmail` - contrato para envio de e-mail
- `IEnviadorSms` - contrato para envio de SMS
- `IEnviadorPush` - contrato para notificações push
- `INotificador` - interface base genérica

**Implementações:**
- `ServicoNotificacaoCompleto` - implementa 3 interfaces
- `NotificadorEmail`, `NotificadorSms`, `NotificadorPush` - especializadas

**Gerenciador:**
- `GerenciadorNotificacoes` - trabalha com `INotificador` (polimorfismo)

### `Pagamentos.cs`
Sistema de pagamentos com múltiplas capacidades:

**Interfaces:**
- `IProcessadorPagamento` - todos os processadores implementam
- `IReembolsavel` - apenas alguns suportam reembolso
- `IParcelavel` - apenas alguns aceitam parcelamento

**Implementações:**
- `PagamentoCartaoCredito` - implementa todas (3 interfaces)
- `PagamentoPix` - implementa 2 interfaces
- `PagamentoBoleto` - implementa apenas 1 interface

**Sistema:**
- `SistemaCheckout` - trabalha com qualquer `IProcessadorPagamento`
- Verifica capacidades em runtime (pattern matching)

### `ExemplosInterface.cs`
Seis exemplos práticos progressivos:

1. **ExemploRepositorio()** - Interface genérica reutilizável
2. **ExemploRepositorioComCache()** - Decorator Pattern
3. **ExemploMultiplasInterfaces()** - Uma classe, múltiplos contratos
4. **ExemploPolimorfismo()** - Código genérico, comportamento específico
5. **ExemploPagamentos()** - Verificação de capacidades runtime
6. **ExemploComparacao()** - Interface vs Classe Abstrata

## 🚀 Como Executar

### Executar todos os exemplos:
```powershell
dotnet run --project MindSetCSharp.Console
```

### Executar apenas este módulo:
```csharp
using MindSetCSharp.Core.Interface;

InterfaceModule.Run();
```

## 💡 Conceitos-Chave

### 1. O Que é Uma Interface?

**Definição:**
```csharp
public interface IProcessadorPagamento
{
    // Apenas ASSINATURAS, não implementação
    string NomeProcessador { get; }
    bool ProcessarPagamento(decimal valor, string dados);
    decimal CalcularTaxa(decimal valor);
}
```

**Características:**
- Define O QUE fazer, não COMO fazer
- Apenas assinaturas (métodos, propriedades, eventos)
- Não contém implementação* (exceto C# 8+ default)
- Não tem campos, construtores ou estado
- Membros são implicitamente públicos

### 2. Implementando uma Interface

```csharp
// Classe que assina o contrato
public class PagamentoPix : IProcessadorPagamento
{
    // DEVE implementar TODOS os membros da interface
    public string NomeProcessador => "PIX";
    
    public bool ProcessarPagamento(decimal valor, string dados)
    {
        // Implementação específica
        Console.WriteLine("Processando PIX...");
        return true;
    }
    
    public decimal CalcularTaxa(decimal valor)
    {
        return valor * 0.005m; // 0.5%
    }
}
```

### 3. Múltiplas Interfaces

```csharp
// Uma classe pode implementar VÁRIAS interfaces
public class CartaoCredito : IProcessadorPagamento, 
                              IReembolsavel, 
                              IParcelavel
{
    // Implementa TODOS os membros de TODAS as interfaces
    
    // De IProcessadorPagamento
    public string NomeProcessador => "Cartão";
    public bool ProcessarPagamento(decimal v, string d) { }
    public decimal CalcularTaxa(decimal v) { }
    
    // De IReembolsavel
    public bool ProcessarReembolso(string id, decimal v) { }
    
    // De IParcelavel
    public decimal CalcularValorParcela(decimal v, int p) { }
    public int MaximoParcelas => 12;
}
```

### 4. Polimorfismo com Interfaces

```csharp
// Método aceita QUALQUER implementação da interface
public void ProcessarCompra(IProcessadorPagamento processador, decimal valor)
{
    // Chama o método da interface
    processador.ProcessarPagamento(valor, "dados");
    
    // Em runtime, executa a implementação específica!
}

// Uso
ProcessarCompra(new PagamentoPix(), 100m);      // Executa PIX
ProcessarCompra(new PagamentoBoleto(), 100m);   // Executa Boleto
ProcessarCompra(new CartaoCredito(), 100m);     // Executa Cartão
```

### 5. Verificação de Capacidades (Pattern Matching)

```csharp
public void ProcessarComOpcionais(IProcessadorPagamento processador)
{
    // Processa pagamento (todos têm)
    processador.ProcessarPagamento(100m, "dados");
    
    // Verifica se suporta parcelamento
    if (processador is IParcelavel parcelavel)
    {
        var valorParcela = parcelavel.CalcularValorParcela(100m, 3);
        Console.WriteLine($"3x de R$ {valorParcela:F2}");
    }
    
    // Verifica se suporta reembolso
    if (processador is IReembolsavel reembolsavel)
    {
        reembolsavel.ProcessarReembolso("TXN-123", 100m);
    }
}
```

### 6. Herança de Interfaces

```csharp
// Interface base
public interface IEntidade
{
    int Id { get; set; }
    string Nome { get; set; }
}

// Interface derivada herda tudo da base
public interface IProduto : IEntidade
{
    decimal Preco { get; set; }
    int Estoque { get; set; }
}

// Classe implementa a derivada (deve implementar TODAS)
public class Produto : IProduto
{
    public int Id { get; set; }          // de IEntidade
    public string Nome { get; set; }     // de IEntidade
    public decimal Preco { get; set; }   // de IProduto
    public int Estoque { get; set; }     // de IProduto
}
```

### 7. Interface Segregation Principle (ISP)

```csharp
// ❌ RUIM: Interface "gorda" com tudo
public interface INotificadorCompleto
{
    void EnviarEmail(string email, string msg);
    void EnviarSms(string tel, string msg);
    void EnviarPush(string device, string msg);
}
// Problema: classe que só envia email precisa implementar TUDO!

// ✅ BOM: Interfaces segregadas
public interface IEnviadorEmail
{
    void EnviarEmail(string email, string msg);
}

public interface IEnviadorSms
{
    void EnviarSms(string tel, string msg);
}

public interface IEnviadorPush
{
    void EnviarPush(string device, string msg);
}

// Classes implementam APENAS o que precisam
public class NotificadorEmail : IEnviadorEmail { }
public class NotificadorSms : IEnviadorSms { }
public class NotificadorCompleto : IEnviadorEmail, IEnviadorSms, IEnviadorPush { }
```

### 8. Implementação Explícita

```csharp
public interface ILista
{
    void Adicionar(object item);
}

public interface IColecao
{
    void Adicionar(object item);
}

// Ambas interfaces têm método com mesmo nome!
public class MinhaClasse : ILista, IColecao
{
    // Implementação explícita - evita conflito
    void ILista.Adicionar(object item)
    {
        Console.WriteLine("Adicionando via ILista");
    }
    
    void IColecao.Adicionar(object item)
    {
        Console.WriteLine("Adicionando via IColecao");
    }
}

// Uso
var obj = new MinhaClasse();
((ILista)obj).Adicionar("item");    // Chama ILista.Adicionar
((IColecao)obj).Adicionar("item");  // Chama IColecao.Adicionar
```

## 📊 Interface vs Classe Abstrata

| Aspecto | Interface | Classe Abstrata |
|---------|-----------|-----------------|
| **Propósito** | Definir CONTRATO | Fornecer BASE |
| **Herança** | Múltipla (várias interfaces) | Simples (uma classe) |
| **Implementação** | Apenas assinaturas* | Métodos concretos + abstratos |
| **Campos** | ❌ Não | ✅ Sim |
| **Construtores** | ❌ Não | ✅ Sim |
| **Estado** | ❌ Não | ✅ Sim |
| **Modificadores** | Todos públicos | public, protected, private |
| **Quando usar** | "Pode fazer" (capacidade) | "É um tipo de" (hierarquia) |

**Exemplo de uso conjunto:**
```csharp
// Classe abstrata: base comum
public abstract class Pagamento
{
    protected string TransacaoId { get; set; }
    
    protected void RegistrarLog(string mensagem)
    {
        // Implementação comum
    }
}

// Interfaces: capacidades opcionais
public class CartaoCredito : Pagamento,          // Herda base
                             IProcessador,        // Contrato obrigatório
                             IReembolsavel,       // Capacidade 1
                             IParcelavel          // Capacidade 2
{
    // Implementa tudo
}
```

## 🎓 Benefícios das Interfaces

### 1. Desacoplamento
```csharp
// ❌ Acoplado a implementação concreta
public class Pedido
{
    private EmailService _emailService = new EmailService();
    
    public void Confirmar()
    {
        _emailService.Enviar("...");  // Difícil testar/trocar
    }
}

// ✅ Desacoplado - depende de abstração
public class Pedido
{
    private readonly INotificador _notificador;
    
    public Pedido(INotificador notificador)
    {
        _notificador = notificador;  // Injeção de dependência
    }
    
    public void Confirmar()
    {
        _notificador.Enviar("...");  // Fácil testar/trocar
    }
}
```

### 2. Testabilidade
```csharp
// Mock para testes
public class NotificadorMock : INotificador
{
    public bool FoiChamado { get; private set; }
    
    public bool Enviar(string dest, string msg)
    {
        FoiChamado = true;
        return true;
    }
}

// Teste
var mock = new NotificadorMock();
var pedido = new Pedido(mock);
pedido.Confirmar();
Assert.True(mock.FoiChamado);  // Verifica se notificou
```

### 3. Extensibilidade
```csharp
// Fácil adicionar novas implementações
public class NotificadorWhatsApp : INotificador
{
    public string TipoNotificacao => "WhatsApp";
    
    public bool Enviar(string dest, string msg)
    {
        // Nova implementação!
        return true;
    }
}

// Código existente continua funcionando
gerenciador.AdicionarNotificador(new NotificadorWhatsApp());
```

### 4. Padrões de Design
```csharp
// Strategy Pattern
public class ProcessadorPedido
{
    public void Processar(Pedido pedido, IProcessadorPagamento estrategia)
    {
        estrategia.ProcessarPagamento(pedido.Total, pedido.DadosPagamento);
    }
}

// Repository Pattern
public class ServicoCliente
{
    private readonly IRepositorio<Cliente> _repo;
    
    public ServicoCliente(IRepositorio<Cliente> repo)
    {
        _repo = repo;  // Pode ser SQL, NoSQL, Memória...
    }
}

// Dependency Injection
services.AddScoped<IRepositorio<Cliente>, RepositorioSQL>();
```

## 🔧 Exercícios Sugeridos

### Nível Básico
1. **Interface IVeiculo**
   - Métodos: Ligar(), Desligar(), Acelerar()
   - Criar 3 implementações: Carro, Moto, Barco

2. **Interface ICalculadora**
   - Métodos: Somar, Subtrair, Multiplicar, Dividir
   - Implementações: Básica e Científica

### Nível Intermediário
3. **Sistema de Arquivos**
   - `IArmazenamento`: Salvar, Carregar, Deletar
   - Implementações: Local, Cloud, FTP

4. **Validadores com Interface**
   - `IValidador<T>`: bool Validar(T obj)
   - Validadores: CPF, Email, Telefone, CEP

### Nível Avançado
5. **Plugin System**
   - `IPlugin`: Nome, Versão, Executar()
   - Carregar plugins dinamicamente
   - Gerenciador de plugins

6. **Event Sourcing**
   - `IEvento`, `IEventStore`, `IEventHandler`
   - Implementar log de eventos
   - Replay de estado

## 📚 Recursos Adicionais

- [Interfaces - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/types/interfaces)
- [Interface Segregation Principle](https://learn.microsoft.com/pt-br/dotnet/architecture/modern-web-apps-azure/architectural-principles#interface-segregation)
- [Dependency Injection](https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection)

## ✅ Checklist de Aprendizado

- [ ] Entendo o que é uma interface e quando usar
- [ ] Sei criar e implementar interfaces
- [ ] Compreendo múltiplas interfaces em uma classe
- [ ] Aplico polimorfismo através de interfaces
- [ ] Conheço Interface Segregation Principle
- [ ] Sei a diferença entre interface e classe abstrata
- [ ] Consigo verificar capacidades em runtime (is/as)
- [ ] Compreendo desacoplamento e injeção de dependência

---

**Módulo anterior:** [Herança](../Herança/)  
**Próximo módulo:** [Enumerações](../Enumerações/) - Tipos enumerados e constantes.
