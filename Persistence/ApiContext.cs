using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class ApiContext : DbContext
{
   public ApiContext(DbContextOptions options) : base(options)
   { }

   public DbSet<Producto> Productos { get; set; }
   public DbSet<Categoria> Categorias { get; set; }
   public DbSet<Factura> Facturas { get; set; }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
   }

}
