using APBDProbnyKol2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBDProbnyKol2.Controllers;

[Route("api/muzyk")]
[ApiController]
public class WytworniaController : ControllerBase
{
    private readonly IWytworniaService _wytworniaService;

    public WytworniaController(IWytworniaService wytworniaService)
    {
        _wytworniaService = wytworniaService;
    }

    [HttpGet("{idMuzyk:int}")]
    public async Task<IActionResult> GetMuzyk(int idMuzyk, CancellationToken cancellationToken)
    {
        var result = await _wytworniaService.GetMuzyk(idMuzyk, cancellationToken);
        if (result == null)
            return NotFound("Taki muzyk nie istnieje");
        return Ok(result);
    }
    
}