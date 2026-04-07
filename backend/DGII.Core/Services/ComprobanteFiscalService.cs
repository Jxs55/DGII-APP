using DGII.Core.Entities;
using DGII.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DGII.Core.Services;

public class ComprobanteFiscalService(IComprobanteFiscalRepository repo, ILogger<ComprobanteFiscalService> logger)
{
    public async Task<IEnumerable<ComprobanteFiscal>> GetAllAsync()
    {
        try
        {
            return await repo.GetAllAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error en capa Core al obtener comprobantes");
            throw;
        }
    }

    public async Task<IEnumerable<ComprobanteFiscal>> GetByRncAsync(string rnc)
    {
        try
        {
            return await repo.GetByRncAsync(rnc);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error en capa Core al obtener comprobantes de {Rnc}", rnc);
            throw;
        }
    }

    public async Task<decimal> GetTotalItbisByRncAsync(string rnc)
    {
        try
        {
            return await repo.GetTotalItbisByRncAsync(rnc);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error en capa Core al calcular ITBIS de {Rnc}", rnc);
            throw;
        }
    }
}