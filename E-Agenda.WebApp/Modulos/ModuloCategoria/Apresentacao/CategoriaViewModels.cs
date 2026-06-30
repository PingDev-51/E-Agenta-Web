using System;
using System.ComponentModel.DataAnnotations;

namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Apresentacao;

public record ListarCategoriaViewModel(
    Guid Id,
    string Titulo,
    string Despesas
);

public record CadastrarCategoriaViewModel(
    [Required(ErrorMessage = "O campo Titulo é obrigatorio")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O Campo Tirulo deve conter entre 2 a 100 caracteres")]
    string Titulo,


    string Despesas
);