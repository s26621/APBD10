using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie10.Entities;

namespace zadanie10.Configs;

public class MedicamentEFConfig : IEntityTypeConfiguration<Medicament>
{
    // robimy podejście fluent - każda metoda coś robi i istnieje w jednej kolumnie, nie wszystko da się zrobić za pomocą adnotacji
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        // zawsze na początku konfigurujemy klucz główny
        // w lambdzie pokazujemy, które pole jest kluczem
        // drugie to nadawanie nazwy, opcjonalne
        builder
            .HasKey(x => x.IdMedicament)
            .HasName("Medicament_pk");

        // automatyczne generowanie kluczy głownych
        //builder.Property(x => x.IdMedicament).UseIdentityColumn();

        // na kolosie jeśli nie wymagają to lepiej ręcznie robić
        builder
            .Property(x => x.IdMedicament)
            .ValueGeneratedNever();

        builder
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(10);
        
        // domyślnie nazwy tabel będą nazwane z dopiskiem "s" do nazwy, a w podejściu relacyjnym popwinno być w liczbie pojedynczej
        // dzięki nameof nie wpisujemy na sztywno i jeśli zrobimy refactor to to wciąż zadziała
        builder.ToTable(nameof(Medicament));

        // tworzymy nasze dane
        Medicament[] medicaments =
        {
            new () {IdMedicament = 1, Name = "APAP", Description = "słabe", Type = "przeciwbólowe" },
            new () {IdMedicament = 2, Name = "Smecta", Description = "średnie", Type = "na biegunkę" },
            new () {IdMedicament = 3, Name = "Forlax", Description = "mocne", Type = "na zaparcia" },
            new () {IdMedicament = 4, Name = "Bepanthen", Description = "delikatne", Type = "na podrażnienie skóry" },
        };

        // dodajemy!
        builder.HasData((medicaments));
    }
}