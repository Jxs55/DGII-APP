using DGII.Core.Entities;
using DGII.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DGII.Core.Services;

public class ContribuyenteService(IContribuyenteRepository repo, ILogger<ContribuyenteService> logger)
{
    public async Task<IEnumerable<Contribuyente>> GetAllAsync()
    {
        try
        {
            return await repo.GetAllAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error en capa Core al obtener contribuyentes");
            throw;
        }
    }

    public async Task<Contribuyente?> GetByRncAsync(string rnc)
    {
        try
        {
            return await repo.GetByRncAsync(rnc);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error en capa Core al obtener contribuyente {Rnc}", rnc);
            throw;
        }
    }
}