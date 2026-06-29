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
        List<ListarContatosDto> dtos = servicoContato.SelecionarTodos();

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

        CadastrarContatosDto dto = new CadastrarContatosDto(
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
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesContatosDto> resultado = servicoContato.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData["ErrorMessage"] = resultado.Errors.First().Message;

            return RedirectToAction(nameof(Listar));
        }

        DetalhesContatosDto dto = resultado.Value;

        EditarContatosViwModel editarVm = new EditarContatosViwModel(
            id,
            dto.Nome,
            dto.Email,
            dto.Telefone,
            dto.Cargo,
            dto.Empresa
        );

        return View(editarVm);
    }


    [HttpPost]
    public ActionResult Editar(EditarContatosViwModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        Result resultado = servicoContato.Editar(new EditarContatosDto(
            editarVm.Id,
            editarVm.Nome,
            editarVm.Email,
            editarVm.Telefone,
            editarVm.Cargo,
            editarVm.Empresa
        ));

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors) // aqui vamos percorrer todos os erros
            {
                string? campo = erro.Metadata["Campo"] is string ? erro.Metadata["Campo"].ToString()! : string.Empty; // se esse valor for uma string retornamos como uma formatado como string se nao retorna uma string vazia

                ModelState.AddModelError(campo, erro.Message); // aqui estamos mostrando a mensagem de erro e o campo que deu erro
            }

            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesContatosDto> resultado = servicoContato.SelecionarPorId(id);

        DetalhesContatosDto dto = resultado.Value;

        ExcluirContatosViwModel excluirVm = new ExcluirContatosViwModel(
            id,
            dto.Nome,
            dto.Email,
            dto.Telefone,
            dto.Cargo,
            dto.Empresa
        );

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirContatosViwModel excluirVm)
    {
        Result resultado = servicoContato.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
        {
            TempData["ErrorMessage"] = resultado.Errors.First().Message;
        }

        return RedirectToAction(nameof(Listar));
    }
}