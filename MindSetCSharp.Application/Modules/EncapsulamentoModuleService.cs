namespace MindSetCSharp.Application.Modules;

using MindSetCSharp.Application.Interfaces;

/// <summary>
/// Serviço que orquestra o módulo Encapsulamento
/// </summary>
public class EncapsulamentoModuleService : IModuleService
{
    public string ModuleName => "Encapsulamento";

    public void Execute()
    {
        EncapsulamentoModule.Run();
    }
}
