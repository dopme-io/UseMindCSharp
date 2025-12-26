namespace MindSetCSharp.Application.Interfaces;

/// <summary>
/// Define o contrato para orquestração da aplicação
/// </summary>
public interface IApplicationOrchestrator
{
    /// <summary>
    /// Registra um módulo para execução
    /// </summary>
    /// <param name="moduleService">Serviço do módulo a ser registrado</param>
    void RegisterModule(IModuleService moduleService);

    /// <summary>
    /// Executa todos os módulos registrados
    /// </summary>
    void ExecuteAllModules();

    /// <summary>
    /// Executa um módulo específico pelo nome
    /// </summary>
    /// <param name="moduleName">Nome do módulo</param>
    void ExecuteModule(string moduleName);

    /// <summary>
    /// Obtém a lista de módulos registrados
    /// </summary>
    IReadOnlyList<string> GetRegisteredModules();
}
