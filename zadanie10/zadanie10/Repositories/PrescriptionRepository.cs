using Microsoft.AspNetCore.Mvc;
using zadanie10.DTO;
using zadanie10.Entities;

namespace zadanie10.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly HospitalDbContext _context;

    public PrescriptionRepository(HospitalDbContext context)
    {
        _context = context;
    }

    public Prescription? CreatePrescription(Patient patient, List<MedicamentDTO> medicaments, DateOnly date, DateOnly dueDate)
    {
        var isPatient = _context.Patients.Find(patient.IdPatient);
        if (isPatient == null)
        {
            _context.Patients.Add(patient);
        }
        if (medicaments.Count > 10) return null;
        foreach (var medicament in medicaments)
        {
            if (_context.Medicaments.Find(medicament.IdMedicament) == null) return null;
        }
        if (date > dueDate) return null;

        var id = _context.Prescriptions.Max(x => x.IdPrescription) + 1;
        var prescription = new Prescription
        {
            IdPrescription = id,
            Date = date,
            DueDate = dueDate,
            IdPatient = patient.IdPatient,
            // nie wiem, którego doktora dodać, bo nie jest podany, a nie może być puste
            IdDoctor = 1
        };
        _context.Prescriptions.Add(prescription);

        return(prescription);

    }
}