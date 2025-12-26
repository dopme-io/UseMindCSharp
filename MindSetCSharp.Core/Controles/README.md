# Controllers (Controles) em .NET

Padrões e práticas para controllers (APIs): resultados padronizados, validação, DI e separação de comandos/queries.

## Conceitos-chave
- Controllers devem ser finos: delegar regras para serviços/domínio
- Action Results: padronize retornos (Ok, NotFound, BadRequest) para clientes previsíveis
- Validação de entrada é obrigatória antes de mutar estado
- Injeção de dependência remove acoplamento a implementações concretas (repos, loggers)
- Separe Commands (operações mutáveis) de Queries (leituras) para clareza
- Logging e métricas ajudam a observar comportamento em produção
- Paginação/filtros evitam respostas gigantes e ajudam performance

## Exemplos do módulo
1) Controller Básico: lista produtos em memória
2) DI em Controllers: repo e logger injetados
3) Action Results: Ok/NotFound/BadRequest
4) Validação de DTO: erros claros para entrada inválida
5) Commands vs Queries: leituras separadas de mutações
6) Paginação/Filtros: paginação simples por nome
7) Logging: log das ações de criação
8) Boas Práticas: checklist

## Boas práticas
- Mantenha controllers pequenos; extraia lógica de negócio para serviços
- Use ActionResult<T> e códigos de status consistentes
- Valide DTOs (anotações ou validação manual) e retorne mensagens claras
- Injete dependências via construtor (repos, loggers, clocks)
- Evite acoplamento a infraestrutura; prefira interfaces
- Ofereça paginação e filtros em endpoints de listagem
- Logue operações-chave e falhas; exponha métricas quando possível

## Checklist rápido
- [ ] Controllers sem lógica de domínio acoplada
- [ ] Validação aplicada a todos os DTOs de entrada
- [ ] Retornos padronizados (Ok/NotFound/BadRequest ou equivalentes)
- [ ] Dependências chegando via DI
- [ ] Endpoints de listagem com paginação/filtros
- [ ] Logging ativo para ações críticas
