namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Coleções
/// </summary>
public class ColecoesModuleService : IModuleService
{
    public string ModuleName => "Coleções";

    public void Execute()
    {
        ColecoesModule.Run();
    }
}
