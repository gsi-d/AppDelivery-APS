using System.ComponentModel.DataAnnotations;

namespace AppAPS.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do produto é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descrição do produto é obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Preço do produto é obrigatório.")]
        public decimal Preco { get; set; }
        public bool Ingrediente { get; set; }
        public string NomeArquivoUpload { get; set; }
        public int IdFichaTecnica { get; set; }
        public virtual FichaTecnica FichaTecnica { get; set; }
    }
}
