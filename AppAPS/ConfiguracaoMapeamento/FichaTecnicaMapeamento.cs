using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class FichaTecnicaMapeamento : IEntityTypeConfiguration<FichaTecnica>
    {
        public void Configure(EntityTypeBuilder<FichaTecnica> builder)
        {
            // Define a chave primária
            builder.HasKey(f => f.Id);

            builder.Property(p => p.Id)
            .ValueGeneratedOnAdd() // Indica que o valor será gerado automaticamente ao adicionar o registro
            .HasColumnType("int");

            // Define o nome da tabela (opcional)
            builder.ToTable("FichaTecnica");

            // Define o relacionamento de FichaTecnica com IngredienteFichaTecnica
            builder
                .HasMany(f => f.Ingredientes)
                .WithOne(i => i.FichaTecnica) // Assuming IngredienteFichaTecnica has a FichaTecnica navigation property
                .HasForeignKey(i => i.FichaTecnicaId) // Assuming there's a FichaTecnicaId foreign key in IngredienteFichaTecnica
                .OnDelete(DeleteBehavior.Cascade); // Define o comportamento de exclusão em cascata
        }
    }
}
