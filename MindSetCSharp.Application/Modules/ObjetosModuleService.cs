namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Objetos
/// </summary>
public class ObjetosModuleService : IModuleService
{
    public string ModuleName => "Objetos";

    public void Execute()
    {
        ObjetosModule.Run();
    }
}
