namespace MindSetCSharp.Application.Factories;

using MindSetCSharp.Application.Interfaces;
using MindSetCSharp.Application.Modules;

/// <summary>
/// Factory para criar instâncias de serviços de módulos
/// </summary>
public class ModuleServiceFactory
{
    /// <summary>
    /// Cria uma instância de um serviço de módulo pelo nome
    /// </summary>
    /// <param name="moduleName">Nome do módulo</param>
    /// <returns>Instância do serviço do módulo</returns>
    /// <exception cref="ArgumentException">Se o módulo não existir</exception>
    public static IModuleService Create(string moduleName)
    {
        return moduleName switch
        {
            "Produtivo" => new ProdutivoModuleService(),
            "Bastidores" => new BastidoresModuleService(),
            "Objetos" => new ObjetosModuleService(),
            "Tipos" => new TiposModuleService(),
            "Referências" => new ReferenciasModuleService(),
            "Encapsulamento" => new EncapsulamentoModuleService(),
            "Herança" => new HerancaModuleService(),
            "Interface" => new InterfaceModuleService(),
            "Classes" => new ClassesModuleService(),
            "Enumerações" => new EnumeracoesModuleService(),
            "Coleções" => new ColecoesModuleService(),
            "Arquivos" => new ArquivosModuleService(),
            "Exceções" => new ExcecoesModuleService(),
            "Eventos" => new EventosModuleService(),
            "Delegates" => new DelegatesModuleService(),
            "Revisão" => new RevisaoModuleService(),
            "Controles" => new ControlesModuleService(),
            "Gráficos" => new GraficosModuleService(),
            "LINQ" => new LINQModuleService(),
            _ => throw new ArgumentException($"Módulo '{moduleName}' não reconhecido", nameof(moduleName))
        };
    }

    /// <summary>
    /// Cria todas as instâncias dos serviços de módulos
    /// </summary>
    /// <returns>Lista de serviços de módulos</returns>
    public static IEnumerable<IModuleService> CreateAll()
    {
        return new IModuleService[]
        {
            new ProdutivoModuleService(),
            new BastidoresModuleService(),
            new ObjetosModuleService(),
            new TiposModuleService(),
            new ReferenciasModuleService(),
            new EncapsulamentoModuleService(),
            new HerancaModuleService(),
            new InterfaceModuleService(),
            new ClassesModuleService(),
            new EnumeracoesModuleService(),
            new ColecoesModuleService(),
            new ArquivosModuleService(),
            new ExcecoesModuleService(),
            new EventosModuleService(),
            new DelegatesModuleService(),
            new RevisaoModuleService(),
            new ControlesModuleService(),
            new GraficosModuleService(),
            new LINQModuleService()
        };
    }
}
