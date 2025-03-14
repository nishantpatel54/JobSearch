using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobSearchApi.Models;
using JobSearchApi.Services;

namespace JobSearchApi.Controllers
{
    [ApiController]
    [Route("api/[contoller]")]
    public class SearchController : ControllerBase
    {
        private readonly IJobService _jobService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> JobBasedOnQuery(string query)
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }

    }
}