using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Dominio;

namespace EAgendaWeb.WebApp.Modulos.ModuloTarefas.Aplicacao;

public record DetalhesTarefaDto(
    Guid Id,
    string Titulo,
    PrioridadeTarefa Prioridade,
    DateTime DataCriacao,
    DateTime? DataConclusao,
    bool Concluida,
    int PercentualConcluido
);

public record CadastroTarefaDto(
    string Titulo,
    PrioridadeTarefa Prioridade
);

public record EditarTarefaDto(
    Guid Id,
    string Titulo,
    PrioridadeTarefa Prioridade,
    DateTime? DataConclusao,
    bool Concluida,
    int PercentualConcluido
);