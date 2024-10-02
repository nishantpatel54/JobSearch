using System.Data.Common;
using JobSearchApi.Data;
using JobSearchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApi.Repository
{
    class JobRepository : IJobRepository
    {
        private readonly JobContext _jobContext;

        public JobRepository(JobContext jobContext)
        {
            _jobContext = jobContext ?? throw new ArgumentNullException(nameof(jobContext));
        }
        public async Task DeleteJobAsync(long jobid)
        {
            var jobToDelete = await _jobContext.Jobs.FindAsync(jobid);
            if (jobToDelete != null){
                _jobContext.Jobs.Remove(jobToDelete);
                await _jobContext.SaveChangesAsync();
            }
        }

        public async Task<List<Job>> FetchAllJobsAsync()
        {
            return await _jobContext.Jobs.ToListAsync();
        }

        public async Task<Job> FetchJobAsync(long jobid)
        {
            return await _jobContext.Jobs.FindAsync(jobid);
        }

        public async Task InsertJobAsync(Job job)
        {
            await _jobContext.Jobs.AddAsync(job);
            await _jobContext.SaveChangesAsync();
        }

        public async Task UpdateJobAsync(Job newJob)
        {
            _jobContext.Entry(newJob).State = EntityState.Modified;
            await _jobContext.SaveChangesAsync();
        }
    }
}