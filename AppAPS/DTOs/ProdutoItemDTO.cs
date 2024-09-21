using AppAPS.Entities;

namespace AppAPS.DTOs
{
    public class ProdutoItemDTO : Produto
    {
        public int Quantidade { get; set; }
        public bool Selecionado { get; set; }
    }
}
