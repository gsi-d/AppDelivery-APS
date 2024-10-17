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

            // Complemento - Opcional
            builder.Property(p => p.Complemento)
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

            builder.HasData(GeneratePedidos(600));
        }

        private List<Pedido> GeneratePedidos(int totalPedidos)
        {
            var pedidos = new List<Pedido>();
            var random = new Random();
            var hoje = DateTime.Today;

            for (int i = 1; i <= totalPedidos; i++)
            {
                var cliente = $"Cliente {i}";
                var cpf = random.Next(100000000, 999999999).ToString("D11"); // CPF com 11 dígitos
                var rua = $"Rua {i}";
                var bairro = (Bairro)random.Next(1, 29); // Enum Bairro de 1 a 28
                var formaPagamento = (FormaPagamento)random.Next(1, 5); // Enum FormaPagamento de 1 a 4
                var formaEntrega = (FormaEntrega)random.Next(1, 3); // Enum FormaEntrega de 1 a 2
                var statusPedido = random.NextDouble() > 0.8 ? (StatusPedido)random.Next(1, 4) : StatusPedido.Finalizado; // Enum StatusPedido

                var complemento = random.NextDouble() > 0.5 ? $"Complemento {i}" : null;

                DateTime dataAbertura;
                if (i <= 30)
                {
                    // Gerar data para o mês atual (outubro)
                    dataAbertura = hoje.AddDays(-random.Next(hoje.Day - 1));
                }
                else
                {
                    // Gerar data para o mês anterior (setembro)
                    dataAbertura = new DateTime(2024, 9, 1).AddDays(random.Next(0, 29));
                }

                var dataUltimaAtualizacao = dataAbertura.AddDays(-random.Next(1, 11));
                DateTime? dataFinalizacao = statusPedido == StatusPedido.Finalizado ? dataUltimaAtualizacao.AddDays(random.Next(1, 6)) : (DateTime?)null;

                var valor = Convert.ToDecimal(Math.Round(random.NextDouble() * 500 + 10, 2)); // Valor entre 10 e 510
                var taxaEntrega = Convert.ToDecimal(Math.Round(random.NextDouble() * 20 + 5, 2)); // Taxa entre 5 e 25

                pedidos.Add(new Pedido
                {
                    Id = i, // Certifique-se de que o campo Id seja incluído
                    Cliente = cliente,
                    CPF = cpf,
                    Rua = rua,
                    Bairro = bairro, // Valor do enum Bairro
                    FormaPagamento = formaPagamento, // Valor do enum FormaPagamento
                    FormaEntrega = formaEntrega, // Valor do enum FormaEntrega
                    Status = statusPedido, // Valor do enum StatusPedido
                    Complemento = complemento,
                    DataAbertura = dataAbertura,
                    DataUltimaAtualizacao = dataUltimaAtualizacao,
                    DataFinalizacao = dataFinalizacao,
                    Valor = valor,
                    TaxaEntrega = taxaEntrega
                });
            }

            return pedidos;
        }


    }
}
