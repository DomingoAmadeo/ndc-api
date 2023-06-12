using AdminPolizasAPI.Entidades;
using AdminPolizasAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdminPolizasAPI.Services
{
    public class CoberturaService : ICoberturaService
    {
        private readonly ApplicationDbContext _context;

        public CoberturaService(ApplicationDbContext context)
        {
            _context = context;        
        }

        public async Task<List<CoberturaDTO>> GetAllCoberturas()
        {
            var result = new List<CoberturaDTO>();
            var coberturas = await _context.Coberturas.ToListAsync();

            foreach (var cobertura in coberturas)
            {

                result.Add(new CoberturaDTO
                    {
                        Id = cobertura.Id,
                        Nombre = cobertura.Nombre
                    }
                );
            }

            return result;
        }
        public async Task<CoberturaDTO?> GetCobertura(int id)
        {
            var cobertura = await _context.Coberturas.FindAsync(id);
            return cobertura == null ? null : new CoberturaDTO
            {
                Id = cobertura.Id,
                Nombre = cobertura.Nombre
            };
        }

        public async Task<int> AddCobertura(CoberturaForAddDTO newCobertura)
        {
            var cobertura = new Cobertura
            {
                Nombre = newCobertura.Nombre
            };

            _context.Coberturas.Add(cobertura);
            await _context.SaveChangesAsync();

            return cobertura.Id;
        }

        public async Task<int> UpdateCobertura(CoberturaDTO updatedCobertura)
        {
            var cobertura = await _context.Coberturas.FindAsync(updatedCobertura.Id);
            if (cobertura == null) return -1;

            cobertura.Nombre = updatedCobertura.Nombre;
            await _context.SaveChangesAsync();

            return updatedCobertura.Id;
        }

        public async Task<bool> DeleteCobertura(int id)
        {
            var cobertura = await _context.Coberturas.FindAsync(id);
            if (cobertura == null) return false;

            _context.Coberturas.Remove(cobertura);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
