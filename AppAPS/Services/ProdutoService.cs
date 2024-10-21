using AppAPS.Data;
using AppAPS.Entities;
using AppAPS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppAPS.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApplicationDbContext _context;
        public ProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _context.Produto.Include(produto => produto.FichaTecnica).ThenInclude(ficha => ficha.Ingredientes).ToListAsync();
        }

        public async Task<Produto?> GetByIdProduto(int id)
        {
            return await _context.Produto.Include(produto => produto.FichaTecnica).ThenInclude(ficha => ficha.Ingredientes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Produto> InserirProduto(Produto produto)
        {
            var entityEntry = await _context.Produto.AddAsync(produto);
            Save();
            return entityEntry.Entity;
        }

        public async Task<Produto> AlterarProduto(Produto produto)
        {
            var entityEntry = _context.Produto.Update(produto);
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
