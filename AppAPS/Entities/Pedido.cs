using AppAPS.Entities.Enum;

namespace AppAPS.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Rua { get; set; }
        public Bairro Bairro { get; set; }
        public List<PedidoItem> Itens { get; set; }
        public StatusPedido Status { get; set; }
    }
}
