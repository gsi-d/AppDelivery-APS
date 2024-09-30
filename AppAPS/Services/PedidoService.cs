using AppAPS.Data;
using AppAPS.DTOs;
using AppAPS.Entities;
using AppAPS.Interfaces;
using AppAPS.Services.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppAPS.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly ApplicationDbContext _context;
        private readonly SessaoUsuario _sessaoUsuario;
        private readonly IMapper _mapper;
        public PedidoService(ApplicationDbContext context, SessaoUsuario sessaoUsuario, IMapper mapper)
        {
            _context = context;
            _sessaoUsuario = sessaoUsuario;
            _mapper = mapper;
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

        public async Task<List<ItemGrafico>> GetPedidosPorBairro()
        {
            List<Pedido> resultado = await _context.Pedido.AsNoTracking().ToListAsync();
            List<ItemGrafico> itensGrafico = new List<ItemGrafico>();
            resultado.DistinctBy(pedido => pedido.Bairro).ToList().ForEach(pedido => itensGrafico.Add(new ItemGrafico { Indicador = EnumHelper.GetEnumDescription(pedido.Bairro), Valor = resultado.Where(pedidoAux => pedidoAux.Bairro == pedido.Bairro).Count() }));
            //List<ItemGrafico> itensGrafico = _mapper.Map<List<ItemGrafico>>(resultado);
            return itensGrafico;
        }

        public async Task<List<ItemGrafico>> GetComparativoPedidosPorBairroMesAnterior(Bairro bairro)
        {
            DateTime hoje = DateTime.Today;
            DateTime primeiroDiaMesAnterior = new DateTime(hoje.Year, hoje.Month, 1).AddMonths(-1);
            DateTime ultimoDiaMesAnterior = new DateTime(hoje.Year, hoje.Month, 1).AddDays(-1);

            List<Pedido> resultado = await _context.Pedido.Where(pedido => pedido.Bairro == bairro &&
                     pedido.DataAbertura.Date >= primeiroDiaMesAnterior &&
                     pedido.DataAbertura.Date <= ultimoDiaMesAnterior).AsNoTracking().ToListAsync();

            List<ItemGrafico> itensGrafico = _mapper.Map<List<ItemGrafico>>(resultado);
            return itensGrafico;
        }

        public async Task<int> GetQtdPedidosDiaAtual()
        {
            int qtdPedidos = await _context.Pedido.Where(pedido => pedido.DataAbertura.Date == DateTime.Today).AsNoTracking().CountAsync();
            return qtdPedidos;
        }

        public async Task<int> GetQtdPedidosDiaAnterior()
        {
            int qtdPedidos = await _context.Pedido.Where(pedido => pedido.DataAbertura.Date == DateTime.Today.AddDays(-1)).AsNoTracking().CountAsync();
            return qtdPedidos;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
