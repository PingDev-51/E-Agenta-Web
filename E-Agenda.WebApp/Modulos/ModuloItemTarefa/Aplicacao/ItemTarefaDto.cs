using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Dominio;

namespace EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Aplicacao;

public record DetalhesItemTarefaDto(
    Guid Id,
    string Titulo,
    bool Concluido,
    Guid TarefaId
);

public record CadastroItemTarefaDto(
    string Titulo,
    Guid TarefaId
);

public record ConcluirItemTarefaDto(
    Guid Id,
    bool Concluido
);