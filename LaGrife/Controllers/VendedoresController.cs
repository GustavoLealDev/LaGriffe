using Microsoft.AspNetCore.Mvc;
using LaGrife.Services;
using LaGrife.Models.Entities;
using System.Data;
using LaGrife.Services.Exceptions;
using LaGrife.Models.ViewModels;

namespace LaGrife.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedoresService;
        private readonly LojasService _lojasService;
        public VendedoresController(VendedorService vendedoresService, LojasService lojasService)
        {
            _vendedoresService = vendedoresService;
            _lojasService = lojasService;
        }

        public IActionResult Index()
        {
            var list = _vendedoresService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var lojas = _lojasService.FindAll();
            var viewModel = new VendedorFormViewModel { Lojas = lojas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedoresService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedoresService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Loja> Lojas = _lojasService.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { vendedor = obj, Lojas = Lojas };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if(id != vendedor.Id)
            {
                return BadRequest();
            }
            try
            {
                _vendedoresService.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundExceptions)
            {
                return NotFound();
            }
            catch (DbConcurrencyExceptions)
            {
                return BadRequest();
            }
        }

    }
}