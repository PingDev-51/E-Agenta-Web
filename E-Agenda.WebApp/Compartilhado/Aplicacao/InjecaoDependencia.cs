using E_Agenda.WebApp.Modulos.ModuloContatos.Aplicacao;
using EAgendaWeb.WebApp.Compartilhado.Aplicacao.Logging;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Aplicacao;

namespace EAgendaWeb.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration,
        ILoggingBuilder logging
    )
    {
        services.AddSerilogLogger(configuration, logging);
        services.AddScoped<ServicoTarefa>();
        services.AddScoped<ServicoContato>();
    }
}
