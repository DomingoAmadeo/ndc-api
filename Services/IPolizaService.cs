using AdminPolizasAPI.Entidades;

namespace AdminPolizasAPI.Interfaces
{
    public interface IPolizaService
    {
        Task<List<PolizaDTO>> GetAllPolizas();
        Task<List<PolizaDetalleDTO>> GetAllPolizaDetalle();
        Task<PolizaDTO?> GetPoliza(int id);
        Task<int> AddPoliza(PolizaForAddDTO newPoliza);
        Task<int> UpdatePoliza(PolizaDTO updatedPoliza);
        Task<bool> DeletePoliza(int id);
    }
}