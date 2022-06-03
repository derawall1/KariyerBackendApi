using KariyerBackendApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KariyerBackendApi.Data;

public class EmployerRepo : IEmployerRepo
{
    private readonly DataContext _dbContext;
    public EmployerRepo( DataContext dbContext)
    {
       
        _dbContext = dbContext;
    }

    public async Task CreateEmployer(Employer employer)
    {

        if (employer == null)
        {
            throw new ArgumentOutOfRangeException(nameof(employer));
        }
        await _dbContext.Employers.AddAsync(employer);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<Employer> GetEmployerById(int id)
    {



        var employer = await _dbContext.Employers.FirstOrDefaultAsync(x => x.Id == id);

       
        return employer;
    }

    public async Task<IEnumerable<Employer>> GetAllEmployers()
    {
        return await _dbContext.Employers.ToListAsync();
    
    }

    public async Task UpdateEmployer(int id, Employer employer)
    {
        if (employer == null)
        {
            throw new ArgumentOutOfRangeException(nameof(employer));
        }
        employer.LastUpdated = DateTime.UtcNow;
         _dbContext.Employers.Update(employer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletedEmployer(int id)
    {
        
        var employer = await _dbContext.Employers.FirstOrDefaultAsync(x => x.Id == id);
        _dbContext.Employers.Remove(employer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExits(string phoneNumber, int? id)
    {
        if (string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentOutOfRangeException(nameof(phoneNumber));
        }
        if(id.HasValue)
            return await _dbContext.Employers.FirstOrDefaultAsync(x=>x.PhoneNumber == phoneNumber) == null? false : true;
        else
            return await _dbContext.Employers.FirstOrDefaultAsync(x => x.Id != id && x.PhoneNumber == phoneNumber) == null ? false : true;

    }
}

