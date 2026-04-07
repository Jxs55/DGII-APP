using DGII.Core.Entities;

namespace DGII.Core.Interfaces;

public interface IComprobanteFiscalRepository
{
    Task<IEnumerable<ComprobanteFiscal>> GetAllAsync();
    Task<IEnumerable<ComprobanteFiscal>> GetByRncAsync(string rncCedula);
    Task<decimal> GetTotalItbisByRncAsync(string rncCedula);
}