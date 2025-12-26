# Guia de Extensão - MindSetCSharp.Application

## Como Adicionar um Novo Módulo

Siga esses passos para adicionar um novo módulo à aplicação:

### Passo 1: Criar o Módulo no Core

Se o módulo ainda não existe em `MindSetCSharp.Core`, crie:

```
MindSetCSharp.Core/
├── SeuTema/
│   ├── SeuTemaModule.cs       (classe com método Run())
│   ├── ExemplosSeuTema.cs     (exemplos)
│   └── README.md
```

**Exemplo de SeuTemaModule.cs:**
```csharp
namespace MindSetCSharp.Core.SeuTema;

public static class SeuTemaModule
{
    public static void Run()
    {
        Console.WriteLine("\n=== SEU TEMA ===");
        Console.WriteLine("Descrição do tema...\n");
        
        ExemplosSeuTema.Exemplo1();
        ExemplosSeuTema.Exemplo2();
        
        Console.WriteLine("\n--- Fim do tema ---");
    }
}
```

### Passo 2: Criar o Serviço de Módulo na Application

Crie um arquivo em `MindSetCSharp.Application/Modules/`:

**SeuTemaModuleService.cs:**
```csharp
namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo SeuTema
/// </summary>
public class SeuTemaModuleService : IModuleService
{
    public string ModuleName => "SeuTema";

    public void Execute()
    {
        SeuTemaModule.Run();
    }
}
```

### Passo 3: Adicionar à Factory

Atualize `ModuleServiceFactory.cs`:

```csharp
public static IModuleService Create(string moduleName)
{
    return moduleName switch
    {
        // ... módulos existentes ...
        "SeuTema" => new SeuTemaModuleService(),  // ← Adicionar esta linha
        _ => throw new ArgumentException(...)
    };
}

public static IEnumerable<IModuleService> CreateAll()
{
    return new IModuleService[]
    {
        // ... módulos existentes ...
        new SeuTemaModuleService(),  // ← Adicionar esta linha
    };
}
```

### Passo 4: Atualizar GlobalUsings da Application

Atualize `MindSetCSharp.Application/GlobalUsings.cs`:

```csharp
global using MindSetCSharp.Core.SeuTema;  // ← Adicionar esta linha
```

### Passo 5: Pronto!

O novo módulo será automaticamente carregado na próxima execução.

---

## Como Adicionar Funcionalidades à Application

### Criar um Novo Serviço

Se você precisa de funcionalidades além de orquestração de módulos:

**Services/SeuNovoServico.cs:**
```csharp
namespace MindSetCSharp.Application.Services;

/// <summary>
/// Interface para seu serviço
/// </summary>
public interface ISeuServico
{
    void FazerAlgo();
}

/// <summary>
/// Implementação do serviço
/// </summary>
public class SeuServico : ISeuServico
{
    public void FazerAlgo()
    {
        // Implementação
    }
}
```

### Usar o Serviço

No `Program.cs` ou em qualquer outro lugar:

```csharp
ISeuServico servico = new SeuServico();
servico.FazerAlgo();
```

---

## Como Criar um Orquestrador Customizado

Se você precisa de um orquestrador com comportamento especial:

**Services/MeuOrquestrador.cs:**
```csharp
namespace MindSetCSharp.Application.Services;

using MindSetCSharp.Application.Interfaces;

public class MeuOrquestrador : IApplicationOrchestrator
{
    private readonly Dictionary<string, IModuleService> _modules = new();

    // Implementar interface IApplicationOrchestrator...
    
    // Adicionar comportamentos customizados
    public void ExecutarModulosEmParalelo()
    {
        Parallel.ForEach(_modules.Values, module =>
        {
            module.Execute();
        });
    }
}
```

---

## Padrões de Implementação

### ✅ Seguir o Padrão IModuleService

```csharp
// ✅ BOM - Implementar a interface
public class MeuModuleService : IModuleService
{
    public string ModuleName => "Meu Módulo";
    public void Execute() => MeuModule.Run();
}

// ❌ RUIM - Chamar diretamente
ProdutivoModule.Run();
BastidoresModule.Run();
```

### ✅ Usar Factory para Criar Módulos

```csharp
// ✅ BOM - Usar factory
var modulo = ModuleServiceFactory.Create("LINQ");
orchestrator.RegisterModule(modulo);

// ❌ RUIM - Criar diretamente
var modulo = new LINQModuleService();
```

### ✅ Depender de Abstrações

```csharp
// ✅ BOM - Usar interface
public class MinhaClasse
{
    private readonly IApplicationOrchestrator _orchestrator;
    
    public MinhaClasse(IApplicationOrchestrator orchestrator)
    {
        _orchestrator = orchestrator;
    }
}

// ❌ RUIM - Usar implementação concreta
public class MinhaClasse
{
    private readonly ApplicationOrchestrator _orchestrator 
        = new ApplicationOrchestrator();
}
```

---

## Testes

### Testando um Módulo Customizado

```csharp
using Xunit;
using Moq;

public class SeuTemaModuleServiceTests
{
    [Fact]
    public void Execute_DeveExecutarSemErros()
    {
        // Arrange
        var service = new SeuTemaModuleService();

        // Act
        var exception = Record.Exception(() => service.Execute());

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ModuleName_DeveRetornarNomeCorreto()
    {
        // Arrange
        var service = new SeuTemaModuleService();

        // Act
        var nome = service.ModuleName;

        // Assert
        Assert.Equal("SeuTema", nome);
    }
}
```

### Testando o Orquestrador

```csharp
public class ApplicationOrchestratorTests
{
    [Fact]
    public void ExecuteModule_ComModuloRegistrado_DeveExecutar()
    {
        // Arrange
        var orchestrator = new ApplicationOrchestrator();
        var mockModule = new Mock<IModuleService>();
        mockModule.Setup(m => m.ModuleName).Returns("Test");
        
        orchestrator.RegisterModule(mockModule.Object);

        // Act
        orchestrator.ExecuteModule("Test");

        // Assert
        mockModule.Verify(m => m.Execute(), Times.Once);
    }
}
```

---

## Dica: Preparando para Injeção de Dependência

Quando implementar DI, estruture assim:

**Program.cs (com DI):**
```csharp
var services = new ServiceCollection();

// Registrar serviços
services.AddSingleton<IApplicationOrchestrator, ApplicationOrchestrator>();
services.AddSingleton(ModuleServiceFactory.CreateAll());

var serviceProvider = services.BuildServiceProvider();

// Usar
var orchestrator = serviceProvider.GetRequiredService<IApplicationOrchestrator>();
orchestrator.ExecuteAllModules();
```

Sua estrutura atual facilita essa transição!

---

## Checklist para Novo Módulo

- [ ] Módulo criado em `MindSetCSharp.Core/SeuTema/`
- [ ] `SeuTemaModule.cs` implementado com método `Run()`
- [ ] `SeuTemaModuleService` criado em `Modules/`
- [ ] Namespace adicionado em `GlobalUsings.cs`
- [ ] Factory atualizada com novo serviço
- [ ] Testes escritos (opcional mas recomendado)
- [ ] `ARCHITECTURE.md` atualizado (opcional)
