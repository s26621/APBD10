using zadanie10.Entities;

namespace zadanie10.Repositories;

public interface IPatientRepository
{
    public Task<bool> DoesPatientExist(Patient patient);

    public void AddPatient(Patient patient);
}