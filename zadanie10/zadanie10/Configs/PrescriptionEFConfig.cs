using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie10.Entities;

namespace zadanie10.Configs;

public class PrescriptionEFConfig : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder
            .HasKey(x => x.IdPrescription)
            .HasName("Prescription_pk");

        builder
            .Property(x => x.IdPrescription)
            .ValueGeneratedNever();
        builder
            .Property(x => x.Date)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder
            .Property(x => x.DueDate)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.ToTable(nameof(Prescription));

        Prescription[] prescriptions =
        {
            new () {IdPrescription = 1, Date = DateOnly.Parse("2024-05-10"), IdDoctor = 1, IdPatient = 1, DueDate = DateOnly.Parse("2024-10-12")},
            new () {IdPrescription = 2, Date = DateOnly.Parse("2024-05-15"), IdDoctor = 2, IdPatient = 2, DueDate = DateOnly.Parse("2024-11-02")},
            new () {IdPrescription = 3, Date = DateOnly.Parse("2024-04-31"), IdDoctor = 1, IdPatient = 2, DueDate = DateOnly.Parse("2024-10-04")},
            new () {IdPrescription = 4, Date = DateOnly.Parse("2024-05-14"), IdDoctor = 2, IdPatient = 1, DueDate = DateOnly.Parse("2024-11-05")},
            new () {IdPrescription = 5, Date = DateOnly.Parse("2024-05-24"), IdDoctor = 2, IdPatient = 1, DueDate = DateOnly.Parse("2024-11-06")},
            new () {IdPrescription = 6, Date = DateOnly.Parse("2024-05-30"), IdDoctor = 3, IdPatient = 1, DueDate = DateOnly.Parse("2024-12-26")},
            new () {IdPrescription = 7, Date = DateOnly.Parse("2024-04-29"), IdDoctor = 3, IdPatient = 3, DueDate = DateOnly.Parse("2024-11-12")},
        };

        builder.HasData(prescriptions);
    }
}