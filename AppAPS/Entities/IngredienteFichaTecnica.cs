

using System.ComponentModel.DataAnnotations.Schema;

namespace AppAPS.Entities
{
    public class IngredienteFichaTecnica
    {
        public int Id { get; set; }
        public Ingredientes Ingrediente { get; set; }
        public int Quantidade { get; set; }
        public Medida Medida { get; set; }
        [NotMapped]
        public bool isUnidade { get; set; }
        [NotMapped]
        public bool isGrama { get; set; }
        [NotMapped]
        public bool isML { get; set; }
        public int FichaTecnicaId { get; set; }
        public virtual FichaTecnica FichaTecnica { get; set; }
    }
}
