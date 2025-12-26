# 📚 Módulo: Exceções

## Sobre Exceções

Exceções são eventos que ocorrem durante a execução de um programa que interrompem o fluxo normal. Em C#, usamos o mecanismo de **try-catch-finally** para tratar erros de forma elegante e controlada.

Tratar exceções é fundamental para:
- ✅ Prevenir falhas abruptas da aplicação
- ✅ Fornecer feedback útil ao usuário
- ✅ Garantir limpeza de recursos
- ✅ Facilitar debugging e manutenção

---

## 🎯 Conceitos Fundamentais

### Try-Catch
```csharp
try
{
    // Código que pode gerar exceção
    int resultado = 10 / 0;
}
catch (DivideByZeroException ex)
{
    // Tratar exceção
    Console.WriteLine($"Erro: {ex.Message}");
}
```

### Finally
```csharp
try
{
    // Código perigoso
}
catch (Exception ex)
{
    // Tratar erro
}
finally
{
    // Sempre executa, mesmo com exceção ou return
    recurso.Liberar();
}
```

### Throw
```csharp
if (idade < 0)
    throw new ArgumentException("Idade não pode ser negativa");
```

### Using Statement
```csharp
using (var arquivo = new FileStream("dados.txt", FileMode.Open))
{
    // Usar recurso
} // Automaticamente chamado Dispose()
```

---

## 📋 Hierarquia de Exceções

```
Exception (raiz de todas exceções)
├── SystemException
│   ├── ArgumentException
│   │   ├── ArgumentNullException
│   │   └── ArgumentOutOfRangeException
│   ├── ArithmeticException
│   │   └── DivideByZeroException
│   ├── FormatException
│   ├── IndexOutOfRangeException
│   ├── InvalidOperationException
│   ├── NullReferenceException
│   └── TimeoutException
├── IOException
│   ├── FileNotFoundException
│   └── DirectoryNotFoundException
└── CustomException (suas exceções)
```

---

## 🔍 Exceções Comuns

| Exceção | Situação | Exemplo |
|---------|----------|---------|
| **ArgumentException** | Argumento inválido | `ValidarIdade(-5)` |
| **ArgumentNullException** | Argumento é nulo | `var x = lista[null]` |
| **ArgumentOutOfRangeException** | Argumento fora do intervalo | `array[100]` (se tamanho < 100) |
| **DivideByZeroException** | Divisão por zero | `10 / 0` |
| **FormatException** | Formato inválido | `int.Parse("abc")` |
| **IndexOutOfRangeException** | Índice inválido | `array[999]` |
| **InvalidOperationException** | Operação inválida | `lista.First()` (lista vazia) |
| **NullReferenceException** | Referência nula | `string? x = null; x.Length` |
| **FileNotFoundException** | Arquivo não existe | `File.Open("inexistente.txt")` |
| **TimeoutException** | Operação expirou | Request com timeout |

---

## 💡 Boas Práticas

### ✅ O QUE FAZER

1. **Capturar exceções específicas**
```csharp
try
{
    Processar();
}
catch (FileNotFoundException ex)
{
    // Trata arquivo não encontrado
}
catch (IOException ex)
{
    // Trata outros erros de I/O
}
```

2. **Usar finally para limpeza**
```csharp
try
{
    arquivo = File.Open("dados.txt");
    Processar(arquivo);
}
finally
{
    arquivo?.Dispose();
}
```

3. **Criar exceções específicas**
```csharp
public class SaldoInsuficienteException : Exception
{
    public decimal SaldoAtual { get; set; }
    // ...
}
```

4. **Relançar exceções quando apropriado**
```csharp
catch (FormatException ex)
{
    Log.Error(ex);
    throw; // Relança original
}
```

5. **Usar using para IDisposable**
```csharp
using var arquivo = new FileStream("dados.txt", FileMode.Open);
// Dispose() automático
```

---

### ❌ O QUE EVITAR

1. **Capturar Exception genérica**
```csharp
// ❌ Ruim
catch (Exception ex)
{
    // Pega TUDO, difícil debugar
}

// ✅ Bom
catch (ArgumentException ex)
{
    // Específico
}
```

