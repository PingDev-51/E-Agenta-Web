using E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;
using FluentResults;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Dominio;
using E_Agenda.WebApp.Modulos.ModuloContatos.Dominio;

namespace E_Agenda.WebApp.Modulos.ModuloContatos.Aplicacao;

public class ServicoContato
{
    private readonly IRepositorioContatos repositorioContato;
    private readonly IRepositorioCompromissos repositorioCompromisso;

    public ServicoContato(IRepositorioContatos repositorioContato, IRepositorioCompromissos repositorioCompromisso)
    {
        this.repositorioContato = repositorioContato;
        this.repositorioCompromisso = repositorioCompromisso;
    }

    public Result Cadastrar(CadastrarContatosDto dto)
    {
        if (ExisteDuplicacao(dto.Email, dto.Telefone))
            return Falha("Informação duplicada", "Já existe um contato com este telefone ou email");

        Contatos novoContato = new Contatos(
            dto.Nome,
            dto.Email,
            dto.Telefone,
            dto.Cargo!,
            dto.Empresa!
        );

        repositorioContato.Cadastrar(novoContato);

        return Result.Ok();
    }
    public Result Editar(EditarContatosDto dto)
    {
        if (ExisteDuplicacao(dto.Email, dto.Telefone, dto.Id))
            return Falha("Informação duplicada", "Já existe um contato com este telefone ou email");

        Contatos ContatoAtualizado = new Contatos(
            dto.Nome,
            dto.Email,
            dto.Telefone,
            dto.Cargo!,
            dto.Empresa!
        );

        bool conseguiuEditar = repositorioContato.Editar(dto.Id, ContatoAtualizado);

        if (!conseguiuEditar)
            return Result.Fail("Contato nao encontrado");

        return Result.Ok();
    }
    public Result Excluir(Guid id)
    {
        Contatos? contato = repositorioContato.SelecionarPorId(id);

        if (contato == null)
            return Result.Fail("Contato não encontrado");

        List<Compromissos> compromissos = repositorioCompromisso.SelecionarTodos();

        foreach (Compromissos c in compromissos)
        {
            if (string.Equals(c.Contato!.Id, id))
                return Result.Fail("Este contato não pode ser excluido pois está relacionado a um compromisso");
        }

        repositorioContato.Excluir(contato.Id);

        return Result.Ok();
    }
    public List<ListarContatosDto> SelecionarTodos()
    {
        List<Contatos> contatos = repositorioContato.SelecionarTodos();

        return contatos.Select(c => new ListarContatosDto(
            c.Id,
            c.Nome,
            c.Email,
            c.Telefone,
            c.Cargo,
            c.Empresa
        )).ToList();
    }
    public Result<DetalhesContatosDto> SelecionarPorId(Guid id)
    {
        Contatos? contato = repositorioContato.SelecionarPorId(id);

        if (contato == null)
            return Result.Fail("Contato não encontrado");

        return Result.Ok(new DetalhesContatosDto(
            contato.Nome,
            contato.Email,
            contato.Telefone,
            contato.Cargo,
            contato.Empresa
        ));
    }

    private bool ExisteDuplicacao(string email, string telefone, Guid? idIgnorado = null)
    {
        List<Contatos> contatos = repositorioContato.SelecionarTodos();

        foreach (Contatos c in contatos)
        {
            if (c.Id != idIgnorado && string.Equals(c.Email, email, StringComparison.OrdinalIgnoreCase))
                return true;

            if (c.Id != idIgnorado && string.Equals(c.Telefone, telefone))
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
