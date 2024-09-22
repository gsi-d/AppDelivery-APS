using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class FichaTecnicaMapeamento : IEntityTypeConfiguration<FichaTecnica>
    {
        public void Configure(EntityTypeBuilder<FichaTecnica> builder)
        {
            builder.ToTable("FichaTecnica");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            builder.HasData(new FichaTecnica
            {
                Id = 1
            });
        }
    }
}
