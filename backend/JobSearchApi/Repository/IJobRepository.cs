using JobSearchApi.Models;

namespace JobSearchApi.Repository
{
    public interface IJobRepository
    {
        Task InsertJobAsync(Job job);
        Task<List<Job>> FetchAllJobsAsync();
        Task<Job> FetchJobAsync(long jobid);
        Task UpdateJobAsync(Job newJob);
        Task DeleteJobAsync(long jobid);
    }
}