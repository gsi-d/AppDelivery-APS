using AppAPS.Data;
using AppAPS.Entities;
using AppAPS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppAPS.Services
{
    public class FichaTecnicaService : IFichaTecnicaService
    {
        private readonly ApplicationDbContext _context;
        public FichaTecnicaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FichaTecnica>> GetAllFichaTecnicas()
        {
            return await _context.FichaTecnica.ToListAsync();
        }

        public async Task<FichaTecnica?> GetByIdFichaTecnica(int id)
        {
            return await _context.FichaTecnica.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FichaTecnica> InserirFichaTecnica(FichaTecnica FichaTecnica)
        {
            var entityEntry = await _context.FichaTecnica.AddAsync(FichaTecnica);
            Save();
            return entityEntry.Entity;
        }

        public async Task<bool> DeletarFichaTecnicas(List<FichaTecnica> FichaTecnicas)
        {
            _context.FichaTecnica.RemoveRange(FichaTecnicas);
            Save();
            return true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
