using Microsoft.AspNetCore.Mvc;

namespace LaGrife.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
