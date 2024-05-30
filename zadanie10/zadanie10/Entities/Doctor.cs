using System.ComponentModel.DataAnnotations;

namespace zadanie10.Entities;

public class Doctor
{
    public int IDdoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}