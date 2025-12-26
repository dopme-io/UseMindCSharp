# 📚 Módulo de Revisão - Exercícios e Desafios

## 📌 Visão Geral

O módulo de Revisão consolida todos os conceitos fundamentais de C# através de exercícios práticos e desafios reais. É o lugar perfeito para reforçar o aprendizado e desenvolver confiança na programação.

## 🎯 Objetivos de Aprendizado

- Consolidar conceitos de C# através da prática
- Resolver problemas usando diferentes abordagens
- Aplicar conhecimentos em cenários reais
- Desenvolver habilidades de pensamento lógico
- Preparar-se para desafios mais complexos

## 📖 Conteúdo

### 1️⃣ Manipulação de Dados
**Objetivo**: Dominar operações com tipos primitivos e estruturas de dados.

**Exercícios**:
- **Conversões Numéricas**: Parse, TryParse, Convert
- **Operações com Strings**: Trim, ToUpper, ToLower, Replace, Split, Substring
- **Data e Hora**: DateTime, TimeSpan, formatação
- **Operações Matemáticas**: Math.Abs, Math.Floor, Math.Pow, etc
- **Validações**: Email, CPF, idade, senha forte

**Habilidades**:
- Converter entre tipos com segurança
- Manipular strings eficientemente
- Trabalhar com datas
- Realizar validações de dados

### 2️⃣ Lógica de Programação
**Objetivo**: Resolver problemas algorítmicos clássicos.

**Exercícios**:
- **Números Pares e Ímpares**: Filtragem com loops
- **Fatorial Recursivo**: Implementação de recursão
- **Fibonacci**: Sequências matemáticas
- **Números Primos**: Verificação de primalidade
- **Maior e Menor**: Busca de extremos

**Habilidades**:
- Dominar loops (for, while)
- Implementar recursão
- Usar condicionais
- Identificar padrões

### 3️⃣ Orientação a Objetos
**Objetivo**: Aplicar princípios de POO em exercícios.

**Exercícios**:
- **Classe Pessoa**: Atributos, propriedades, métodos
- **Herança com Animais**: Criar classes derivadas
- **Interface Veículos**: Implementar contratos

**Habilidades**:
- Criar classes e objetos
- Implementar herança
- Usar interfaces
- Aplicar encapsulamento

### 4️⃣ Algoritmos
**Objetivo**: Implementar algoritmos clássicos de computação.

**Exercícios**:
- **Busca Binária**: Algoritmo de busca em array ordenado
- **Bubble Sort**: Algoritmo de ordenação
- **Inversão de String**: Reverter e detectar palíndromos

**Habilidades**:
- Compreender busca e ordenação
- Implementar algoritmos eficientes
- Analisar complexidade
- Otimizar performance

### 5️⃣ Coleções
**Objetivo**: Usar coleções para resolver problemas práticos.

**Exercícios**:
- **Lista de Compras**: CRUD com List<T>
- **Dicionário de Estoque**: Pares chave-valor
- **Valores Únicos**: HashSet para remover duplicatas

**Habilidades**:
- Escolher a coleção apropriada
- Operações de CRUD
- Filtragem e busca
- Manipular múltiplas estruturas

### 6️⃣ Desafios Práticos
**Objetivo**: Resolver problemas do mundo real.

**Desafios**:
- **Calculadora de IMC**: Cálculos e classificação
- **Gerenciador de Tarefas**: Sistema completo
- **Sistema de Notas**: Cálculo de média e situação

**Habilidades**:
- Integrar múltiplos conceitos
- Trabalhar com dados reais
- Criar sistemas funcionais
- Implementar lógica de negócio

## 📊 Matriz de Aprendizado

```
Conceito              | Tipo Exercício    | Dificuldade | Status
─────────────────────┼──────────────────┼─────────────┼────────
Tipos de Dados       | Manipulação      | ⭐         | ✓
Strings              | Manipulação      | ⭐⭐       | ✓
Data/Hora            | Manipulação      | ⭐⭐       | ✓
Loops e Condições    | Lógica           | ⭐         | ✓
Recursão             | Lógica           | ⭐⭐⭐     | ✓
Classes              | POO              | ⭐⭐       | ✓
Herança              | POO              | ⭐⭐⭐     | ✓
Interfaces           | POO              | ⭐⭐⭐     | ✓
Busca Binária        | Algoritmo        | ⭐⭐⭐     | ✓
Ordenação            | Algoritmo        | ⭐⭐       | ✓
Listas               | Coleções         | ⭐⭐       | ✓
Dicionários          | Coleções         | ⭐⭐⭐     | ✓
HashSet              | Coleções         | ⭐⭐       | ✓
Sistemas Complexos   | Prático          | ⭐⭐⭐⭐   | ✓
```

## 💡 Estratégias de Estudo

### 1. Incremente a Dificuldade Gradualmente
```
Fácil → Médio → Difícil → Muito Difícil
  ⭐    ⭐⭐    ⭐⭐⭐    ⭐⭐⭐⭐
```

### 2. Pratique Regularmente
- **5 minutos**: Ler o problema
- **15 minutos**: Tentar resolver sozinho
- **5 minutos**: Comparar com a solução
- **5 minutos**: Refatorar e otimizar

