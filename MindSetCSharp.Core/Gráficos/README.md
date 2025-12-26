# 📚 Módulo de Gráficos em C#

## 📌 Visão Geral

Este módulo explora técnicas de visualização de dados usando gráficos ASCII no console. Aprenderemos a representar dados de forma visual e intuitiva, facilitando a análise e compreensão de informações.

## 🎯 Objetivos de Aprendizado

- Criar gráficos ASCII no console
- Visualizar dados de diferentes formas
- Utilizar cores para destacar informações
- Organizar dados em tabelas
- Plotar funções matemáticas
- Criar diagramas e estatísticas
- Implementar visualizações eficazes

## 📖 Conteúdo

### 1️⃣ Gráfico de Barras

**Descrição**: Representação visual comparativa de valores usando barras horizontais ou verticais.

**Características**:
- Fácil de comparar valores
- Ideal para dados categóricos
- Suporta múltiplas categorias
- Intuitivo e legível

**Exemplo**:
```
Janeiro       │ ████████████████████████████░░░░░░░░░░░ │ 45
Fevereiro     │ ██████████████████████████████░░░░░░░░░ │ 52
Março         │ █████████████████████░░░░░░░░░░░░░░░░░░ │ 38
Abril         │ ██████████████████████████████████░░░░░ │ 61
Maio          │ ███████████████████████████░░░░░░░░░░░░ │ 55
Junho         │ ████████████████████████░░░░░░░░░░░░░░░ │ 48
```

**Quando Usar**:
- Comparação de valores entre categorias
- Análise de vendas, produção, etc
- Dados discretos e bem definidos
- Relatórios executivos

**Implementação**:
```csharp
int maxValor = dados.Values.Max();
foreach (var (chave, valor) in dados) {
    int largura = (int)((double)valor / maxValor * 40);
    string barra = new string('█', largura);
    Console.WriteLine($"{chave,-12} │ {barra,40} │ {valor}");
}
```

### 2️⃣ Gráfico de Linhas

**Descrição**: Visualização de tendências ao longo do tempo ou progressão de valores.

**Características**:
- Mostra tendências claramente
- Ideal para séries temporais
- Fácil identificar padrões
- Conecta pontos em sequência

**Exemplo**:
```
28 │ ●                                        
27 │  \                                       
26 │   ●─────●                                
25 │        \       ●                         
24 │         \     / \                        
23 │          \   /   ●                       
22 │           \ /     \                      
```

**Quando Usar**:
- Evolução de valores no tempo
- Temperatura, preço, população, etc
- Análise de tendências
- Previsões baseadas em histórico

**Implementação**:
```csharp
for (int y = alturaGrafico; y >= 0; y--) {
    for (int x = 0; x < dados.Length; x++) {
        if (AlturaColuna(x) == y) {
            Console.Write("●");
        } else if (AlturaColuna(x) > y) {
            Console.Write("│");
        }
    }
}
```

### 3️⃣ Tabela de Dados

**Descrição**: Organização estruturada de dados em linhas e colunas.

**Características**:
- Apresentação clara e organizada
- Fácil localizar informações específicas
- Suporta múltiplos tipos de dados
- Profissional e formal

**Exemplo**:
```
┌────────────────────┬────────────┬─────────┬───────────┐
│ Nome               │ Matrícula  │  Média  │ Situação  │
├────────────────────┼────────────┼─────────┼───────────┤
│ Ana Silva          │ 2021001    │  8.5    │ ✓ Aprovado│
│ Bruno Santos       │ 2021002    │  7.2    │ ✓ Aprovado│
│ Carlos Junior      │ 2021003    │  5.8    │ ✗ Reprovado
└────────────────────┴────────────┴─────────┴───────────┘
```

**Quando Usar**:
- Dados estruturados
- Relatórios detalhados
- Listagens de registros
- Comparação de múltiplos atributos

**Implementação**:
```csharp
Console.WriteLine("┌────────┬────────┐");
foreach (var item in dados) {
    Console.WriteLine($"│ {item.Nome,-6} │ {item.Valor,-6} │");
}
Console.WriteLine("└────────┴────────┘");
```

### 4️⃣ Histograma

**Descrição**: Distribuição de frequências em intervalos (classes).

