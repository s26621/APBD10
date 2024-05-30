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
    public IActionResult CreatePrescription(Patient patient, List<MedicamentDTO> medicaments, DateOnly date, DateOnly dueDate)
    {
        var prescription = _service.CreatePrescription(patient, medicaments, date, dueDate);
        if (prescription == null) return BadRequest();
        return Created();

    }
}