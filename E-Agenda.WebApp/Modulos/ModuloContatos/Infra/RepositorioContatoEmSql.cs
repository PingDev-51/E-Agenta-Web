using System;
using Dapper;
using E_Agenda.WebApp.Modulos.ModuloContatos.Dominio;
using E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;
using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;
using Microsoft.Data.SqlClient;


namespace E_Agenda.WebApp.Modulos.ModuloContatos.Infra;

public class RepositorioContatoEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioContatos // terminar as aulas e ver como fasso o repositorio SQL
{
    private const string InserirSql = """
        INSERT INTO dbo.TBContato
        (
            Id,
            Nome,
            Email,
            Telefone,
            Cargo,
            Empresa
        )
        VALUES
        (
            @Id,
            @Nome,
            @Email,
            @Telefone,
            @Cargo,
            @Empresa
        );
    """;

    protected const string atualizarSql = """
        UPDATE dbo.TBContato
        SET
            Nome = @Nome,
            Email = @Email,
            Telefone = @Telefone,
            Cargo = @Cargo,
            Empresa = @Empresa
        WHERE Id = @Id;
    """;

    private const string ExcluirSql = """
        DELETE FROM dbo.TBContato
        WHERE Id = @Id;
    """;

    private const string SelecionarPorIdSql = """
        SELECT Id, Nome, Email, Telefone, Cargo, Empresa
        FROM dbo.TBContato
        WHERE Id = @Id;
    """;

    private const string SelecionarTodosSql = """
        SELECT Id, Nome, Email, Telefone, Cargo, Empresa
        FROM dbo.TBContato
        ORDER BY [Nome];
    """;
    public void Cadastrar(Contatos entidade)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        conexao.Execute(InserirSql, entidade);
    }

    public bool Editar(Guid idSelecionado, Contatos entidadeAtualizada)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Execute(atualizarSql, entidadeAtualizada) == 1;
    }

    public bool Excluir(Guid idSelecionado)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        return conexao.Execute(ExcluirSql, new { Id = idSelecionado }) == 1;
    }

    public List<Contatos> Filtrar(Predicate<Contatos> filtro)
    {
        return SelecionarTodos().FindAll(filtro);
    }

    public Contatos? SelecionarPorId(Guid idSelecionado)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.QuerySingleOrDefault<Contatos>(SelecionarPorIdSql, new { Id = idSelecionado });
    }

    public List<Contatos> SelecionarTodos()
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Query<Contatos>(SelecionarTodosSql).ToList();
    }
}
