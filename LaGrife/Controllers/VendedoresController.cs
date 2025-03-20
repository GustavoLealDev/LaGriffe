using Microsoft.AspNetCore.Mvc;
using LaGrife.Services;
using LaGrife.Models.Entities;

namespace LaGrife.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedorService _vendedoresService;

        public VendedoresController(VendedorService vendedoresService)
        {
            _vendedoresService = vendedoresService;
        }

        public IActionResult Index()
        {
            var list = _vendedoresService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedoresService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
