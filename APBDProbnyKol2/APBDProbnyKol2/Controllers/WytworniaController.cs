using APBDProbnyKol2.DTOs;
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

    [HttpPost]
    public async Task<IActionResult> AddMuzyk(MuzykDTO muzykDto, CancellationToken cancellationToken)
    {
        var result = await _wytworniaService.AddMuzyk(muzykDto, cancellationToken);

        if (result == -1)
            return BadRequest("Taki muzyk już istnieje!!");

        return Ok(result);
    }
    
}