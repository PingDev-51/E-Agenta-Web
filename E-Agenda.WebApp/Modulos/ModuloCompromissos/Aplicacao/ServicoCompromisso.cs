using System;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Apresentacao;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Dominio;
using E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;
using FluentResults;

namespace E_Agenda.WebApp.Modulos.ModuloCompromissos.Aplicacao;

public class ServicoCompromisso
{
    private readonly IRepositorioCompromissos repositorioCompromissos;
    private readonly IRepositorioContatos repositorioContatos;

    public ServicoCompromisso(IRepositorioCompromissos repositorioCompromissos, IRepositorioContatos repositorioContatos)
    {
        this.repositorioCompromissos = repositorioCompromissos;
        this.repositorioContatos = repositorioContatos;
    }

    public Result Cadastrar(CadastrarCompromissosDto dto)
    {
        Contatos? contatoSelecionado = repositorioContatos.SelecionarPorId(dto.contatoId);

        if (contatoSelecionado == null)
            return Falha("Não foi possivel encontrar um contato", "contato");

        Compromissos novoCompromisso = new Compromissos(
            dto.Assunto,
            dto.HoraDeInicio,
            dto.HoraDeTermino,
            dto.TipoDeCompromisso,
            dto.Local,
            dto.Link,
            contatoSelecionado!
        );

        repositorioCompromissos.Cadastrar(novoCompromisso);

        return Result.Ok();
    }

    public Result Editar()
    {
        throw new NotImplementedException();
    }

    public Result Excluir()
    {
        throw new NotImplementedException();
    }

    public Result SelecionarPorId()
    {
        throw new NotImplementedException();
    }

    public List<ListarCompromissosDto> SelecionarTodos()
    {
        List<Compromissos> compromissos = repositorioCompromissos.SelecionarTodos();

        return compromissos.Select(c => new ListarCompromissosDto(
            c.Id,
            c.Assunto,
            c.DataOcorrencia,
            c.HoraDeInicio,
            c.HoraDeTermino,
            c.TipoDeCompromisso,
            c.Local,
            c.Link,
            c.Contato!.Nome
        )).ToList();
    }

    private static Result Falha(string campo, string mensagem)
    {
        IError erro = new Error(mensagem).WithMetadata("Campo", campo);

        return Result.Fail(erro);
    }

    public List<OpcaoContatoDto> SelecionarContatos()
    {
        List<Contatos> contatos = repositorioContatos.SelecionarTodos();

        return contatos
            .Select(contatos => new OpcaoContatoDto(contatos.Id, contatos.Nome))
            .ToList();
    }
}
