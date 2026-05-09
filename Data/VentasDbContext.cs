using Microsoft.EntityFrameworkCore;
using VentasApi.Models;

namespace VentasApi.Data
{
    public class VentasDbContext : DbContext
    {
        public VentasDbContext(DbContextOptions<VentasDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }
}
