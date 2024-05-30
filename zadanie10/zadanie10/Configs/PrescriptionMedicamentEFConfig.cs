using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie10.Entities;

namespace zadanie10.Configs;

public class PrescriptionMedicamentEFConfig : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder
            .HasKey(x => new { x.IdPrescription, x.IdMedicament })
            .HasName("PrescriptionMedicament_pk");

        builder
            .HasOne(x => x.Prescription)
            .WithMany(x => x.Medicaments)
            .HasForeignKey(x => x.IdPrescription)
            .HasConstraintName("PrescriptionMedicament_Prescription")
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(x => x.Medicament)
            .WithMany(x => x.Prescriptions)
            .HasForeignKey(x => x.IdMedicament)
            .HasConstraintName("PrescriptionMedicament_Medicament")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(x => x.Details)
            .HasMaxLength(20)
            .IsRequired();

        builder.ToTable(nameof(Prescription)+"_"+nameof(Medicament));

        // pr - 7, med - 4
        PrescriptionMedicament[] prescriptionMedicaments =
        {
            new () {IdMedicament = 1, IdPrescription = 1, Dose = 3, Details = "onie"},
            new () {IdMedicament = 4, IdPrescription = 1, Dose = 1, Details = "otak"},
            new () {IdMedicament = 2, IdPrescription = 1, Dose = 2, Details = "o t a k"},
            new () {IdMedicament = 2, IdPrescription = 2, Dose = 1, Details = "ojej"},
            new () {IdMedicament = 3, IdPrescription = 2, Dose = 3, Details = "o j e j"},
            new () {IdMedicament = 1, IdPrescription = 3, Dose = 1, Details = "omatko"},
            new () {IdMedicament = 4, IdPrescription = 3, Dose = 5, Details = "o matko"},
            new () {IdMedicament = 1, IdPrescription = 4, Dose = 5, Details = "o"},
            new () {IdMedicament = 3, IdPrescription = 5, Dose = 1, Details = "a"},
            new () {IdMedicament = 1, IdPrescription = 6, Dose = 2, Details = "aaaa"},
            new () {IdMedicament = 4, IdPrescription = 6, Dose = 6, Details = "oooo"},
            new () {IdMedicament = 2, IdPrescription = 7, Dose = 1, Details = "eee"},
            new () {IdMedicament = 1, IdPrescription = 7, Dose = 6, Details = "yyy"},
        };

        builder.HasData(prescriptionMedicaments);

    }
}