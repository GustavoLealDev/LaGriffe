using LaGrife.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace LaGrife.Services
{
    public class LojasService
    {
        private readonly LaGrifeContext _context;

        public LojasService(LaGrifeContext context)
        {
            _context = context;
        }

        public async Task<List<Loja>> FindAllAsync()
        {
            return await _context.Loja.OrderBy(x => x.Local).ToListAsync();
        }
    }
}
