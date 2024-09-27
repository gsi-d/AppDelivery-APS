using AppAPS.Entities;

namespace AppAPS.Interfaces
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetAllProdutos();
        Task<Produto?> GetByIdProduto(int id);
        Task<Produto> InserirProduto(Produto produto);
        Task<bool> DeletarProdutos(List<Produto> produtos);
    }
}
