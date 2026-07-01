using AutoMapper;
using eAgenda.WebApp.Modulos.ModuloTarefa.Aplicacao;

namespace eAgenda.WebApp.Modulos.ModuloTarefa.Apresentacao;

public class TarefaProfile : Profile
{
    public TarefaProfile()
    {
        CreateMap<ItemTarefaDto, ItemTarefaViewModel>();
        CreateMap<ListarTarefasDto, ListarTarefasViewModel>();
        CreateMap<CadastrarTarefaViewModel, CadastrarTarefaDto>();
        CreateMap<EditarTarefaViewModel, EditarTarefaDto>();
        CreateMap<AdicionarItemTarefaViewModel, AdicionarItemTarefaDto>();
        CreateMap<DetalhesTarefaDto, EditarTarefaViewModel>();
        CreateMap<DetalhesTarefaDto, ExcluirTarefaViewModel>();

        CreateMap<DetalhesTarefaDto, GerenciarItensTarefaViewModel>()
            .ForCtorParam("NovoItemTitulo", opt => opt.MapFrom(_ => string.Empty));
    }
}