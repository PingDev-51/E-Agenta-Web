using System.ComponentModel.DataAnnotations;
using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EAgendaWeb.WebApp.Modulos.ModuloDespesas.Apresentacao;

public record ListarDespesaViewModel(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamento FormaPagamento
    // List<string> Categorias
);

public record CadastroDespesaViewModel(
    [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório!")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "O campo \"Descrição\" deve conter entre 2 e 100 caracteres.")]
    string Descricao,

    DateTime? DataOcorrencia,

    [Required(ErrorMessage = "O campo \"Valor\" é obrigatório!")]
    [Range(typeof(decimal), "0.01", "9999999999",
        ErrorMessage = "O valor deve ser maior que zero.")]
    decimal Valor,

    [Required(ErrorMessage = "O campo \"Forma de Pagamento\" é obrigatório!")]
    FormaPagamento FormaPagamento

    // [Required(ErrorMessage = "Selecione pelo menos uma categoria.")]
    // List<Guid> CategoriasIds
)
{
    // public List<SelectListItem> CategoriasDisponiveis { get; set; } = [];
}

public record ExcluirDespesaViewModel(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamento FormaPagamento
    // List<string> Categorias
);

public record EditarDespesaViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório!")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "O campo \"Descrição\" deve conter entre 2 e 100 caracteres.")]
    string Descricao,

    DateTime DataOcorrencia,

    [Required(ErrorMessage = "O campo \"Valor\" é obrigatório!")]
    [Range(typeof(decimal), "0.01", "9999999999",
        ErrorMessage = "O valor deve ser maior que zero.")]
    decimal Valor,

    [Required(ErrorMessage = "O campo \"Forma de Pagamento\" é obrigatório!")]
    FormaPagamento FormaPagamento

    // [Required(ErrorMessage = "Selecione pelo menos uma categoria.")]
    // List<Guid> CategoriasIds
)
{
    // public List<SelectListItem> CategoriasDisponiveis { get; set; } = [];
}