using LaGrife.Models.Entities;
using LaGrife.Models.Enums;

namespace LaGrife.Services
{
    public class SeedingService
    {
        private LaGrifeContext _context;

        public SeedingService(LaGrifeContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Loja.Any() || _context.Vendedor.Any() || _context.Vendas.Any())
            {
                return;
            }

            Loja loja1 = new Loja(1, "Av. Dr. Eugênio Borges, 1737 - Arsenal, São Gonçalo");

            Vendedor vendedor1 = new Vendedor(1, "Ricardo Torres", "RicardoT@gmail.com", new DateTime(1998, 4, 21));

            Venda v1 = new Venda(1, new DateTime(2025, 03, 14), 425.00, VendaStatus.Pendente, vendedor1);
            Venda v3 = new Venda(1, new DateTime(2025, 03, 14), 225.00, VendaStatus.Comprado, vendedor1);

            _context.Loja.AddRange(loja1);
            _context.Vendedor.AddRange(vendedor1);
            _context.Vendas.AddRange(v1,v3);

            _context.SaveChanges();
        }
    }
}