2. **Catch vazio**
```csharp
// ❌ Ruim
try
{
    Processar();
}
catch (Exception)
{
    // Silencia erro silenciosamente
}

// ✅ Bom
try
{
    Processar();
}
catch (Exception ex)
{
    Log.Error(ex);
    throw;
}
```

3. **Perder contexto**
```csharp
// ❌ Ruim
catch (Exception ex)
{
    throw new Exception("Erro"); // Perde stack trace
}

// ✅ Bom
catch (Exception ex)
{
    throw new Exception("Erro", ex); // Mantém contexto
}
```

4. **Ignorar recursos**
```csharp
// ❌ Ruim
FileStream arquivo = File.Open("dados.txt");
Processar(arquivo);
// Arquivo nunca é fechado

// ✅ Bom
using var arquivo = File.Open("dados.txt");
Processar(arquivo);
// Fecha automaticamente
```

---

## 🛠️ Exemplos Práticos

### Validação com Exceção
```csharp
public class Usuario
{
    public string Nome { get; set; }

    public Usuario(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório", nameof(nome));

        Nome = nome;
    }
}

// Uso
try
{
    var usuario = new Usuario(""); // Exceção
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
```

### Gerenciamento de Recursos
```csharp
public class ContaBancaria : IDisposable
{
    private bool _descartado = false;

    public void Sacar(decimal valor)
    {
        if (_descartado)
            throw new ObjectDisposedException(nameof(ContaBancaria));

        // Sacar valor...
    }

    public void Dispose()
    {
        if (!_descartado)
        {
            // Liberar recursos
            _descartado = true;
        }
    }
}

// Uso
using var conta = new ContaBancaria();
conta.Sacar(100);
// Dispose() automático
```

### Stack Trace para Debugging
```csharp
try
{
    ProcessarDados();
}
catch (Exception ex)
{
    Console.WriteLine(ex.StackTrace);
    // Output:
    // at Program.MetodoC() in Program.cs:line 20
    // at Program.MetodoB() in Program.cs:line 15
    // at Program.MetodoA() in Program.cs:line 10
}
```

---

## 📌 Quando Usar Cada Recurso

| Situação | Usar |
|----------|------|
| Recuperar de erro | **try-catch** |
| Garantir limpeza | **finally** ou **using** |
| Validar entrada | **throw** ArgumentException |
| Arquivo não existe | **catch** FileNotFoundException |
| Operação inválida | **catch** InvalidOperationException |
| Saldo insuficiente | **throw** CustomException |

---

## 🚀 Padrões Avançados

### 1. Exceção com Contexto
```csharp
try
{
    int resultado = 10 / 0;
}
catch (DivideByZeroException ex)
{
    throw new InvalidOperationException("Erro ao calcular média", ex);
}
```

### 2. Finally com Return
```csharp
public string Processar()
{
    try
    {
        return "Sucesso";
    }
    finally
    {
        Console.WriteLine("Finally executa mesmo com return!");
    }
}
```

### 3. IDisposable Pattern
```csharp
public class Recurso : IDisposable
{
    private bool disposed = false;

    public void Liberar()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Liberar recursos gerenciados
            }
            disposed = true;
        }
    }

    ~Recurso() => Dispose(false);
    public void Dispose() => Liberar();
}
```

---

## 📚 Recursos Adicionais

- 📖 [Microsoft Docs - Exceções](https://docs.microsoft.com/pt-br/dotnet/standard/exceptions/)
- 📖 [C# Exception Handling](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/exception-handling)
- 📖 [IDisposable Pattern](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose)

---

## ✅ Checklist de Aprendizado

- [ ] Entendo o fluxo try-catch-finally
- [ ] Consigo identificar exceções comuns do .NET
- [ ] Sei quando criar exceções customizadas
- [ ] Implementei IDisposable em classe própria
- [ ] Conheço a diferença entre catch específico e genérico
- [ ] Consigo ler e entender stack traces
- [ ] Uso using statement corretamente
- [ ] Implementei validação com exceção
- [ ] Consigo relançar exceções com contexto
- [ ] Entendo o padrão IDisposable Pattern

---

## 🎓 Próximos Passos

Após dominar exceções, explore:
1. **Async/Await** - Tratamento assíncrono
2. **Logging** - Registrar exceções
3. **Custom Handlers** - Tratadores globais
4. **Unit Testing** - Testar exceções

---

**Última atualização:** 2024
**Versão:** 1.0