### 3. Evite Armadilhas Comuns

❌ **Errados**:
```csharp
// Conversão sem tratamento de erro
int numero = int.Parse(input); // Pode lançar exceção

// Busca ineficiente
bool existe = lista.Contains(valor); // O(n) em List

// Strings concatenadas em loop
string resultado = "";
for (int i = 0; i < 1000; i++) {
    resultado += i; // Muito lento
}
```

✅ **Corretos**:
```csharp
// Conversão segura
if (int.TryParse(input, out int numero)) {
    // Usar numero
}

// Busca eficiente
bool existe = hashSet.Contains(valor); // O(1) em HashSet

// String concatenação eficiente
var sb = new StringBuilder();
for (int i = 0; i < 1000; i++) {
    sb.Append(i); // Muito mais rápido
}
```

## 🎓 Exemplo de Resolução Passo a Passo

### Problema: Verificar se um número é primo

**Passo 1**: Entender o problema
- Número primo é divisível apenas por 1 e ele mesmo
- 2, 3, 5, 7, 11 são primos
- 4, 6, 8, 9 não são primos

**Passo 2**: Pensar no algoritmo
```
1. Se número < 2: não é primo
2. Para cada número de 2 até sqrt(número):
   - Se número é divisível: não é primo
3. Se nenhuma divisão encontrada: é primo
```

**Passo 3**: Implementar
```csharp
bool EhPrimo(int numero) {
    if (numero < 2) return false;
    
    for (int i = 2; i <= Math.Sqrt(numero); i++) {
        if (numero % i == 0)
            return false;
    }
    return true;
}
```

**Passo 4**: Testar
```csharp
// Deve retornar true
EhPrimo(7)  // true
EhPrimo(11) // true

// Deve retornar false
EhPrimo(4)  // false
EhPrimo(1)  // false
```

**Passo 5**: Otimizar
```csharp
// Já otimizado usando Math.Sqrt
// Complexity: O(√n)
```

## 🔗 Relacionamento com Outros Módulos

```
┌─────────────────────────────────┐
│       REVISÃO (Consolidação)    │
├─────────────────────────────────┤
│                                 │
│  ├─ Tipos (tipos primitivos)    │
│  ├─ Classes (POO)               │
│  ├─ Herança (herança)           │
│  ├─ Interface (contratos)       │
│  ├─ Coleções (estruturas)       │
│  ├─ Exceções (tratamento)       │
│  └─ LINQ (queries)              │
│                                 │
└─────────────────────────────────┘
```

## 📈 Progresso de Aprendizado

**Iniciante** (Primeiras 2-3 execuções)
- Foco em entender cada exercício
- Permitir-se copiar e adaptar
- Executar e ver os resultados

**Intermediário** (Próximas 3-5 execuções)
- Tentar resolver sem ver o código
- Refatorar soluções
- Adicionar novos casos de teste

**Avançado** (6+ execuções)
- Otimizar para performance
- Adicionar validações
- Criar variações dos exercícios

## ✅ Checklist de Domínio

### Manipulação de Dados
- [ ] Converter tipos com Parse/TryParse/Convert
- [ ] Manipular strings (Trim, Split, Replace, etc)
- [ ] Trabalhar com datas
- [ ] Validar entradas

### Lógica de Programação
- [ ] Implementar loops corretamente
- [ ] Usar recursão quando apropriado
- [ ] Identificar padrões
- [ ] Resolver problemas lógicos

### Orientação a Objetos
- [ ] Criar classes com propriedades/métodos
- [ ] Implementar herança corretamente
- [ ] Usar interfaces para contratos
- [ ] Aplicar encapsulamento

### Algoritmos
- [ ] Entender busca binária
- [ ] Implementar ordenação
- [ ] Analisar complexidade
- [ ] Otimizar performance

### Coleções
- [ ] Escolher a coleção apropriada
- [ ] Realizar operações CRUD
- [ ] Filtrar e buscar dados
- [ ] Combinar múltiplas estruturas

### Desafios Práticos
- [ ] Integrar múltiplos conceitos
- [ ] Resolver problemas reais
- [ ] Implementar lógica de negócio
- [ ] Criar sistemas funcionais

## 🚀 Próximos Passos

Após completar este módulo:

1. **Revisit Modules**: Volte aos módulos anteriores e crie seus próprios exemplos
2. **Create Projects**: Desenvolva pequenos projetos usando os conceitos
3. **Read Code**: Leia código de projetos open source
4. **Teach Others**: Explique os conceitos para alguém
5. **Competitive Programming**: Pratique em sites como HackerRank, LeetCode

## 📚 Recursos Adicionais

- [C# Documentation - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [LeetCode](https://leetcode.com/)
- [HackerRank](https://www.hackerrank.com/)
- [Project Euler](https://projecteuler.net/)
- [GeeksforGeeks - C#](https://www.geeksforgeeks.org/csharp-tutorial/)

---

**Lembre-se**: A prática constante é a chave para dominar programação. Quanto mais você resolver exercícios, mais natural se tornará pensar em soluções!

**Bom estudo! 🚀**
