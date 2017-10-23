using System;
using Microsoft.EntityFrameworkCore;

namespace SondaProject.Models
{
    public class SondaContext : DbContext
    {
        public SondaContext(DbContextOptions<SondaContext> options)
            : base(options)
        {
        }

        public DbSet<Sonda> Sondas { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Planalto> Planaltos { get; set; }
    }
}
