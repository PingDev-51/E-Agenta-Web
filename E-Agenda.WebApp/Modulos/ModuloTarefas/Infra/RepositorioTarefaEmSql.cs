using Dapper;
using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Dominio;
using Microsoft.Data.SqlClient;

namespace EAgendaWeb.WebApp.Modulos.ModuloTarefa.Infra;

public sealed class RepositorioTarefaEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioTarefa
{
    private const string InserirSql = """
        INSERT INTO dbo.TBTarefas
        (
            Id,
            Titulo,
            Prioridade,
            DataCriacao,
            DataConclusao,
            Concluida,
            PercentualConcluido
        )
        VALUES
        (
            @Id,
            @Titulo,
            @Prioridade,
            @DataCriacao,
            @DataConclusao,
            @Concluida,
            @PercentualConcluido
        );
    """;

    private const string AtualizarSql = """
        UPDATE dbo.TBTarefas
        SET
            Titulo = @Titulo,
            Prioridade = @Prioridade,
            DataConclusao = @DataConclusao,
            Concluida = @Concluida,
            PercentualConcluido = @PercentualConcluido
        WHERE Id = @Id;
    """;

    private const string ExcluirSql = """
        DELETE FROM dbo.TBTarefas
        WHERE Id = @Id;
    """;

    private const string SelecionarPorIdSql = """
        SELECT
            Id,
            Titulo,
            Prioridade,
            DataCriacao,
            DataConclusao,
            Concluida,
            PercentualConcluido
        FROM dbo.TBTarefas
        WHERE Id = @Id;
    """;

    private const string SelecionarTodosSql = """
        SELECT
            Id,
            Titulo,
            Prioridade,
            DataCriacao,
            DataConclusao,
            Concluida,
            PercentualConcluido
        FROM dbo.TBTarefas
        ORDER BY Prioridade DESC, DataCriacao;
    """;

    public void Cadastrar(Tarefa entidade)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        conexao.Execute(InserirSql, entidade);
    }

    public bool Editar(Guid idSelecionado, Tarefa entidadeAtualizada)
    {
        entidadeAtualizada.Id = idSelecionado;

        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Execute(AtualizarSql, entidadeAtualizada) == 1;
    }

    public bool Excluir(Guid idSelecionado)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Execute(ExcluirSql, new { Id = idSelecionado }) == 1;
    }

    public Tarefa? SelecionarPorId(Guid idSelecionado)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.QuerySingleOrDefault<Tarefa>(
            SelecionarPorIdSql,
            new { Id = idSelecionado });
    }

    public List<Tarefa> SelecionarTodos()
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Query<Tarefa>(SelecionarTodosSql).ToList();
    }

    public List<Tarefa> Filtrar(Predicate<Tarefa> filtro)
    {
        return SelecionarTodos().FindAll(filtro);
    }
}