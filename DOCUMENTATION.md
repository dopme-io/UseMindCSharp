# MindSetCSharp - Documentação do Projeto

## Visão Geral

Projeto educacional completo em .NET 10 que explora fundamentos e conceitos avançados de C# através de uma abordagem prática e modular.

## Arquitetura da Solução

### Estrutura de Projetos

**MindSetCSharp.sln** - Solução principal contendo:

1. **MindSetCSharp.Core** (Class Library)
   - Biblioteca de classes com todos os módulos educacionais
   - Target Framework: net10.0
   - Organizada em 19 módulos temáticos

2. **MindSetCSharp.Console** (Console App)
   - Aplicação demonstrativa
   - Referencia MindSetCSharp.Core
   - Entry point para executar todos os módulos

## Módulos Implementados

| Módulo | Namespace | Descrição |
|--------|-----------|-----------|
| Produtivo | `MindSetCSharp.Core.Produtivo` | Técnicas de produtividade |
| Bastidores | `MindSetCSharp.Core.Bastidores` | Internos da execução .NET |
| Objetos | `MindSetCSharp.Core.Objetos` | Fundamentos de POO |
| Tipos | `MindSetCSharp.Core.Tipos` | Tipos de dados em C# |
| Referências | `MindSetCSharp.Core.Referencias` | Trabalho com referências |
| Encapsulamento | `MindSetCSharp.Core.Encapsulamento` | Princípios de encapsulamento |
| Herança | `MindSetCSharp.Core.Heranca` | Conceitos de herança |
| Interface | `MindSetCSharp.Core.Interface` | Uso de interfaces |
| Classes | `MindSetCSharp.Core.Classes` | Criação e uso de classes |
| Enumerações | `MindSetCSharp.Core.Enumeracoes` | Definição e uso de enums |
| Coleções | `MindSetCSharp.Core.Colecoes` | Arrays, listas, dicionários |
| Arquivos | `MindSetCSharp.Core.Arquivos` | Manipulação de arquivos |
| Exceções | `MindSetCSharp.Core.Excecoes` | Tratamento de exceções |
| Eventos | `MindSetCSharp.Core.Eventos` | Sistema de eventos |
| Delegates | `MindSetCSharp.Core.Delegates` | Uso de delegados |
| Revisão | `MindSetCSharp.Core.Revisao` | Exercícios e desafios |
| Controles | `MindSetCSharp.Core.Controles` | Controles de interface |
| Gráficos | `MindSetCSharp.Core.Graficos` | Criação de gráficos |
| LINQ | `MindSetCSharp.Core.LINQ` | Language Integrated Query |

## Como Usar

### Pré-requisitos

```powershell
# Verificar versão do .NET
dotnet --version
# Deve retornar 10.0.x ou superior
```

### Comandos Principais

```powershell
# Compilar toda a solução
dotnet build

# Executar aplicação console
dotnet run --project MindSetCSharp.Console

# Limpar artefatos de build
dotnet clean

# Restaurar dependências
dotnet restore
```

### Estrutura de Arquivos

```
MindSetCSharp/
│
├── MindSetCSharp.sln                    # Solução principal
│
├── MindSetCSharp.Console/
│   ├── Program.cs                       # Entry point da aplicação
│   └── MindSetCSharp.Console.csproj     # Projeto console
│
├── MindSetCSharp.Core/
│   ├── Produtivo/
│   │   └── ProdutivoModule.cs
│   ├── Bastidores/
│   │   └── BastidoresModule.cs
│   ├── Objetos/
│   │   └── ObjetosModule.cs
│   ├── Tipos/
│   │   └── TiposModule.cs
│   ├── Referencias/
│   │   └── ReferenciasModule.cs
│   ├── Encapsulamento/
│   │   └── EncapsulamentoModule.cs
│   ├── Herança/
│   │   └── HerancaModule.cs
│   ├── Interface/
│   │   └── InterfaceModule.cs
│   ├── Classes/
│   │   └── ClassesModule.cs
│   ├── Enumerações/
│   │   └── EnumeracoesModule.cs
│   ├── Coleções/
│   │   └── ColecoesModule.cs
│   ├── Arquivos/
│   │   └── ArquivosModule.cs
│   ├── Exceções/
│   │   └── ExcecoesModule.cs
│   ├── Eventos/
│   │   └── EventosModule.cs
│   ├── Delegates/
│   │   └── DelegatesModule.cs
│   ├── Revisão/
│   │   └── RevisaoModule.cs
│   ├── Controles/
│   │   └── ControlesModule.cs
│   ├── Gráficos/
│   │   └── GraficosModule.cs
│   ├── LINQ/
│   │   └── LINQModule.cs
│   └── MindSetCSharp.Core.csproj        # Projeto class library
│
├── README.md                            # Documentação principal
├── LICENSE                              # Licença do projeto
└── .gitignore                           # Arquivos ignorados pelo Git
```

## Padrões de Código

### Convenções de Nomenclatura

- **Namespaces**: PascalCase seguindo a estrutura de pastas
- **Classes**: PascalCase com sufixo "Module" para módulos
- **Métodos**: PascalCase (ex: `Run()`)
- **Propriedades**: PascalCase

### Estrutura de Módulo

Cada módulo segue o padrão:

```csharp
using System;

namespace MindSetCSharp.Core.[NomeModulo];

public static class [Nome]Module
{
    public static void Run()
    {
        Console.WriteLine("[Descrição do módulo]");
        // Implementação específica
    }
}
```

## Próximos Passos

Para expandir o projeto, considere:

1. **Adicionar testes unitários**
   ```powershell
   dotnet new xunit -n MindSetCSharp.Tests
   dotnet sln add MindSetCSharp.Tests/MindSetCSharp.Tests.csproj
   ```

2. **Implementar exemplos práticos** em cada módulo

3. **Adicionar documentação XML** para IntelliSense

4. **Criar projetos de exemplo** para conceitos avançados

5. **Adicionar configurações EditorConfig** para padronização

## Contribuindo

Este projeto segue os princípios:

- **Código limpo** e legível
- **Documentação clara** em português
- **Exemplos práticos** e funcionais
- **Organização modular** por conceito

## Recursos Adicionais

- [Documentação oficial do .NET](https://learn.microsoft.com/pt-br/dotnet/)
- [C# Programming Guide](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [.NET API Browser](https://learn.microsoft.com/pt-br/dotnet/api/)

## Status do Projeto

✅ Estrutura base implementada  
✅ Todos os 19 módulos criados  
✅ Aplicação console funcional  
✅ Build e execução validados  
✅ README atualizado  

Projeto pronto para desenvolvimento incremental de conteúdo!
