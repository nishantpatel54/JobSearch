using JobSearchApi.Models;

namespace JobSearchApi.Services
{
    public interface IJobService
    {
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(long jobid);
        Task CreateJobAsync(Job job);
        Task UpdateJobAsync(Job job);
        Task DeleteJobAsync(long jobid);
    }
}