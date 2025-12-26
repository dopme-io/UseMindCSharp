namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Bastidores
/// </summary>
public class BastidoresModuleService : IModuleService
{
    public string ModuleName => "Bastidores";

    public void Execute()
    {
        BastidoresModule.Run();
    }
}
