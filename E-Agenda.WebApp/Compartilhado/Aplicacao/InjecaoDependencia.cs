using eAgenda.WebApp.Compartilhado.Aplicacao.Logging;
using eAgenda.WebApp.Modulos.ModuloCategoria.Aplicacao;
using eAgenda.WebApp.Modulos.ModuloCompromisso.Aplicacao;
using eAgenda.WebApp.Modulos.ModuloContato.Aplicacao;
using eAgenda.WebApp.Modulos.ModuloDespesa.Aplicacao;
using eAgenda.WebApp.Modulos.ModuloTarefa.Aplicacao;

namespace eAgenda.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration,
        ILoggingBuilder logging
    )
    {
        services.AddSerilogLogger(configuration, logging);

        services.AddScoped<ServicoContato>();
        services.AddScoped<ServicoCompromisso>();
        services.AddScoped<ServicoCategoria>();
        services.AddScoped<ServicoDespesa>();
        services.AddScoped<ServicoTarefa>();
    }
}
