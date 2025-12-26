namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Gráficos
/// </summary>
public class GraficosModuleService : IModuleService
{
    public string ModuleName => "Gráficos";

    public void Execute()
    {
        GraficosModule.Run();
    }
}
