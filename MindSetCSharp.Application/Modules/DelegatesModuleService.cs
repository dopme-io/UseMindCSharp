namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Delegates
/// </summary>
public class DelegatesModuleService : IModuleService
{
    public string ModuleName => "Delegates";

    public void Execute()
    {
        DelegatesModule.Run();
    }
}
