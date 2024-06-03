using zadanie10.DTO;
using zadanie10.Entities;

namespace zadanie10.Repositories;

public interface IPrescriptionRepository
{
    public Task<Prescription?> CreatePrescription(PrescriptionDTO prescription);
}