using System;
using AutoMapper;
using E_Agenda.WebApp.Modulos.ModuloContatos.Aplicacao;

namespace E_Agenda.WebApp.Modulos.ModuloContatos.Apresentacao;

public class ContatosProfile : Profile
{
    public ContatosProfile()
    {
        CreateMap<ListarContatosDto, ListarContatosViewModel>();
        CreateMap<CadastrarContatosViewModel, CadastrarContatosDto>();
        CreateMap<EditarContatosViewModel, EditarContatosDto>();

        CreateMap<DetalhesContatosDto, EditarContatosViewModel>();
        CreateMap<DetalhesContatosDto, ExcluirContatosViewModel>();
    }
}
