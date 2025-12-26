# 📚 Módulo: Delegates

## Sobre Delegates

Delegates são **tipos que representam referências a métodos**. Eles permitem tratar funções como dados (funções de primeira classe), habilitando callbacks, estratégias e composição funcional.

Por que usar delegates?
- ✅ Passar comportamentos como parâmetros
- ✅ Substituir ifs por estratégias
- ✅ Criar pipelines (multicast)
- ✅ Interagir com eventos e LINQ

---

## 🎯 Conceitos Fundamentais

### Declaração
```csharp
public delegate int Operacao(int a, int b);
```

### Uso
```csharp
Operacao soma = (a, b) => a + b;
int r = soma(3, 4); // 7
```

### Tipos prontos (preferidos)
- `Action` — não retorna valor (`void`)
- `Func<T1,...,TResult>` — retorna valor
- `Predicate<T>` — retorna `bool` (atalho para `Func<T,bool>`)

---

## 📋 Multicast Delegates

Delegates podem ter vários handlers (+=). A ordem de execução segue a ordem de inscrição.

```csharp
Action pipeline = null!;
pipeline += () => Console.WriteLine("Passo 1");
pipeline += () => Console.WriteLine("Passo 2");
pipeline();
```

⚠️ Se um handler lança exceção, os seguintes não executam (sem tratamento).

---

## 🔌 Callbacks

```csharp
void ProcessarArquivos(IEnumerable<string> arqs, Action<string> aoProcessar)
{
    foreach (var a in arqs) aoProcessar(a);
}

ProcessarArquivos(lista, arq => Console.WriteLine(arq));
```

---

## 🧠 Strategy com Delegates

```csharp
public double Calcular(double preco, Func<double, double> estrategia)
    => estrategia(preco);

var preco = Calcular(100, p => p * 0.7); // Black Friday
```

---

## 🔀 Func / Action / Predicate

```csharp
Action<string> log = msg => Console.WriteLine(msg);
Func<int,int,int> somar = (a,b) => a+b;
Predicate<int> ehPar = n => n % 2 == 0;
```

---

## ↕️ Covariância / Contravariância

- **Covariância (retorno)**: delegate que retorna tipo base pode apontar para método que retorna derivado.
- **Contravariância (parâmetro)**: delegate que recebe derivado pode usar método que recebe base.

```csharp
public delegate Animal CriarAnimal();
CriarAnimal c = CriarCachorro; // Covariância no retorno

public delegate void ProcessarCachorro(Cachorro c);
ProcessarCachorro p = ProcessarAnimal; // Contravariância no parâmetro
```

---

## ✅ Boas Práticas

1. **Prefira `Func`/`Action`/`Predicate`** a delegates custom, salvo quando nomes claros forem úteis.
2. **Trate exceções em multicast** para não interromper cadeia.
3. **Evite stateful lambdas** quando puder — facilita teste.
4. **Delegates para estratégia/callback**, não para tudo (mantenha simplicidade).
5. **Nomeie delegates custom** de forma clara: `CalculoImposto`, `GeradorRelatorio`.

---

## 🚫 O que evitar

- Usar delegates quando uma interface simples é mais clara.
- Criar muitos delegates customizados quando `Func/Action` resolvem.
- Bloquear thread dentro de handler que deveria ser assíncrono.
- Depender da ordem de multicast sem documentar.

---

## 📊 Checklist de Aprendizado

- [ ] Sei declarar e invocar delegates
- [ ] Uso `Func`, `Action`, `Predicate`
- [ ] Consigo criar pipelines (multicast)
- [ ] Implemento callbacks com delegates
- [ ] Aplico Strategy passando funções
- [ ] Entendo covariância/contravariância
- [ ] Trato exceções em multicast
- [ ] Sei quando preferir interfaces x delegates

---

## 🎓 Próximos Passos

1. **Eventos** – delegates + padrão pub/sub
2. **Expression Trees** – delegates representando ASTs
3. **Funcionais** – composição de funções e pipelines

---

**Última atualização:** 2024  
**Versão:** 1.0
