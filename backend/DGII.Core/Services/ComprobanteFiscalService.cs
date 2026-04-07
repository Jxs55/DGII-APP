using DGII.Core.Entities;
using DGII.Core.Interfaces;

namespace DGII.Core.Services;

public class ComprobanteFiscalService(IComprobanteFiscalRepository repo)
{
    public Task<IEnumerable<ComprobanteFiscal>> GetAllAsync() => repo.GetAllAsync();
    public Task<IEnumerable<ComprobanteFiscal>> GetByRncAsync(string rnc) => repo.GetByRncAsync(rnc);
    public Task<decimal> GetTotalItbisByRncAsync(string rnc) => repo.GetTotalItbisByRncAsync(rnc);
}