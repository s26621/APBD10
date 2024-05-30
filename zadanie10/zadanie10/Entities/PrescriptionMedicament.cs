namespace zadanie10.Entities;

public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
    
    // tam, gdzie mamy klucze obce, dajemy pola wirtualne
    public virtual Medicament Medicament { get; set; }
    public virtual Prescription Prescription { get; set; }
}