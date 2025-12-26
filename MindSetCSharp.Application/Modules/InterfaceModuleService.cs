namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Interface
/// </summary>
public class InterfaceModuleService : IModuleService
{
    public string ModuleName => "Interface";

    public void Execute()
    {
        InterfaceModule.Run();
    }
}
