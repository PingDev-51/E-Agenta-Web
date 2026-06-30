using System;
using AutoMapper;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Aplicacao;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Dominio;
using E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;
using EAgendaWeb.WebApp.Compartilhado.Apresentacao.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Agenda.WebApp.Modulos.ModuloCompromissos.Apresentacao;

public class CompromissosControllers : Controller
{

    private readonly ServicoCompromisso servicoCompromisso;
    private readonly IMapper mapeador;

    public CompromissosControllers(ServicoCompromisso servicoCompromisso, IMapper mapeador)
    {
        this.servicoCompromisso = servicoCompromisso;
        this.mapeador = mapeador;
    }

    public ActionResult Listar()
    {
        List<ListarCompromissosDto> dtos = servicoCompromisso.SelecionarTodos();

        ListarCompromissosViewModels listarVm = mapeador.Map<ListarCompromissosViewModels>(dtos);

        return View(listarVm);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarCompromissosViewModels cadastrarVm = new CadastrarCompromissosViewModels(
            string.Empty,
            DateTime.Now,
            DateTime.Now,
            TipoCompromisso.Indefinido,
            string.Empty,
            string.Empty,
            Guid.Empty,
            SelecionarContatos()
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarCompromissosViewModels cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm with { Contato = SelecionarContatos() });

        CadastrarCompromissosDto dto = mapeador.Map<CadastrarCompromissosDto>(cadastrarVm);

        Result resultado = servicoCompromisso.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    private List<OpcaoContatoViewModels> SelecionarContatos()
    {
        List<OpcaoContatoDto> contatos = servicoCompromisso.SelecionarContatos();

        return contatos.Select(c => new OpcaoContatoViewModels(
            c.Id,
            c.Nome
        )).ToList();
    }
}
