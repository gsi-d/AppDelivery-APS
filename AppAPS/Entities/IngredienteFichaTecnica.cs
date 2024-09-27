

namespace AppAPS.Entities
{
    public class IngredienteFichaTecnica
    {
        public int Id { get; set; }
        public Ingredientes Ingrediente { get; set; }
        public int Quantidade { get; set; }
        public Medida Medida { get; set; }
        public int FichaTecnicaId { get; set; }
        public virtual FichaTecnica FichaTecnica { get; set; }
    }
}
