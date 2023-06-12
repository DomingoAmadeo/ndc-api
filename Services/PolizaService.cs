using AdminPolizasAPI.Entidades;
using AdminPolizasAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdminPolizasAPI.Services
{
    public class PolizaService : IPolizaService
    {
        private readonly ApplicationDbContext _context;

        public PolizaService(ApplicationDbContext context)
        {
            _context = context;        
        }

        public async Task<List<PolizaDTO>> GetAllPolizas()
        {
            var result = new List<PolizaDTO>();
            var polizas = await _context.Polizas.ToListAsync();

            foreach (var poliza in polizas)
            {

                result.Add(new PolizaDTO
                    {
                        Id = poliza.Id,
                        Nombre = poliza.Nombre
                    }
                );
            }

            return result;
        }

        public async Task<List<PolizaDetalleDTO>> GetAllPolizaDetalle()
        {
            var result = new List<PolizaDetalleDTO>();
            var polizas = await _context.Polizas.Include("PolizasCoberturas.Cobertura").Where(p => p.PolizasCoberturas.Count > 0).ToListAsync();

            foreach (var poliza in polizas)
            {
                var polizasCoberturas = new List<PolizasCoberturasDTO>();

                foreach (var pc in poliza.PolizasCoberturas)
                {
                    polizasCoberturas.Add( new PolizasCoberturasDTO
                        {
                            Id = pc.Id,
                            CoberturaId = pc.CoberturaId,
                            Cobertura = new CoberturaDTO
                                {
                                    Id = pc.Cobertura.Id,
                                    Nombre = pc.Cobertura.Nombre,
                                    Monto = pc.MontoAsegurado
                                },
                            MontoAsegurado = pc.MontoAsegurado
                        }
                    );
                }

                result.Add(new PolizaDetalleDTO
                    {
                        Id = poliza.Id,
                        Nombre = poliza.Nombre,
                        PolizasCoberturas = polizasCoberturas
                    }
                );
            }

            return result;
        }

        public async Task<PolizaDTO?> GetPoliza(int id)
        {
            var poliza = await _context.Polizas.FindAsync(id);
            return poliza == null ? null : new PolizaDTO
            {
                Id = poliza.Id,
                Nombre = poliza.Nombre
            };
        }

        public async Task<int> AddPoliza(PolizaForAddDTO newPoliza)
        {
            var poliza = new Poliza
            {
                Nombre = newPoliza.Nombre
            };

            _context.Polizas.Add(poliza);
            await _context.SaveChangesAsync();

            return poliza.Id;
        }

        public async Task<int> UpdatePoliza(PolizaDTO updatedPoliza)
        {
            var poliza = await _context.Polizas.FindAsync(updatedPoliza.Id);
            if (poliza == null) return -1;

            poliza.Nombre = updatedPoliza.Nombre;
            await _context.SaveChangesAsync();

            return updatedPoliza.Id;
        }

        public async Task<bool> DeletePoliza(int id)
        {
            var poliza = await _context.Polizas.FindAsync(id);
            if (poliza == null) return false;

            _context.Polizas.Remove(poliza);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
