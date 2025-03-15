using LaGrife.Models.Entities;
using LaGrife.Models.Enums;

namespace LaGrife.Data
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
            Loja loja2 = new Loja(2, "https://www.instagram.com/lagriffemultimarcassg/");

            Vendedor vendedor1 = new Vendedor(1, "Ricardo Torres", "RicardoT@gmail.com", new DateTime(1998, 4, 21), loja1);
            Vendedor vendedor2 = new Vendedor(2, "Marcos Junior", "Marc10Jr@outlook.com", new DateTime(1992, 8, 13), loja1);

            Vendas v1 = new Vendas(1, new DateTime(2025, 03, 14), 425.00, VendaStatus.Pendente, vendedor1);
            Vendas v2 = new Vendas(1, new DateTime(2025, 03, 11), 100.00, VendaStatus.Comprado, vendedor1);
            Vendas v3 = new Vendas(1, new DateTime(2025, 03, 14), 225.00, VendaStatus.Comprado, vendedor1);
            Vendas v4 = new Vendas(1, new DateTime(2025, 03, 13), 200.00, VendaStatus.Cancelada, vendedor1);

            _context.Loja.AddRange(loja1, loja2);
            _context.Vendedor.AddRange(vendedor1);
            _context.Vendas.AddRange(v1,v2,v3,v4);

            _context.SaveChanges();
        }
    }
}
