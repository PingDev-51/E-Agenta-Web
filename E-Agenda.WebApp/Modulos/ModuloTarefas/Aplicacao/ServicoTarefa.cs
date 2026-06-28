using AutoMapper;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Dominio;
using FluentResults;

namespace EAgendaWeb.WebApp.Modulos.ModuloTarefas.Aplicacao;

public class ServicoTarefa
{
    private readonly IRepositorioTarefa repositorioTarefa;
    private readonly IMapper mapper;

    public ServicoTarefa(IRepositorioTarefa repositorioTarefa, IMapper mapper)
    {
        this.repositorioTarefa = repositorioTarefa;
        this.mapper = mapper;
    }

    public Result Cadastrar(CadastroTarefaDto dto)
    {
        Tarefa novaTarefa = new(dto.Titulo, dto.Prioridade);

        Result resultadoValidacao = ValidarEntidade(novaTarefa);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioTarefa.Cadastrar(novaTarefa);

        return Result.Ok();
    }

    public List<DetalhesTarefaDto> SelecionarTodos()
    {
        return repositorioTarefa
            .SelecionarTodos()
            .Select(t => new DetalhesTarefaDto(
                t.Id,
                t.Titulo,
                t.Prioridade,
                t.DataCriacao,
                t.DataConclusao,
                t.Concluida,
                t.PercentualConcluido))
            .ToList();
    }

    public Result<DetalhesTarefaDto> SelecionarPorId(Guid id)
    {
        Tarefa? tarefa = repositorioTarefa.SelecionarPorId(id);

        if (tarefa == null)
            return Result.Fail("Tarefa não encontrada!");

        return Result.Ok(new DetalhesTarefaDto(
            tarefa.Id,
            tarefa.Titulo,
            tarefa.Prioridade,
            tarefa.DataCriacao,
            tarefa.DataConclusao,
            tarefa.Concluida,
            tarefa.PercentualConcluido));
    }

    public Result Editar(EditarTarefaDto dto)
    {
        Tarefa tarefaAtualizada = new(dto.Titulo, dto.Prioridade)
        {
            DataConclusao = dto.DataConclusao,
            Concluida = dto.Concluida,
            PercentualConcluido = dto.PercentualConcluido
        };

        Result resultadoValidacao = ValidarEntidade(tarefaAtualizada);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioTarefa.Editar(dto.Id, tarefaAtualizada);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Result<DetalhesTarefaDto> resultado = SelecionarPorId(id);

        if (resultado.IsFailed)
            return Result.Fail("Tarefa não encontrada!");

        repositorioTarefa.Excluir(id);

        return Result.Ok();
    }

    private static Result ValidarEntidade(Tarefa tarefa)
    {
        List<string> erros = tarefa.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(
            new Error(erros.First())
                .WithMetadata("Campo", string.Empty)
        );
    }
}