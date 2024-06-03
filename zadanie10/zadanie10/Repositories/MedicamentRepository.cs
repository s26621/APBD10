using Microsoft.EntityFrameworkCore;
using zadanie10.DTO;
using zadanie10.Entities;

namespace zadanie10.Repositories;

public class MedicamentRepository : IMedicamentRepository
{
    private readonly HospitalDbContext _context;

    public MedicamentRepository(HospitalDbContext context)
    {
        _context = context;
    }

    public bool IsNumberOfMedsLowerThanLimit(List<MedicamentDTO> medicaments)
    {
        return medicaments.Count < 10;
    }

    public async Task<bool> DoAllMedsExist(List<MedicamentDTO> medicaments)
    {
        int[] medIds = medicaments.Select(x => x.IdMedicament).ToArray();
        List<Medicament> meds = await _context.Medicaments.Where(x => medIds.Contains(x.IdMedicament)).ToListAsync();
        return medicaments.Count == meds.Count;
    }
}