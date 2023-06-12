using AdminPolizasAPI.Entidades;

namespace AdminPolizasAPI.Interfaces
{
    public interface ICoberturaService
    {
        Task<List<CoberturaDTO>> GetAllCoberturas();
        Task<CoberturaDTO> GetCobertura(int id);
        Task<int> AddCobertura(CoberturaForAddDTO newCobertura);
        Task<int> UpdateCobertura(CoberturaDTO updatedCobertura);
        Task<bool> DeleteCobertura(int id);
    }
}