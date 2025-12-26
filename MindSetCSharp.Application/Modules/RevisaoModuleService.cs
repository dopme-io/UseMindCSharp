namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Revisão
/// </summary>
public class RevisaoModuleService : IModuleService
{
    public string ModuleName => "Revisão";

    public void Execute()
    {
        RevisaoModule.Run();
    }
}