**Características**:
- Mostra distribuição de dados
- Agrupa em intervalos
- Identificar concentração
- Análise de padrões

**Exemplo**:
```
20-29 │ ▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░ │ 8 pessoas
30-39 │ ▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░ │ 7 pessoas
40-49 │ ▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░ │ 9 pessoas
50-59 │ ▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░ │ 5 pessoas
60-69 │ ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ │ 1 pessoa
```

**Quando Usar**:
- Distribuição de dados (idade, renda, etc)
- Análise de frequências
- Dados contínuos ou discretos
- Estatística descritiva

**Implementação**:
```csharp
var intervalos = Agrupar(dados, faixa);
foreach (var (intervalo, frequencia) in intervalos) {
    int largura = (frequencia / maxFrequencia) * 30;
    Console.WriteLine($"{intervalo} │ {new string('▓', largura)}");
}
```

### 5️⃣ Diagrama de Dispersão

**Descrição**: Visualização de relação entre duas variáveis (x, y).

**Características**:
- Mostra correlação entre variáveis
- Identifica padrões e outliers
- Cada ponto = observação
- Revela relacionamentos

**Exemplo**:
```
10 │              ●  
9  │         ●       
8  │    ●  ●        
7  │ ●        ●    
6  │    ●           
5  │ ●    ●        
4  │●             
3  │ ●             
2  │                
1  │●               
0  │────────────────
   0 1 2 3 4 5 6 7 8
```

**Quando Usar**:
- Análise de correlação
- Relação entre variáveis
- Vendas vs investimento em publicidade
- Altura vs peso, experiência vs salário

**Implementação**:
```csharp
for (int y = maxY; y >= 0; y--) {
    for (int x = 0; x <= maxX; x++) {
        if (dados.Any(d => d.X == x && d.Y == y)) {
            Console.Write("●");
        }
    }
}
```

### 6️⃣ Plotagem de Funções Matemáticas

**Descrição**: Visualização gráfica de funções matemáticas.

**Características**:
- Representação visual de fórmulas
- Identifica características (raízes, máximos, mínimos)
- Suporta diferentes escalas
- Educacional e analítico

**Exemplo** (y = x²):
```
10 │                       ●
9  │                    ●  
8  │                 ●     
7  │              ●        
6  │           ●           
5  │        ●              
4  │     ●                 
3  │  ●                    
2  │ ●                     
1  │ ●                     
0  │●────────────────────●
  -3 -2 -1  0  1  2  3
```

**Quando Usar**:
- Educação e ensino de cálculo
- Análise matemática
- Física e engenharia
- Visualizar comportamento de funções

**Implementação**:
```csharp
for (int x = -limite; x <= limite; x++) {
    double y = Funcao(x);
    int altura = (int)(y / maxY * alturaGrafico);
    if (altura == y) Console.Write("●");
}
```

### 7️⃣ Gráfico de Setor (Pizza)

**Descrição**: Representação de proporções e percentuais.

**Características**:
- Mostra partes de um todo
- Percentuais claros
- Ideal para categorias
- Proporções visuais

**Exemplo**:
```
Chrome    │ ███████████████████████░░░░░░░░░░░░░░░░░ 65%
Firefox   │ ███████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ 20%
Safari    │ ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ 10%
Edge      │ █░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  5%
```

**Quando Usar**:
- Market share
- Composição de orçamento
- Distribuição de recursos
- Participação de mercado

**Implementação**:
```csharp
foreach (var (categoria, valor) in dados) {
    double percentual = (valor / total) * 100;
    int largura = (int)(percentual / 100 * 40);
    Console.WriteLine($"{categoria} │ {new string('█', largura)}");
}
```

### 8️⃣ Visualização com Cores

**Descrição**: Uso de cores para destacar e organizar informações.

**Características**:
- Cores destacam padrões
- Código de cores intuitivo
- Melhora legibilidade
- Comunicação visual efetiva

**Cores Comuns**:
- 🟢 Verde: Bom, OK, Sucesso
- 🟡 Amarelo: Aviso, Cuidado, Normal
- 🔴 Vermelho: Erro, Crítico, Problema
- 🔵 Azul: Informação, Neutro
- ⚪ Branco: Padrão, Neutro

