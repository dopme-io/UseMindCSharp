namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Enumerações
/// </summary>
public class EnumeracoesModuleService : IModuleService
{
    public string ModuleName => "Enumerações";

    public void Execute()
    {
        EnumeracoesModule.Run();
    }
}
