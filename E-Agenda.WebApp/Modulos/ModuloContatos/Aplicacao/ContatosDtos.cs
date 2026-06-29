using System;

namespace E_Agenda.WebApp.Modulos.ModuloContatos.Aplicacao;

public record ListarContatosContatosDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Cargo,
    string Empresa
);
public record CadastrarContatosContatosDto(
    string Nome,
    string Email,
    string Telefone,
    string Cargo,
    string Empresa
);
public record EditarContatosContatosDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Cargo,
    string Empresa
);
public record ExcluirContatosContatosDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Cargo,
    string Empresa
);
