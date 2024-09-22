﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;

namespace AppAPS.ConfiguracaoMapeamento
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            builder.Property(c => c.Nome).HasColumnType("varchar")
                   .IsRequired().HasMaxLength(200);

            builder.Property(c => c.Descricao).HasColumnType("varchar")
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Preco).HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(c => c.Ingrediente).HasColumnType("bit")
                   .IsRequired();

            builder.Property(c => c.NomeArquivoUpload)
            .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(p => p.FichaTecnica)
                .WithMany()
                .HasForeignKey(p => p.FichaTecnicaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Produto { Id = 1, Nome = "Cheeseburger Duplo", Descricao = "Dois suculentos hambúrgueres de carne bovina grelhados, com queijo cheddar derretido, alface fresca, tomate maduro e molho especial. Tudo isso dentro de um pão macio com gergelim.", Preco = 17.50m, NomeArquivoUpload = "/uploads/cheeseburger_duplo.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 2, Nome = "Batata Frita Grande", Descricao = "Batatas fritas crocantes e douradas por fora, macias por dentro, temperadas na medida certa. Acompanhamento perfeito para qualquer refeição.", Preco = 8.99m, NomeArquivoUpload = "/uploads/batata_frita_grande.jpeg", FichaTecnicaId = 1 },
                new Produto { Id = 3, Nome = "Frango Empanado Crocante", Descricao = "Peitos de frango suculentos e temperados, empanados em uma crosta crocante de ervas e especiarias. Perfeito para os amantes de frango frito.", Preco = 15.00m, NomeArquivoUpload = "/uploads/frango_empanado.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 4, Nome = "Milkshake de Chocolate", Descricao = "Milkshake cremoso de chocolate, feito com sorvete artesanal de alta qualidade, servido com chantilly e cobertura de chocolate.", Preco = 12.50m, NomeArquivoUpload = "/uploads/milkshake_chocolate.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 5, Nome = "Wrap de Frango Grelhado", Descricao = "Tortilla macia recheada com pedaços de frango grelhado, alface, tomate, queijo cheddar e molho ranch. Uma opção leve e deliciosa.", Preco = 14.75m, NomeArquivoUpload = "/uploads/wrap_frango_grelhado.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 6, Nome = "Combo Bacon Duplo", Descricao = "Hambúrguer com dois suculentos hambúrgueres de carne bovina, bacon crocante, queijo cheddar derretido, cebolas caramelizadas e molho especial. Acompanha batata frita e refrigerante.", Preco = 25.99m, NomeArquivoUpload = "/uploads/combo_bacon_duplo.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 7, Nome = "Nuggets de Frango", Descricao = "Pequenos pedaços de frango empanado, crocantes e suculentos, servidos com seu molho preferido. Ideal como lanche rápido ou acompanhamento.", Preco = 10.99m, NomeArquivoUpload = "/uploads/nuggets_frango.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 8, Nome = "Salada Caesar com Frango", Descricao = "Salada fresca de alface romana com frango grelhado, croutons crocantes e queijo parmesão ralado, tudo regado com molho Caesar cremoso.", Preco = 18.00m, NomeArquivoUpload = "/uploads/salada_caesar_frango.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 9, Nome = "Pizza Pepperoni Individual", Descricao = "Pizza individual com molho de tomate artesanal, fatias generosas de pepperoni, queijo mussarela derretido e massa fina e crocante.", Preco = 22.99m, NomeArquivoUpload = "/uploads/pizza_pepperoni.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 10, Nome = "Coxinhas de Frango com Catupiry", Descricao = "Clássicas coxinhas recheadas com frango desfiado temperado e cremoso catupiry, envolvidas por uma massa dourada e crocante.", Preco = 9.50m, NomeArquivoUpload = "/uploads/coxinhas_frango_catupiry.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 11, Nome = "Chá Gelado de Limão", Descricao = "Bebida refrescante feita com chá preto gelado, adoçado na medida certa e com um toque de limão fresco. Ideal para acompanhar seu lanche.", Preco = 6.50m, NomeArquivoUpload = "/uploads/cha_gelado_limao.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 12, Nome = "Sorvete de Baunilha com Calda de Caramelo", Descricao = "Sorvete cremoso de baunilha servido com uma deliciosa calda de caramelo, perfeito para os amantes de sobremesas doces e suaves.", Preco = 8.75m, NomeArquivoUpload = "/uploads/sorvete_baunilha_caramelo.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 13, Nome = "Hambúrguer Vegano", Descricao = "Hambúrguer 100% vegano, feito com proteína vegetal, alface, tomate, cebola roxa e maionese vegana, servido em pão integral.", Preco = 19.99m, NomeArquivoUpload = "/uploads/hamburguer_vegano.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 14, Nome = "Pastel de Carne", Descricao = "Pastel frito recheado com carne moída temperada e azeitonas, envolto em uma massa crocante e dourada. Um lanche clássico e saboroso.", Preco = 7.50m, NomeArquivoUpload = "/uploads/pastel_carne.jpg", FichaTecnicaId = 1 },
                new Produto { Id = 15, Nome = "Cachorro-Quente Especial", Descricao = "Pão de hot-dog macio com salsicha grelhada, coberta com molho de tomate caseiro, queijo cheddar derretido, batata palha e milho verde.", Preco = 13.99m, NomeArquivoUpload = "/uploads/cachorro_quente_especial.jpg", FichaTecnicaId = 1 }
            );
        }
    }
}
