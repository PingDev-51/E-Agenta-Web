using System;
using E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using FluentResults;

namespace E_Agenda.WebApp.Modulos.ModuloContatos.Aplicacao;

public class ServicoContato
{
    private readonly IRepositorioContatos repositorioContato;

    public ServicoContato(IRepositorioContatos repositorioContato)
    {
        this.repositorioContato = repositorioContato;
    }

    public Result Cadastrar(CadastrarContatosContatosDto dto)
    {
        if (ExisteDuplicacao(dto.Email, dto.Telefone))
            return Falha("Informação duplicada", "Já existe um contato com este telefone ou email");

        Contatos novoContato = new Contatos(
            dto.Nome,
            dto.Email,
            dto.Telefone,
            dto.Cargo,
            dto.Empresa
        );

        repositorioContato.Cadastrar(novoContato);

        return Result.Ok();
    }
    public Result Editar()
    {

    }
    public Result Excluir()
    {

    }
    public List<ListarContatosContatosDto> SelecionarTodos()
    {
        List<Contatos> contatos = repositorioContato.SelecionarTodos();

        return contatos.Select(c => new ListarContatosContatosDto(
            c.Id,
            c.Nome,
            c.Email,
            c.Telefone,
            c.Cargo,
            c.Empresa
        )).ToList();
    }
    public Result SelecionarPorId()
    {

    }

    private bool ExisteDuplicacao(string email, string telefone, string? idIgnirado = null)
    {
        List<Contatos> contatos = repositorioContato.SelecionarTodos();

        foreach (Contatos c in contatos)
        {
            if (string.Equals(c.Email, email, StringComparison.OrdinalIgnoreCase))
                return true;

            if (string.Equals(c.Telefone, telefone))
                return true;
        }

        return false;
    }

    private static Result Falha(string campo, string mensagem)
    {
        IError erro = new Error(mensagem).WithMetadata("Campo", campo);

        return Result.Fail(erro);
    }
}
