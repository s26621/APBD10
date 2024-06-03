using Microsoft.AspNetCore.Mvc;
using zadanie10.DTO;
using zadanie10.Entities;
using zadanie10.Services;

namespace zadanie10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _service;

    public PrescriptionController(IPrescriptionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescription(PrescriptionDTO prescription)
    {
        var pr = await _service.CreatePrescription(prescription);
        if (pr == null) return BadRequest();
        return Created();

    }
}