using System;
using AutoMapper;
using E_Agenda.WebApp.Modulos.ModuloCompromissos.Aplicacao;

namespace E_Agenda.WebApp.Modulos.ModuloCompromissos.Apresentacao;

public class CompromissoProfile : Profile
{
    public CompromissoProfile()
    {
        CreateMap<ListarCompromissosDto, ListarCompromissosViewModels>();
        CreateMap<CadastrarCompromissosViewModels, CadastrarCompromissosDto>();
    }
}
