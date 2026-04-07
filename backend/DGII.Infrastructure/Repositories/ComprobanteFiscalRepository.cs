using DGII.Core.Entities;
using DGII.Core.Interfaces;
using DGII.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DGII.Infrastructure.Repositories;

public class ComprobanteFiscalRepository(DgiiDbContext context, ILogger<ComprobanteFiscalRepository> logger)
    : IComprobanteFiscalRepository
{
    public async Task<IEnumerable<ComprobanteFiscal>> GetAllAsync()
    {
        try
        {
            return await context.ComprobantesFiscales.ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error obteniendo comprobantes");
            throw;
        }
    }

    public async Task<IEnumerable<ComprobanteFiscal>> GetByRncAsync(string rncCedula)
    {
        try
        {
            return await context.ComprobantesFiscales.Where(c => c.RncCedula == rncCedula).ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error obteniendo comprobantes de {Rnc}", rncCedula);
            throw;
        }
    }

    public async Task<decimal> GetTotalItbisByRncAsync(string rncCedula)
    {
        try
        {
            var itbisValues = await context.ComprobantesFiscales
                .Where(c => c.RncCedula == rncCedula)
                .Select(c => c.Itbis18)
                .ToListAsync();

            return itbisValues.Sum();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error calculando ITBIS de {Rnc}", rncCedula);
            throw;
        }
    }
}