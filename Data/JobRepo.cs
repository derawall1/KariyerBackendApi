﻿using KariyerBackendApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace KariyerBackendApi.Data;

public class JobRepo : IJobRepo
{
    private readonly DataContext _dbContext;
    private readonly List<string> InconvenientWords =  new List<string>(){"rock star", "guru", "ninja", "dominant"};
    public JobRepo(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateJob(Job job)
    {

        if (job == null)
        {
            throw new ArgumentOutOfRangeException(nameof(job));
        }
        var JobQuality = 0;
        if (!string.IsNullOrEmpty(job.WorkType))
            JobQuality += 1;
        if (job.Salary > 0)
            JobQuality += 1;
       
        if (!string.IsNullOrEmpty(job.PreksAndBenefits))
            JobQuality += 1;
        var isGood = job.JobDescription.Where(s => Regex.Split(job.JobDescription, @"\W").Any(w => InconvenientWords.Contains(w)));
        if (!isGood.Any())
            JobQuality += 2;

        if (JobQuality > 0)
            job.JobPostingQuality = JobQuality;

        await _dbContext.Jobs.AddAsync(job);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Job> GetJobById(int id)
    {
        return await _dbContext.Jobs.FindAsync(id);
    }

    public async Task<IEnumerable<Job>> GetAllJobs()
    {
        return await _dbContext.Jobs.ToListAsync();
    }

    public async Task UpdateJob(int id, Job job)
    {
        if (job == null)
        {
            throw new ArgumentOutOfRangeException(nameof(Job));
        }

        _dbContext.Jobs.Update(job);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletedJob(int id)
    {
        var job = await _dbContext.Jobs.FindAsync(id);
        _dbContext.Jobs.Remove(job);

        await _dbContext.SaveChangesAsync();

    }
}

