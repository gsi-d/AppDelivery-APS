using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class IngredienteFichaTecnicaMapeamento : IEntityTypeConfiguration<IngredienteFichaTecnica>
    {
        public void Configure(EntityTypeBuilder<IngredienteFichaTecnica> builder)
        {
            // Define a chave primária
            builder.HasKey(i => i.Id);

            builder.Property(p => p.Id)
            .ValueGeneratedOnAdd() // Indica que o valor será gerado automaticamente ao adicionar o registro
            .HasColumnType("int");

            // Define o nome da tabela (opcional)
            builder.ToTable("IngredienteFichaTecnica");

            // Configura o campo Ingrediente como um enum armazenado como string ou int (dependendo de sua preferência)
            builder.Property(i => i.Ingrediente).HasColumnType("tinyint")
                .IsRequired(); // Se o campo for obrigatório

            // Configura o campo Quantidade como obrigatório
            builder.Property(i => i.Quantidade).HasColumnType("int")
                .IsRequired();

            // Configura o campo Medida como enum (se for enum, pode ser armazenado como int ou string)
            builder.Property(i => i.Medida).HasColumnType("tinyint")
                .IsRequired();

            // Configura a Foreign Key para FichaTecnica (relacionamento muitos-para-um)
            builder
                .HasOne(i => i.FichaTecnica)
                .WithMany(f => f.Ingredientes)
                .HasForeignKey(i => i.FichaTecnicaId)
                .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata

            // Configurações adicionais podem ser feitas aqui
        }
    }
}
