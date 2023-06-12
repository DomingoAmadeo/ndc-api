using System.ComponentModel.DataAnnotations;

namespace AdminPolizasAPI.Entidades
{
    public class PolizasCoberturasForAddDTO
    {
        public int PolizaId { get; set; }

        public int CoberturaId { get; set; }

        public decimal MontoAsegurado { get; set; }
    }
}
