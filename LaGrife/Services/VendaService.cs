using LaGrife.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaGrife.Services
{
    public class VendaService
    {
        private readonly LaGrifeContext _context;

        public VendaService(LaGrifeContext context)
        {
            _context = context;
        }

        public async Task<List<Venda>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Vendas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Loja)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
