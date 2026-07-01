using E_Agenda.WebApp.Modulos.ModuloCategoria.Dominio;
using EAgendaWeb.WebApp.Compartilhado.Dominio;

namespace EAgendaWeb.WebApp.Modulos.ModuloDespesas.Dominio;

public class Despesas : EntidadeBase<Despesas>
{
    public string Descricao { get; set; }

    public DateTime DataOcorrencia { get; set; }

    public decimal Valor { get; set; }

    public FormaPagamento FormaPagamento { get; set; }

    public List<Categoria>? Categorias { get; set; } = null;

    public Despesas() { }

    public Despesas(
        string descricao,
        decimal valor,
        FormaPagamento formaPagamento,
        List<Categoria>? categorias
        )
    {
        Descricao = descricao;
        Valor = valor;
        FormaPagamento = formaPagamento;
        Categorias = categorias;
        DataOcorrencia = DateTime.Now;
        Categorias = categorias;
    }

    public override void Atualizar(Despesas despesaAtualizada)
    {
        Descricao = despesaAtualizada.Descricao;
        DataOcorrencia = despesaAtualizada.DataOcorrencia;
        Valor = despesaAtualizada.Valor;
        FormaPagamento = despesaAtualizada.FormaPagamento;
        Categorias = despesaAtualizada.Categorias;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (Descricao.Length < 2 || Descricao.Length > 100)
            erros.Add("O campo \"Descrição\" deve conter entre 2 e 100 caracteres.");

        if (Valor <= 0)
            erros.Add("O valor deve ser maior que zero.");

        if (Categorias == null || Categorias.Count == 0)
            erros.Add("Selecione pelo menos uma categoria.");

        return erros;
    }
}
