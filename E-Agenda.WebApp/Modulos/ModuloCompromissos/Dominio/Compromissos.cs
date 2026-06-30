using System;
using E_Agenda.WebApp.Modulos.ModuloContatos.Domionio;
using EAgendaWeb.WebApp.Compartilhado.Dominio;

namespace E_Agenda.WebApp.Modulos.ModuloCompromissos.Dominio;

public class Compromissos : EntidadeBase<Compromissos>
{
    public string Assunto { get; set; } = string.Empty;
    public DateTime DataOcorrencia { get; set; }
    public DateTime HoraDeInicio { get; set; }
    public DateTime HoraDeTermino { get; set; }
    public TipoCompromisso TipoDeCompromisso { get; set; }
    public string Local { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public Contatos? Contato { get; set; } = null;

    public Compromissos(string assunto, DateTime horaDeInicio, DateTime horaDeTermino, TipoCompromisso tipoDeCompromisso, string local = null, string link = null, Contatos? contato = null)
    {
        Assunto = assunto;
        DataOcorrencia = DateTime.Now;
        HoraDeInicio = horaDeInicio;
        HoraDeTermino = horaDeTermino;
        TipoDeCompromisso = tipoDeCompromisso;
        Local = local;
        Link = link;
        Contato = contato;
    }

    public override void Atualizar(Compromissos entidadeAtualizada)
    {
        Assunto = entidadeAtualizada.Assunto;
        DataOcorrencia = entidadeAtualizada.DataOcorrencia;
        HoraDeInicio = entidadeAtualizada.HoraDeInicio;
        HoraDeTermino = entidadeAtualizada.HoraDeTermino;
        TipoDeCompromisso = entidadeAtualizada.TipoDeCompromisso;
        Local = entidadeAtualizada.Local;
        Link = entidadeAtualizada.Link;
        Contato = entidadeAtualizada.Contato;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (Assunto.Length < 2 || Assunto.Length > 100)
            erros.Add("O campo Assunto precisa conter entre 2 a 100 caracteres");

        return erros;
    }
}
