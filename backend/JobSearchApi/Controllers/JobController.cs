using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobSearchApi.Models;
using JobSearchApi.Services;

namespace JobSearchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService ?? throw new ArgumentNullException(nameof(jobService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(long id)
        {
            try
            {
                var job = await _jobService.GetJobByIdAsync(id);
                return Ok(job);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Job>> CreateJob(Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _jobService.CreateJobAsync(job);
                return CreatedAtAction(nameof(GetJob), new { id = job.JobId }, job);
            }
            catch (Exception)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while creating the job.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(long id, Job job)
        {
            if (id != job.JobId)
            {
                return BadRequest("The ID in the URL does not match the ID in the job object.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _jobService.UpdateJobAsync(job);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while updating the job.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(long id)
        {
            try
            {
                await _jobService.DeleteJobAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while deleting the job.");
            }
        }
    }
}