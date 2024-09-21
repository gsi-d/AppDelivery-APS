using AppAPS.Data;
using AppAPS.Entities;
using AppAPS.Interfaces;
using AppAPS.Services.Model;

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

        public List<Produto> GetAllProdutos()
        {
            try
            {
                //return _context.Produto.ToList();
                return _sessaoUsuario.Produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto GetByIdProdutos(int id)
        {
            return _sessaoUsuario.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public List<Produto> GetSomenteProdutos()
        {
            return _sessaoUsuario.Produtos.Where(produto => !produto.Ingrediente).ToList();
        }

        public Produto InserirProduto(Produto produto)
        {
            try
            {
                //var entityEntry = _context.Produto.Add(produto);
                //Save();
                //return entityEntry.Entity;
                _sessaoUsuario.Produtos.Add(produto);
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeletarProdutos(List<Produto> produtos)
        {
            try
            {
                //var entityEntry = _context.Produto.Add(produto);
                //Save();
                //return entityEntry.Entity;
                foreach (Produto produto in produtos)
                {
                    _sessaoUsuario.Produtos.Remove(produto);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
