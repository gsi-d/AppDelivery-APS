using AppAPS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class PedidoMapeamento : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            // Define a chave primária e auto-incremento (identity)
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd() // Define que o Id é gerado automaticamente (sequencial)
                .HasColumnType("int"); // Tipo de coluna int

            // Nome do cliente - Obrigatório
            builder.Property(p => p.Cliente)
                .IsRequired()
                .HasColumnType("varchar(150)") // Define como varchar com 150 caracteres
                .HasMaxLength(150);

            // CPF do cliente - Obrigatório
            builder.Property(p => p.CPF)
                .IsRequired()
                .HasColumnType("varchar(11)") // Define como varchar para o CPF, que normalmente tem 11 caracteres
                .HasMaxLength(11);

                builder.HasIndex(p => p.CPF)
                .IsUnique();

            // Rua - Obrigatória
            builder.Property(p => p.Rua)
                .IsRequired()
                .HasColumnType("varchar(255)") // Define como varchar com 255 caracteres
                .HasMaxLength(255);

            // Bairro - Enum
            builder.Property(p => p.Bairro)
                .IsRequired()
                .HasColumnType("int"); // Define o enum como int

            // Forma de Pagamento - Enum
            builder.Property(p => p.FormaPagamento)
                .IsRequired()
                .HasColumnType("int"); // Define o enum como int

            // Forma de Entrega - Enum
            builder.Property(p => p.FormaEntrega)
                .IsRequired()
                .HasColumnType("int"); // Define o enum como int

            // Status do Pedido - Enum (não obrigatório)
            builder.Property(p => p.Status)
                .HasColumnType("int"); // Define o enum como int

            // Observações - Opcional
            builder.Property(p => p.Observacoes)
                .HasColumnType("varchar(500)") // Define como varchar com 500 caracteres
                .HasMaxLength(500);

            // Data de Abertura - Obrigatória
            builder.Property(p => p.DataAbertura)
                .IsRequired()
                .HasColumnType("datetime"); // Define como datetime

            // Data da Última Atualização - Obrigatória
            builder.Property(p => p.DataUltimaAtualizacao)
                .IsRequired()
                .HasColumnType("datetime"); // Define como datetime

            // Data de Finalização - Opcional
            builder.Property(p => p.DataFinalizacao)
                .HasColumnType("datetime"); // Define como datetime

            // Valor do Pedido - Obrigatório
            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Define como decimal com precisão de 18 e 2 casas decimais

            // Taxa de Entrega - Obrigatória
            builder.Property(p => p.TaxaEntrega)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Define como decimal com precisão de 18 e 2 casas decimais

            // Relacionamento um-para-muitos com PedidoItem
            builder.HasMany(p => p.Itens)
                .WithOne(i => i.Pedido)
                .HasForeignKey(i => i.PedidoId)
                .OnDelete(DeleteBehavior.Cascade); // Exclui os itens associados quando um pedido é excluído
        }
    }
}
