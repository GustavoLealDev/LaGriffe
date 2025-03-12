using Microsoft.AspNetCore.Mvc;
using LaGrife.Models;

namespace LaGrife.Controllers
{
    public class LojasController : Controller
    {
        public IActionResult Index()
        {
            List<Loja> list = new List<Loja>();
            list.Add(new Loja { Id = 1, Local = "Av. Dr. Eugênio Borges, 1737 - Arsenal "});
            return View(list);
        }
    }
}
