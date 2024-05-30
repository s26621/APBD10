namespace zadanie10.Entities;

public class Medicament
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }

    // po tej stronie dodajemy listy
    public virtual ICollection<PrescriptionMedicament> Prescriptions { get; set; } = new List<PrescriptionMedicament>();
}