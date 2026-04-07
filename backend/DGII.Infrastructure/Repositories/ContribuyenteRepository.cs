using DGII.Core.Entities;
using DGII.Core.Interfaces;
using DGII.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DGII.Infrastructure.Repositories;

public class ContribuyenteRepository(DgiiDbContext context, ILogger<ContribuyenteRepository> logger)
    : IContribuyenteRepository
{
    public async Task<IEnumerable<Contribuyente>> GetAllAsync()
    {
        try
        {
            return await context.Contribuyentes.ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error obteniendo contribuyentes");
            throw;
        }
    }

    public async Task<Contribuyente?> GetByRncAsync(string rncCedula)
    {
        try
        {
            return await context.Contribuyentes.FindAsync(rncCedula);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error obteniendo contribuyente {Rnc}", rncCedula);
            throw;
        }
    }
}