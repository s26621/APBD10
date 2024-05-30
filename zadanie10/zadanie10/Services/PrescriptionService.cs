using zadanie10.DTO;
using zadanie10.Entities;
using zadanie10.Repositories;

namespace zadanie10.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _repository;

    public PrescriptionService(IPrescriptionRepository repository)
    {
        _repository = repository;
    }

    public Prescription? CreatePrescription(Patient patient, List<MedicamentDTO> medicaments, DateOnly date, DateOnly dueDate)
    {
        return _repository.CreatePrescription(patient, medicaments, date, dueDate);
    }
}