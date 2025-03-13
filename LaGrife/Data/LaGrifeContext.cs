using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LaGrife.Models
{
    public class LaGrifeContext : DbContext
    {
        public LaGrifeContext (DbContextOptions<LaGrifeContext> options)
            : base(options)
        {
        }

        public DbSet<LaGrife.Models.Loja> Loja { get; set; } = default!;
    }
}
