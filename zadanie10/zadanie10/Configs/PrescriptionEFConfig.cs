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
        builder
            .HasOne(x => x.Patient)
            .WithMany(x => x.Prescriptions)
            .HasForeignKey(x => x.IdPatient)
            .HasConstraintName("Prescription_Patient")
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(x => x.Doctor)
            .WithMany(x => x.Prescriptions)
            .HasForeignKey(x => x.IdDoctor)
            .HasConstraintName("Prescription_Doctor")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(nameof(Prescription));

        Prescription[] prescriptions =
        {
            new () {IdPrescription = 1, Date = new DateTime(2024,05,10), IdDoctor = 1, IdPatient = 1, DueDate = new DateTime(2024,10,12)},
            new () {IdPrescription = 2, Date = new DateTime(2024,05,1), IdDoctor = 2, IdPatient = 2, DueDate = new DateTime(2024,11,02)},
            new () {IdPrescription = 3, Date = new DateTime(2024,04,30), IdDoctor = 1, IdPatient = 2, DueDate = new DateTime(2024,10,04)},
            new () {IdPrescription = 4, Date = new DateTime(2024,05,14), IdDoctor = 2, IdPatient = 1, DueDate = new DateTime(2024,11,05)},
            new () {IdPrescription = 5, Date = new DateTime(2024, 05, 24), IdDoctor = 2, IdPatient = 1, DueDate = new DateTime(2024,11,06)},
            new () {IdPrescription = 6, Date = new DateTime(2024, 05,30), IdDoctor = 3, IdPatient = 1, DueDate = new DateTime(2024,12,26)},
            new () {IdPrescription = 7, Date = new DateTime(2024,04,29), IdDoctor = 3, IdPatient = 3, DueDate = new DateTime(2024,11,12)},
        };

        builder.HasData(prescriptions);
    }
}