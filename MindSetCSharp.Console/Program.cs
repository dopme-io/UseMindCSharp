// Criar a orquestração da aplicação
IApplicationOrchestrator orchestrator = new ApplicationOrchestrator();

// Registrar todos os módulos disponíveis
var moduleServices = ModuleServiceFactory.CreateAll().ToList();
foreach (var moduleService in moduleServices)
{
	orchestrator.RegisterModule(moduleService);
}

// Exibir cabeçalho
Console.WriteLine("=== MindSet CSharp: Use Mindset com CSharp ===");
Console.WriteLine("Explorando a base fundamental da programação em C#\n");

var registeredModules = orchestrator.GetRegisteredModules().ToList();
Console.WriteLine($"Total de módulos registrados: {registeredModules.Count}\n");

while (true)
{
	Console.WriteLine("Selecione um módulo para executar:");
	for (var i = 0; i < registeredModules.Count; i++)
	{
		Console.WriteLine($" {i + 1:00} - {registeredModules[i]}");
	}
	Console.WriteLine(" A  - Executar todos");
	Console.WriteLine(" 0  - Sair");
	Console.Write("\nOpção: ");

	var input = Console.ReadLine()?.Trim();
	if (string.IsNullOrWhiteSpace(input))
	{
		Console.WriteLine("Opção vazia. Tente novamente.\n");
		continue;
	}

	if (input.Equals("0", StringComparison.OrdinalIgnoreCase) ||
		input.Equals("sair", StringComparison.OrdinalIgnoreCase) ||
		input.Equals("q", StringComparison.OrdinalIgnoreCase))
	{
		Console.WriteLine("\nSaindo...");
		Environment.Exit(0);
	}

	if (input.Equals("a", StringComparison.OrdinalIgnoreCase) || input == "*")
	{
		Console.WriteLine("\n--- Executando todos os módulos ---\n");
		orchestrator.ExecuteAllModules();
		Console.WriteLine("\n--- Execução concluída ---\n");
		continue;
	}

	if (int.TryParse(input, out var index) && index >= 1 && index <= registeredModules.Count)
	{
		var moduleName = registeredModules[index - 1];
		Console.WriteLine($"\n--- Executando módulo: {moduleName} ---\n");
		orchestrator.ExecuteModule(moduleName);
		Console.WriteLine("\n--- Execução concluída ---\n");
		continue;
	}

	var matchedByName = registeredModules.FirstOrDefault(m => m.Equals(input, StringComparison.OrdinalIgnoreCase));
	if (matchedByName is not null)
	{
		Console.WriteLine($"\n--- Executando módulo: {matchedByName} ---\n");
		orchestrator.ExecuteModule(matchedByName);
		Console.WriteLine("\n--- Execução concluída ---\n");
		continue;
	}

	Console.WriteLine($"Opção inválida: {input}\n");
}
