using Microsoft.EntityFrameworkCore;
using zadanie10.Configs;

namespace zadanie10.Entities;

public class HospitalDbContext : DbContext
{
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    
    
    // raczej nie potrzebujemy kontekstów tabel asocjacyjnych

    public HospitalDbContext()
    {
        
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
    {
        
    }
    
    // każda klasa ma swój plik konfiguracyjny, dzięki czemu łatwo będzie coś zmienić
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // aplikujemy wszystkie pliki konfigurujące, które znajdują się w tym samym miejscu co tamta klasa
        // typeof może być dowolnego pliku konfigurującego
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrescriptionEFConfig).Assembly);
    }

}