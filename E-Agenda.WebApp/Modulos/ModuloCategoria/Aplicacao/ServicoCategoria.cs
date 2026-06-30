using System;
using E_Agenda.WebApp.Modulos.ModuloCategoria.Dominio;
using FluentResults;

namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Aplicacao;

public class ServicoCategoria
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public List<ListarCategoriaDto> SelecionarTodos()
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        return categorias.Select(c => new ListarCategoriaDto(
            c.Id,
            c.Titulo,
            c.Depesas!.Descricao
        )).ToList();
    }


}
