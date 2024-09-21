using System.ComponentModel.DataAnnotations;

namespace AppAPS.Entities
{
    public class FichaTecnica
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Descrição do produto é obrigatório.")]
        public string Descricao { get; set; }
        public List<Produto> Ingredientes { get; set; }
    }
}
