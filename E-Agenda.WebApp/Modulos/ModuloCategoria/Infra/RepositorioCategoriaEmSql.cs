using System;
using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Dominio;

namespace E_Agenda.WebApp.Modulos.ModuloCategoria.Infra;

public class RepositorioCategoriaEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioItemTarefa
{
    public void Adicionar(ItemTarefa item)
    {
        throw new NotImplementedException();
    }

    public bool AtualizarStatus(Guid id, bool concluido)
    {
        throw new NotImplementedException();
    }

    public bool Remover(Guid id)
    {
        throw new NotImplementedException();
    }

    public ItemTarefa? SelecionarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<ItemTarefa> SelecionarPorTarefa(Guid tarefaId)
    {
        throw new NotImplementedException();
    }
}
