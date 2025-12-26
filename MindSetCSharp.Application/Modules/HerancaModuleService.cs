namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Herança
/// </summary>
public class HerancaModuleService : IModuleService
{
    public string ModuleName => "Herança";

    public void Execute()
    {
        HerancaModule.Run();
    }
}
