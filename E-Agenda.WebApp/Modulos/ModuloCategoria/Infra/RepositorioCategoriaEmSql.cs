// using System;
// using EAgendaWeb.WebApp.Compartilhado.Infra.Sql;
// using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Dominio;
// using Microsoft.Data.SqlClient;
// using Dapper;
// using E_Agenda.WebApp.Modulos.ModuloCategoria.Dominio;
// using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;

// namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Infra;

// public class RepositorioCategoriaEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioCategoria
// {

//     protected const string inserirSql = """
//         INSERT INTO dbo.TBCAtegoria
//             (Id, Titulo, DepesasId)
//         VALUES
//             (@Id, @Titulo, @DepesasId);
//     """;

//     protected const string atualizarSql = """
//         UPDATE dbo.TBCategoria
//         SET
//             Titulo = @Titulo,
//             DepesasId = @DepesasId,
//         WHERE Id = @Id;
//     """;

//     protected const string excluirSql = """
//         DELETE FROM dbo.TBCategoria
//         WHERE Id = @Id;
//     """;

//     protected const string selecionarPorIdSql = """
//         SELECT
//             c.Id AS CategoriaId,
//             c.Titulo,
//             d.DepesasId,
//             d.Descricao,
//             d.DataOcorrencia,
//             d.Valor,
//             d.FormaPagamento,
//             d.CategoriasId,
//         FROM dbo.TBCategoria AS c
//         LEFT JOIN dbo.TBDespesas AS d
//             ON d.Id = cp.DepesasId
//         WHERE c.Id = @Id;
//     """;

//     protected const string selecionarTodosSql = """
//         SELECT
//             c.Id AS CategoriaId,
//             c.Titulo,
//             d.DepesasId,
//             d.Descricao,
//             d.DataOcorrencia,
//             d.Valor,
//             d.FormaPagamento,
//             d.CategoriasId,
//         FROM dbo.TBCategoria AS c
//         LEFT JOIN dbo.TBDespesas AS d
//             ON d.Id = cp.DepesasId
//         ORDER BY cp.DataOcorrencia, cp.HoraInicio;
//     """;


//     public void Cadastrar(Categoria entidade)
//     {
//         throw new NotImplementedException();
//     }

//     public bool Editar(Guid idSelecionado, Categoria entidadeAtualizada)
//     {
//         throw new NotImplementedException();
//     }

//     public bool Excluir(Guid idSelecionado)
//     {
//         throw new NotImplementedException();
//     }

//     public List<Categoria> Filtrar(Predicate<Categoria> filtro)
//     {
//         throw new NotImplementedException();
//     }

//     public Categoria? SelecionarPorId(Guid idSelecionado)
//     {
//         throw new NotImplementedException();
//     }

//     public List<Categoria> SelecionarTodos()
//     {
//         throw new NotImplementedException();
//     }


//     private static Categoria MapearCompromisso(CategoriaRow row)
//     {
//         return new Categoria
//         {
//             Id = row.CategoriaId,
//             Titulo = row.Titulo,
//             Depesas = row.DespesasId.HasValue ? new Despesas
//             {
//                 Id = row.DespesasId.Value,
//                 Descricao = row.DespesasDescricao ?? string.Empty,
//                 Valor = row.DespesasValor,
//                 FormaPagamento = row.DespesasFormaPagamento
//             } : null
//         };
//     }

//     protected object CriarParametros(Categoria categoria)
//     {
//         return new
//         {
//             categoria.Id,
//             categoria.Titulo,
//             ContatoId = categoria.Depesas?.Id
//         };
//     }


// }

// public sealed class CategoriaRow
// {
//     public Guid CategoriaId { get; set; }
//     public string Titulo { get; set; } = string.Empty;
//     public Guid? DespesasId { get; set; }
//     public string? DespesasDescricao { get; set; }
//     public decimal DespesasValor { get; set; }
//     public FormaPagamento DespesasFormaPagamento { get; set; }
// }

