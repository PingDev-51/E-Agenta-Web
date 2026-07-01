using System;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Dominio;
using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;
using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;

namespace E_Agenda.WebApp.Modulos.ModuloCompromissos.Infra;

public class RepositorioCompromissoEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioCompromissos
{
    public void Cadastrar(Compromissos entidade)
    {
        throw new NotImplementedException();
    }

    public bool Editar(Guid idSelecionado, Compromissos entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Compromissos> Filtrar(Predicate<Compromissos> filtro)
    {
        throw new NotImplementedException();
    }

    public Compromissos? SelecionarPorId(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Compromissos> SelecionarTodos()
    {
        throw new NotImplementedException();
    }
}
