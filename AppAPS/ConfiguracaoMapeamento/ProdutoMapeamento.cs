using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppAPS.Entities;
using System.Reflection.Emit;

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

            builder.HasData(
        new Produto
        {
            Id = 1,
            Nome = "Cheeseburger Duplo",
            Descricao = "Dois suculentos hambúrgueres de carne bovina grelhados, com queijo cheddar derretido, alface fresca, tomate maduro e molho especial. Tudo isso dentro de um pão macio com gergelim.",
            Preco = 17.50m,
            NomeArquivoUpload = "/uploads/cheeseburger_duplo.jpg"
        },
        new Produto
        {
            Id = 2,
            Nome = "Batata Frita Grande",
            Descricao = "Batatas fritas crocantes e douradas por fora, macias por dentro, temperadas na medida certa. Acompanhamento perfeito para qualquer refeição.",
            Preco = 8.99m,
            NomeArquivoUpload = "/uploads/batata_frita_grande.jpeg"
        },
        new Produto
        {
            Id = 3,
            Nome = "Frango Empanado Crocante",
            Descricao = "Peitos de frango suculentos e temperados, empanados em uma crosta crocante de ervas e especiarias. Perfeito para os amantes de frango frito.",
            Preco = 15.00m,
            NomeArquivoUpload = "/uploads/frango_empanado.jpg"
        },
        new Produto
        {
            Id = 4,
            Nome = "Milkshake de Chocolate",
            Descricao = "Milkshake cremoso de chocolate, feito com sorvete artesanal de alta qualidade, servido com chantilly e cobertura de chocolate.",
            Preco = 12.50m,
            NomeArquivoUpload = "/uploads/milkshake_chocolate.jpg"
        },
        new Produto
        {
            Id = 5,
            Nome = "Wrap de Frango Grelhado",
            Descricao = "Tortilla macia recheada com pedaços de frango grelhado, alface, tomate, queijo cheddar e molho ranch. Uma opção leve e deliciosa.",
            Preco = 14.75m,
            NomeArquivoUpload = "/uploads/wrap_frango_grelhado.jpg"
        },
        new Produto
        {
            Id = 6,
            Nome = "Combo Bacon Duplo",
            Descricao = "Hambúrguer com dois suculentos hambúrgueres de carne bovina, bacon crocante, queijo cheddar derretido, cebolas caramelizadas e molho especial. Acompanha batata frita e refrigerante.",
            Preco = 25.99m,
            NomeArquivoUpload = "/uploads/combo_bacon_duplo.jpg"
        },
        new Produto
        {
            Id = 7,
            Nome = "Nuggets de Frango",
            Descricao = "Pequenos pedaços de frango empanado, crocantes e suculentos, servidos com seu molho preferido. Ideal como lanche rápido ou acompanhamento.",
            Preco = 10.99m,
            NomeArquivoUpload = "/uploads/nuggets_frango.jpg"
        },
        new Produto
        {
            Id = 8,
            Nome = "Salada Caesar com Frango",
            Descricao = "Salada fresca de alface romana com frango grelhado, croutons crocantes e queijo parmesão ralado, tudo regado com molho Caesar cremoso.",
            Preco = 18.00m,
            NomeArquivoUpload = "/uploads/salada_caesar_frango.jpg"
        },
        new Produto
        {
            Id = 9,
            Nome = "Pizza Pepperoni Individual",
            Descricao = "Pizza individual com molho de tomate artesanal, fatias generosas de pepperoni, queijo mussarela derretido e massa fina e crocante.",
            Preco = 22.99m,
            NomeArquivoUpload = "/uploads/pizza_pepperoni.jpg"
        },
        new Produto
        {
            Id = 10,
            Nome = "Coxinhas de Frango com Catupiry",
            Descricao = "Clássicas coxinhas recheadas com frango desfiado temperado e cremoso catupiry, envolvidas por uma massa dourada e crocante.",
            Preco = 9.50m,
            NomeArquivoUpload = "/uploads/coxinhas_frango_catupiry.jpg"
        },
        new Produto
        {
            Id = 12,
            Nome = "Sorvete de Baunilha com Calda de Caramelo",
            Descricao = "Sorvete cremoso de baunilha servido com uma deliciosa calda de caramelo, perfeito para os amantes de sobremesas doces e suaves.",
            Preco = 8.75m,
            NomeArquivoUpload = "/uploads/sorvete_baunilha_caramelo.jpg"
        },
        new Produto
        {
            Id = 13,
            Nome = "Hambúrguer Vegano",
            Descricao = "Hambúrguer 100% vegano, feito com proteína vegetal, alface, tomate, cebola roxa e maionese vegana, servido em pão integral.",
            Preco = 19.99m,
            NomeArquivoUpload = "/uploads/hamburguer_vegano.jpg"
        },
        new Produto
        {
            Id = 14,
            Nome = "Pastel de Carne",
            Descricao = "Pastel frito recheado com carne moída temperada e azeitonas, envolto em uma massa crocante e dourada. Um lanche clássico e saboroso.",
            Preco = 7.50m,
            NomeArquivoUpload = "/uploads/pastel_carne.jpg"
        },
        new Produto
        {
            Id = 15,
            Nome = "Cachorro-Quente Especial",
            Descricao = "Pão de hot-dog macio com salsicha grelhada, coberta com molho de tomate caseiro, queijo cheddar derretido, batata palha e milho verde.",
            Preco = 13.99m,
            NomeArquivoUpload = "/uploads/cachorro_quente_especial.jpg"
        },
        new Produto
        {
            Id = 16,
            Nome = "Coca-Cola 2l",
            Descricao = "Refrigerante gaseificado, sabor cola, servido gelado.",
            Preco = 5.00m,
            NomeArquivoUpload = "/uploads/coca_cola.jpg",
            Bebida = true
        },
        new Produto
        {
            Id = 17,
            Nome = "Guaraná Antarctica 2l",
            Descricao = "Refrigerante sabor guaraná, tradicional e refrescante.",
            Preco = 5.00m,
            NomeArquivoUpload = "/uploads/guarana_antarctica.jpeg",
            Bebida = true
        },
        new Produto
        {
            Id = 18,
            Nome = "Fanta Laranja 2l",
            Descricao = "Refrigerante gaseificado, sabor laranja, com alta refrescância.",
            Preco = 5.00m,
            NomeArquivoUpload = "/uploads/fanta_laranja.jpeg",
            Bebida = true
        },
        new Produto
        {
            Id = 19,
            Nome = "Sprite 2l",
            Descricao = "Refrigerante sabor limão, leve e refrescante, servido gelado.",
            Preco = 5.00m,
            NomeArquivoUpload = "/uploads/sprite.jpeg",
            Bebida = true
        },
        new Produto
        {
            Id = 20,
            Nome = "Suco de Laranja",
            Descricao = "Suco natural de laranja, sem açúcar, servido gelado.",
            Preco = 7.00m,
            NomeArquivoUpload = "/uploads/suco_laranja.jpg",
            Bebida = true
        },
        new Produto
        {
            Id = 21,
            Nome = "Água Mineral",
            Descricao = "Água mineral natural, servida gelada ou em temperatura ambiente.",
            Preco = 3.50m,
            NomeArquivoUpload = "/uploads/agua_mineral.jpg",
            Bebida = true
        }
    );
        }
    }
}
