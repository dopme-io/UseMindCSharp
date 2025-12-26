namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Exceções
/// </summary>
public class ExcecoesModuleService : IModuleService
{
    public string ModuleName => "Exceções";

    public void Execute()
    {
        ExcecoesModule.Run();
    }
}
