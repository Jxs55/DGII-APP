using DGII.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGII.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContribuyentesController(ContribuyenteService service, ILogger<ContribuyentesController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await service.GetAllAsync());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error en GET /contribuyentes");
            return StatusCode(500, "Error interno");
        }
    }

    [HttpGet("{rnc}")]
    public async Task<IActionResult> GetByRnc(string rnc)
    {
        try
        {
            var result = await service.GetByRncAsync(rnc);
            return result is null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error en GET /contribuyentes/{Rnc}", rnc);
            return StatusCode(500, "Error interno");
        }
    }
}