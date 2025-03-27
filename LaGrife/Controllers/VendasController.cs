using LaGrife.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaGrife.Controllers
{
    public class VendasController : Controller
    {
        private readonly VendaService _vendaService;

        public VendasController(VendaService vendaService)
        {
            _vendaService = vendaService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Search(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _vendaService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public IActionResult GroupSearch()
        {
            return View();
        }
    }
}
