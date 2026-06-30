using System;
using AutoMapper;
using E_Agenda.WebApp.Modulos.ModuloCategoria.Aplicacao;
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

    }
}
