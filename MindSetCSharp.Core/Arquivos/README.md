# Arquivos no .NET

Leitura, escrita e manipulação de arquivos com System.IO: texto, binário, streams, async I/O, JSON e CSV simples.

## Conceitos-chave
- `File`/`Directory` para operações rápidas; `FileInfo`/`DirectoryInfo` para metadados e fluência
- Sempre especifique `Encoding` em texto; padrão pode variar por ambiente
- Streams permitem buffers e leitura incremental (útil para arquivos grandes)
- Preferir APIs assíncronas para não bloquear threads em I/O
- JSON: `System.Text.Json` é leve e rápido para a maioria dos cenários
- CSV simples pode ser tratado com `Split`, mas use libs dedicadas em casos complexos
- Use `Path.Combine` e pastas temporárias (`Path.GetTempPath`) para evitar conflitos

## Exemplos do módulo
1) Leitura de Texto: `File.ReadAllLines` com encoding
2) Escrita e Append: `WriteAllText`/`AppendAllText`
3) File vs FileInfo: metadados e deleção
4) Streams + Buffer: copiar dados sem alocações extras
5) I/O Assíncrono: `WriteAllBytesAsync`/`ReadAllBytesAsync`
6) JSON: serialização/desserialização com `System.Text.Json`
7) CSV Simples: gravação e leitura básica separando por `;`
8) Boas Práticas: checklist rápido

## Boas práticas
- Envolva streams em `using`/`await using` para garantir fechamento
- Não bloqueie: prefira métodos Async em operações de disco/rede
- Declare `Encoding.UTF8` explicitamente ao ler/gravar texto
- Para arquivos grandes, processe em blocos (streams) em vez de ler tudo em memória
- Construa caminhos com `Path.Combine` para evitar erros de separador
- Em cenários reais de CSV/JSON complexos, considere bibliotecas dedicadas (CsvHelper, etc.)

## Checklist rápido
- [ ] Encoding explícito em leitura/escrita de texto
- [ ] Streams fechadas corretamente (using)
- [ ] I/O pesado usa métodos Async
- [ ] Caminhos montados com `Path.Combine`
- [ ] Operações com arquivos grandes usam buffering/streams
- [ ] Seriais JSON/CSV com libs adequadas quando necessário
