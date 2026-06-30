using System;
using EAgendaWeb.WebApp.Compartilhado.Dominio;

namespace E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;

public class Contatos : EntidadeBase<Contatos>
{

    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public string Empresa { get; set; } = string.Empty;

    //Adicionar um compromisso


    public Contatos(string nome, string email, string telefone, string cargo = null, string empresa = null)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Cargo = cargo;
        Empresa = empresa;
    }

    public override void Atualizar(Contatos entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Email = entidadeAtualizada.Email;
        Telefone = entidadeAtualizada.Telefone;
        Cargo = entidadeAtualizada.Cargo;
        Empresa = entidadeAtualizada.Empresa;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo nome deve conter entre 2 a 100 carascteres");

        if (Email.Length < 2 || Email.Length > 100)
            erros.Add("O campo Email deve conter entre 2 a 100 carascteres");

        if (Telefone.Length < 11 || Telefone.Length > 12)
            erros.Add("O campo Telefone deve conter entre 2 a 100 carascteres");

        if (Cargo.Length < 2 || Cargo.Length > 100)
            erros.Add("O campo Cargo deve conter entre 2 a 100 carascteres");

        if (Empresa.Length < 2 || Empresa.Length > 100)
            erros.Add("O campo Empresa deve conter entre 2 a 100 carascteres");

        return erros;

    }
}
