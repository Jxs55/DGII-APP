using DGII.Core.Entities;

namespace DGII.Core.Interfaces;

public interface IContribuyenteRepository
{
    Task<IEnumerable<Contribuyente>> GetAllAsync();
    Task<Contribuyente?> GetByRncAsync(string rncCedula);
}