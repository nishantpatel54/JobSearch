using JobSearchApi.Models;
using JobSearchApi.Repository;

namespace JobSearchApi.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }
        public async Task CreateJobAsync(Job job)
        {
            ArgumentNullException.ThrowIfNull(job);

            await _jobRepository.InsertJobAsync(job);
        }

        public async Task DeleteJobAsync(long jobid)
        {
            await _jobRepository.DeleteJobAsync(jobid);
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.FetchAllJobsAsync();
        }

        public async Task<Job> GetJobByIdAsync(long jobid)
        {
            var job = await _jobRepository.FetchJobAsync(jobid);
            if (job == null)
            {
                throw new KeyNotFoundException($"Job with ID {jobid} not found.");
            }

            return job;
        }

        public async Task UpdateJobAsync(Job job)
        {
            ArgumentNullException.ThrowIfNull(job);

            await _jobRepository.UpdateJobAsync(job);
        }
    }
}