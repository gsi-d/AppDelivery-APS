using AppAPS.Entities;

namespace AppAPS.Interfaces
{
    public interface ISessaoUsuario
    {
        public int UsuarioId { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<FichaTecnica> FichasTecnicas { get; set; }
    }
}
