using System.ComponentModel.DataAnnotations;

namespace EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Apresentacao;

public record ListarItemTarefaViewModel(
    Guid Id,
    string Titulo,
    bool Concluido,
    Guid TarefaId
);

public record CadastroItemTarefaViewModel(
    [Required(ErrorMessage = "O campo \"Título\" é obrigatório!")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "O campo \"Título\" deve conter entre 2 e 100 caracteres.")]
    string Titulo,

    Guid TarefaId
);

public record ExcluirItemTarefaViewModel(
    Guid Id,
    string Titulo,
    bool Concluido,
    Guid TarefaId
);

public record ConcluirItemTarefaViewModel(
    Guid Id,
    bool Concluido
);