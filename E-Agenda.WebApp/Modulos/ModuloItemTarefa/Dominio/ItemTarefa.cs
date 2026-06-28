using EAgendaWeb.WebApp.Compartilhado.Dominio;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Dominio;

namespace EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Dominio;

public class ItemTarefa : EntidadeBase<ItemTarefa>
{
    public string Titulo { get; set; }

    public bool Concluido { get; set; }

    public Guid TarefaId { get; set; }

    public Tarefa Tarefa { get; set; }

    public ItemTarefa()
    {
    }

    public ItemTarefa(string titulo, Guid tarefaId)
    {
        Titulo = titulo;
        TarefaId = tarefaId;
        Concluido = false;
    }

    public override void Atualizar(ItemTarefa itemAtualizado)
    {
        Titulo = itemAtualizado.Titulo;
        Concluido = itemAtualizado.Concluido;
        TarefaId = itemAtualizado.TarefaId;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (string.IsNullOrWhiteSpace(Titulo))
            erros.Add("O campo \"Título\" é obrigatório.");

        if (Titulo.Length < 2 || Titulo.Length > 100)
            erros.Add("O campo \"Título\" deve conter entre 2 e 100 caracteres.");

        if (TarefaId == Guid.Empty)
            erros.Add("O item deve estar vinculado a uma tarefa.");

        return erros;
    }
}