using System.ComponentModel.DataAnnotations;

namespace AppAPS.Entities
{
    public class FichaTecnica
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }
        public List<Produto> Ingredientes { get; set; }
    }
}
