using AutoMapper;
using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Dominio;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Dominio;
using FluentResults;

namespace EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Aplicacao;

public class ServicoItemTarefa
{
    private readonly IRepositorioItemTarefa repositorioItemTarefa;
    private readonly IRepositorioTarefa repositorioTarefa;
    private readonly IMapper mapper;

    public ServicoItemTarefa(
        IRepositorioItemTarefa repositorioItemTarefa,
        IRepositorioTarefa repositorioTarefa,
        IMapper mapper)
    {
        this.repositorioItemTarefa = repositorioItemTarefa;
        this.repositorioTarefa = repositorioTarefa;
        this.mapper = mapper;
    }

    public Result Adicionar(CadastroItemTarefaDto dto)
    {
        ItemTarefa novoItem = new(dto.Titulo, dto.TarefaId);

        Result resultadoValidacao = ValidarEntidade(novoItem);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioItemTarefa.Adicionar(novoItem);

        AtualizarProgressoTarefa(dto.TarefaId);

        return Result.Ok();
    }

    public List<DetalhesItemTarefaDto> SelecionarPorTarefa(Guid tarefaId)
    {
        return repositorioItemTarefa
            .SelecionarPorTarefa(tarefaId)
            .Select(i => new DetalhesItemTarefaDto(
                i.Id,
                i.Titulo,
                i.Concluido,
                i.TarefaId))
            .ToList();
    }

    public Result<DetalhesItemTarefaDto> SelecionarPorId(Guid id)
    {
        ItemTarefa? item = repositorioItemTarefa.SelecionarPorId(id);

        if (item == null)
            return Result.Fail("Item não encontrado!");

        return Result.Ok(
            new DetalhesItemTarefaDto(
                item.Id,
                item.Titulo,
                item.Concluido,
                item.TarefaId));
    }

    public Result Concluir(ConcluirItemTarefaDto dto)
    {
        ItemTarefa? item = repositorioItemTarefa.SelecionarPorId(dto.Id);

        if (item == null)
            return Result.Fail("Item não encontrado!");

        repositorioItemTarefa.AtualizarStatus(item.Id, dto.Concluido);

        AtualizarProgressoTarefa(item.TarefaId);

        return Result.Ok();
    }

    public Result Remover(Guid id)
    {
        ItemTarefa? item = repositorioItemTarefa.SelecionarPorId(id);

        if (item == null)
            return Result.Fail("Item não encontrado!");

        repositorioItemTarefa.Remover(id);

        AtualizarProgressoTarefa(item.TarefaId);

        return Result.Ok();
    }

    private void AtualizarProgressoTarefa(Guid tarefaId)
    {
        Tarefa? tarefa = repositorioTarefa.SelecionarPorId(tarefaId);

        if (tarefa == null)
            return;

        List<ItemTarefa> itens = repositorioItemTarefa.SelecionarPorTarefa(tarefaId);

        if (itens.Count == 0)
        {
            tarefa.PercentualConcluido = 0;
            tarefa.Concluida = false;
            tarefa.DataConclusao = null;
        }
        else
        {
            int concluidos = itens.Count(i => i.Concluido);

            tarefa.PercentualConcluido =
                (int)Math.Round((double)concluidos * 100 / itens.Count);

            tarefa.Concluida = tarefa.PercentualConcluido == 100;

            tarefa.DataConclusao = tarefa.Concluida
                ? DateTime.Now
                : null;
        }

        repositorioTarefa.Editar(tarefa.Id, tarefa);
    }

    private static Result ValidarEntidade(ItemTarefa item)
    {
        List<string> erros = item.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(
            new Error(erros.First())
                .WithMetadata("Campo", string.Empty)
        );
    }
}