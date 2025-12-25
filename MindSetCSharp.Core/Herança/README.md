# Módulo Herança - Reutilização e Extensão de Código

## 📖 Visão Geral

Este módulo explora em profundidade o conceito de herança em C#, demonstrando como criar hierarquias de classes, reutilizar código, estender funcionalidades e aplicar polimorfismo.

## 🎯 Objetivos de Aprendizado

- Criar hierarquias de classes (base e derivadas)
- Usar palavras-chave: `virtual`, `override`, `base`, `abstract`
- Implementar polimorfismo
- Trabalhar com classes abstratas
- Entender quando usar herança vs composição
- Aplicar princípios de reutilização de código

## 📁 Arquivos do Módulo

### `Funcionario.cs`
Hierarquia de funcionários demonstrando herança clássica:

**Classe Base: `Funcionario`**
- Propriedades comuns: Nome, CPF, DataAdmissao, SalarioBase
- Métodos `virtual`: CalcularSalario(), CalcularBonus(), ExibirInformacoes()
- Permite que classes derivadas personalizem comportamento

**Classes Derivadas:**
1. **`Gerente`** - herda Funcionario
   - Adiciona: Departamento, NumeroSubordinados
   - Sobrescreve cálculo de salário (50% a mais)
   - Bônus baseado em subordinados

2. **`Desenvolvedor`** - herda Funcionario
   - Adiciona: Linguagem, Nivel, ProjetosCompletos
   - Salário varia por nível (Junior/Pleno/Senior)
   - Bônus baseado em projetos

3. **`Estagiario`** - herda Funcionario
   - Adiciona: Curso, Universidade, DataTermino
   - Salário sem multiplicadores
   - Bônus menor

### `Veiculo.cs`
Demonstra classes abstratas e métodos abstratos:

**Classe Abstrata: `Veiculo`**
- Não pode ser instanciada diretamente
- Define template para todos os veículos
- Métodos `abstract`: Acelerar(), Frear(), ObterTipo()
- Métodos `virtual`: Buzinar(), ExibirInformacoes()
- Classes derivadas DEVEM implementar métodos abstratos

**Classes Derivadas:**
1. **`Carro`**
   - Propriedades: NumeroPortas, TipoCombustivel
   - Aceleração normal, velocidade máxima 220 km/h

2. **`Moto`**
   - Propriedades: Cilindradas, TemCarenagem
   - Acelera mais rápido (1.3x), velocidade máxima 180 km/h
   - Método especial: Empinar()

3. **`Caminhao`**
   - Propriedades: CapacidadeCarga, NumeroEixos
   - Acelera mais devagar (0.6x), velocidade máxima 120 km/h
   - Método especial: Carregar()

### `ExemplosHeranca.cs`
Cinco exemplos práticos demonstrando todos os conceitos:

1. **ExemploFuncionarios()** - Hierarquia e comportamentos específicos
2. **ExemploPolimorfismo()** - Lista de Funcionario com tipos diferentes
3. **ExemploVeiculos()** - Classes abstratas em ação
4. **ExemploPolimorfismoVeiculos()** - Tratamento polimórfico
5. **ExemploUsoDaClasseBase()** - Uso da palavra `base`

## 🚀 Como Executar

### Executar todos os exemplos:
```powershell
dotnet run --project MindSetCSharp.Console
```

### Executar apenas este módulo:
```csharp
using MindSetCSharp.Core.Heranca;

HerancaModule.Run();
```

## 💡 Conceitos-Chave

### 1. Sintaxe de Herança

```csharp
// Classe base
public class Animal
{
    public string Nome { get; set; }
    
    public virtual void EmitirSom()
    {
        Console.WriteLine("Som genérico");
    }
}

// Classe derivada
public class Cachorro : Animal  // : indica herança
{
    // Sobrescreve método da classe base
    public override void EmitirSom()
    {
        Console.WriteLine("Au au!");
    }
}
```

### 2. Modificadores de Herança

**`virtual`** - Marca método que pode ser sobrescrito
```csharp
public virtual decimal CalcularSalario()
{
    return SalarioBase;
}
```

**`override`** - Sobrescreve método virtual da classe base
```csharp
public override decimal CalcularSalario()
{
    return SalarioBase * 1.5m;
}
```

**`base`** - Acessa membros da classe base
```csharp
// Chamar construtor da classe base
public Gerente(string nome, decimal salario) 
    : base(nome, salario)
{
    // código adicional
}

// Chamar método da classe base
public override void ExibirInfo()
{
    base.ExibirInfo();  // Chama versão da classe base
    Console.WriteLine("Info adicional");
}
```

