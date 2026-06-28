using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;

public record DetalhesDespesaDto(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamento FormaPagamento
    // List<Guid> CategoriasIds
);

public record CadastroDespesaDto(
    string Descricao,
    DateTime? DataOcorrencia,
    decimal Valor,
    FormaPagamento FormaPagamento
    // List<Guid> CategoriasIds
);

public record EditarDespesaDto(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamento FormaPagamento
    // List<Guid> CategoriasIds
);