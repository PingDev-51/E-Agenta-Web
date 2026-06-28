using AutoMapper;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Aplicacao;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Dominio;

namespace EAgendaWeb.WebApp.Modulos.ModuloTarefas.Apresentacao;

public class TarefaProfile : Profile
{
    public TarefaProfile()
    {
        CreateMap<DetalhesTarefaDto, ListarTarefaViewModel>();
        
        CreateMap<CadastroTarefaViewModel, CadastroTarefaDto>();
        CreateMap<Tarefa, DetalhesTarefaDto>();
        CreateMap<DetalhesTarefaDto, ExcluirTarefaViewModel>();
        CreateMap<DetalhesTarefaDto, EditarTarefaViewModel>();
        CreateMap<EditarTarefaViewModel, EditarTarefaDto>();
    }
}