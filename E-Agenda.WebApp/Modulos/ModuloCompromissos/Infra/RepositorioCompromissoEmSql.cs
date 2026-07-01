using System;
using Dapper;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Dominio;
using E_Agenda.WebApp.Modulos.ModuloContatos.Dominio;
using E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;
using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;
using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;
using Microsoft.Data.SqlClient;

namespace E_Agenda.WebApp.Modulos.ModuloCompromissos.Infra;

public class RepositorioCompromissoEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioCompromissos
{
    protected const string inserirSql = """
        INSERT INTO dbo.TBCompromisso
            (Id, Assunto, DataOcorrencia, HoraDeInicio, HoraDeTermino, TipoDeCompromisso, Local, Link, ContatoId)
        VALUES
            (@Id, @Assunto, @DataOcorrencia, @HoraDeInicio, @HoraDeTermino, @TipoDeCompromisso, @Local, @Link, @ContatoId);
    """;

    protected const string atualizarSql = """
        UPDATE dbo.TBCompromisso
        SET
            Assunto = @Assunto,
            DataOcorrencia = @DataOcorrencia,
            HoraDeInicio = @HoraDeInicio,
            HoraDeTermino = @HoraDeTermino,
            TipoDeCompromisso = @TipoDeCompromisso,
            Local = @Local,
            Link = @Link,
            ContatoId = @ContatoId
        WHERE Id = @Id;
    """;

    protected const string excluirSql = """
        DELETE FROM dbo.TBCompromisso
        WHERE Id = @Id;
    """;

    protected const string selecionarPorIdSql = """
        SELECT
            cp.Id AS CompromissoId,
            cp.Assunto,
            cp.DataOcorrencia,
            cp.HoraDeInicio,
            cp.HoraDeTermino,
            cp.TipoDeCompromisso,
            cp.Local,
            cp.Link,
            ct.Id AS ContatoId,
            ct.Nome AS ContatoNome,
            ct.Email AS ContatoEmail,
            ct.Telefone AS ContatoTelefone,
            ct.Cargo AS ContatoCargo,
            ct.Empresa AS ContatoEmpresa
        FROM dbo.TBCompromisso AS cp
        LEFT JOIN dbo.TBContato AS ct
            ON ct.Id = cp.ContatoId
        WHERE cp.Id = @Id;
    """;

    protected const string selecionarTodosSql = """
        SELECT
            cp.Id AS CompromissoId,
            cp.Assunto,
            cp.DataOcorrencia,
            cp.HoraDeInicio,
            cp.HoraDeTermino,
            cp.TipoDeCompromisso,
            cp.Local,
            cp.Link,
            ct.Id AS ContatoId,
            ct.Nome AS ContatoNome,
            ct.Email AS ContatoEmail,
            ct.Telefone AS ContatoTelefone,
            ct.Cargo AS ContatoCargo,
            ct.Empresa AS ContatoEmpresa
        FROM dbo.TBCompromisso AS cp
        LEFT JOIN dbo.TBContato AS ct
            ON ct.Id = cp.ContatoId
        ORDER BY cp.DataOcorrencia, cp.HoraInicio;
    """;

    public void Cadastrar(Compromissos entidade)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        conexao.Execute(inserirSql, entidade);
    }

    public bool Editar(Guid idSelecionado, Compromissos entidadeAtualizada)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Execute(atualizarSql, entidadeAtualizada) == 1;
    }

    public bool Excluir(Guid idSelecionado)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        return conexao.Execute(excluirSql, new { Id = idSelecionado }) == 1;
    }

    public List<Compromissos> Filtrar(Predicate<Compromissos> filtro)
    {
        return SelecionarTodos().FindAll(filtro);
    }

    public Compromissos? SelecionarPorId(Guid idSelecionado)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        CompromissoRow? compromissoRow = conexao.QuerySingleOrDefault<CompromissoRow>(
            selecionarPorIdSql,
            new { Id = idSelecionado }
        );

        if (compromissoRow == null)
            return null;

        return MapearCompromisso(compromissoRow);
    }

    public List<Compromissos> SelecionarTodos()
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open(); ;

        return conexao
            .Query<CompromissoRow>(selecionarTodosSql)
            .Select(MapearCompromisso)
            .ToList();
    }

    private static Compromissos MapearCompromisso(CompromissoRow row)
    {
        return new Compromissos
        {
            Id = row.CompromissoId,
            Assunto = row.Assunto,
            DataOcorrencia = row.DataOcorrencia.Date,
            HoraDeInicio = row.HoraDeInicio,
            HoraDeTermino = row.HoraDeTermino,
            TipoDeCompromisso = row.TipoDeCompromisso,
            Local = row.Local,
            Link = row.Link,
            Contato = row.ContatoId.HasValue
                ? new Contatos
                {
                    Id = row.ContatoId.Value,
                    Nome = row.ContatoNome ?? string.Empty,
                    Email = row.ContatoEmail ?? string.Empty,
                    Telefone = row.ContatoTelefone ?? string.Empty,
                    Cargo = row.ContatoCargo,
                    Empresa = row.ContatoEmpresa
                }
                : null
        };
    }

    protected object CriarParametros(Compromissos compromisso)
    {
        return new
        {
            compromisso.Id,
            compromisso.Assunto,
            DataOcorrencia = compromisso.DataOcorrencia.Date,
            compromisso.HoraDeInicio,
            compromisso.HoraDeTermino,
            Tipo = (int)compromisso.TipoDeCompromisso,
            compromisso.Local,
            compromisso.Link,
            ContatoId = compromisso.Contato?.Id
        };
    }


}

public sealed class CompromissoRow
{
    public Guid CompromissoId { get; set; }
    public string Assunto { get; set; } = string.Empty;
    public DateTime DataOcorrencia { get; set; }
    public DateTime HoraDeInicio { get; set; }
    public DateTime HoraDeTermino { get; set; }
    public TipoCompromisso TipoDeCompromisso { get; set; }
    public string? Local { get; set; }
    public string? Link { get; set; }
    public Guid? ContatoId { get; set; }
    public string? ContatoNome { get; set; }
    public string? ContatoEmail { get; set; }
    public string? ContatoTelefone { get; set; }
    public string? ContatoCargo { get; set; }
    public string? ContatoEmpresa { get; set; }
}

