# Exemplos de Uso - MindSetCSharp.Application

## 1. Executar Todos os Módulos

O código padrão que está em `Program.cs`:

```csharp
// Criar orquestrador
IApplicationOrchestrator orchestrator = new ApplicationOrchestrator();

// Registrar todos os módulos
foreach (var moduleService in ModuleServiceFactory.CreateAll())
{
    orchestrator.RegisterModule(moduleService);
}

// Executar todos
orchestrator.ExecuteAllModules();
```

**Saída esperada:**
```
=== MindSet CSharp: Use Mindset com CSharp ===
Explorando a base fundamental da programação em C#

Registrando módulos...

Total de módulos registrados: 19

--- Iniciando execução dos módulos ---

=== PRODUTIVO ===
[Exemplos do módulo...]

=== BASTIDORES ===
[Exemplos do módulo...]

... (17 módulos mais)

=== Fim do programa ===
```

---

## 2. Executar Um Módulo Específico

```csharp
var orchestrator = new ApplicationOrchestrator();

// Registrar apenas um módulo
var linqModule = ModuleServiceFactory.Create("LINQ");
orchestrator.RegisterModule(linqModule);

// Executar
orchestrator.ExecuteModule("LINQ");
```

---

## 3. Executar Múltiplos Módulos Específicos

```csharp
var orchestrator = new ApplicationOrchestrator();

// Registrar módulos selecionados
var modulosParaExecutar = new[] { "Classes", "Interface", "Herança" };

foreach (var nomeModulo in modulosParaExecutar)
{
    var module = ModuleServiceFactory.Create(nomeModulo);
    orchestrator.RegisterModule(module);
}

// Executar todos registrados
orchestrator.ExecuteAllModules();
```

---

## 4. Listar Módulos Registrados

```csharp
var orchestrator = new ApplicationOrchestrator();

// Registrar módulos
foreach (var moduleService in ModuleServiceFactory.CreateAll())
{
    orchestrator.RegisterModule(moduleService);
}

// Obter lista
var modulos = orchestrator.GetRegisteredModules();

Console.WriteLine("Módulos disponíveis:");
foreach (var nomeModulo in modulos)
{
    Console.WriteLine($"  - {nomeModulo}");
}
```

**Saída:**
```
Módulos disponíveis:
  - Produtivo
  - Bastidores
  - Objetos
  - Tipos
  - Referências
  - Encapsulamento
  - Herança
  - Interface
  - Classes
  - Enumerações
  - Coleções
  - Arquivos
  - Exceções
  - Eventos
  - Delegates
  - Revisão
  - Controles
  - Gráficos
  - LINQ
```

---

## 5. Executar Módulo por Entrada do Usuário

```csharp
var orchestrator = new ApplicationOrchestrator();

// Registrar todos
foreach (var moduleService in ModuleServiceFactory.CreateAll())
{
    orchestrator.RegisterModule(moduleService);
}

Console.WriteLine("Digite o nome do módulo a executar:");
string nomeModulo = Console.ReadLine() ?? "";

try
{
    orchestrator.ExecuteModule(nomeModulo);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
```

---

## 6. Criar um Novo Módulo Customizado

### Passo 1: Criar a classe do módulo em Core

```csharp
// MindSetCSharp.Core/MeuTema/MeuTemaModule.cs
namespace MindSetCSharp.Core.MeuTema;

public static class MeuTemaModule
{
    public static void Run()
    {
        Console.WriteLine("\n=== MEU TEMA ===");
        Console.WriteLine("Exemplos do meu tema...");
        
        Exemplo1();
        Exemplo2();
    }

    private static void Exemplo1()
    {
        Console.WriteLine("Exemplo 1");
    }

    private static void Exemplo2()
    {
        Console.WriteLine("Exemplo 2");
    }
}
```

### Passo 2: Criar o serviço em Application

```csharp
// MindSetCSharp.Application/Modules/MeuTemaModuleService.cs
namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

public class MeuTemaModuleService : IModuleService
{
    public string ModuleName => "MeuTema";

    public void Execute()
    {
        MeuTemaModule.Run();
    }
}
```

### Passo 3: Adicionar à Factory

```csharp
// MindSetCSharp.Application/Factories/ModuleServiceFactory.cs
public static IModuleService Create(string moduleName)
{
    return moduleName switch
    {
        // ... existentes ...
        "MeuTema" => new MeuTemaModuleService(),  // ← Adicionar
        _ => throw new ArgumentException(...)
    };
}

public static IEnumerable<IModuleService> CreateAll()
{
    return new IModuleService[]
    {
        // ... existentes ...
        new MeuTemaModuleService(),  // ← Adicionar
    };
}
```

### Passo 4: Usar

```csharp
var orchestrator = new ApplicationOrchestrator();
var meuModulo = ModuleServiceFactory.Create("MeuTema");
orchestrator.RegisterModule(meuModulo);
orchestrator.ExecuteModule("MeuTema");
```

---

## 7. Implementar um Orquestrador Customizado

