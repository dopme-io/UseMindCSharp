namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo LINQ
/// </summary>
public class LINQModuleService : IModuleService
{
    public string ModuleName => "LINQ";

    public void Execute()
    {
        LINQModule.Run();
    }
}
