namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Classes
/// </summary>
public class ClassesModuleService : IModuleService
{
    public string ModuleName => "Classes";

    public void Execute()
    {
        ClassesModule.Run();
    }
}