**Exemplo**:
```csharp
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("✓ Sucesso");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("✗ Erro");
Console.ResetColor();
```

## 📊 Comparação de Gráficos

```
Tipo              Melhor Para           Dados Necessários
─────────────────────────────────────────────────────────
Barras            Comparação            Categorias + Valores
Linhas            Tendências            Série temporal
Tabela            Dados específicos      Estruturado
Histograma        Distribuição          Frequências
Dispersão         Correlação            Pares (X, Y)
Função            Comportamento         Fórmula matemática
Pizza             Proporções            Partes de um todo
Cores             Destaque              Status/Severidade
```

## 💡 Melhores Práticas

### 1. Escolha o Gráfico Certo
```csharp
// ✅ Bom: Gráfico de barras para comparação
VisualizarBarras(vendas);

// ❌ Ruim: Gráfico de linhas para categorias
VisualizarLinhas(vendas);
```

### 2. Escala Apropriada
```csharp
// ✅ Bom: Usar maxValor para normalizar
int largura = (int)((double)valor / maxValor * 40);

// ❌ Ruim: Escala fixa inadequada
int largura = valor / 2; // Pode sair da tela
```

### 3. Legendas e Títulos
```csharp
// ✅ Bom: Informações claras
Console.WriteLine("📊 Vendas por Mês (em mil reais):");
foreach (var (mes, valor) in vendas) {
    VisualizarBarra(mes, valor);
}

// ❌ Ruim: Sem contexto
VisualizarDados(vendas);
```

### 4. Cores Significativas
```csharp
// ✅ Bom: Cores com significado
if (temperatura > 30) {
    Console.ForegroundColor = ConsoleColor.Red;
} else if (temperatura > 20) {
    Console.ForegroundColor = ConsoleColor.Yellow;
}

// ❌ Ruim: Cores aleatórias
Console.ForegroundColor = ConsoleColor.Magenta;
```

### 5. Performance em Grandes Volumes
```csharp
// ✅ Bom: Agrupar dados antes de visualizar
var agrupados = dados.GroupBy(d => d.Categoria);
VisualizarGrafico(agrupados);

// ❌ Ruim: Plotar todos os pontos individuais
VisualizarTodosPontos(dados);
```

## 🔗 Interatividade no Console

### Atualizar em Tempo Real
```csharp
while (true) {
    Console.Clear();
    var dados = ObterDadosAtuais();
    VisualizarGrafico(dados);
    Thread.Sleep(1000);
}
```

### Entrada do Usuário
```csharp
Console.WriteLine("Escolha o tipo de gráfico:");
Console.WriteLine("1. Barras");
Console.WriteLine("2. Linhas");
Console.WriteLine("3. Tabela");

string escolha = Console.ReadLine();
VisualizarGrafico(dados, escolha);
```

## 📚 Bibliotecas Externas

Para gráficos mais avançados, considere:

### OxyPlot
```csharp
var model = new PlotModel { Title = "Meus Dados" };
var series = new BarSeries();
model.Series.Add(series);
```

### LiveCharts
```csharp
var values = new ChartValues<double> { 1, 2, 3 };
var series = new BarSeries { Values = values };
```

### Spectre.Console
```csharp
var chart = new BarChart()
    .AddItem("Jan", 45, Color.Green);
AnsiConsole.Write(chart);
```

## ✅ Checklist de Aprendizado

- [ ] Consigo criar gráfico de barras ASCII
- [ ] Domino gráfico de linhas
- [ ] Crio tabelas formatadas
- [ ] Entendo histogramas
- [ ] Consigo plotar em X,Y
- [ ] Plotar funções matemáticas
- [ ] Uso cores efetivamente
- [ ] Escolho o gráfico apropriado
- [ ] Formato dados antes de visualizar
- [ ] Crio visualizações interativas

## 📚 Recursos Adicionais

- [Console Colors - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.console.foregroundcolor)
- [Spectre.Console GitHub](https://github.com/spectreconsole/spectre.console)
- [Data Visualization Guide](https://www.interaction-design.org/literature/article/information-visualization)

---

**Próximos Passos**: Combine visualizações com dados reais para criar relatórios interativos e informativos!
