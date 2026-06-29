using System;
using System.ComponentModel.DataAnnotations;

namespace E_Agenda.WebApp.Modulos.ModuloContatos.Apresentacao;

public record ListarContatosContatosViewModels(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Cargo,
    string Empresa
);

public record CadastrarContatosContatosViewModels(
    [Required (ErrorMessage = "O campo Nome Deve ser preenchido")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo Nome deve conter entre 2 a 100 caracteres")]
    string Nome,

    [Required (ErrorMessage = "O campo Email Deve ser preenchido")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo Email deve conter entre 2 a 100 caracteres")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
    string Email,

    [Required (ErrorMessage = "O campo Telefone Deve ser preenchido")]
    [StringLength(12, MinimumLength = 11, ErrorMessage = "O campo Telefone deve conter entre 11 a 12 caracteres")]
    string Telefone,

    [Required (ErrorMessage = "O campo Cargo Deve ser preenchido")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo Cargo deve conter entre 2 a 100 caracteres")]
    string Cargo,

    [Required (ErrorMessage = "O campo Empresa Deve ser preenchido")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo Empresa deve conter entre 2 a 100 caracteres")]
    string Empresa
);