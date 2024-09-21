using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;
using Microsoft.FluentUI.AspNetCore.Components.DesignTokens;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class FichaTecnicaMapeamento : IEntityTypeConfiguration<FichaTecnica>
    {
        public void Configure(EntityTypeBuilder<FichaTecnica> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd() // O banco gerará o valor automaticamente
                .HasColumnType("int");

            builder.HasOne(p => p.Produto)
              .WithMany()
              .HasForeignKey(p => p.IdProduto)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(f => f.Ingredientes)
              .WithOne(p => p.FichaTecnica)
              .HasForeignKey(p => p.IdFichaTecnica)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
