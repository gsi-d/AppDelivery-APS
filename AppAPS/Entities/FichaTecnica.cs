using System.ComponentModel.DataAnnotations;

namespace AppAPS.Entities
{
    public class FichaTecnica
    {
        public int Id { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
