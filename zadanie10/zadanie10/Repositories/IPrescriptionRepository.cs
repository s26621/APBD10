using zadanie10.DTO;
using zadanie10.Entities;

namespace zadanie10.Repositories;

public interface IPrescriptionRepository
{
    public Prescription? CreatePrescription(Patient patient, List<MedicamentDTO> medicaments, DateOnly date, DateOnly dueDate);
}