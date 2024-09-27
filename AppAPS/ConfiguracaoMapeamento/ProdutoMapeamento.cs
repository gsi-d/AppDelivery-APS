using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Define a chave primária
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
            .ValueGeneratedOnAdd() // Indica que o valor será gerado automaticamente ao adicionar o registro
            .HasColumnType("int");


            // Define o nome da tabela (opcional)
            builder.ToTable("Produto");

            // Define o nome como obrigatório e configura o tipo de coluna no banco
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)"); // Define um tipo de coluna varchar com 100 caracteres

            // Define a descrição como obrigatória e configura o tipo de coluna
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(255)"); // Define um tipo de coluna varchar com 255 caracteres

            // Define o preço como obrigatório e configura o tipo decimal no banco de dados
            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Define um tipo decimal com precisão 18 e escala 2

            // Define o campo Bebida como booleano
            builder.Property(p => p.Bebida)
                .HasColumnType("bit"); // Tipo booleano (bit no SQL Server)

            // Define o NomeArquivoUpload como varchar e não obrigatório
            builder.Property(p => p.NomeArquivoUpload)
                .HasColumnType("varchar(255)"); // Define um tipo de coluna varchar com 255 caracteres

            // Configura a Foreign Key opcional para FichaTecnica
            builder.HasOne(p => p.FichaTecnica)
                .WithMany()
                .HasForeignKey(p => p.FichaTecnicaId)
                .OnDelete(DeleteBehavior.SetNull); // Define que, se a FichaTecnica for excluída, o campo FichaTecnicaId será setado como NULL

            // Outras configurações de coluna podem ser adicionadas aqui se necessário
        }
    }
}
