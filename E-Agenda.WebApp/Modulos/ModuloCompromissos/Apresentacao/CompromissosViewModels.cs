using System;
using System.ComponentModel.DataAnnotations;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Dominio;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Dominio;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace E_Agenda.WebApp.Modulos.ModuloCompromissos.Apresentacao;

public record ListarCompromissosViewModels(
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

public record CadastrarCompromissosViewModels(
    [Required (ErrorMessage = "O campo Assunto e obrigatorio.")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "O campo Assunto precisa ter entre 2 a 100 caracteres")]
    string Assunto,

    [Required(ErrorMessage = "O campo data de inicio é obrigastorio")]
    DateTime HoraDeIncio,

    [Required(ErrorMessage = "O campo data de termino é obrigastorio")]
    DateTime HoraDeTermino,
    TipoCompromisso TipoDeCompromisso,
    string Local,
    string Link,

    Guid ContatoId,
    [ValidateNever]
    List<OpcaoContatoViewModels> Contato
);


public record OpcaoContatoViewModels(
    Guid Id,
    string Nome
);