# Módulo Objetos - Fundamentos de POO

## 📖 Visão Geral

Este módulo demonstra os conceitos fundamentais da Programação Orientada a Objetos (POO) em C#, incluindo criação de classes, instanciação de objetos, propriedades, métodos e interações entre objetos.

## 🎯 Objetivos de Aprendizado

- Compreender o que são objetos e classes
- Criar e instanciar objetos
- Definir propriedades e métodos
- Trabalhar com construtores
- Entender referências de objetos
- Praticar interações entre múltiplos objetos

## 📁 Arquivos do Módulo

### `Pessoa.cs`
Classe básica demonstrando:
- Propriedades auto-implementadas
- Múltiplos construtores (sobrecarga)
- Métodos de instância
- Override do método `ToString()`

**Conceitos demonstrados:**
```csharp
// Construtor padrão
Pessoa pessoa1 = new Pessoa();

// Construtor com parâmetros
Pessoa pessoa2 = new Pessoa("Maria", 25, "maria@email.com");

// Chamando métodos
pessoa2.ApresentarSe();
pessoa2.FazerAniversario();
```

### `ContaBancaria.cs`
Classe mais complexa demonstrando:
- Encapsulamento (campos privados)
- Propriedades somente leitura
- Estado e comportamento
- Validações em métodos
- Interação entre objetos (transferências)

**Conceitos demonstrados:**
```csharp
ContaBancaria conta = new ContaBancaria("Ana Paula", "12345-6", 1000m);
conta.Depositar(500m);
conta.Sacar(200m);
conta.Transferir(outraConta, 300m);
```

### `ExemplosObjetos.cs`
Classe estática com 4 exemplos práticos:

1. **ExemploPessoa()** - Criação e uso básico de objetos
2. **ExemploContaBancaria()** - Estado e comportamento de objetos
3. **ExemploMultiplosObjetos()** - Trabalhando com coleções de objetos
4. **ExemploReferencias()** - Entendendo referências de objetos

### `ObjetosModule.cs`
Módulo principal que orquestra todos os exemplos.

## 🚀 Como Executar

### Executar todos os exemplos:
```powershell
dotnet run --project MindSetCSharp.Console
```

### Executar apenas este módulo (modificar Program.cs):
```csharp
using MindSetCSharp.Core.Objetos;

ObjetosModule.Run();
```

## 💡 Conceitos-Chave

### 1. Classes vs Objetos
- **Classe**: molde/template (ex: "Pessoa")
- **Objeto**: instância concreta (ex: "Maria Silva, 25 anos")

### 2. Estado e Comportamento
- **Estado**: dados armazenados em propriedades (ex: `Nome`, `Idade`)
- **Comportamento**: ações realizadas por métodos (ex: `ApresentarSe()`)

### 3. Construtores
- Métodos especiais para inicializar objetos
- Podem ter sobrecarga (múltiplas versões)
- Executam automaticamente na criação do objeto

### 4. Encapsulamento
- Campos privados protegem dados internos
- Propriedades públicas controlam acesso
- Validações em métodos garantem consistência

### 5. Referências
- Variáveis de objetos armazenam **referências** (endereços de memória)
- Múltiplas variáveis podem referenciar o mesmo objeto
- Alterações afetam todas as referências

## 📊 Exemplos de Saída

```
╔═══════════════════════════════════════════════════════╗
║         EXEMPLO 1: Objetos Pessoa                    ║
╚═══════════════════════════════════════════════════════╝

Pessoa 2 (construtor completo):
Olá! Meu nome é Maria Silva, tenho 25 anos.
Meu e-mail é: maria@email.com

Maria Silva é maior de idade? True
```

```
════════════════════════════════
        EXTRATO BANCÁRIO         
════════════════════════════════
Conta: 12345-6
Titular: Ana Paula
Saldo Atual: R$ 1000,00
════════════════════════════════
```

## 🔧 Exercícios Sugeridos

1. **Criar nova classe `Produto`**
   - Propriedades: Nome, Preço, Estoque
   - Métodos: VenderUnidades(), ReporEstoque()

2. **Estender classe `Pessoa`**
   - Adicionar propriedade CPF
   - Criar método para validar CPF
   - Adicionar data de nascimento e calcular idade

3. **Sistema de Biblioteca**
   - Criar classes: Livro, Autor, Biblioteca
   - Implementar empréstimo e devolução
   - Gerenciar múltiplos livros

4. **Aprimorar `ContaBancaria`**
   - Adicionar histórico de transações
   - Implementar diferentes tipos de conta
   - Adicionar limite de cheque especial

## 📚 Recursos Adicionais

- [Classes e Objetos - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/types/classes)
- [Propriedades em C#](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/properties)
- [Construtores](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/constructors)

## ✅ Checklist de Aprendizado

- [ ] Entendo a diferença entre classe e objeto
- [ ] Sei criar objetos usando construtores
- [ ] Compreendo propriedades e métodos
- [ ] Sei trabalhar com múltiplos objetos
- [ ] Entendo como referências funcionam
- [ ] Consigo aplicar encapsulamento básico

---

**Próximo módulo:** [Tipos](../Tipos/) - Explorando tipos de valor e referência em profundidade.
