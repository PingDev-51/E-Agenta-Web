using AutoMapper;
using eAgenda.WebApp.Modulos.ModuloContato.Aplicacao;

namespace eAgenda.WebApp.Modulos.ModuloContato.Apresentacao;

public class ContatoProfile : Profile
{
    public ContatoProfile()
    {
        CreateMap<ListarContatosDto, ListarContatosViewModel>();
        CreateMap<CadastrarContatoViewModel, CadastrarContatoDto>();
        CreateMap<EditarContatoViewModel, EditarContatoDto>();
        CreateMap<DetalhesContatoDto, EditarContatoViewModel>();
        CreateMap<DetalhesContatoDto, ExcluirContatoViewModel>();
    }
}