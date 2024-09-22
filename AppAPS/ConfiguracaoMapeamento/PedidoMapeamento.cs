using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class PedidoMapeamento : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Cliente)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Rua)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.FormaPagamento)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(p => p.Bairro)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(p => p.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(p => p.Observacoes)
                .HasMaxLength(500);

            builder.HasMany(p => p.Itens)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
