

using KariyerBackendApi.Models;


namespace KariyerBackendApi.Data;

public interface IEmployerRepo
{
    Task CreateEmployer(Employer employer);
    Task UpdateEmployer(int id, Employer employer);
    Task DeletedEmployer( int id);
    Task<Employer> GetEmployerById(int id);
    Task<bool> IsExits(string phoneNumber, int? id);
    Task<IEnumerable<Employer>> GetAllEmployers();
}

