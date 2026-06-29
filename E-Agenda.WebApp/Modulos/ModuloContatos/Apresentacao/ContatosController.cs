using System;
using E_Agenda.WebApp.Modulos.ModuloContatos.Aplicacao;
using E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;
using E_Agenda.WebApp.Modulos.ModuloContatos.Infra;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Agenda.WebApp.Modulos.ModuloContatos.Apresentacao;

public class ContatosController : Controller
{
    private readonly ServicoContato servicoContato;

    public ContatosController(ServicoContato servicoContato)
    {
        this.servicoContato = servicoContato;
    }

    public ActionResult Listar()
    {
        List<ListarContatosContatosDto> dtos = servicoContato.SelecionarTodos();

        List<ListarContatosContatosViewModels> listarVm = dtos.Select(c => new ListarContatosContatosViewModels(
            c.Id,
            c.Nome,
            c.Email,
            c.Telefone,
            c.Cargo,
            c.Empresa
        )).ToList();

        return View(listarVm);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarContatosContatosViewModels cadastrarVm = new CadastrarContatosContatosViewModels(
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }


    [HttpPost]
    public ActionResult Cadastrar(CadastrarContatosContatosViewModels cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarContatosContatosDto dto = new CadastrarContatosContatosDto(
            cadastrarVm.Nome,
            cadastrarVm.Email,
            cadastrarVm.Telefone,
            cadastrarVm.Cargo,
            cadastrarVm.Empresa
        );

        Result resultado = servicoContato.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors) // percorrendo o erro
            {
                string? campo = erro.Metadata["Campo"] is string ? erro.Metadata["Campo"].ToString()! : string.Empty; // se for string entao me de campo.String se nao retorne uma  string vaazia

                ModelState.AddModelError(campo, erro.Message); // apresenta a mensagem de erro caso exista
            }

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar()
    {


        return View();
    }

}