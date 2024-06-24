using Microsoft.AspNetCore.Mvc;
using tests.Models;
using tests.Repositories;

namespace tests.Controllers;


[Route("api/pharmacy")]
[ApiController]
public class PharmacyController : ControllerBase
{
    private readonly IPharmacyRepository _pharmacyRepository;

    public PharmacyController(IPharmacyRepository pharmacyRepository)
    {
        _pharmacyRepository = pharmacyRepository;
    }

    [HttpGet]
    public IActionResult GetPrescriptions(string? doctorLastName)
    {
        var prescriptions = _pharmacyRepository.GetPrescriptions(doctorLastName);
        return Ok(prescriptions);
    }
    [HttpPost]
    public IActionResult AddPrescription([FromBody] PrescriptionCreateDto prescriptionCreateDto)
    {
        if (prescriptionCreateDto.DueDate <= prescriptionCreateDto.Date)
        {
            return BadRequest("DueDate must be later than Date.");
        }

        try
        {
            var newPrescription = _pharmacyRepository.AddPrescription(prescriptionCreateDto);
            return CreatedAtAction(nameof(GetPrescriptionById), new { id = newPrescription.IdPrescription }, newPrescription);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetPrescriptionById(int id)
    {
        var prescription = _pharmacyRepository.GetPrescriptionById(id);
        if (prescription == null)
        {
            return NotFound();
        }
        return Ok(prescription);
    }
}