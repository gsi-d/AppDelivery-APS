using System.ComponentModel.DataAnnotations;

namespace AppAPS.Entities
{
    public class ProdutoFicha
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Produto é obrigatório.")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "Ficha Técnica é obrigatória.")]
        public int FichaTecnicaId { get; set; }
        public FichaTecnica FichaTecnica { get; set; }
    }
}
