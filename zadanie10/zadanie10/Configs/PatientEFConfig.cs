using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie10.Entities;

namespace zadanie10.Configs;

public class PatientEFConfig : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .HasKey(x => x.IdPatient)
            .HasName("Patient_pk");

        builder
            .Property(x => x.IdPatient)
            .ValueGeneratedNever();

        builder
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(10);
        builder
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(10);
        builder
            .Property(x => x.BirthDate)
            .IsRequired();

        builder.ToTable(nameof(Patient));

        Patient[] patients =
        {
            new() { IdPatient = 1, FirstName = "Ula", LastName = "Mapsa", BirthDate = DateTime.Parse("2000-01-20") },
            new() { IdPatient = 2, FirstName = "Ela", LastName = "Manic", BirthDate = DateTime.Parse("1995-04-14") },
            new() { IdPatient = 3, FirstName = "Andrzej", LastName = "Towalnie", BirthDate = DateTime.Parse("1998-12-30") },
        };

        builder.HasData(patients);
    }
}