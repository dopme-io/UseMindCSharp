namespace MindSetCSharp.Application.Services;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Orquestra a execução dos módulos da aplicação
/// </summary>
public class ApplicationOrchestrator : IApplicationOrchestrator
{
    private readonly Dictionary<string, IModuleService> _modules = new();

    public void RegisterModule(IModuleService moduleService)
    {
        if (moduleService == null)
            throw new ArgumentNullException(nameof(moduleService));

        _modules[moduleService.ModuleName] = moduleService;
    }

    public void ExecuteAllModules()
    {
        foreach (var module in _modules.Values)
        {
            ExecuteModuleSafely(module);
        }
    }

    public void ExecuteModule(string moduleName)
    {
        if (string.IsNullOrWhiteSpace(moduleName))
            throw new ArgumentException("O nome do módulo não pode ser vazio", nameof(moduleName));

        if (!_modules.TryGetValue(moduleName, out var module))
            throw new InvalidOperationException($"Módulo '{moduleName}' não encontrado");

        ExecuteModuleSafely(module);
    }

    public IReadOnlyList<string> GetRegisteredModules()
    {
        return _modules.Keys.ToList().AsReadOnly();
    }

    private void ExecuteModuleSafely(IModuleService module)
    {
        try
        {
            module.Execute();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[ERRO] Erro ao executar módulo '{module.ModuleName}': {ex.Message}");
        }
    }
}
