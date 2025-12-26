namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Arquivos
/// </summary>
public class ArquivosModuleService : IModuleService
{
    public string ModuleName => "Arquivos";

    public void Execute()
    {
        ArquivosModule.Run();
    }
}
