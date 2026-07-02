using eAgenda.WebApp.Modulos.ModuloDespesa.Dominio;

namespace eAgenda.WebApp.Modulos.ModuloDespesa.Aplicacao;

public record ListarDespesasDto(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamento FormaPagamento,
    List<CategoriaDespesaDto> Categorias
);

public record CadastrarDespesaDto(
    string Descricao,
    DateTime? DataOcorrencia,
    decimal Valor,
    FormaPagamento FormaPagamento,
    List<Guid> CategoriaIds
);

public record EditarDespesaDto(
    Guid Id,
    string Descricao,
    DateTime? DataOcorrencia,
    decimal Valor,
    FormaPagamento FormaPagamento,
    List<Guid> CategoriaIds
);

public record DetalhesDespesaDto(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamento FormaPagamento,
    List<CategoriaDespesaDto> Categorias
);

public record CategoriaDespesaDto(Guid Id, string Titulo);