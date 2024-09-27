using AppAPS.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppAPS.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<FichaTecnica> FichaTecnica { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<IngredienteFichaTecnica> IngredienteFichaTecnica { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
