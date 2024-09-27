using AppAPS.Data;
using AppAPS.Entities;
using AppAPS.Interfaces;
using AppAPS.Services.Model;
using Microsoft.EntityFrameworkCore;

namespace AppAPS.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly ApplicationDbContext _context;
        private readonly SessaoUsuario _sessaoUsuario;
        public PedidoService(ApplicationDbContext context, SessaoUsuario sessaoUsuario)
        {
            _context = context;
            _sessaoUsuario = sessaoUsuario;
        }

        public async Task<List<Pedido>> GetAllPedidos()
        {
            return await _context.Pedido.ToListAsync();
        }

        public async Task<List<Pedido>> GetAllPedidosDiaAtual()
        {
            return await _context.Pedido.Where(pedido => pedido.DataAbertura.Date == DateTime.Today).ToListAsync();
        }

        public async Task<List<Pedido>> GetPedidosEntregadorDiaAtual()
        {
            return await _context.Pedido.Where(pedido => (pedido.Status == StatusPedido.ProntoParaEntrega || pedido.Status == StatusPedido.EmTransito) && pedido.DataAbertura.Date == DateTime.Today).ToListAsync();
        }

        public async Task<List<Pedido>> GetPedidosClienteDiaAtual(string cpf)
        {
            return await _context.Pedido.Where(pedido => (pedido.CPF == cpf) && pedido.DataAbertura.Date == DateTime.Today).ToListAsync();
        }

        public async Task<Pedido> GetByIdPedidos(int id)
        {
            return await _context.Pedido.Include(Pedido => Pedido).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pedido> InserirPedido(Pedido Pedido)
        {
            var entityEntry = await _context.Pedido.AddAsync(Pedido);
            Save();
            return entityEntry.Entity;
        }

        public async Task<bool> DeletarPedidos(List<Pedido> Pedidos)
        {
            _context.Pedido.RemoveRange(Pedidos);
            Save();
            return true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
