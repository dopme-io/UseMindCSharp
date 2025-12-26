namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Controles
/// </summary>
public class ControlesModuleService : IModuleService
{
    public string ModuleName => "Controles";

    public void Execute()
    {
        ControlesModule.Run();
    }
}
