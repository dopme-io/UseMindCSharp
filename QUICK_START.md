# Guia Rápido - MindSetCSharp.Application

## ⚡ Início Rápido (5 minutos)

### 1. O que foi criado?

Uma **nova camada de aplicação** que desacopla o Console do Core:

```
Antes:      Console → Module.Run() → Core
Depois:     Console → Orchestrator → ModuleService → Core
```

### 2. Como usar?

#### Opção A: Executar Tudo (Padrão)

```csharp
var orchestrator = new ApplicationOrchestrator();

foreach (var module in ModuleServiceFactory.CreateAll())
{
    orchestrator.RegisterModule(module);
}

orchestrator.ExecuteAllModules();
```

#### Opção B: Executar Um Módulo

```csharp
var orchestrator = new ApplicationOrchestrator();
var module = ModuleServiceFactory.Create("LINQ");
orchestrator.RegisterModule(module);
orchestrator.ExecuteModule("LINQ");
```

#### Opção C: Listar Módulos

```csharp
var modules = orchestrator.GetRegisteredModules();
foreach (var name in modules)
{
    Console.WriteLine(name);
}
```

### 3. Estrutura

```
MindSetCSharp.Application/
├── Interfaces/        ← Contratos (IModuleService, IApplicationOrchestrator)
├── Services/          ← Implementação (ApplicationOrchestrator)
├── Modules/           ← 19 adaptadores (ProdutivoModuleService, etc.)
└── Factories/         ← ModuleServiceFactory
```

### 4. Arquivos Importantes

| Arquivo | Propósito |
|---------|-----------|
| `IModuleService` | Define que todo módulo precisa de `ModuleName` e `Execute()` |
| `IApplicationOrchestrator` | Define como registrar e executar módulos |
| `ApplicationOrchestrator` | Implementação que gerencia execução |
| `ModuleServiceFactory` | Cria instâncias de módulos |

### 5. Adicionar Novo Módulo (3 Passos)

**Passo 1**: Criar `*ModuleService` em `Modules/`
```csharp
public class MeuTemaModuleService : IModuleService
{
    public string ModuleName => "MeuTema";
    public void Execute() => MeuTemaModule.Run();
}
```

**Passo 2**: Adicionar à `ModuleServiceFactory`
```csharp
"MeuTema" => new MeuTemaModuleService(),
```

**Passo 3**: Pronto! Usar normalmente
```csharp
var module = ModuleServiceFactory.Create("MeuTema");
```

---

## 📚 Documentação Completa

| Arquivo | Quando Ler |
|---------|-----------|
| [ARCHITECTURE.md](ARCHITECTURE.md) | Entender a estrutura geral |
| [ARCHITECTURE_DIAGRAM.md](ARCHITECTURE_DIAGRAM.md) | Ver diagramas visuais |
| [EXTENSION_GUIDE.md](EXTENSION_GUIDE.md) | Adicionar funcionalidades |
| [USAGE_EXAMPLES.md](USAGE_EXAMPLES.md) | Ver exemplos práticos |
| [REFACTORING_SUMMARY.md](REFACTORING_SUMMARY.md) | Entender as mudanças |

---

## 🎯 Benefícios Principais

| Benefício | Antes | Depois |
|-----------|-------|--------|
| **Acoplamento** | Console depende de 19 módulos | Console usa abstração |
| **Flexibilidade** | Adicionar módulo = editar Console | Só criar `*ModuleService` |
| **Testes** | Difícil mockar | Interfaces facilitam mocks |
| **Manutenção** | 19 imports no Console | Factory centraliza tudo |

---

## ❓ Perguntas Frequentes

### P: Preciso mudar algo no Console?

**R**: Não! O Console está pronto. Ele usa `ApplicationOrchestrator` e `ModuleServiceFactory`.

### P: Como adicionar um novo módulo?

**R**: Criar `*ModuleService` em `Modules/` e registrar em `ModuleServiceFactory`. Veja [EXTENSION_GUIDE.md](EXTENSION_GUIDE.md).

### P: Posso criar meu próprio Orchestrator?

