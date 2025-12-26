# Arquitetura de Camadas - MindSetCSharp

## Visão Geral

O projeto foi refatorado para seguir um padrão de **arquitetura em camadas** (Layered Architecture), promovendo melhor separação de responsabilidades e desacoplamento entre os componentes.

## Estrutura de Camadas

### 1. **MindSetCSharp.Console** (Camada de Apresentação)
- **Responsabilidade**: Ponto de entrada da aplicação
- **Dependências**: MindSetCSharp.Application
- **Conteúdo**:
  - `Program.cs`: Orquestra a execução dos módulos através do `ApplicationOrchestrator`
  - `GlobalUsings.cs`: Define os namespaces globais

**Benefícios do Desacoplamento**:
- Não depende mais diretamente do Core
- Usa abstrações (`IApplicationOrchestrator`, `IModuleService`)
- Facilita testes e mudanças futuras

### 2. **MindSetCSharp.Application** (Camada de Aplicação) ⭐ NOVA
- **Responsabilidade**: Orquestração e coordenação de funcionalidades
- **Dependências**: MindSetCSharp.Core
- **Conteúdo**:

#### Interfaces (`Interfaces/`)
- `IModuleService`: Contrato para serviços de módulos
  - Define `ModuleName` e `Execute()`
  - Abstração que desacopla a apresentação da lógica

- `IApplicationOrchestrator`: Contrato para orquestração
  - Gerencia registro e execução de módulos
  - Implementa tratamento de erros

#### Serviços (`Services/`)
- `ApplicationOrchestrator`: Implementa `IApplicationOrchestrator`
  - Registra módulos dinamicamente
  - Executa todos ou módulos específicos
  - Trata exceções durante execução

#### Módulos (`Modules/`)
- 19 serviços de módulo implementando `IModuleService`
- Exemplos:
  - `ProdutivoModuleService`
  - `ArquivosModuleService`
  - `LINQModuleService`
  - etc...

#### Factory (`Factories/`)
- `ModuleServiceFactory`: Padrão Factory para criação de módulos
  - `Create(string moduleName)`: Cria módulo específico
  - `CreateAll()`: Cria todas as instâncias

### 3. **MindSetCSharp.Core** (Camada de Negócio/Domínio)
- **Responsabilidade**: Lógica central de ensino e exemplos
- **Dependências**: Nenhuma (camada isolada)
- **Conteúdo**: 19 módulos temáticos
  - Produtivo, Bastidores, Objetos, Tipos, etc.
  - Classes, Interfaces, Enumerações, Coleções, etc.
  - LINQ, Exceções, Eventos, Delegates, etc.

## Fluxo de Execução

```
Console.Program
    ↓
ApplicationOrchestrator (IApplicationOrchestrator)
    ↓
ModuleServiceFactory.CreateAll()
    ↓
IModuleService[] (19 implementações)
    ↓
Core.Modules (ProdutivoModule, ArquivosModule, etc...)
```

## Benefícios da Refatoração

### ✅ Desacoplamento
- **Antes**: Console dependia diretamente de cada módulo
- **Depois**: Console depende de abstrações (interfaces)

### ✅ Flexibilidade
- Fácil adicionar novos módulos sem modificar Console
- Implementar novos orquestradores sem mudar Core

### ✅ Testabilidade
- Interfaces facilitam mocks e testes unitários
- Factory permite testes isolados

### ✅ Manutenibilidade
- Responsabilidades bem definidas
- Código mais organizado e legível

### ✅ Escalabilidade
- Padrão Factory permite crescimento
- Novo tipos de serviços podem ser adicionados facilmente

## Padrões de Design Utilizados

1. **Strategy Pattern**: IModuleService define diferentes estratégias de execução
2. **Factory Pattern**: ModuleServiceFactory cria instâncias
3. **Facade Pattern**: ApplicationOrchestrator simplifica a complexidade
4. **Dependency Injection Ready**: Estrutura preparada para DI

## Exemplo de Uso

### Executar todos os módulos:
```csharp
IApplicationOrchestrator orchestrator = new ApplicationOrchestrator();

foreach (var module in ModuleServiceFactory.CreateAll())
{
    orchestrator.RegisterModule(module);
}

orchestrator.ExecuteAllModules();
```

### Executar módulo específico:
```csharp
var orchestrator = new ApplicationOrchestrator();
var moduloLINQ = ModuleServiceFactory.Create("LINQ");
orchestrator.RegisterModule(moduloLINQ);
orchestrator.ExecuteModule("LINQ");
```

### Obter módulos registrados:
```csharp
var modules = orchestrator.GetRegisteredModules();
Console.WriteLine($"Módulos: {string.Join(", ", modules)}");
```

## Próximos Passos Sugeridos

1. **Injeção de Dependência**
   - Implementar `IServiceProvider` ou usar `Microsoft.Extensions.DependencyInjection`
   - Facilitar testes e configuração

2. **Configuração**
   - Adicionar `IConfiguration` para controlar quais módulos executar
   - Arquivo `appsettings.json`

3. **Logging**
   - Implementar `ILogger` em `ApplicationOrchestrator`
   - Registrar execução e erros

4. **Testes**
   - Testes unitários para `ApplicationOrchestrator`
   - Mocks de `IModuleService` para testes

## Estrutura de Diretórios

```
MindSetCSharp.Application/
├── GlobalUsings.cs
├── MindSetCSharp.Application.csproj
├── Interfaces/
│   ├── IModuleService.cs
│   └── IApplicationOrchestrator.cs
├── Services/
│   └── ApplicationOrchestrator.cs
├── Modules/
│   ├── ProdutivoModuleService.cs
│   ├── ArquivosModuleService.cs
│   ├── LINQModuleService.cs
│   └── ... (19 total)
└── Factories/
    └── ModuleServiceFactory.cs
```

## Dependências entre Projetos

```
MindSetCSharp.Console
    ↓ (depende de)
MindSetCSharp.Application
    ↓ (depende de)
MindSetCSharp.Core
```

Fluxo de dependência: **apresentação → aplicação → domínio**

Sem referências cíclicas, permitindo composição clara.
