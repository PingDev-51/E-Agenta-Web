using System;
using AutoMapper;
using E_Agenda.WebApp.Modulos.ModuloCategoria.Aplicacao;
using EAgendaWeb.WebApp.Compartilhado.Apresentacao.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Apresentacao;

public class CategoriaController : Controller
{
    private readonly ServicoCategoria servicoCategoria;
    private readonly IMapper mapeador;

    public CategoriaController(ServicoCategoria servicoCategoria, IMapper mapeador)
    {
        this.servicoCategoria = servicoCategoria;
        this.mapeador = mapeador;
    }

    public ActionResult Listar()
    {
        List<ListarCategoriaDto> dto = servicoCategoria.SelecionarTodos();

        List<ListarCategoriaViewModel> listarVm = mapeador.Map<List<ListarCategoriaViewModel>>(dto);

        return View(listarVm);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarCategoriaViewModel cadastrarVm = new CadastrarCategoriaViewModel(
            string.Empty,
            Guid.Empty,
            SelecionarDespesas()
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarCategoriaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm with { Despesas = SelecionarDespesas() });

        CadastrarCategoriaDto dto = mapeador.Map<CadastrarCategoriaDto>(cadastrarVm);

        Result resultado = servicoCategoria.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesCategoriaDto> resultado = servicoCategoria.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        DetalhesCategoriaDto dto = resultado.Value;

        EditarCategoriaViewModel editarVm = mapeador.Map<EditarCategoriaViewModel>(dto);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarCategoriaViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarCategoriaDto dto = mapeador.Map<EditarCategoriaDto>(editarVm);

        Result resultado = servicoCategoria.Editar(dto);


        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesCategoriaDto> resultado = servicoCategoria.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        DetalhesCategoriaDto dto = resultado.Value;

        ExcluirCategoriaViewModel excluirVm = mapeador.Map<ExcluirCategoriaViewModel>(dto);

        return View(excluirVm);
    }


    [HttpPost]
    public ActionResult Excluir(ExcluirCategoriaViewModel excluirVm)
    {
        Result resultado = servicoCategoria.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData["MensagemErro"] = resultado.Errors.First().Message;

        return RedirectToAction(nameof(Listar));
    }

    private List<OpcaoDespesasViewModel> SelecionarDespesas()
    {
        List<OpcaoDespesasDto> despesas = servicoCategoria.SelecionarDespesas();

        return despesas.Select(d => new OpcaoDespesasViewModel(d.Id, d.Descricao)).ToList();
    }
}
