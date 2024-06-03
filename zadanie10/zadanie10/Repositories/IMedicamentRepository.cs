using zadanie10.DTO;

namespace zadanie10.Repositories;

public interface IMedicamentRepository
{
    public bool IsNumberOfMedsLowerThanLimit(List<MedicamentDTO> medicaments);
    public Task<bool> DoAllMedsExist(List<MedicamentDTO> medicaments);
}