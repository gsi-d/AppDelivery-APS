using AppAPS.Data;
using AppAPS.Entities;
using AppAPS.Interfaces;
using AppAPS.Services.Model;
using Microsoft.EntityFrameworkCore;

namespace AppAPS.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApplicationDbContext _context;
        private readonly SessaoUsuario _sessaoUsuario;
        public ProdutoService(ApplicationDbContext context, SessaoUsuario sessaoUsuario)
        {
            _context = context;
            _sessaoUsuario = sessaoUsuario;
        }

        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _context.Produto.Include(produto => produto.FichaTecnica).ToListAsync();
        }

        public async Task<Produto> GetByIdProdutos(int id)
        {
            return await _context.Produto.Include(produto => produto.FichaTecnica).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Produto>> GetSomenteProdutos()
        {
            return await _context.Produto.Include(produto => produto.FichaTecnica).Where(produto => !produto.Ingrediente).ToListAsync();
        }

        public async Task<Produto> InserirProduto(Produto produto)
        {
            var entityEntry = await _context.Produto.AddAsync(produto);
            Save();
            return entityEntry.Entity;
        }

        public async Task<bool> DeletarProdutos(List<Produto> produtos)
        {
            _context.Produto.RemoveRange(produtos);
            Save();
            return true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
