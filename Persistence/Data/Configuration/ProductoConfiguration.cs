using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {

        builder.ToTable("Producto");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(p => p.Nombre)
        .HasColumnName("Nombre")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.Descripcion)
        .HasColumnName("Descripcion")
        .HasColumnType("varchar")
        .HasMaxLength(255);

        builder.Property(p => p.Precio)
        .HasColumnName("Precio")
        .HasColumnType("decimal(18,2)") 
        .IsRequired();


        builder
        .HasOne(c => c.Categoria)
        .WithMany(p => p.Productos)
        .HasForeignKey(c => c.CategoriaIdFk);

    }
}
