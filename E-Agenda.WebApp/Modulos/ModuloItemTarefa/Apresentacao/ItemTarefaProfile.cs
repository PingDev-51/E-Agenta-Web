using AutoMapper;
using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Aplicacao;
using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Dominio;

namespace EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Apresentacao;

public class ItemTarefaProfile : Profile
{
    public ItemTarefaProfile()
    {
       
        CreateMap<DetalhesItemTarefaDto, ListarItemTarefaViewModel>();

        CreateMap<CadastroItemTarefaViewModel, CadastroItemTarefaDto>();
        CreateMap<DetalhesItemTarefaDto, ExcluirItemTarefaViewModel>();
        CreateMap<ConcluirItemTarefaViewModel, ConcluirItemTarefaDto>();
        CreateMap<ItemTarefa, DetalhesItemTarefaDto>();
    }
}