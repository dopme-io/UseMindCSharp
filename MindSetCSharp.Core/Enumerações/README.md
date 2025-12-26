# 📚 Módulo: Enumerações

## Sobre Enumerações

Enumerações (**enum**) representam conjuntos de valores nomeados (constantes simbólicas) para deixar o código mais legível, seguro e expressivo.

Por que usar enums?
- ✅ Substituem números mágicos por nomes claros
- ✅ Garantem valores válidos (type-safe)
- ✅ Facilitam switches e validações
- ✅ Combinam permissões com Flags (bitwise)

---

## 🎯 Conceitos Fundamentais

### Declaração
```csharp
public enum StatusPedido
{
    Pendente = 0,
    Aprovado = 1,
    Rejeitado = 2
}
```

### Uso
```csharp
StatusPedido status = StatusPedido.Aprovado;
if (status == StatusPedido.Aprovado) Aprovar();
```

### Iteração
```csharp
foreach (StatusPedido s in Enum.GetValues(typeof(StatusPedido)))
    Console.WriteLine(s);
```

### Conversões
```csharp
int valor = (int)StatusPedido.Aprovado;   // enum -> int
var status = (StatusPedido)1;             // int -> enum (cuidado)
```

---

## 🧭 Flags (bitwise)

Use `[Flags]` para combinar valores:
```csharp
[Flags]
public enum Permissoes
{
    Nenhuma = 0,
    Ler = 1 << 0,
    Escrever = 1 << 1,
    Executar = 1 << 2,
    Admin = Ler | Escrever | Executar
}

var p = Permissoes.Ler | Permissoes.Escrever;
if (p.HasFlag(Permissoes.Ler)) { /* ... */ }
```

Dicas:
- Defina `Nenhuma = 0`
- Use potências de 2 (1, 2, 4, 8, ...)
- Combine com `|`, teste com `HasFlag`

---

## 🔍 Utilitários Úteis

```csharp
Enum.GetNames<StatusPedido>();      // nomes
Enum.GetValues<StatusPedido>();     // valores
Enum.IsDefined(typeof(StatusPedido), 3); // valida
Enum.TryParse("Aprovado", out StatusPedido s); // seguro
```

### Description Attribute
```csharp
public enum TipoDocumento
{
    [Description("CPF - Pessoa Física")]
    CPF,
    [Description("CNPJ - Pessoa Jurídica")]
    CNPJ
}

string texto = doc.GetDescription();
```

---

## ⚖️ Switch Expression com Enum
```csharp
var acao = status switch
{
    StatusPedido.Pendente  => "Aguardando",
    StatusPedido.Aprovado  => "Processar",
    StatusPedido.Rejeitado => "Revisar",
    _ => "Desconhecido"
};
```

---

## ✅ Boas Práticas

1. **Nome no singular**: `StatusPedido`, `Plano`, `Prioridade`.
2. **Defina valores explícitos** quando precisar estabilidade (persistência/DB/API).
3. **Use Flags para combinações** e potências de 2.
4. **Valide entrada externa** com `Enum.TryParse` + `Enum.IsDefined`.
5. **Forneça descrição** com `DescriptionAttribute` para exibição.
6. **Não exponha números mágicos**; sempre converta para enum.
7. **Cuidado ao converter de int** (checar `IsDefined`).

---

## 🚫 O que evitar

- Converter entrada do usuário direto para enum sem `TryParse`.
- Usar enums grandes e mutáveis (muitos valores mudando frequentemente).
- Misturar enums com semânticas diferentes no mesmo tipo.
- Esquecer `None/0` em Flags.

---

## 📊 Checklist de Aprendizado

- [ ] Sei declarar e usar enums básicos
- [ ] Consigo iterar com `Enum.GetValues`
- [ ] Uso `TryParse` com validação
- [ ] Sei aplicar `[Flags]` e `HasFlag`
- [ ] Consigo mapear enum em dicionários
- [ ] Uso switch expression com enum
- [ ] Aplico `DescriptionAttribute` para exibição
- [ ] Valido valores antes de persistir

---

## 🎓 Próximos Passos

1. **Persistência**: armazenar enums como string/int em banco ou JSON.
2. **Internacionalização**: mapear enums para textos localizados.
3. **APIs**: garantir compatibilidade de versões quando enums são expostos.
4. **Combinação com Records**: enriquecer DTOs com enums + metadata.

---

**Última atualização:** 2024  
**Versão:** 1.0
