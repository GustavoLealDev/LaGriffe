using LaGrife.Models.Entities;

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
    }
}
