

using KariyerBackendApi.Models;

namespace KariyerBackendApi.Data;

public interface IJobRepo
{
    Task CreateJob(Job job);
    Task UpdateJob(int id, Job job);
    Task DeletedJob(int id);
    Task<Job> GetJobById(int id);
    Task<IEnumerable<Job>> GetAllJobs();
}

