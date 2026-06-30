using System;
using E_Agenda.WebApp.Modulos.ModuloContatos.Aplicacao;
using EAgendaWeb.WebApp.Compartilhado.Apresentacao.Extensions;
using FluentResults;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace E_Agenda.WebApp.Modulos.ModuloContatos.Apresentacao;

public class ContatosController : Controller
{
    private readonly ServicoContato servicoContato;
    private readonly IMapper mapeador;

    public ContatosController(ServicoContato servicoContato, IMapper mapeador)
    {
        this.servicoContato = servicoContato;
        this.mapeador = mapeador;
    }

    public ActionResult Listar()
    {
        List<ListarContatosDto> dtos = servicoContato.SelecionarTodos();

        List<ListarContatosViewModel> listarVm = mapeador.Map<List<ListarContatosViewModel>>(dtos);

        return View(listarVm);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarContatosViewModel cadastrarVm = new CadastrarContatosViewModel(
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }


    [HttpPost]
    public ActionResult Cadastrar(CadastrarContatosViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarContatosDto dto = mapeador.Map<CadastrarContatosDto>(cadastrarVm);

        Result resultado = servicoContato.Cadastrar(dto);

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
        Result<DetalhesContatosDto> resultado = servicoContato.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        DetalhesContatosDto dto = resultado.Value;

        EditarContatosViewModel editarVm = mapeador.Map<EditarContatosViewModel>(dto);

        return View(editarVm);
    }


    [HttpPost]
    public ActionResult Editar(EditarContatosViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarContatosDto dto = mapeador.Map<EditarContatosDto>(editarVm);

        Result resultado = servicoContato.Editar(dto);

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
        Result<DetalhesContatosDto> resultado = servicoContato.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
        }

        DetalhesContatosDto dto = resultado.Value;

        ExcluirContatosViewModel excluirVm = mapeador.Map<ExcluirContatosViewModel>(dto);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirContatosViewModel excluirVm)
    {
        Result resultado = servicoContato.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
        }

        return RedirectToAction(nameof(Listar));
    }
}