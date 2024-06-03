using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zadanie10.DTO;
using zadanie10.Entities;

namespace zadanie10.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly HospitalDbContext _context;
    private readonly IMedicamentRepository _medRepository;
    public readonly IPatientRepository _patientRepository;

    public PrescriptionRepository(HospitalDbContext context, IMedicamentRepository medRepository, IPatientRepository patientRepository)
    {
        _context = context;
        _medRepository = medRepository;
        _patientRepository = patientRepository;
    }

    public async Task<Prescription?> CreatePrescription(PrescriptionDTO prescriptionDTO)
    {
        (Patient patient, List<MedicamentDTO> medicaments, DateTime date, DateTime dueDate) = prescriptionDTO;
        
        if (!await _patientRepository.DoesPatientExist(patient))
        {
            _patientRepository.AddPatient(patient);
        }
        
        if (!_medRepository.IsNumberOfMedsLowerThanLimit(medicaments)) return null;
        if (!await _medRepository.DoAllMedsExist(medicaments)) return null;
        
        // to zamiast tego niżej
        // foreach (var medicament in medicaments)
        // {
        //     if (_context.Medicaments.Find(medicament.IdMedicament) == null) return null;
        // }
        
        
        // to w service
        // if (date > dueDate) return null;
        
        var id = GetNewId();
        
        // to już tu
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

    private int GetNewId()
    {
        return _context.Prescriptions.Max(x => x.IdPrescription) + 1;
    }
}