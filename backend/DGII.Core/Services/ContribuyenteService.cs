using DGII.Core.Entities;
using DGII.Core.Interfaces;

namespace DGII.Core.Services;

public class ContribuyenteService(IContribuyenteRepository repo)
{
    public Task<IEnumerable<Contribuyente>> GetAllAsync() => repo.GetAllAsync();
    public Task<Contribuyente?> GetByRncAsync(string rnc) => repo.GetByRncAsync(rnc);
}