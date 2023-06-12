using System.ComponentModel.DataAnnotations;

namespace AdminPolizasAPI.Entidades
{
    public class PolizasCoberturasDTO
    {
        public int Id { get; set; }

        public int PolizaId { get; set; }

        public int CoberturaId { get; set; }

        public PolizaDTO? Poliza { get; set; }

        public CoberturaDTO? Cobertura { get; set; }

        public decimal MontoAsegurado { get; set; }
    }
}
