using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd() // O banco gerará o valor automaticamente
                .HasColumnType("int");

            builder.Property(c => c.Nome).HasColumnType("varchar")
                   .IsRequired();

            // Definindo o tipo e as restrições da coluna Nome
            builder.Property(c => c.Descricao).HasColumnType("varchar")
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Preco).HasColumnType("numeric(12,2)")
                   .IsRequired();

            builder.Property(c => c.Ingrediente).HasColumnType("bit")
                   .IsRequired();

            builder.Property(c => c.NomeArquivoUpload)
            .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(p => p.FichaTecnica)
              .WithMany()
              .HasForeignKey(p => p.IdFichaTecnica)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
