using System;
using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;
using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Dominio;
using Microsoft.Data.SqlClient;
using Dapper;
using E_Agenda.WebApp.Modulos.ModuloCategoria.Dominio;

namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Infra;

public class RepositorioCategoriaEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioCategoria
{
    public void Cadastrar(Categoria entidade)
    {
        throw new NotImplementedException();
    }

    public bool Editar(Guid idSelecionado, Categoria entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Categoria> Filtrar(Predicate<Categoria> filtro)
    {
        throw new NotImplementedException();
    }

    public Categoria? SelecionarPorId(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Categoria> SelecionarTodos()
    {
        throw new NotImplementedException();
    }
}
