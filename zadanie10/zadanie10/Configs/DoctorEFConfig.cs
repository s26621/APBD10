using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie10.Entities;

namespace zadanie10.Configs;

public class DoctorEFConfig : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder
            .HasKey(x => x.IDdoctor)
            .HasName("Doctor_pk");
        
        builder
            .Property(x => x.IDdoctor)
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
            .Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(20);

        builder.ToTable(nameof(Doctor));

        Doctor[] doctors =
        {
            new() {IDdoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jan.kowalski@gmail.com"},
            new() {IDdoctor = 2, FirstName = "Tomasz", LastName = "Problem", Email = "tomasz.problem@gmail.com"},
            new() {IDdoctor = 3, FirstName = "Ala", LastName = "Makota", Email = "ala.makota@gmail.com"},
        };

        builder.HasData(doctors);
    }
}