using BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Context
{
    public class AplicationDbContext:DbContext 
    {
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Poliza> Polizas { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
