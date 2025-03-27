using LaGrife.Models.Entities;
using LaGrife.Models.Enums;
using NuGet.Protocol.Plugins;

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

            Vendedor s1 = new Vendedor(1, "Bob Marley", "bobM@gmail.com", new DateTime(1998, 4, 21), loja1);
            Vendedor s2 = new Vendedor(2, "Maria Thereza", "maria12The@gmail.com", new DateTime(1979, 12, 31), loja1);
            Vendedor s3 = new Vendedor(3, "Marco Alex", "Malex@gmail.com", new DateTime(1988, 1, 15), loja1);
            Vendedor s4 = new Vendedor(4, "Maria Martha", "martha13@gmail.com", new DateTime(1993, 11, 30), loja1);
            Vendedor s5 = new Vendedor(5, "Marck Donald", "MarkGray@gmail.com", new DateTime(2000, 1, 9), loja1);
            Vendedor s6 = new Vendedor(6, "Gustavo Lima", "GustavoL@hotmail.com", new DateTime(1997, 3, 4), loja1);
            Vendedor s7 = new Vendedor(1, "Ricardo Torres", "RicardoT@gmail.com", new DateTime(1998, 4, 21), loja1);

            Venda v1 = new Venda(1, new DateTime(2025, 02, 14), 425.00, VendaStatus.Pendente, s7);
            Venda v2 = new Venda(1, new DateTime(2025, 02, 14), 225.00, VendaStatus.Comprado, s7);
            Venda v3 = new Venda(1, new DateTime(2025, 02, 25), 11000.0, VendaStatus.Pendente, s1);
            Venda v4 = new Venda(2, new DateTime(2025, 02, 4), 7000.0, VendaStatus.Pendente, s5);
            Venda v5 = new Venda(3, new DateTime(2025, 02, 13), 4000.0, VendaStatus.Pendente, s4);
            Venda v6 = new Venda(4, new DateTime(2025, 02, 1), 8000.0, VendaStatus.Comprado, s1);
            Venda v7 = new Venda(5, new DateTime(2025, 02, 21), 3000.0, VendaStatus.Comprado, s3);
            Venda v8 = new Venda(6, new DateTime(2025, 02, 15), 2000.0, VendaStatus.Comprado, s1);
            Venda v9 = new Venda(7, new DateTime(2025, 02, 28), 13000.0, VendaStatus.Comprado, s2);
            Venda v10 = new Venda(8, new DateTime(2025, 02, 11), 4000.0, VendaStatus.Comprado, s4);
            Venda v11 = new Venda(9, new DateTime(2025, 02, 14), 11000.0, VendaStatus.Comprado, s6);
            Venda v12 = new Venda(10, new DateTime(2025, 02, 7), 9000.0, VendaStatus.Comprado, s6);
            Venda v13 = new Venda(11, new DateTime(2025, 02, 13), 6000.0, VendaStatus.Comprado, s2);
            Venda v14 = new Venda(12, new DateTime(2025, 02, 25), 7000.0, VendaStatus.Comprado, s3);
            Venda v15 = new Venda(13, new DateTime(2025, 03, 26), 10000.0, VendaStatus.Pendente, s4);
            Venda v16 = new Venda(14, new DateTime(2025, 03, 4), 3000.0, VendaStatus.Comprado, s5);
            Venda v17 = new Venda(15, new DateTime(2025, 03, 12), 4000.0, VendaStatus.Comprado, s1);
            Venda v18 = new Venda(16, new DateTime(2025, 03, 5), 2000.0, VendaStatus.Pendente, s4);
            Venda v19 = new Venda(17, new DateTime(2025, 03, 1), 12000.0, VendaStatus.Pendente, s1);
            Venda v20 = new Venda(18, new DateTime(2025, 03, 24), 6000.0, VendaStatus.Pendente, s3);
            Venda v21 = new Venda(19, new DateTime(2025, 03, 22), 8000.0, VendaStatus.Pendente, s5);
            Venda v22 = new Venda(20, new DateTime(2025, 03, 15), 8000.0, VendaStatus.Pendente, s6);
            Venda v23 = new Venda(21, new DateTime(2025, 03, 17), 9000.0, VendaStatus.Comprado, s2);
          
            _context.Loja.AddRange(loja1);
            _context.Vendedor.AddRange(s1, s2, s3, s4, s5, s6,s7);
            _context.Vendas.AddRange(v1,v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14,
                v15, v16, v17, v18, v19, v20, v21, v22, v23);

            _context.SaveChanges();
        }
    }
}
