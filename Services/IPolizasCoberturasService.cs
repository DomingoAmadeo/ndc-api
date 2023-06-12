using AdminPolizasAPI.Entidades;

namespace AdminPolizasAPI.Interfaces
{
    public interface IPolizasCoberturasService
    {
        Task<List<PolizasCoberturasDTO>> GetAllPolizasCoberturas();
        Task<PolizasCoberturasDTO?> GetPolizasCoberturas(int id);
        Task<int> AddPolizasCoberturas(PolizasCoberturasForAddDTO polizasCoberturasDto);
        Task<bool> AddPolizasCoberturasDetalle(PolizasCoberturasDetalleForAddDTO newPolizasCoberturasDetalle);
        Task<int> UpdatePolizasCoberturas(PolizasCoberturasDTO polizasCoberturasDto);
        Task<bool> DeletePolizasCoberturas(int id);
    }
}