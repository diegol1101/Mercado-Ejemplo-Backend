using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria> 
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {

        builder.ToTable("Categoria");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(p => p.Descripcion)
        .HasColumnName("Descripcion")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

    }
}
