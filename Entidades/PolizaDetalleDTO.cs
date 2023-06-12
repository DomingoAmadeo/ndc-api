using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPolizasAPI.Entidades
{
    public class PolizaDetalleDTO : PolizaDTO
    {
        public List<PolizasCoberturasDTO> PolizasCoberturas { get; set; } = new List<PolizasCoberturasDTO>();
        public IList<CoberturaDTO> Coberturas
        {
            get
            {
                if (PolizasCoberturas.Count > 0)
                {
                    return PolizasCoberturas.Select(pc => pc.Cobertura).ToList();
                }
                return new List<CoberturaDTO>();
            }
        }
        public decimal MontoTotal
        {
            get
            {
                if (PolizasCoberturas.Count > 0)
                {
                    return PolizasCoberturas.Sum(pc => pc.MontoAsegurado);
                }
                return 0M;
            }
        }
    }
}
