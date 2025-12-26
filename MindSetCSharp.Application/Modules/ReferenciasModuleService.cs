namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Referências
/// </summary>
public class ReferenciasModuleService : IModuleService
{
    public string ModuleName => "Referências";

    public void Execute()
    {
        ReferenciasModule.Run();
    }
}
