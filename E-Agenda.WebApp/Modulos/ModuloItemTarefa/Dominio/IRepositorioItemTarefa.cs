using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Dominio;

public interface IRepositorioItemTarefa
{
    void Adicionar(ItemTarefa item);

    bool Remover(Guid id);

    bool AtualizarStatus(Guid id, bool concluido);

    ItemTarefa? SelecionarPorId(Guid id);

    List<ItemTarefa> SelecionarPorTarefa(Guid tarefaId);
}