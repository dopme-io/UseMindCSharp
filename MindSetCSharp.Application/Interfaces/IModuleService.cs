namespace MindSetCSharp.Application.Interfaces;

/// <summary>
/// Define o contrato para serviços de módulos
/// </summary>
public interface IModuleService
{
    /// <summary>
    /// Obtém o nome do módulo
    /// </summary>
    string ModuleName { get; }

    /// <summary>
    /// Executa o módulo
    /// </summary>
    void Execute();
}