**`abstract`** - Define método que DEVE ser implementado
```csharp
public abstract class Forma
{
    // Método abstrato (sem implementação)
    public abstract double CalcularArea();
}

public class Circulo : Forma
{
    // OBRIGATÓRIO implementar
    public override double CalcularArea()
    {
        return Math.PI * Raio * Raio;
    }
}
```

### 3. Classes Abstratas vs Concretas

**Classe Abstrata:**
- Não pode ser instanciada: `new Veiculo()` ❌
- Pode ter métodos abstratos (sem implementação)
- Pode ter métodos concretos (com implementação)
- Serve como template/base

**Classe Concreta:**
- Pode ser instanciada: `new Carro()` ✅
- Deve implementar todos os métodos abstratos herdados

### 4. Polimorfismo

Objetos de classes derivadas podem ser tratados como objetos da classe base:

```csharp
// Lista de classe base contém objetos de classes derivadas
List<Funcionario> equipe = new List<Funcionario>
{
    new Gerente("Maria", 6000m),      // Gerente É UM Funcionario
    new Desenvolvedor("João", 4500m), // Desenvolvedor É UM Funcionario
    new Estagiario("Ana", 1800m)      // Estagiario É UM Funcionario
};

// Chama o método apropriado para cada tipo
foreach (var f in equipe)
{
    // Cada tipo calcula de forma diferente!
    Console.WriteLine(f.CalcularSalario());
}
```

### 5. Hierarquia de Classes

```
        Funcionario (base)
              |
    +----+----+----+
    |    |    |    |
 Gerente Dev Estagiario
```

```
        Veiculo (abstrata)
              |
    +----+----+----+
    |    |         |
  Carro Moto  Caminhao
```

## 📊 Comparação: Herança vs Composição

### Use Herança quando:
✅ Existe relação "É UM" (Gerente É UM Funcionario)  
✅ Precisa compartilhar comportamento comum  
✅ Quer polimorfismo (tratar derivadas como base)

### Use Composição quando:
✅ Existe relação "TEM UM" (Pedido TEM Cliente)  
✅ Precisa combinar funcionalidades de várias fontes  
✅ Quer maior flexibilidade

```csharp
// Herança: Gerente É UM Funcionario
public class Gerente : Funcionario { }

// Composição: Pedido TEM UM Cliente
public class Pedido 
{
    public Cliente Cliente { get; set; }
}
```

## 🔧 Exercícios Sugeridos

### Nível Básico
1. **Hierarquia de Animais**
   - Classe base: Animal (virtual EmitirSom)
   - Derivadas: Cachorro, Gato, Passaro
   - Cada um sobrescreve EmitirSom()

2. **Formas Geométricas**
   - Classe abstrata: Forma (abstract CalcularArea)
   - Derivadas: Circulo, Retangulo, Triangulo

### Nível Intermediário
3. **Sistema Bancário Estendido**
   - Classe base: Conta
   - Derivadas: ContaCorrente, ContaPoupanca, ContaInvestimento
   - Cada tipo com regras diferentes de saque/rendimento

4. **Produtos de E-commerce**
   - Classe base: Produto
   - Derivadas: ProdutoFisico, ProdutoDigital, Servico
   - Cálculo de frete diferente para cada tipo

### Nível Avançado
5. **Sistema de Notificações**
   - Classe abstrata: Notificacao
   - Derivadas: Email, SMS, Push, WhatsApp
   - Cada uma com método de envio específico

6. **Jogo com Personagens**
   - Classe abstrata: Personagem
   - Derivadas: Guerreiro, Mago, Arqueiro
   - Habilidades específicas e cálculos de dano diferentes

## 🎓 Conceitos Avançados

- ✅ Herança simples (C# não tem herança múltipla)
- ✅ Polimorfismo em tempo de execução
- ✅ Upcasting e downcasting
- ✅ Métodos `sealed` (impedem override)
- ✅ Classes `sealed` (impedem herança)
- ✅ Padrão Template Method
- ✅ Princípio de Substituição de Liskov (SOLID)

## 📚 Recursos Adicionais

- [Herança - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [Polimorfismo](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/object-oriented/polymorphism)
- [Classes Abstratas](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)

## ✅ Checklist de Aprendizado

- [ ] Entendo a relação "É UM" da herança
- [ ] Sei criar classes base e derivadas
- [ ] Compreendo virtual, override e base
- [ ] Sei trabalhar com classes abstratas
- [ ] Entendo e aplico polimorfismo
- [ ] Sei quando usar herança vs composição
- [ ] Consigo criar hierarquias de classes
- [ ] Compreendo os benefícios da reutilização

---

**Módulo anterior:** [Encapsulamento](../Encapsulamento/)  
**Próximo módulo:** [Interface](../Interface/) - Contratos e implementações múltiplas.