**R**: Sim! Implemente `IApplicationOrchestrator`. Veja exemplo em [USAGE_EXAMPLES.md](USAGE_EXAMPLES.md#7-implementar-um-orquestrador-customizado).

### P: Como testar isso?

**R**: Use Moq com as interfaces. Exemplo em [USAGE_EXAMPLES.md](USAGE_EXAMPLES.md#12-mocking-para-testes).

### P: Posso usar com Injeção de Dependência?

**R**: Sim! Estrutura está pronta. Exemplo em [USAGE_EXAMPLES.md](USAGE_EXAMPLES.md#10-usar-com-injeção-de-dependência-futuro).

---

## 🔧 Estrutura de Namespaces

```
MindSetCSharp
├── Console.*              ← Apresentação
├── Application
│   ├── .Interfaces       ← Contratos
│   ├── .Services         ← Orquestração
│   ├── .Modules          ← Adaptadores
│   └── .Factories        ← Criação
└── Core.*                ← Domínio
```

**Regra**: Console → Application → Core (sem volta!)

---

## 📦 Dependências Entre Projetos

```
MindSetCSharp.Console
  ↓ (depende de)
MindSetCSharp.Application
  ↓ (depende de)
MindSetCSharp.Core
```

- ✅ Sem dependências cíclicas
- ✅ Fluxo claro de dependências
- ✅ Fácil entender o que depende do quê

---

## 🚀 Exemplos Rápidos

### Listar Todos os Módulos

```csharp
var factory = new ModuleServiceFactory();
var modules = ModuleServiceFactory.CreateAll();

foreach (var module in modules)
{
    Console.WriteLine(module.ModuleName);
}
```

**Output:**
```
Produtivo
Bastidores
Objetos
Tipos
...
LINQ
```

### Executar Módulo Especificado pelo Usuário

```csharp
var orchestrator = new ApplicationOrchestrator();
ModuleServiceFactory.CreateAll().ForEach(m => 
    orchestrator.RegisterModule(m));

Console.Write("Digite o módulo: ");
string nome = Console.ReadLine() ?? "";

orchestrator.ExecuteModule(nome);
```

### Contar Quantos Módulos Têm

```csharp
var count = ModuleServiceFactory.CreateAll().Count();
Console.WriteLine($"Total: {count} módulos");
```

---

## 💡 Dicas

1. **Use Factory** para criar módulos, não `new SeuModuleService()`
2. **Dependa de interfaces**, não de implementações
3. **ApplicationOrchestrator trata erros**, seus serviços podem ser seguros
4. **Namespaces globais** já estão configurados em GlobalUsings.cs

---

## ✅ Validação

Para confirmar que tudo está funcionando:

1. Abra a solução em Visual Studio
2. Build MindSetCSharp.Console
3. Execute o programa
4. Deve ver os 19 módulos sendo executados

Se der erro, verifique se as referências de projeto estão corretas.

---

## 📚 Próximas Leituras

**Se quiser entender mais:**
1. Leia [ARCHITECTURE.md](ARCHITECTURE.md) para visão completa
2. Leia [EXTENSION_GUIDE.md](EXTENSION_GUIDE.md) para estender
3. Veja código em `MindSetCSharp.Application/` para ver padrões

**Se quiser adicionar funcionalidades:**
1. Veja [USAGE_EXAMPLES.md](USAGE_EXAMPLES.md) para inspiração
2. Implemente `IModuleService` para novo módulo
3. Ou implemente `IApplicationOrchestrator` para novo orquestrador

---

## 🎯 Resumo em 1 Minuto

- ✅ Nova camada `MindSetCSharp.Application` criada
- ✅ 19 `ModuleService` implementados
- ✅ `ApplicationOrchestrator` orquestra execução
- ✅ `ModuleServiceFactory` cria instâncias
- ✅ Console refatorado e desacoplado
- ✅ Documentação completa disponível

**Status**: 🟢 Pronto para usar!

---

**Dúvidas?** Consulte um dos documentos listados acima.

**Quer contribuir?** Veja [EXTENSION_GUIDE.md](EXTENSION_GUIDE.md).

**Quer ver exemplos?** Veja [USAGE_EXAMPLES.md](USAGE_EXAMPLES.md).
