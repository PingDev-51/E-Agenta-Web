using AutoMapper;
using EAgendaWeb.WebApp.Compartilhado.Apresentacao.Extensions;
using EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Aplicacao;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EAgendaWeb.WebApp.Modulos.ModuloItensTarefa.Apresentacao;

public class ItemTarefaController : Controller
{
    private readonly ServicoItemTarefa servicoItemTarefa;
    private readonly IMapper mapper;

    public ItemTarefaController(
        ServicoItemTarefa servicoItemTarefa,
        IMapper mapper)
    {
        this.servicoItemTarefa = servicoItemTarefa;
        this.mapper = mapper;
    }

    public ActionResult Listar(Guid tarefaId)
    {
        List<DetalhesItemTarefaDto> detalhesDtos =
            servicoItemTarefa.SelecionarPorTarefa(tarefaId);

        List<ListarItemTarefaViewModel> viewModels =
            mapper.Map<List<ListarItemTarefaViewModel>>(detalhesDtos);

        ViewBag.TarefaId = tarefaId;

        return View(viewModels);
    }

    [HttpGet]
    public ActionResult Cadastrar(Guid tarefaId)
    {
        CadastroItemTarefaViewModel vm = new("", tarefaId);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastroItemTarefaViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        CadastroItemTarefaDto dto =
            mapper.Map<CadastroItemTarefaDto>(vm);

        Result resultado = servicoItemTarefa.Adicionar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(vm);
        }

        return RedirectToAction(
            nameof(Listar),
            new { tarefaId = vm.TarefaId });
    }

    [HttpPost]
    public ActionResult Concluir(ConcluirItemTarefaViewModel vm)
    {
        ConcluirItemTarefaDto dto =
            mapper.Map<ConcluirItemTarefaDto>(vm);

        Result resultado = servicoItemTarefa.Concluir(dto);

        if (resultado.IsFailed)
        {
            TempData["MensagemErro"] =
                resultado.Errors.First().Message;
        }

        Result<DetalhesItemTarefaDto> item =
            servicoItemTarefa.SelecionarPorId(vm.Id);

        if (item.IsSuccess)
        {
            return RedirectToAction(
                nameof(Listar),
                new { tarefaId = item.Value.TarefaId });
        }

        return RedirectToAction("Listar", "Tarefa");
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesItemTarefaDto> resultado =
            servicoItemTarefa.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction("Listar", "Tarefa");

        ExcluirItemTarefaViewModel vm =
            mapper.Map<ExcluirItemTarefaViewModel>(resultado.Value);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirItemTarefaViewModel vm)
    {
        Result resultado =
            servicoItemTarefa.Remover(vm.Id);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(vm);
        }

        return RedirectToAction(
            nameof(Listar),
            new { tarefaId = vm.TarefaId });
    }
}