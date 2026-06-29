using System;

namespace E_Agenda.WebApp.Modulos.ModuloContatos.Aplicacao;

public record ListarContatosDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Cargo,
    string Empresa
);
public record CadastrarContatosDto(
    string Nome,
    string Email,
    string Telefone,
    string Cargo,
    string Empresa
);
public record EditarContatosDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Cargo,
    string Empresa
);
public record DetalhesContatosDto(
    string Nome,
    string Email,
    string Telefone,
    string Cargo,
    string Empresa
);
