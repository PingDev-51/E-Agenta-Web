using System;
using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;
using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;

namespace E_Agenda.WebApp.Modulos.ModuloCompromissos.Infra;

public class RepositorioCompromissoEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioDespesas
{
    public void Cadastrar(Despesas entidade)
    {
        throw new NotImplementedException();
    }

    public bool Editar(Guid idSelecionado, Despesas entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Despesas> Filtrar(Predicate<Despesas> filtro)
    {
        throw new NotImplementedException();
    }

    public Despesas? SelecionarPorId(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Despesas> SelecionarTodos()
    {
        throw new NotImplementedException();
    }
}
