// using System;
// using System.ComponentModel;
// using E_Agenda.WebApp.Modulos.ModuloCategoria.Dominio;
// using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;
// using FluentResults;

// namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Aplicacao;

// public class ServicoCategoria
// {
//     private readonly IRepositorioCategoria repositorioCategoria;
//     private readonly IRepositorioDespesas repositorioDespesas;

//     public ServicoCategoria(IRepositorioCategoria repositorioCategoria, IRepositorioDespesas repositorioDespesas)
//     {
//         this.repositorioCategoria = repositorioCategoria;
//         this.repositorioDespesas = repositorioDespesas;
//     }

//     public Result Cadastrar(CadastrarCategoriaDto dto)
//     {
//         Despesas? despesasSelecionada = repositorioDespesas.SelecionarPorId(dto.DespesasId);

//         if (despesasSelecionada == null)
//             return Falha("Não foi possivel encontrar uma despesa", "Despesas");

//         if (ExisteDuplicado(dto.Titulo))
//             return Falha("Titulo", "Já existe este titulo");

//         Categoria novaCategoria = new Categoria(
//             dto.Titulo,
//             despesasSelecionada!
//         );

//         repositorioCategoria.Cadastrar(novaCategoria);

//         return Result.Ok();
//     }

//     public Result Editar(EditarCategoriaDto dto)
//     {
//         Despesas? despesasSelecionada = repositorioDespesas.SelecionarPorId(dto.DespesasId);

//         if (despesasSelecionada == null)
//             return Falha("Despesa", "Não foi possivel encontrar uma Despesa");

//         if (ExisteDuplicado(dto.Titulo, dto.Id))
//             return Falha("Titulo", "Já existe este titulo");

//         Categoria CategoriaAtualizada = new Categoria(
//             dto.Titulo,
//             despesasSelecionada!
//         );

//         bool conseguiuEditar = repositorioCategoria.Editar(dto.Id, CategoriaAtualizada);

//         if (!conseguiuEditar)
//             return Falha("Despesa", "Não foi possivel encontrar uma Despesa");

//         return Result.Ok();
//     }

//     public Result Excluir(Guid id)
//     {
//         Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

//         if (categoria == null)
//             return Falha("Despesa", "Não foi possivel encontrar uma Despesa");

//         List<Despesas> despesas = repositorioDespesas.SelecionarTodos();

//         foreach (Despesas d in despesas)
//         {
//             if (string.Equals(d.Categorias!.Id, id))
//                 return Result.Fail("Esta Categoria não pode ser excluída pois está relacionada a uma Despesa.");
//         }

//         repositorioCategoria.Excluir(id);

//         return Result.Ok();
//     }

//     public Result<DetalhesCategoriaDto> SelecionarPorId(Guid id)
//     {
//         Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

//         if (categoria == null)
//             return Result.Fail("Compromissos não encontrado");

//         return Result.Ok(new DetalhesCategoriaDto(
//             categoria.Titulo,
//             categoria.Depesas!.Id,
//             SelecionarDespesas()
//         ));
//     }
//     public List<ListarCategoriaDto> SelecionarTodos()
//     {
//         List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

//         return categorias.Select(c => new ListarCategoriaDto(
//             c.Id,
//             c.Titulo,
//             c.Depesas!.Descricao
//         )).ToList();
//     }

//     public List<OpcaoDespesasDto> SelecionarDespesas()
//     {
//         List<Despesas> despesas = repositorioDespesas.SelecionarTodos();

//         return despesas.Select(d => new OpcaoDespesasDto(d.Id, d.Descricao)).ToList();
//     }

//     private static Result Falha(string campo, string mensagem)
//     {
//         IError erro = new Error(mensagem).WithMetadata("Campo", campo);

//         return Result.Fail(erro);
//     }

//     private bool ExisteDuplicado(string etiqueta, Guid? idIgnorado = null)
//     {
//         List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

//         foreach (Categoria c in categorias)
//         {
//             if (c.Id != idIgnorado && string.Equals(c.Titulo, etiqueta, StringComparison.OrdinalIgnoreCase))
//                 return true;
//         }

//         return false;
//     }
// }
