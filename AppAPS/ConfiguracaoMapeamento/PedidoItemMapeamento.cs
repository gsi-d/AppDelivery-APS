using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class PeditoItemMapeamento : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            // Define a chave primária e auto-incremento (identity)
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd() // Define que o Id é gerado automaticamente (sequencial)
                .HasColumnType("int"); // Define o tipo da coluna como int

            // Define a Foreign Key para Pedido (relacionamento muitos-para-um)
            builder.HasOne(p => p.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(p => p.PedidoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata (quando um Pedido for excluído, os itens também são)

            // Define a Foreign Key para Produto (relacionamento muitos-para-um)
            builder.HasOne(p => p.Produto)
                .WithMany()
                .HasForeignKey(p => p.ProdutoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Impede a exclusão de um Produto se ele estiver associado a um PedidoItem

            // Define a Quantidade como obrigatória e configura o tipo da coluna
            builder.Property(p => p.Quantidade)
                .IsRequired()
                .HasColumnType("int"); // Define o tipo da coluna como int
        }
    }
}
