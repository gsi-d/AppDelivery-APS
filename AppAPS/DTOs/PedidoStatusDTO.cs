using AppAPS.Entities;

namespace AppAPS.DTOs
{
    public class PedidoStatusDTO
    {
        public Pedido Pedido { get; set; }
        public StatusPedido NovoStatus { get; set; }
    }
}
