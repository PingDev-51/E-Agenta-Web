using Dapper;
using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;
using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;
using Microsoft.Data.SqlClient;

namespace EAgendaWeb.WebApp.Modulos.ModuloDespesas.Infra;

public sealed class RepositorioDespesaEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioDespesas
{
    private const string InserirSql = """
        INSERT INTO dbo.TBDespesas
        (
            Id,
            Descricao,
            DataOcorrencia,
            Valor,
            FormaPagamento
        )
        VALUES
        (
            @Id,
            @Descricao,
            @DataOcorrencia,
            @Valor,
            @FormaPagamento
        );
    """;

    private const string AtualizarSql = """
        UPDATE dbo.TBDespesas
        SET
            Descricao = @Descricao,
            DataOcorrencia = @DataOcorrencia,
            Valor = @Valor,
            FormaPagamento = @FormaPagamento
        WHERE Id = @Id;
    """;

    private const string ExcluirSql = """
        DELETE FROM dbo.TBDespesas
        WHERE Id = @Id;
    """;

    private const string SelecionarPorIdSql = """
        SELECT
            Id,
            Descricao,
            DataOcorrencia,
            Valor,
            FormaPagamento
        FROM dbo.TBDespesas
        WHERE Id = @Id;
    """;

    private const string SelecionarTodosSql = """
        SELECT
            Id,
            Descricao,
            DataOcorrencia,
            Valor,
            FormaPagamento
        FROM dbo.TBDespesas
        ORDER BY DataOcorrencia DESC;
    """;

    public void Cadastrar(Despesas entidade)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        conexao.Execute(InserirSql, entidade);
    }

    public bool Editar(Guid idSelecionado, Despesas entidadeAtualizada)
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

    public Despesas? SelecionarPorId(Guid idSelecionado)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.QuerySingleOrDefault<Despesas>(
            SelecionarPorIdSql,
            new { Id = idSelecionado });
    }

    public List<Despesas> SelecionarTodos()
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Query<Despesas>(SelecionarTodosSql).ToList();
    }

    public List<Despesas> Filtrar(Predicate<Despesas> filtro)
    {
        return SelecionarTodos().FindAll(filtro);
    }
}