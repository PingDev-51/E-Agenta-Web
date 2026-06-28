using System.ComponentModel.DataAnnotations;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Dominio;

namespace EAgendaWeb.WebApp.Modulos.ModuloTarefas.Apresentacao;

public record ListarTarefaViewModel(
    Guid Id,
    string Titulo,
    PrioridadeTarefa Prioridade,
    DateTime DataCriacao,
    bool Concluida,
    int PercentualConcluido
);

public record CadastroTarefaViewModel(
    [Required(ErrorMessage = "O campo \"Título\" é obrigatório!")]
    string Titulo,

    [Required(ErrorMessage = "O campo \"Prioridade\" é obrigatório!")]
    PrioridadeTarefa Prioridade
);

public record ExcluirTarefaViewModel(
    Guid Id,
    string Titulo,
    PrioridadeTarefa Prioridade,
    DateTime DataCriacao,
    DateTime? DataConclusao,
    bool Concluida,
    int PercentualConcluido
);

public record EditarTarefaViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Título\" é obrigatório!")]
    string Titulo,

    [Required(ErrorMessage = "O campo \"Prioridade\" é obrigatório!")]
    PrioridadeTarefa Prioridade,

    DateTime? DataConclusao,

    bool Concluida,

    [Range(0, 100, ErrorMessage = "O percentual deve estar entre 0 e 100.")]
    int PercentualConcluido
);