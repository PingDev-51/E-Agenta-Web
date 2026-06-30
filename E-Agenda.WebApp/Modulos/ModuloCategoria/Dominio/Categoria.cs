using System;
using EAgendaWeb.WebApp.Compartilhado.Dominio;
using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;

namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Dominio;

public class Categoria : EntidadeBase<Categoria>
{
    public string Titulo { get; set; } = string.Empty;
    public Despesas? Depesas { get; set; } = null;

    public Categoria(string titulo, Despesas? depesas)
    {
        Titulo = titulo;
        Depesas = depesas;
    }

    public override void Atualizar(Categoria entidadeAtualizada)
    {
        Titulo = entidadeAtualizada.Titulo;
        Depesas = entidadeAtualizada.Depesas;
    }

    public override List<string> Validar()
    {
        List<string> erro = new();

        if (Titulo.Length < 2 || Titulo.Length > 100)
            erro.Add("O campo Titulo deve conter entre 2 a 100 caracteres");

        return erro;
    }
}
