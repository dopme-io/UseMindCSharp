namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Produtivo
/// </summary>
public class ProdutivoModuleService : IModuleService
{
    public string ModuleName => "Produtivo";

    public void Execute()
    {
        ProdutivoModule.Run();
    }
}
