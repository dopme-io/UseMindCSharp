# 📚 Módulo: Eventos

## Sobre Eventos

Eventos permitem **notificar** e **reagir** a mudanças de estado entre objetos, seguindo o padrão **publicação/assinatura** (pub/sub). Em C#, eventos são construídos sobre delegates e o padrão `EventHandler`.

Eventos ajudam a:
- ✅ Desacoplar remetente e assinante
- ✅ Encadear fluxos de trabalho (workflow)
- ✅ Atualizar UI / logs sem alterar a lógica principal
- ✅ Extender comportamento sem herdar ou modificar código

---

## 🎯 Conceitos Fundamentais

### Delegate ➜ Evento ➜ Handler
```
Publisher (emite)  --->  Evento (delegate)  --->  Subscriber (assina)
```

### Declaração de Eventos
```csharp
public event Action Clicado;                       // Evento simples
public event EventHandler Processado;              // Padrão .NET
public event EventHandler<PedidoEventArgs> Mudou;   // Com dados
```

### Disparar Evento (Safe Invoke)
```csharp
Clicado?.Invoke();
Processado?.Invoke(this, EventArgs.Empty);
Mudou?.Invoke(this, new PedidoEventArgs(id, status));
```

### Assinar / Desassinar
```csharp
botao.Clicado += OnClick;
botao.Clicado -= OnClick; // IMPORTANTE: evitar vazamentos
```

---

## 📋 8 Exemplos do Módulo

1. **Evento Básico (Action)** – clique de botão simples
2. **EventHandler** – padrão .NET com `EventArgs.Empty`
3. **EventArgs Customizados** – progresso de download
4. **Multicast** – múltiplos handlers e ordem de execução
5. **Inscrição/Desinscrição** – evitar spam e vazamento
6. **Eventos Assíncronos** – handlers `async` com `Task.WhenAll`
7. **Eventos em Cadeia** – um evento dispara o próximo
8. **Boas Práticas** – `?.Invoke`, `OnX`, EventHandler<T>

---

## 🛠️ Padrões de Uso

### Padrão EventHandler
```csharp
public event EventHandler Processado;
protected virtual void OnProcessado()
    => Processado?.Invoke(this, EventArgs.Empty);
```

### Padrão EventHandler<TEventArgs>
```csharp
public event EventHandler<DownloadEventArgs> Progresso;
protected virtual void OnProgresso(DownloadEventArgs args)
    => Progresso?.Invoke(this, args);
```

### Eventos Assíncronos (quando necessário)
```csharp
public event Func<object?, string, Task>? AoProcessarAsync;
public async Task DispararAsync(string msg)
{
    if (AoProcessarAsync is null) return;
    var handlers = AoProcessarAsync.GetInvocationList()
        .Cast<Func<object?, string, Task>>();
    await Task.WhenAll(handlers.Select(h => h(this, msg)));
}
```

---

## 📊 Operadores e Termos

| Termo | Descrição | Exemplo |
|-------|-----------|---------|
| Delegate | Tipo que representa método(s) | `Action`, `Func`, `EventHandler` |
| Evento | Encapsula delegate + add/remove | `public event Action Clicked;` |
| Publisher | Quem dispara o evento | `botao.Clicar()` |
| Subscriber | Quem reage ao evento | `botao.Clicado += Handler;` |
| Multicast | Vários handlers | Vários `+=` no mesmo evento |
| Safe Invoke | Evitar null | `Evento?.Invoke(...)` |

---

## 💡 Boas Práticas

### ✅ O QUE FAZER

1. **Use `EventHandler` ou `EventHandler<T>`**
```csharp
public event EventHandler<PedidoEventArgs>? PedidoCriado;
```

2. **Exponha método `OnEvento` protegido**
```csharp
protected virtual void OnPedidoCriado(PedidoEventArgs e)
    => PedidoCriado?.Invoke(this, e);
```

3. **Verifique null com `?.Invoke`**
```csharp
PedidoCriado?.Invoke(this, e);
```

4. **Desinscreva quando não precisar mais**
```csharp
pedido.PedidoCriado -= Handler;
```

5. **Use dados ricos em EventArgs**
```csharp
public class PedidoEventArgs : EventArgs
{
    public int Id { get; }
    public string Status { get; }
    public PedidoEventArgs(int id, string status) { Id = id; Status = status; }
}
```

6. **Encapsule disparo em métodos**
```csharp
private void AtualizarStatus(string status)
{
    Status = status;
    OnStatusAlterado(new StatusEventArgs(status));
}
```

---

### ❌ O QUE EVITAR

1. **Expor delegate diretamente**
```csharp
// ❌ Ruim
public Action Clicked; // Permite overwrite
```

2. **Invocar sem checar null**
```csharp
// ❌ Ruim
Clicked(); // Pode dar NullReference
```

3. **Usar campos públicos mutáveis**
```csharp
// ❌ Ruim
public EventHandler Evento; // Pode ser sobrescrito externamente
```

4. **Assinar e nunca desassinar**
```csharp
// ❌ Ruim
obj.Evento += Handler; // Se obj vive muito, possível leak
```

5. **Bloquear thread em handler assíncrono**
```csharp
// ❌ Ruim
EventoAsync += (_, __) => Task.Delay(1000).Wait();
```

---

## 🚀 Padrões Avançados

### Multicast e Ordem
- Handlers são invocados na **ordem de inscrição** (`+=`).
- Se um handler lança exceção, os seguintes não executam (para EventHandler). Trate erros em cada handler.

### Eventos em Cadeia
- Um evento dispara outro para compor pipelines.
- Use métodos `OnX` para cada etapa.

### Eventos Assíncronos
- Prefira `Task` e `await Task.WhenAll` para aguardar todos os handlers.
- Evite `async void` exceto em UI.

### Event Aggregator (conceito)
- Centraliza publicação/assinatura para módulos desacoplados.
- Fora do escopo deste módulo, mas útil em aplicações grandes.

---

## 🔍 Dicas de Depuração

- Logue dentro de cada handler para saber quem executou.
- Guarde contagem de inscritos: `Evento?.GetInvocationList().Length`.
- Trate exceções por handler para não interromper a cadeia.

---

## ✅ Checklist de Aprendizado

- [ ] Sei declarar eventos com `event`
- [ ] Uso `EventHandler` / `EventHandler<T>`
- [ ] Sei criar `EventArgs` customizados
- [ ] Consigo disparar com `?.Invoke`
- [ ] Sei assinar e desassinar eventos
- [ ] Entendo multicast e ordem de execução
- [ ] Sei compor eventos em cadeia
- [ ] Consigo lidar com handlers assíncronos
- [ ] Evito NullReference em eventos
- [ ] Reconheço quando usar eventos vs outros padrões

---

## 🎓 Próximos Passos

1. **Event Aggregator** – para modularizar eventos em apps grandes
2. **Reactive Extensions (Rx)** – fluxo reativo baseado em observables
3. **IObservable/IObserver** – padrão Observer na BCL
4. **Eventos em UI** – WPF/WinForms/MAUI
5. **MediatR** – mediar comandos/consultas/eventos em aplicações

---

## 📝 Dicas Finais

1. **Mantenha handlers pequenos** – delegue trabalho pesado para serviços
2. **Nomeie eventos no passado** – `Processado`, `Alterado`, `Concluido`
3. **Dados no EventArgs** – envie contexto suficiente
4. **Evite estado global** – prefira instâncias claras de publisher
5. **Teste** – simule eventos para garantir fluxo correto

---

**Última atualização:** 2024  
**Versão:** 1.0
