
namespace AdminPolizasAPI.Entidades
{
    public class PolizasCoberturasDetalleForAddDTO
    {
        public int PolizaId { get; set; }
        public List<Detalle> Detalle { get; set; } = new List<Detalle>();
    }

    public class Detalle
    {
        public int CoberturaId { get; set; }
        public decimal MontoAsegurado { get; set; }
    }
}
