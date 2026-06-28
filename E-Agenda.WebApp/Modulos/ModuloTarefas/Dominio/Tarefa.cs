using EAgendaWeb.WebApp.Compartilhado.Dominio;
using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Dominio;

namespace EAgendaWeb.WebApp.Modulos.ModuloTarefas.Dominio;

public class Tarefa : EntidadeBase<Tarefa>
{
    public string Titulo { get; set; }

    public PrioridadeTarefa Prioridade { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime? DataConclusao { get; set; }

    public bool Concluida { get; set; }

    public int PercentualConcluido { get; set; }

     public List<ItemTarefa> Itens { get; set; }
    

    public Tarefa()
    {
        Itens = [];
        DataCriacao = DateTime.Now;
    }

    public Tarefa(string titulo, PrioridadeTarefa prioridade)
    {
        Titulo = titulo;
        Prioridade = prioridade;
        DataCriacao = DateTime.Now;
        PercentualConcluido = 0;
        Concluida = false;
        Itens = [];
    }

    public override void Atualizar(Tarefa tarefaAtualizada)
    {
        Titulo = tarefaAtualizada.Titulo;
        Prioridade = tarefaAtualizada.Prioridade;
        DataConclusao = tarefaAtualizada.DataConclusao;
        Concluida = tarefaAtualizada.Concluida;
        PercentualConcluido = tarefaAtualizada.PercentualConcluido;
        Itens = tarefaAtualizada.Itens;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Titulo.Length < 2 || Titulo.Length > 100)
            erros.Add("O campo \"Título\" deve conter entre 2 e 100 caracteres.");

        if (PercentualConcluido < 0 || PercentualConcluido > 100)
            erros.Add("O percentual deve estar entre 0 e 100.");

        if (Concluida && DataConclusao == null)
            erros.Add("Uma tarefa concluída deve possuir data de conclusão.");

        if (!Concluida && DataConclusao != null)
            erros.Add("Uma tarefa pendente não pode possuir data de conclusão.");

        return erros;
    }
}
