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

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }
        
        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Loja).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Vendedor obj)
        {
            if(!_context.Vendedor.Any(x => x.Id == obj.Id))
            {
                throw new Exception("Nenhum vendedor encontrado");
            }
            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
