using zadanie10.Entities;

namespace zadanie10.DTO;

public record PrescriptionDTO(Patient patient, List<MedicamentDTO> medicaments, DateTime date, DateTime dueDate );