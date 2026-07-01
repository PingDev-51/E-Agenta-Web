using E_Agenda.WebApp.Modulos.ModuloCompromissos.Dominio;
using eAgenda.WebApp.Compartilhado.Infra.Sql;
using eAgenda.WebApp.Modulos.ModuloCategoria.Dominio;
using eAgenda.WebApp.Modulos.ModuloCategoria.Infra;
using eAgenda.WebApp.Modulos.ModuloCompromisso.Dominio;
using eAgenda.WebApp.Modulos.ModuloCompromisso.Infra;
using eAgenda.WebApp.Modulos.ModuloContato.Dominio;
using eAgenda.WebApp.Modulos.ModuloContato.Infra;
using eAgenda.WebApp.Modulos.ModuloDespesa.Dominio;
using eAgenda.WebApp.Modulos.ModuloTarefa.Dominio;
using eAgenda.WebApp.Modulos.ModuloTarefa.Infra;
using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Infra;

namespace eAgenda.WebApp.Compartilhado.Infra;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

        services.AddScoped<IRepositorioContato, RepositorioContatoEmSql>();
        services.AddScoped<IRepositorioCompromisso, RepositorioCompromissoEmSql>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmSql>();
        services.AddScoped<IRepositorioDespesa, RepositorioDespesaEmSql>();
        services.AddScoped<IRepositorioTarefa, RepositorioTarefaEmSql>();
    }
}
