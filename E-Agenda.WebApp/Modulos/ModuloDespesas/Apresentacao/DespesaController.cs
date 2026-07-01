
// using AutoMapper;
// using EAgendaWeb.WebApp.Compartilhado.Apresentacao.Extensions;
// using EAgendaWeb.WebApp.Modulos.ModuloDespesas.Aplicacao;
// using FluentResults;
// using Microsoft.AspNetCore.Mvc;

// namespace EAgendaWeb.WebApp.Modulos.ModuloDespesas.Apresentacao;

// public class DespesaController : Controller
// {
//     private readonly ServicoDespesa servicoDespesa;
//     private readonly IMapper mapper;

//     public DespesaController(ServicoDespesa servicoDespesa, IMapper mapper)
//     {
//         this.servicoDespesa = servicoDespesa;
//         this.mapper = mapper;
//     }

//     public ActionResult Listar()
//     {
//         List<DetalhesDespesaDto> detalhesDespesaDtos = servicoDespesa.SelecionarTodos();

//         List<ListarDespesaViewModel> listarDespesaViewModels =
//             mapper.Map<List<ListarDespesaViewModel>>(detalhesDespesaDtos);

//         return View(listarDespesaViewModels);
//     }

//     [HttpGet]
//     public ActionResult Cadastrar()
//     {
//         //Carregar categorias disponíveis
//         // vm.CategoriasDisponiveis = ...

//         return View();
//     }

//     [HttpPost]
//     public ActionResult Cadastrar(CadastroDespesaViewModel vm)
//     {
//         if (!ModelState.IsValid)
//         {
//             // TODO: Recarregar categorias antes de retornar a View
//             // vm.CategoriasDisponiveis = ...

//             return View(vm);
//         }

//         CadastroDespesaDto dto = mapper.Map<CadastroDespesaDto>(vm);

//         Result resultado = servicoDespesa.Cadastrar(dto);

//         if (resultado.IsFailed)
//         {
//             ModelState.AddModelError(resultado);

//             // Recarregar categorias
//             // vm.CategoriasDisponiveis = ...

//             return View(vm);
//         }

//         return RedirectToAction(nameof(Listar));
//     }

//     [HttpGet]
//     public ActionResult Editar(Guid id)
//     {
//         Result<DetalhesDespesaDto> resultado = servicoDespesa.SelecionarPorId(id);

//         if (resultado.IsFailed)
//             return RedirectToAction(nameof(Listar));

//         EditarDespesaViewModel vm =
//             mapper.Map<EditarDespesaViewModel>(resultado.Value);

//         //  Carregar categorias disponíveis
//         //  Marcar as categorias já vinculadas à despesa

//         return View(vm);
//     }

//     [HttpPost]
//     public ActionResult Editar(EditarDespesaViewModel vm)
//     {
//         if (!ModelState.IsValid)
//         {
//             //Recarregar categorias
//             // vm.CategoriasDisponiveis = ...

//             return View(vm);
//         }

//         EditarDespesaDto dto = mapper.Map<EditarDespesaDto>(vm);

//         Result resultado = servicoDespesa.Editar(dto);

//         if (resultado.IsFailed)
//         {
//             ModelState.AddModelError(resultado);

//             //Recarregar categorias
//             // vm.CategoriasDisponiveis = ...

//             return View(vm);
//         }

//         return RedirectToAction(nameof(Listar));
//     }

//     [HttpGet]
//     public ActionResult Excluir(Guid id)
//     {
//         Result<DetalhesDespesaDto> resultado = servicoDespesa.SelecionarPorId(id);

//         if (resultado.IsFailed)
//             return RedirectToAction(nameof(Listar));

//         ExcluirDespesaViewModel vm =
//             mapper.Map<ExcluirDespesaViewModel>(resultado.Value);

//         return View(vm);
//     }

//     [HttpPost]
//     public ActionResult Excluir(ExcluirDespesaViewModel vm)
//     {
//         Result resultado = servicoDespesa.Excluir(vm.Id);

//         if (resultado.IsFailed)
//         {
//             ModelState.AddModelError(resultado);

//             return View(vm);
//         }

//         return RedirectToAction(nameof(Listar));
//     }
// }