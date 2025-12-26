namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Tipos
/// </summary>
public class TiposModuleService : IModuleService
{
    public string ModuleName => "Tipos";

    public void Execute()
    {
        TiposModule.Run();
    }
}
