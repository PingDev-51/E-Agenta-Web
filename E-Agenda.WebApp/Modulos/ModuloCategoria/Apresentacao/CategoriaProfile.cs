using System;
using AutoMapper;
using E_Agenda.WebApp.Modulos.ModuloCategoria.Aplicacao;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Apresentacao;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<ListarCategoriaDto, ListarCategoriaViewModel>();
        CreateMap<CadastrarCategoriaViewModel, CadastrarCategoriaDto>();
        CreateMap<EditarCategoriaViewModel, EditarCategoriaDto>();
        CreateMap<ExcluirCategoriaViewModel, ExcluirCategoriaDto>();

        CreateMap<DetalhesCategoriaDto, EditarCategoriaViewModel>();
        CreateMap<DetalhesCategoriaDto, ExcluirCategoriaViewModel>();
    }
}
