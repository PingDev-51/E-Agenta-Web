using AutoMapper;
using EAgendaWeb.WebApp.Compartilhado.Apresentacao.Extensions;
using EAgendaWeb.WebApp.Modulos.ModuloTarefas.Aplicacao;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EAgendaWeb.WebApp.Modulos.ModuloTarefas.Apresentacao;

public class TarefaController : Controller
{
    private readonly ServicoTarefa servicoTarefa;
    private readonly IMapper mapper;

    public TarefaController(ServicoTarefa servicoTarefa, IMapper mapper)
    {
        this.servicoTarefa = servicoTarefa;
        this.mapper = mapper;
    }

    public ActionResult Listar()
    {
        List<DetalhesTarefaDto> detalhesTarefaDtos = servicoTarefa.SelecionarTodos();

        List<ListarTarefaViewModel> listarTarefaViewModels =
            mapper.Map<List<ListarTarefaViewModel>>(detalhesTarefaDtos);

        return View(listarTarefaViewModels);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastroTarefaViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        CadastroTarefaDto dto = mapper.Map<CadastroTarefaDto>(vm);

        Result resultado = servicoTarefa.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesTarefaDto> resultado = servicoTarefa.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        EditarTarefaViewModel vm =
            mapper.Map<EditarTarefaViewModel>(resultado.Value);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Editar(EditarTarefaViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        EditarTarefaDto dto = mapper.Map<EditarTarefaDto>(vm);

        Result resultado = servicoTarefa.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesTarefaDto> resultado = servicoTarefa.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        ExcluirTarefaViewModel vm =
            mapper.Map<ExcluirTarefaViewModel>(resultado.Value);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirTarefaViewModel vm)
    {
        Result resultado = servicoTarefa.Excluir(vm.Id);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }
}