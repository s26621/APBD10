using zadanie10.DTO;
using zadanie10.Entities;

namespace zadanie10.Services;

public interface IPrescriptionService
{
    public Task<Prescription?> CreatePrescription(PrescriptionDTO prescriptionDTO);
}