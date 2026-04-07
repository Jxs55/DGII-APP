using DGII.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGII.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComprobantesFiscalesController(ComprobanteFiscalService service, ILogger<ComprobantesFiscalesController> logger)
    : ControllerBase
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
            logger.LogError(ex, "Error en GET /comprobantes");
            return StatusCode(500, "Error interno");
        }
    }

    [HttpGet("contribuyente/{rnc}")]
    public async Task<IActionResult> GetByRnc(string rnc)
    {
        try
        {
            return Ok(await service.GetByRncAsync(rnc));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error en GET /comprobantes/contribuyente/{Rnc}", rnc);
            return StatusCode(500, "Error interno");
        }
    }

    [HttpGet("contribuyente/{rnc}/total-itbis")]
    public async Task<IActionResult> GetTotalItbis(string rnc)
    {
        try
        {
            return Ok(new { rncCedula = rnc, totalItbis = await service.GetTotalItbisByRncAsync(rnc) });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error calculando ITBIS");
            return StatusCode(500, "Error interno");
        }
    }
}