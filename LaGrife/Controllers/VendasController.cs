using Microsoft.AspNetCore.Mvc;

namespace LaGrife.Controllers
{
    public class VendasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }
        public IActionResult GroupSearch()
        {
            return View();
        }
    }
}
