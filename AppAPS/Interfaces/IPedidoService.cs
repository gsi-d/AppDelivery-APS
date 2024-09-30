using AppAPS.DTOs;
using AppAPS.Entities;

namespace AppAPS.Interfaces
{
    public interface IPedidoService
    {
        Task<List<Pedido>> GetAllPedidos();
        Task<List<Pedido>> GetAllPedidosDiaAtual();
        Task<List<Pedido>> GetPedidosEntregadorDiaAtual();
        Task<List<Pedido>> GetPedidosClienteDiaAtual(string cpf);
        Task<Pedido> GetByIdPedidos(int id);
        Task<Pedido> InserirPedido(Pedido Pedido);
        Task<bool> DeletarPedidos(List<Pedido> Pedidos);
        Task<List<ItemGrafico>> GetPedidosPorBairro();
        Task<int> GetQtdPedidosDiaAtual();
        Task<int> GetQtdPedidosDiaAnterior();
        Task<List<ItemGrafico>> GetComparativoPedidosPorBairroMesAnterior(Bairro bairro);
    }
}
