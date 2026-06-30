using System;

namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Aplicacao;

public record ListarCategoriaDto(
    Guid Id,
    string Titulo,
    string Despesas
);

public record CadastrarCategoriaDto(
    string Titulo,
    Guid DespesasId,
    OpcaoDespesasDto Despesas
);

public record EditarCategoriaDto(
    Guid Id,
    string Titulo,
    Guid DespesasId,
    OpcaoDespesasDto Despesas
);

public record ExcluirCategoriaDto(
    Guid Id,
    string Titulo,
    Guid DespesasId,
    OpcaoDespesasDto Despesas
);
public record DetalhesCategoriaDto(
    string Titulo,
    Guid DespesasId,
    List<OpcaoDespesasDto> Despesas
);

public record OpcaoDespesasDto(
    Guid Id,
    string Descricao
);