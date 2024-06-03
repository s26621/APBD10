using zadanie10.Entities;

namespace zadanie10.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly HospitalDbContext _context;

    public PatientRepository(HospitalDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesPatientExist(Patient patient)
    {
        return await _context.Patients.FindAsync(patient.IdPatient) != null;
    }

    public async void AddPatient(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
    }
}