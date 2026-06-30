using System;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Dominio;

namespace E_Agenda.WebApp.Modulos.ModuloCompromissos.Aplicacao;

public record ListarCompromissosDto(
    Guid Id,
    string Assunto,
    DateTime DataOcorrencia,
    DateTime HoraDeIncio,
    DateTime HoraDeTermino,
    TipoCompromisso TipoDeCompromisso,
    string Local,
    string Link,
    string Contato
);

public record CadastrarCompromissosDto(
    string Assunto,
    DateTime HoraDeInicio,
    DateTime HoraDeTermino,
    TipoCompromisso TipoDeCompromisso,
    string Local,
    string Link,
    Guid contatoId,
    List<OpcaoContatoDto> Contato
);

public record EditarCompromissosDto(
    Guid Id,
    string Assunto,
    DateTime HoraDeInicio,
    DateTime HoraDeTermino,
    TipoCompromisso TipoDeCompromisso,
    string Local,
    string Link,
    Guid contatoId,
    List<OpcaoContatoDto> Contato
);

public record ExcluirCompromissosDto(
    Guid Id,
    string Assunto,
    DateTime HoraDeInicio,
    DateTime HoraDeTermino,
    TipoCompromisso TipoDeCompromisso,
    string Local,
    string Link,
    Guid contatoId,
    List<OpcaoContatoDto> Contato
);

public record DetalhesCompromissosDto(
    string Assunto,
    DateTime DataOcorrencia,
    DateTime HoraDeIncio,
    DateTime HoraDeTermino,
    TipoCompromisso TipoDeCompromisso,
    string Local,
    string Link,
    Guid contatoId,
    List<OpcaoContatoDto> Contato
);

public record OpcaoContatoDto(
    Guid Id,
    string Nome
);
