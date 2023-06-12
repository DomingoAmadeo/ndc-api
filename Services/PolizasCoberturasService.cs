using AdminPolizasAPI;
using AdminPolizasAPI.Entidades;
using AdminPolizasAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdminPolizasAPI.Services
{
    public class PolizasCoberturasService : IPolizasCoberturasService
    {
        private readonly ApplicationDbContext _context;

        public PolizasCoberturasService(ApplicationDbContext context)
        {
            _context = context;        
        }

        public async Task<List<PolizasCoberturasDTO>> GetAllPolizasCoberturas()
        {
            var result = new List<PolizasCoberturasDTO>();
            var polizasCoberturas = await _context.PolizasCoberturas
                                                    .Include("Poliza")
                                                    .Include("Cobertura")
                                                    .ToListAsync();

            foreach (var polizaCobertura in polizasCoberturas)
            {

                result.Add(new PolizasCoberturasDTO
                    {
                        Id = polizaCobertura.Id,
                        CoberturaId = polizaCobertura.CoberturaId,
                        Cobertura = new CoberturaDTO { Id = polizaCobertura.Cobertura.Id, Nombre = polizaCobertura.Cobertura.Nombre },
                        PolizaId = polizaCobertura.PolizaId,
                        Poliza = new PolizaDTO { Id = polizaCobertura.Poliza.Id, Nombre = polizaCobertura.Poliza.Nombre },
                        MontoAsegurado = polizaCobertura.MontoAsegurado
                    }
                );
            }
            return result;
        }

        public async Task<PolizasCoberturasDTO?> GetPolizasCoberturas(int id)
        {
            var polizasCoberturas = await _context.PolizasCoberturas
                                                    .Include("Poliza")
                                                    .Include("Cobertura")
                                                    .FirstOrDefaultAsync(pc => pc.Id == id);
            return polizasCoberturas == null ? null : new PolizasCoberturasDTO
            {
                Id = polizasCoberturas.Id,
                CoberturaId = polizasCoberturas.CoberturaId,
                Cobertura = new CoberturaDTO { Id = polizasCoberturas.Cobertura.Id, Nombre = polizasCoberturas.Cobertura.Nombre },
                PolizaId = polizasCoberturas.PolizaId,
                Poliza = new PolizaDTO { Id = polizasCoberturas.Poliza.Id, Nombre = polizasCoberturas.Poliza.Nombre },
                MontoAsegurado = polizasCoberturas.MontoAsegurado
            };
        }

        public async Task<int> AddPolizasCoberturas(PolizasCoberturasForAddDTO newPolizasCoberturas)
        {
            var polizasCoberturas = new PolizasCoberturas
            {
                CoberturaId = newPolizasCoberturas.CoberturaId,
                PolizaId = newPolizasCoberturas.PolizaId,
                MontoAsegurado = newPolizasCoberturas.MontoAsegurado
            };

            _context.PolizasCoberturas.Add(polizasCoberturas);
            await _context.SaveChangesAsync();

            return polizasCoberturas.Id;
        }

        public async Task<bool> AddPolizasCoberturasDetalle(PolizasCoberturasDetalleForAddDTO newPolizasCoberturasDetalle)
        {
            foreach (var detalle in newPolizasCoberturasDetalle.Detalle)
            {
                var polizasCoberturas = new PolizasCoberturas
                {
                    PolizaId = newPolizasCoberturasDetalle.PolizaId,
                    CoberturaId = detalle.CoberturaId,
                    MontoAsegurado = detalle.MontoAsegurado
                };
                _context.PolizasCoberturas.Add(polizasCoberturas);
            }
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<int> UpdatePolizasCoberturas(PolizasCoberturasDTO updatedPolizasCoberturas)
        {
            var polizasCoberturas = await _context.PolizasCoberturas.FindAsync(updatedPolizasCoberturas.Id);
            if (polizasCoberturas == null) return -1;

            polizasCoberturas.PolizaId = updatedPolizasCoberturas.PolizaId;
            polizasCoberturas.CoberturaId = updatedPolizasCoberturas.CoberturaId;
            polizasCoberturas.MontoAsegurado = updatedPolizasCoberturas.MontoAsegurado;
            await _context.SaveChangesAsync();

            return updatedPolizasCoberturas.Id;
        }

        public async Task<bool> DeletePolizasCoberturas(int id)
        {
            var polizasCoberturas = await _context.PolizasCoberturas.FindAsync(id);
            if (polizasCoberturas == null) return false;

            _context.PolizasCoberturas.Remove(polizasCoberturas);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
