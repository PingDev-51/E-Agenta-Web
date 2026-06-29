using System;
using E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;
using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;

namespace E_Agenda.WebApp.Modulos.ModuloContatos.Infra;

public class RepositorioContatoEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioContatos // terminar as aulas e ver como fasso o repositorio SQL
{
    public void Cadastrar(Contatos entidade)
    {
        throw new NotImplementedException();
    }

    public bool Editar(Guid idSelecionado, Contatos entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Contatos> Filtrar(Predicate<Contatos> filtro)
    {
        throw new NotImplementedException();
    }

    public Contatos? SelecionarPorId(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Contatos> SelecionarTodos()
    {
        throw new NotImplementedException();
    }
}
