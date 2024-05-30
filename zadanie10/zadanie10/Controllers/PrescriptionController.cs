using Microsoft.AspNetCore.Mvc;
using zadanie10.DTO;
using zadanie10.Entities;

namespace zadanie10.Controllers;

public class PrescriptionController : ControllerBase
{
    private HospitalDbContext _context;

    public PrescriptionController(HospitalDbContext context)
    {
        _context = context;
    }

    public IActionResult CreatePrescription(Patient patient, List<MedicamentDTO> medicaments, DateTime date, DateTime dueDate)
    {
        // placeholder
        return NotFound();
    }
}