using eAgenda.WebApp.Modulos.ModuloCompromisso.Dominio;

namespace eAgenda.WebApp.Modulos.ModuloCompromisso.Aplicacao;

public record ListarCompromissosDto(
    Guid Id,
    string Assunto,
    DateTime DataOcorrencia,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino,
    TipoCompromisso Tipo,
    string? Local,
    string? Link,
    Guid? ContatoId,
    string? ContatoNome
);

public record CadastrarCompromissoDto(
    string Assunto,
    DateTime DataOcorrencia,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino,
    TipoCompromisso Tipo,
    string? Local,
    string? Link,
    Guid? ContatoId
);

public record EditarCompromissoDto(
    Guid Id,
    string Assunto,
    DateTime DataOcorrencia,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino,
    TipoCompromisso Tipo,
    string? Local,
    string? Link,
    Guid? ContatoId
);

public record DetalhesCompromissoDto(
    Guid Id,
    string Assunto,
    DateTime DataOcorrencia,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino,
    TipoCompromisso Tipo,
    string? Local,
    string? Link,
    Guid? ContatoId,
    string? ContatoNome
);

public record OpcaoContatoDto(Guid Id, string Nome);
