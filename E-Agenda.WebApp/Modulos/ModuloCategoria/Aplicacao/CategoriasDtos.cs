using System;

namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Aplicacao;

public record ListarCategoriaDto(
    Guid Id,
    string Titulo,
    string Despesas
);