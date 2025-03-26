using LaGrife.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaGrife.Services
{
    public class VendedorService
    {
        private readonly LaGrifeContext _context;

        public VendedorService(LaGrifeContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }
        
        public async Task InsertAsync(Vendedor obj)
        {
            _context.Add(obj);
             await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> FindByIdAsync(int id)
        {
            return  await _context.Vendedor.Include(obj => obj.Loja).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vendedor obj)
        {
            if(!await _context.Vendedor.AnyAsync(x => x.Id == obj.Id))
            {
                throw new Exception("Nenhum vendedor encontrado");
            }
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
