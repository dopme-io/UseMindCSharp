# Bastidores do .NET

Fundamentos de execução, memória e eficiência no .NET: tipos de valor x referência, boxing/unboxing, GC, imutabilidade e uso de Span.

## Conceitos-chave
- Tipos valor são copiados; tipos referência compartilham a mesma instância
- Boxing/unboxing convertem entre valor e `object` com custo de alocação e cast
- Strings são imutáveis; `StringBuilder` evita alocações repetidas
- Cópias defensivas impedem efeitos colaterais em coleções compartilhadas
- Structs vivem tipicamente na stack (ou embutidas), classes no heap gerenciado
- `Span<T>`/`Memory<T>` permitem fatiar sem alocar novas estruturas
- GC libera memória gerenciada, mas recursos nativos precisam de `IDisposable`

## Exemplos do módulo
1) Valor x Referência: structs vs classes e efeitos de atribuição
2) Boxing/Unboxing: custos e pattern matching para reduzir casts
3) Strings Imutáveis: concatenação vs `StringBuilder`
4) Cópias de Coleções: referência compartilhada vs cópia defensiva
5) Struct vs Class: alocação e custo ilustrativo (use benchmarks reais)
6) Span/Slice: fatias sem alocação extra
7) GC e IDisposable: liberar recursos e observar memória
8) Boas Práticas: checklist rápido de bastidores

## Boas práticas
- Prefira structs pequenos, imutáveis e sem herança; classes para objetos ricos
- Evite boxing em hot paths usando generics e tipos específicos
- Em loops de concatenação, troque "+" por `StringBuilder`
- Sempre faça cópia defensiva ao expor coleções mutáveis para outras camadas
- Meça performance com BenchmarkDotNet, não com suposições
- Libere `IDisposable` com `using`/`await using`; evite vazamentos
- Use `Span<T>`/`Memory<T>` para evitar alocações transitórias em slices

## Checklist rápido
- [ ] Evitei boxing desnecessário em trechos críticos
- [ ] Coleções expostas têm cópia defensiva ou são somente leitura
- [ ] Strings em loops usam `StringBuilder`
- [ ] Recursos `IDisposable` estão dentro de `using`
- [ ] Hot paths medidos com benchmark confiável
- [ ] Uso `Span<T>`/`Memory<T>` onde preciso evitar alocação extra
