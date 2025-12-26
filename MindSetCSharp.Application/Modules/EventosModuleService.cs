namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Eventos
/// </summary>
public class EventosModuleService : IModuleService
{
    public string ModuleName => "Eventos";

    public void Execute()
    {
        EventosModule.Run();
    }
}
