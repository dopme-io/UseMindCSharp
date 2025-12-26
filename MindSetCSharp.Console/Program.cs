// Criar a orquestração da aplicação
IApplicationOrchestrator orchestrator = new ApplicationOrchestrator();

// Exibir cabeçalho
Console.WriteLine("=== MindSet CSharp: Use Mindset com CSharp ===");
Console.WriteLine("Explorando a base fundamental da programação em C#\n");
Console.WriteLine("Registrando módulos...\n");

// Registrar todos os módulos
foreach (var moduleService in ModuleServiceFactory.CreateAll())
{
	orchestrator.RegisterModule(moduleService);
}

// Exibir módulos registrados
var registeredModules = orchestrator.GetRegisteredModules();
Console.WriteLine($"Total de módulos registrados: {registeredModules.Count}\n");
Console.WriteLine("--- Iniciando execução dos módulos ---\n");

// Executar todos os módulos
orchestrator.ExecuteAllModules();

Console.WriteLine("\n=== Fim do programa ===" );
