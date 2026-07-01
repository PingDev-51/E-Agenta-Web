using System;
using Dapper;
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

    private const string AtualizarStatusSql = """
        UPDATE dbo.TBItensTarefa
        SET
            Id, = @Id,
            Nome, = @Nome,
            Email, = @Email,
            Telefone, = @Telefone,
            Cargo, =  @Cargo,
            Empresa = @Empresa

        WHERE Id = @Id;
    """;

    private const string ExcluirSql = """
        DELETE FROM dbo.TBItensTarefa
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
        WHERE Id = @Id
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
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Query<Contatos>(SelecionarTodosSql).ToList();
    }
}
