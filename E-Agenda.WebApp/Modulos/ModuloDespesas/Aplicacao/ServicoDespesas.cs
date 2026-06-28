using AutoMapper;
using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;
using FluentResults;

namespace EAgendaWeb.WebApp.Modulos.ModuloDespesas.Aplicacao;

public class ServicoDespesa
{
    private readonly IRepositorioDespesas repositorioDespesa;
    private readonly IMapper mapper;

    public ServicoDespesa(IRepositorioDespesas repositorioDespesa, IMapper mapper)
    {
        this.repositorioDespesa = repositorioDespesa;
        this.mapper = mapper;
    }

    public Result Cadastrar(CadastroDespesaDto dto)
    {
        Despesas novaDespesa = new(
            dto.Descricao,
            dto.Valor,
            dto.FormaPagamento
            // new List<Categoria>()
        );

        if (dto.DataOcorrencia.HasValue)
            novaDespesa.DataOcorrencia = dto.DataOcorrencia.Value;

        Result resultadoValidacao = ValidarEntidade(novaDespesa);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioDespesa.Cadastrar(novaDespesa);

        return Result.Ok();
    }

    public List<DetalhesDespesaDto> SelecionarTodos()
    {
        return repositorioDespesa
            .SelecionarTodos()
            .Select(d => new DetalhesDespesaDto(
                d.Id,
                d.Descricao,
                d.DataOcorrencia,
                d.Valor,
                d.FormaPagamento
            ))
            .ToList();
    }

    public Result<DetalhesDespesaDto> SelecionarPorId(Guid id)
    {
        Despesas? despesa = repositorioDespesa.SelecionarPorId(id);

        if (despesa == null)
            return Result.Fail("Despesa não encontrada!");

        return Result.Ok(new DetalhesDespesaDto(
            despesa.Id,
            despesa.Descricao,
            despesa.DataOcorrencia,
            despesa.Valor,
            despesa.FormaPagamento
        ));
    }

    public Result Editar(EditarDespesaDto dto)
    {
        Despesas despesaAtualizada = new(
            dto.Descricao,
            dto.Valor,
            dto.FormaPagamento
            // new List<Categoria>()
        )
        {
            DataOcorrencia = dto.DataOcorrencia
        };

        Result resultadoValidacao = ValidarEntidade(despesaAtualizada);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioDespesa.Editar(dto.Id, despesaAtualizada);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Result<DetalhesDespesaDto> resultado = SelecionarPorId(id);

        if (resultado.IsFailed)
            return Result.Fail("Despesa não encontrada!");

        repositorioDespesa.Excluir(id);

        return Result.Ok();
    }

    private static Result ValidarEntidade(Despesas despesa)
    {
        List<string> erros = despesa.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(
            new Error(erros.First())
                .WithMetadata("Campo", string.Empty)
        );
    }
}