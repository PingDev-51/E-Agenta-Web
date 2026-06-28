using Dapper;
using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;
using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Dominio;
using Microsoft.Data.SqlClient;

namespace EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Infra;

public sealed class RepositorioItemTarefaEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioItemTarefa
{
    private const string InserirSql = """
        INSERT INTO dbo.TBItensTarefa
        (
            Id,
            Titulo,
            Concluido,
            TarefaId
        )
        VALUES
        (
            @Id,
            @Titulo,
            @Concluido,
            @TarefaId
        );
    """;

    private const string AtualizarStatusSql = """
        UPDATE dbo.TBItensTarefa
        SET
            Concluido = @Concluido
        WHERE Id = @Id;
    """;

    private const string ExcluirSql = """
        DELETE FROM dbo.TBItensTarefa
        WHERE Id = @Id;
    """;

    private const string SelecionarPorIdSql = """
        SELECT
            Id,
            Titulo,
            Concluido,
            TarefaId
        FROM dbo.TBItensTarefa
        WHERE Id = @Id;
    """;

    private const string SelecionarPorTarefaSql = """
        SELECT
            Id,
            Titulo,
            Concluido,
            TarefaId
        FROM dbo.TBItensTarefa
        WHERE TarefaId = @TarefaId
        ORDER BY Concluido, Titulo;
    """;

    public void Adicionar(ItemTarefa item)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        conexao.Execute(InserirSql, item);
    }

    public bool AtualizarStatus(Guid id, bool concluido)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Execute(
            AtualizarStatusSql,
            new
            {
                Id = id,
                Concluido = concluido
            }) == 1;
    }

    public bool Remover(Guid id)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Execute(
            ExcluirSql,
            new { Id = id }) == 1;
    }

    public ItemTarefa? SelecionarPorId(Guid id)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.QuerySingleOrDefault<ItemTarefa>(
            SelecionarPorIdSql,
            new { Id = id });
    }

    public List<ItemTarefa> SelecionarPorTarefa(Guid tarefaId)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Query<ItemTarefa>(
            SelecionarPorTarefaSql,
            new { TarefaId = tarefaId })
            .ToList();
    }
}