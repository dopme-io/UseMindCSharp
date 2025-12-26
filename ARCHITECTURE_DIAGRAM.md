# Diagrama de Arquitetura - MindSetCSharp

## Diagrama de Dependências

```
┌─────────────────────────────────────────────────────────────┐
│                   MindSetCSharp.Console                      │
│              (Camada de Apresentação)                        │
│                                                              │
│  Program.cs                                                  │
│  └─ Cria ApplicationOrchestrator                            │
│  └─ Registra módulos via Factory                           │
│  └─ Executa via IApplicationOrchestrator                   │
└──────────────────────┬──────────────────────────────────────┘
                       │ Depende de
                       ▼
┌─────────────────────────────────────────────────────────────┐
│              MindSetCSharp.Application                       │
│            (Camada de Aplicação) ⭐ NOVA                   │
│                                                              │
│  ┌──────────────────────────────────────────────────────┐  │
│  │ Interfaces/                                          │  │
│  │ ├─ IModuleService                                    │  │
│  │ └─ IApplicationOrchestrator                          │  │
│  └──────────────────────────────────────────────────────┘  │
│                                                              │
│  ┌──────────────────────────────────────────────────────┐  │
│  │ Services/                                            │  │
│  │ └─ ApplicationOrchestrator (impl. Orchestrator)      │  │
│  │    ├─ Registra módulos                              │  │
│  │    ├─ Executa todos os módulos                      │  │
│  │    ├─ Executa módulo específico                     │  │
│  │    └─ Trata erros                                   │  │
│  └──────────────────────────────────────────────────────┘  │
│                                                              │
│  ┌──────────────────────────────────────────────────────┐  │
│  │ Modules/ (19 Implementações)                        │  │
│  │ ├─ ProdutivoModuleService                           │  │
│  │ ├─ ArquivosModuleService                            │  │
│  │ ├─ ColecoesModuleService                            │  │
│  │ ├─ ClassesModuleService                             │  │
│  │ ├─ EnumeracoesModuleService                         │  │
│  │ ├─ EncapsulamentoModuleService                      │  │
│  │ ├─ HerancaModuleService                             │  │
│  │ ├─ InterfaceModuleService                           │  │
│  │ ├─ DelegatesModuleService                           │  │
│  │ ├─ EventosModuleService                             │  │
│  │ ├─ ExcecoesModuleService                            │  │
│  │ ├─ LINQModuleService                                │  │
│  │ ├─ ReferenciasModuleService                         │  │
│  │ ├─ ObjetosModuleService                             │  │
│  │ ├─ TiposModuleService                               │  │
│  │ ├─ ControlesModuleService                           │  │
│  │ ├─ GraficosModuleService                            │  │
│  │ ├─ RevisaoModuleService                             │  │
│  │ └─ BastidoresModuleService                          │  │
│  └──────────────────────────────────────────────────────┘  │
│                                                              │
│  ┌──────────────────────────────────────────────────────┐  │
│  │ Factories/                                           │  │
│  │ └─ ModuleServiceFactory                              │  │
│  │    ├─ Create(moduleName): IModuleService             │  │
│  │    └─ CreateAll(): IEnumerable<IModuleService>       │  │
│  └──────────────────────────────────────────────────────┘  │
└──────────────────────┬──────────────────────────────────────┘
                       │ Depende de
                       ▼
┌─────────────────────────────────────────────────────────────┐
│               MindSetCSharp.Core                             │
│            (Camada de Domínio/Negócio)                      │
│                                                              │
│  19 Módulos Temáticos:                                      │
│  ├─ Produtivo/          └─ ProdutivoModule.Run()           │
│  ├─ Bastidores/         └─ BastidoresModule.Run()          │
│  ├─ Objetos/            └─ ObjetosModule.Run()             │
│  ├─ Tipos/              └─ TiposModule.Run()               │
│  ├─ Referencias/        └─ ReferenciasModule.Run()         │
│  ├─ Encapsulamento/     └─ EncapsulamentoModule.Run()      │
│  ├─ Heranca/            └─ HerancaModule.Run()             │
│  ├─ Interface/          └─ InterfaceModule.Run()           │
│  ├─ Classes/            └─ ClassesModule.Run()             │
│  ├─ Enumeracoes/        └─ EnumeracoesModule.Run()         │
│  ├─ Colecoes/           └─ ColecoesModule.Run()            │
│  ├─ Arquivos/           └─ ArquivosModule.Run()            │
│  ├─ Excecoes/           └─ ExcecoesModule.Run()            │
│  ├─ Eventos/            └─ EventosModule.Run()             │
│  ├─ Delegates/          └─ DelegatesModule.Run()           │
│  ├─ Revisao/            └─ RevisaoModule.Run()             │
│  ├─ Controles/          └─ ControlesModule.Run()           │
│  ├─ Graficos/           └─ GraficosModule.Run()            │
│  └─ LINQ/               └─ LINQModule.Run()                │
└─────────────────────────────────────────────────────────────┘
```

## Fluxo de Execução

