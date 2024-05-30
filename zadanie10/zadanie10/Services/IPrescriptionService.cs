using zadanie10.DTO;
using zadanie10.Entities;

namespace zadanie10.Services;

public interface IPrescriptionService
{
    public Prescription? CreatePrescription(Patient patient, List<MedicamentDTO> medicaments, DateOnly date, DateOnly dueDate);
}