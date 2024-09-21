using AppAPS.Entities;

namespace AppAPS.Interfaces
{
    public interface IProdutoService
    {
        List<Produto> GetAllProdutos();
        List<Produto> GetSomenteProdutos();
        Produto GetByIdProdutos(int id);
        Produto InserirProduto(Produto produto);
        bool DeletarProdutos(List<Produto> produtos);
    }
}
