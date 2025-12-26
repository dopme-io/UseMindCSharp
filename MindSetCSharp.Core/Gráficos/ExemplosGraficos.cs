namespace MindSetCSharp.Core.Graficos;

/// <summary>
/// Exemplos práticos de visualização de dados usando gráficos ASCII.
/// </summary>
public static class ExemplosGraficos
{
    /// <summary>
    /// Exemplo 1: Gráfico de Barras Horizontal
    /// Visualizar comparação de valores
    /// </summary>
    public static void ExemploGraficoBarras()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║    EXEMPLO 1: Gráfico de Barras                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var vendas = new Dictionary<string, int>
        {
            { "Janeiro", 45 },
            { "Fevereiro", 52 },
            { "Março", 38 },
            { "Abril", 61 },
            { "Maio", 55 },
            { "Junho", 48 }
        };

        Console.WriteLine("📊 Vendas por Mês (em mil reais):\n");

        int maxValor = vendas.Values.Max();

        foreach (var (mes, valor) in vendas)
        {
            int larguraBarra = (int)((double)valor / maxValor * 40);
            string barra = new string('█', larguraBarra);
            Console.WriteLine($"{mes,-12} │ {barra,40} │ {valor}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 2: Gráfico de Linhas
    /// Visualizar tendência ao longo do tempo
    /// </summary>
    public static void ExemploGraficoLinhas()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 2: Gráfico de Linhas                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        int[] temperaturas = { 18, 20, 22, 25, 28, 26, 24, 22, 20, 19, 17, 16 };
        string[] meses = { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" };

        Console.WriteLine("🌡️  Temperatura Média por Mês (°C):\n");

        int alturaGrafico = 15;
        int minTemp = 15;
        int maxTemp = 30;

        // Desenhar grade
        for (int y = alturaGrafico; y >= 0; y--)
        {
            int temp = minTemp + (y * (maxTemp - minTemp) / alturaGrafico);

            Console.Write($"{temp:D2} │ ");

            for (int x = 0; x < temperaturas.Length; x++)
            {
                int alturaColuna = (int)((double)(temperaturas[x] - minTemp) / (maxTemp - minTemp) * alturaGrafico);

                if (alturaColuna == y)
                {
                    Console.Write("●");
                }
                else if (alturaColuna > y)
                {
                    Console.Write("│");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.Write(" ");
            }

            Console.WriteLine();
        }

        // Eixo X
        Console.WriteLine("    └─" + string.Join("─", Enumerable.Range(0, temperaturas.Length).Select(_ => "─")));
        Console.Write("      ");
        foreach (var mes in meses)
        {
            Console.Write(mes + " ");
        }
        Console.WriteLine("\n");
    }

    /// <summary>
    /// Exemplo 3: Tabela de Dados
    /// Organizar dados em formato tabular
    /// </summary>
    public static void ExemploTabela()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 3: Tabela de Dados                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var alunos = new List<(string Nome, int Matricula, double Media, string Situacao)>
        {
            ("Ana Silva", 2021001, 8.5, "Aprovado"),
            ("Bruno Santos", 2021002, 7.2, "Aprovado"),
            ("Carlos Junior", 2021003, 5.8, "Reprovado"),
            ("Diana Oliveira", 2021004, 9.1, "Aprovado"),
            ("Eduardo Costa", 2021005, 6.9, "Aprovado")
        };

        Console.WriteLine("📋 Relação de Alunos:\n");

        // Cabeçalho
        Console.WriteLine("┌────────────────────┬────────────┬─────────┬───────────┐");
        Console.WriteLine("│ Nome               │ Matrícula  │  Média  │ Situação  │");
        Console.WriteLine("├────────────────────┼────────────┼─────────┼───────────┤");

        // Dados
        foreach (var (nome, matricula, media, situacao) in alunos)
        {
            string icone = situacao == "Aprovado" ? "✓" : "✗";
            Console.WriteLine($"│ {nome,-18} │ {matricula,-10} │ {media,6:F1}  │ {icone} {situacao,-6} │");
        }

        // Rodapé
        Console.WriteLine("└────────────────────┴────────────┴─────────┴───────────┘");

        // Estatísticas
        double mediaGeral = alunos.Average(a => a.Media);
        int aprovados = alunos.Count(a => a.Situacao == "Aprovado");

        Console.WriteLine($"\n📊 Estatísticas:");
        Console.WriteLine($"  Média Geral: {mediaGeral:F2}");
        Console.WriteLine($"  Aprovados: {aprovados}/{alunos.Count}");
        Console.WriteLine($"  Taxa de Aprovação: {(aprovados * 100.0 / alunos.Count):F1}%");
        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 4: Histograma
    /// Distribuição de frequências
    /// </summary>
    public static void ExemploHistograma()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 4: Histograma                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Dados de idade de pessoas
        int[] idades = {
            25, 32, 28, 45, 51, 38, 42, 29, 55, 48,
            35, 61, 39, 44, 52, 26, 58, 36, 49, 31,
            47, 33, 60, 37, 50, 27, 41, 53, 34, 62
        };

        Console.WriteLine("📊 Distribuição de Idades:\n");

        // Criar intervalos
        var intervalos = new Dictionary<string, int>
        {
            { "20-29", 0 },
            { "30-39", 0 },
            { "40-49", 0 },
            { "50-59", 0 },
            { "60-69", 0 }
        };

        foreach (var idade in idades)
        {
            if (idade >= 20 && idade < 30) intervalos["20-29"]++;
            else if (idade >= 30 && idade < 40) intervalos["30-39"]++;
            else if (idade >= 40 && idade < 50) intervalos["40-49"]++;
            else if (idade >= 50 && idade < 60) intervalos["50-59"]++;
            else if (idade >= 60 && idade < 70) intervalos["60-69"]++;
        }

        int maxFrequencia = intervalos.Values.Max();

        foreach (var (intervalo, frequencia) in intervalos)
        {
            int larguraBarra = (int)((double)frequencia / maxFrequencia * 30);
            string barra = new string('▓', larguraBarra);
            Console.WriteLine($"{intervalo} │ {barra,-30} │ {frequencia} pessoas");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 5: Diagrama de Dispersão
    /// Visualizar relação entre duas variáveis
    /// </summary>
    public static void ExemploDiagramaDispersao()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║     EXEMPLO 5: Diagrama de Dispersão                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var dados = new List<(int Estudo, int Nota)>
        {
            (2, 4), (3, 5), (4, 6), (5, 7), (6, 8),
            (7, 8), (8, 9), (9, 10), (1, 3), (10, 10),
            (5, 6), (3, 5), (7, 8), (4, 5), (8, 9)
        };

        Console.WriteLine("📈 Horas de Estudo vs Nota (Escala 0-10):\n");

        int maxX = 10;
        int maxY = 10;

        // Desenhar grid
        for (int y = maxY; y >= 0; y--)
        {
            Console.Write($"{y:D2} │ ");

            for (int x = 0; x <= maxX; x++)
            {
                // Verificar se há ponto nesta posição
                bool temPonto = dados.Any(d => d.Estudo == x && d.Nota == y);

                if (temPonto)
                    Console.Write("●");
                else if (x == 0 || y == 0)
                    Console.Write("─");
                else
                    Console.Write(" ");

                Console.Write(" ");
            }

            Console.WriteLine();
        }

        // Eixo X
        Console.WriteLine("    └" + string.Concat(Enumerable.Range(0, maxX + 1).Select(_ => "──")));
        Console.Write("      ");
        for (int x = 0; x <= maxX; x++)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine("\n    Horas de Estudo →\n");
    }

    /// <summary>
    /// Exemplo 6: Plotagem de Função Matemática
    /// Visualizar gráfico de uma função
    /// </summary>
    public static void ExemploFuncaoMatematica()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║  EXEMPLO 6: Função Matemática (y = x²)               ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("📐 Gráfico de y = x²:\n");

        int centro = 5;
        int altura = 10;
        int largura = 20;

        // Calcular valores
        var pontos = new Dictionary<int, double>();
        for (int x = -centro; x <= centro; x++)
        {
            pontos[x] = x * x;
        }

        double maxY = pontos.Values.Max();

        // Desenhar
        for (int y = altura; y >= 0; y--)
        {
            Console.Write("│ ");

            for (int x = -centro; x <= centro; x++)
            {
                int alturaPonto = (int)((double)pontos[x] / maxY * altura);

                if (alturaPonto == y)
                    Console.Write("● ");
                else if (alturaPonto > y)
                    Console.Write("│ ");
                else
                    Console.Write("  ");
            }

            Console.WriteLine("│");
        }

        // Base
        Console.WriteLine("└" + new string('─', centro * 2 * 2 + 3) + "┘");

        // Eixos
        Console.Write("  ");
        for (int x = -centro; x <= centro; x++)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine("\n");
    }

    /// <summary>
    /// Exemplo 7: Gráfico de Setor (Pizza)
    /// Mostrar proporções em ASCII
    /// </summary>
    public static void ExemploGraficoSetor()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║      EXEMPLO 7: Gráfico de Setor (Pizza)             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        var dados = new Dictionary<string, int>
        {
            { "Chrome", 65 },
            { "Firefox", 20 },
            { "Safari", 10 },
            { "Edge", 5 }
        };

        Console.WriteLine("🥧 Participação de Mercado de Navegadores:\n");

        int total = dados.Values.Sum();

        // Barra horizontal
        int larguraTotal = 40;
        int posicao = 0;

        foreach (var (navegador, valor) in dados)
        {
            double percentual = (double)valor / total * 100;
            int largura = (int)(percentual / 100 * larguraTotal);

            Console.Write($"{navegador,-10} │ ");
            Console.ForegroundColor = GetColor(navegador);
            Console.Write(new string('█', largura));
            Console.ResetColor();
            Console.WriteLine($" {percentual:F1}% ({valor})");
        }

        Console.WriteLine("\nLegenda:");
        foreach (var navegador in dados.Keys)
        {
            Console.ForegroundColor = GetColor(navegador);
            Console.WriteLine($"  █ {navegador}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Exemplo 8: Visualização com Cores
    /// Usar cores para destacar informações
    /// </summary>
    public static void ExemploVisualizacaoCores()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║    EXEMPLO 8: Visualização com Cores                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // Escala de temperatura
        Console.WriteLine("🌡️  Escala de Temperatura:\n");

        var temperaturas = new List<(string Local, int Temp)>
        {
            ("São Paulo", 28),
            ("Rio de Janeiro", 32),
            ("Curitiba", 18),
            ("Manaus", 35),
            ("Brasília", 25),
            ("Salvador", 30)
        };

        foreach (var (local, temp) in temperaturas)
        {
            Console.Write($"{local,-15} │ ");

            // Cores baseadas na temperatura
            if (temp >= 30)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (temp >= 25)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (temp >= 20)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write(new string('█', temp / 2));
            Console.ResetColor();
            Console.WriteLine($" {temp}°C");
        }

        // Indicadores de status
        Console.WriteLine("\n📊 Indicadores de Status:\n");

        var status = new List<(string Item, int Valor, string Tipo)>
        {
            ("Servidor Online", 99, "ok"),
            ("Memória Disponível", 45, "warning"),
            ("CPU Utilizado", 85, "critical"),
            ("Disco Livre", 60, "ok"),
            ("Conexão", 100, "ok")
        };

        foreach (var (item, valor, tipo) in status)
        {
            Console.Write($"{item,-20} │ ");

            // Cor baseada no tipo
            switch (tipo)
            {
                case "ok":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "warning":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "critical":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            int largura = valor / 5;
            Console.Write(new string('█', largura));
            Console.ResetColor();
            Console.WriteLine($" {valor}%");
        }

        Console.WriteLine();
    }

    // Métodos auxiliares
    private static ConsoleColor GetColor(string navegador)
    {
        return navegador switch
        {
            "Chrome" => ConsoleColor.Cyan,
            "Firefox" => ConsoleColor.Yellow,
            "Safari" => ConsoleColor.Gray,
            "Edge" => ConsoleColor.Blue,
            _ => ConsoleColor.White
        };
    }
}
