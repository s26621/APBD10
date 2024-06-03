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

    public async Task<Prescription?> CreatePrescription(PrescriptionDTO prescriptionDTO)
    {
        if (prescriptionDTO.date > prescriptionDTO.dueDate) return null;
        return await _repository.CreatePrescription(prescriptionDTO);
    }
}