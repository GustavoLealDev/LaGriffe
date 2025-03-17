using Microsoft.AspNetCore.Mvc;
using LaGrife.Services;

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
    }
}