```
START
  │
  ├─→ Program.cs
  │
  ├─→ ApplicationOrchestrator::new()
  │
  ├─→ ModuleServiceFactory::CreateAll()
  │   └─→ IEnumerable<IModuleService> (19 módulos)
  │
  ├─→ Para cada módulo:
  │   orchestrator.RegisterModule(moduleService)
  │   │
  │   └─→ Dictionary<string, IModuleService>._modules
  │
  ├─→ orchestrator.ExecuteAllModules()
  │   │
  │   └─→ Para cada módulo registrado:
  │       ├─→ module.Execute()
  │       │   └─→ ModuleService.Execute()
  │       │       └─→ Core.ProdutivoModule.Run()
  │       │           └─→ ProdutivoModule executa exemplos
  │       │
  │       └─→ Se erro: Captura exceção e continua
  │
  └─→ END
```

## Padrões de Design Implementados

```
┌─────────────────────────────────────────────────┐
│         PADRÕES DE DESIGN UTILIZADOS            │
├─────────────────────────────────────────────────┤
│                                                  │
│  ✓ Strategy Pattern                             │
│    - IModuleService define estratégias          │
│    - Cada módulo = estratégia diferente         │
│    - Intercambiáveis em tempo de execução      │
│                                                  │
│  ✓ Factory Pattern                              │
│    - ModuleServiceFactory cria instâncias      │
│    - Centraliza lógica de criação              │
│    - Fácil adicionar novos módulos             │
│                                                  │
│  ✓ Facade Pattern                               │
│    - IApplicationOrchestrator simplifica API    │
│    - Esconde complexidade de coordenação       │
│    - Interface clara e simples                 │
│                                                  │
│  ✓ Template Method (potencial)                 │
│    - ApplicationOrchestrator define fluxo      │
│    - Subclasses customizam comportamento       │
│                                                  │
│  ✓ Dependency Injection Ready                  │
│    - Interfaces permitem injeção               │
│    - Fácil implementar com framework DI        │
│                                                  │
└─────────────────────────────────────────────────┘
```

## Comparação: Antes vs Depois

### ANTES (Acoplado)

```csharp
// Program.cs - Acoplado com cada módulo
ProdutivoModule.Run();
BastidoresModule.Run();
ObjetosModule.Run();
TiposModule.Run();
// ... 19 chamadas diretas
```

**Problemas:**
- ❌ Forte acoplamento com Core
- ❌ Difícil adicionar/remover módulos
- ❌ Impossível testar isoladamente
- ❌ Sem abstração de conceitos

### DEPOIS (Desacoplado)

```csharp
// Program.cs - Desacoplado via abstrações
IApplicationOrchestrator orchestrator = new ApplicationOrchestrator();

foreach (var moduleService in ModuleServiceFactory.CreateAll())
{
    orchestrator.RegisterModule(moduleService);
}

orchestrator.ExecuteAllModules();
```

**Benefícios:**
- ✅ Desacoplamento via interfaces
- ✅ Fácil adicionar novos módulos
- ✅ Testável com mocks
- ✅ Conceitos bem definidos
- ✅ Código extensível

## Estrutura de Namespaces

```
MindSetCSharp
├── Console/
│   └── Program (Entrada)
├── Application/
│   ├── Interfaces/         (Contratos)
│   ├── Services/           (Orquestração)
│   ├── Modules/            (Adaptadores)
│   └── Factories/          (Criação)
└── Core/
    ├── Produtivo/          (Exemplos)
    ├── Bastidores/         (Exemplos)
    ├── Classes/            (Exemplos)
    ├── LINQ/               (Exemplos)
    └── ... (mais 15 módulos)
```

## Responsabilidades por Camada

```
┌──────────────────────────────────────────┐
│ CONSOLE (Apresentação)                    │
├──────────────────────────────────────────┤
│ • Configurar aplicação                   │
│ • Orquestrar fluxo de entrada            │
│ • Exibir resultados                      │
└──────────────────────────────────────────┘
           ▼ Delega para
┌──────────────────────────────────────────┐
│ APPLICATION (Orquestração)                │
├──────────────────────────────────────────┤
│ • Registrar serviços                     │
│ • Orquestrar execução                    │
│ • Tratar erros                           │
│ • Coordenar módulos                      │
└──────────────────────────────────────────┘
           ▼ Delega para
┌──────────────────────────────────────────┐
│ CORE (Negócio/Domínio)                    │
├──────────────────────────────────────────┤
│ • Implementar lógica de negócio          │
│ • Exemplos educacionais                  │
│ • Classes de domínio                     │
│ • Algoritmos e padrões                   │
└──────────────────────────────────────────┘
```

## Pontos de Extensão

```
MindSetCSharp.Application oferece 3 pontos de extensão:

1. NOVO MÓDULO
   └─ Criar novo *ModuleService
   └─ Registrar na Factory
   └─ Pronto para usar

2. NOVO ORQUESTRADOR
   └─ Implementar IApplicationOrchestrator
   └─ Customizar lógica de execução
   └─ Usar no Program.cs

3. NOVO SERVIÇO
   └─ Criar interface em Interfaces/
   └─ Implementar em Services/
   └─ Injetar onde necessário
```
