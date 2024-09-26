using System.ComponentModel.DataAnnotations;

namespace AppAPS.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do cliente é obrigatório.")]
        public string Cliente { get; set; }
        [Required(ErrorMessage = "Rua é obrigatória.")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Forma de pagamento é obrigatória.")]
        public FormaPagamento FormaPagamento { get; set; }
        [Required(ErrorMessage = "Forma de entrega é obrigatória.")]
        public FormaEntrega FormaEntrega { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório.")]
        public Bairro Bairro { get; set; }
        public StatusPedido Status { get; set; }
        // Propriedade auxiliar para o binding com @bind-Value
        public string? Observacoes { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public List<PedidoItem> Itens { get; set; } = new List<PedidoItem>();

        public void DadosInclusao()
        {
            Random random = new Random();
            this.Id = random.Next();
            this.Status = StatusPedido.Confirmado;
            this.DataAbertura = DateTime.Now;
            this.DataUltimaAtualizacao = DateTime.Now;
        }
    }
}