```csharp
// MindSetCSharp.Application/Services/OrchestradorComLog.cs
using MindSetCSharp.Application.Interfaces;

public class OrchestradorComLog : IApplicationOrchestrator
{
    private readonly Dictionary<string, IModuleService> _modules = new();

    public void RegisterModule(IModuleService moduleService)
    {
        if (moduleService == null)
            throw new ArgumentNullException(nameof(moduleService));

        _modules[moduleService.ModuleName] = moduleService;
        Console.WriteLine($"[LOG] Módulo registrado: {moduleService.ModuleName}");
    }

    public void ExecuteAllModules()
    {
        Console.WriteLine("[LOG] Iniciando execução de todos os módulos...");
        
        foreach (var module in _modules.Values)
        {
            ExecuteModuleSafely(module);
        }
        
        Console.WriteLine("[LOG] Execução concluída.");
    }

    public void ExecuteModule(string moduleName)
    {
        if (!_modules.TryGetValue(moduleName, out var module))
            throw new InvalidOperationException($"Módulo '{moduleName}' não encontrado");

        Console.WriteLine($"[LOG] Executando módulo: {moduleName}");
        ExecuteModuleSafely(module);
        Console.WriteLine($"[LOG] Módulo executado com sucesso: {moduleName}");
    }

    public IReadOnlyList<string> GetRegisteredModules()
    {
        return _modules.Keys.ToList().AsReadOnly();
    }

    private void ExecuteModuleSafely(IModuleService module)
    {
        try
        {
            module.Execute();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERRO] Módulo '{module.ModuleName}': {ex.Message}");
        }
    }
}
```

**Uso:**
```csharp
IApplicationOrchestrator orchestrator = new OrchestradorComLog();

foreach (var moduleService in ModuleServiceFactory.CreateAll())
{
    orchestrator.RegisterModule(moduleService);
}

orchestrator.ExecuteAllModules();
```

---

## 8. Filtrar e Executar Módulos Contendo Padrão

```csharp
var orchestrator = new ApplicationOrchestrator();

// Registrar todos
foreach (var moduleService in ModuleServiceFactory.CreateAll())
{
    orchestrator.RegisterModule(moduleService);
}

// Filtrar módulos que contêm "Module" no nome
var modulosFiltrados = orchestrator.GetRegisteredModules()
    .Where(m => m.Contains("e", StringComparison.OrdinalIgnoreCase))
    .ToList();

Console.WriteLine($"Módulos com 'e': {string.Join(", ", modulosFiltrados)}");

// Executar apenas os filtrados
foreach (var modulo in modulosFiltrados)
{
    orchestrator.ExecuteModule(modulo);
}
```

---

## 9. Contar e Reportar Execução

```csharp
var orchestrator = new ApplicationOrchestrator();
int totalExecutado = 0;
int totalFalhos = 0;

// Registrar
foreach (var moduleService in ModuleServiceFactory.CreateAll())
{
    orchestrator.RegisterModule(moduleService);
}

// Executar com contagem
var modulos = orchestrator.GetRegisteredModules();
foreach (var nomeModulo in modulos)
{
    try
    {
        orchestrator.ExecuteModule(nomeModulo);
        totalExecutado++;
    }
    catch (Exception)
    {
        totalFalhos++;
    }
}

Console.WriteLine($"\n=== RELATÓRIO ===");
Console.WriteLine($"Total de módulos: {modulos.Count}");
Console.WriteLine($"Executados com sucesso: {totalExecutado}");
Console.WriteLine($"Falhados: {totalFalhos}");
```

---

## 10. Usar Com Injeção de Dependência (Futuro)

Exemplo de como será quando implementar DI:

```csharp
// Program.cs com Microsoft.Extensions.DependencyInjection
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Registrar serviços
services.AddSingleton<IApplicationOrchestrator, ApplicationOrchestrator>();
services.AddSingleton(ModuleServiceFactory.CreateAll());

var serviceProvider = services.BuildServiceProvider();

// Usar
var orchestrator = serviceProvider.GetRequiredService<IApplicationOrchestrator>();

foreach (var moduleService in serviceProvider.GetRequiredService<IEnumerable<IModuleService>>())
{
    orchestrator.RegisterModule(moduleService);
}

orchestrator.ExecuteAllModules();
```

---

## 11. Testar um Módulo em Isolamento

```csharp
using Xunit;

public class LinqModuleServiceTests
{
    [Fact]
    public void Execute_DeveExecutarSemErros()
    {
        // Arrange
        var service = new LINQModuleService();

        // Act & Assert
        var exception = Record.Exception(() => service.Execute());
        Assert.Null(exception);
    }

    [Fact]
    public void ModuleName_DeveSerLINQ()
    {
        // Arrange & Act
        var service = new LINQModuleService();

        // Assert
        Assert.Equal("LINQ", service.ModuleName);
    }
}
```

---

## 12. Mocking para Testes

```csharp
using Moq;

public class ApplicationOrchestratorTests
{
    [Fact]
    public void RegisterModule_DeveAdicionarAoDicionario()
    {
        // Arrange
        var orchestrator = new ApplicationOrchestrator();
        var mockModule = new Mock<IModuleService>();
        mockModule.Setup(m => m.ModuleName).Returns("Test");

        // Act
        orchestrator.RegisterModule(mockModule.Object);

        // Assert
        var modules = orchestrator.GetRegisteredModules();
        Assert.Contains("Test", modules);
    }

    [Fact]
    public void ExecuteModule_DeveExecutarModuloRegistrado()
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

## Resumo dos Casos de Uso

| Caso de Uso | Exemplo |
|-------------|---------|
| Executar tudo | `orchestrator.ExecuteAllModules()` |
| Executar um | `orchestrator.ExecuteModule("LINQ")` |
| Listar módulos | `orchestrator.GetRegisteredModules()` |
| Criar novo módulo | Implementar `IModuleService` |
| Orquestrador custom | Estender `IApplicationOrchestrator` |
| Testar em isolamento | Usar `Moq` com interfaces |
| Com DI | `services.AddSingleton<IApplicationOrchestrator>` |

Todos esses exemplos demonstram a flexibilidade e extensibilidade da nova arquitetura!
