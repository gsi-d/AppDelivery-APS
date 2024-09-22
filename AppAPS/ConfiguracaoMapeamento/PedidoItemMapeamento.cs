using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class PeditoItemMapeamento : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            // Definindo a tabela
            builder.ToTable("PedidoItem");

            // Definindo a chave primária
            builder.HasKey(pi => pi.Id);

            // Propriedades
            builder.Property(pi => pi.Quantidade)
                .IsRequired();

            // Relacionamento com Pedido (muitos-para-um)
            builder.HasOne(pi => pi.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(pi => pi.PedidoId)
                .OnDelete(DeleteBehavior.Cascade); // Exclui itens associados se o pedido for deletado

            // Relacionamento com Produto (muitos-para-um)
            builder.HasOne(pi => pi.Produto)
                .WithMany()
                .HasForeignKey(pi => pi.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict); // Protege a exclusão de produtos se forem referenciados
        }
    }
}
