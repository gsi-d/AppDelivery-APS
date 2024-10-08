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
        private DateTime DataDe = DateTime.MinValue;
        private DateTime DataAte = DateTime.MaxValue;
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
            return await _context.Pedido.Include(Pedido => Pedido.Itens).ThenInclude(item => item.Produto).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pedido> InserirPedido(Pedido Pedido)
        {
            try
            {
                var entityEntry = await _context.Pedido.AddAsync(Pedido);
                Save();
                return entityEntry.Entity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Pedido> AlterarPedido(Pedido Pedido)
        {
            var entityEntry = _context.Pedido.Update(Pedido);
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
            return itensGrafico;
        }

        public async Task<List<ItemGrafico>> GetPedidosPorBairroComPeriodo(PeriodoFiltro periodo)
        {
            DefinePeriodoFiltragem(periodo);

            List<Pedido> resultado = await _context.Pedido.Where(pedido => pedido.DataAbertura >= DataDe && pedido.DataAbertura <= DataAte).AsNoTracking().ToListAsync();
            List<ItemGrafico> itensGrafico = new List<ItemGrafico>();
            resultado.DistinctBy(pedido => pedido.Bairro).ToList().ForEach(pedido => itensGrafico.Add(new ItemGrafico { Indicador = EnumHelper.GetEnumDescription(pedido.Bairro), Valor = resultado.Where(pedidoAux => pedidoAux.Bairro == pedido.Bairro).Count() }));
            return itensGrafico;
        }

        public async Task<List<ItemGrafico>> GetComparativoPedidosPorBairroMesAnterior(Bairro bairro)
        {
            DateTime hoje = DateTime.Today;
            DateTime primeiroDiaMesAnterior = new DateTime(hoje.Year, hoje.Month, 1).AddMonths(-1);
            DateTime ultimoDiaMesAnterior = new DateTime(hoje.Year, hoje.Month, 1).AddDays(-1);

            List<ItemGrafico> listaItensGrafico = new List<ItemGrafico>();

            for (DateTime data = primeiroDiaMesAnterior; data <= ultimoDiaMesAnterior; data = data.AddDays(1))
            {
                // Adicionar o dia e o mês na lista
                listaItensGrafico.Add(new ItemGrafico { Periodo = data.ToString("dd/MM") });
            }

            List<Pedido> resultado = await _context.Pedido.Where(pedido => pedido.Bairro == bairro &&
                     pedido.DataAbertura.Date >= primeiroDiaMesAnterior &&
                     pedido.DataAbertura.Date <= ultimoDiaMesAnterior).AsNoTracking().ToListAsync();

            List<ItemGrafico> itensGraficoVindoBanco = _mapper.Map<List<ItemGrafico>>(resultado);
            foreach (ItemGrafico itemVindoBanco in itensGraficoVindoBanco)
            {
                listaItensGrafico.Where(item => item.Periodo == itemVindoBanco.Periodo).ToList().ForEach(item => item.Valor++);
            }
            return listaItensGrafico;
        }

        public async Task<int> GetQtdPedidosDiaAtual()
        {
            int qtdPedidos = await _context.Pedido.Where(pedido => pedido.DataAbertura.Date == DateTime.Today).AsNoTracking().CountAsync();
            return qtdPedidos;
        }

        public async Task<int> GetQtdPedidosDiaAtualPorStatus(StatusPedido status)
        {
            int qtdPedidos = await _context.Pedido.Where(pedido => pedido.DataAbertura.Date == DateTime.Today && pedido.Status == status).AsNoTracking().CountAsync();
            return qtdPedidos;
        }

        public async Task<int> GetQtdPedidosDiaAnterior()
        {
            int qtdPedidos = await _context.Pedido.Where(pedido => pedido.DataAbertura.Date == DateTime.Today.AddDays(-1)).AsNoTracking().CountAsync();
            return qtdPedidos;
        }

        public async Task<decimal> GetTotalVendasDiaAtual()
        {
            decimal qtdPedidos = await _context.Pedido.Where(pedido => pedido.DataAbertura.Date == DateTime.Today).AsNoTracking().SumAsync(pedido => pedido.Valor);
            return qtdPedidos;
        }

        public async Task<decimal> GetTotalVendasDiaAnterior()
        {
            decimal qtdPedidos = await _context.Pedido.Where(pedido => pedido.DataAbertura.Date == DateTime.Today.AddDays(-1)).AsNoTracking().SumAsync(pedido => pedido.Valor);
            return qtdPedidos;
        }

        public void DefinePeriodoFiltragem(PeriodoFiltro periodo)
        {
            DateTime dataAtual = DateTime.Now;

            switch (periodo)
            {
                case PeriodoFiltro.Hoje:
                    DataDe = dataAtual.Date;
                    DataAte = dataAtual.Date.AddDays(1).AddTicks(-1);
                    break;
                case PeriodoFiltro.SemanaAtual:
                    DataDe = dataAtual.Date.AddDays(-(int)dataAtual.DayOfWeek);
                    DataAte = DataDe.AddDays(7).AddTicks(-1);
                    break;
                case PeriodoFiltro.MesAtual:
                    DataDe = new DateTime(dataAtual.Year, dataAtual.Month, 1);
                    DataAte = DataDe.AddMonths(1).AddTicks(-1);
                    break;
                case PeriodoFiltro.MesAnterior:
                    DataDe = new DateTime(dataAtual.Year, dataAtual.Month, 1).AddMonths(-1);
                    DataAte = DataDe.AddMonths(1).AddTicks(-1);
                    break;
                case PeriodoFiltro.AnoAtual:
                    DataDe = new DateTime(dataAtual.Year, 1, 1);
                    DataAte = new DateTime(dataAtual.Year + 1, 1, 1).AddTicks(-1);
                    break;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
