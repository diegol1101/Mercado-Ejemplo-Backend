using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class FacturaConfiguration : IEntityTypeConfiguration<Factura> 
{
    public void Configure(EntityTypeBuilder<Factura> builder)
    {

        builder.ToTable("Factura");
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
        .IsRequired();

        builder.Property(f => f.Nombre)
        .HasColumnName("Nombre Cliente")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(f=>f.Cantidad)
        .HasColumnName("Cantidad")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(f=>f.Vtotal)
        .HasColumnName("Valor Total")
        .HasColumnType("decimal(18,2)")
        .IsRequired();

        builder
        .HasOne(f => f.Producto)
        .WithMany(p => p.Facturas)
        .HasForeignKey(f => f.ProductoIdFk);

    }
}
