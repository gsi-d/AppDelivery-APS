

using AppAPS.Entities;

namespace AppAPS.Interfaces
{
    public interface IFichaTecnicaService
    {
        Task<List<FichaTecnica>> GetAllFichaTecnicas();
        Task<FichaTecnica?> GetByIdFichaTecnica(int id);
        Task<FichaTecnica> InserirFichaTecnica(FichaTecnica FichaTecnica);
        Task<bool> DeletarFichaTecnicas(List<FichaTecnica> FichaTecnicas);
    }
}
