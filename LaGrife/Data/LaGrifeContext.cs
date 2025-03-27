using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LaGrife.Models.Entities
{
    public class LaGrifeContext : DbContext
    {
        public LaGrifeContext(DbContextOptions<LaGrifeContext> options)
            : base(options)
        {
        }
        public DbSet<Loja> Loja { get; set; } = default!;
        public DbSet<Venda> Vendas { get; set; } = default!;
        public DbSet<Vendedor> Vendedor { get; set; } = default!;
    }
}
