using E_Agenda.WebApp.Modulos.ModuloCompromissos.Dominio;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Infra;
using E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;
using E_Agenda.WebApp.Modulos.ModuloContatos.Infra;
using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;
using EAgendaWeb.WebApp.Modulos.ModuloTarefa.Infra;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Dominio;
namespace EAgendaWeb.WebApp.Compartilhado.Infra;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
        services.AddScoped<IRepositorioTarefa, RepositorioTarefaEmSql>();
        services.AddScoped<IRepositorioContatos, RepositorioContatoEmSql>();
        services.AddScoped<IRepositorioCompromissos, RepositorioCompromissoEmSql>();

    }
}
