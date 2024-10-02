using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobSearchApi.Models;
using JobSearchApi.Repository;
using JobSearchApi.Services;
using Moq;
using Xunit;

namespace JobSearchApi.Tests
{
    public class JobServiceTests
    {
        private readonly Mock<IJobRepository> _mockRepository;
        private readonly JobService _jobService;

        public JobServiceTests()
        {
            _mockRepository = new Mock<IJobRepository>();
            _jobService = new JobService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllJobsAsync_ShouldReturnAllJobs()
        {
            // Arrange
            var expectedJobs = new List<Job>
            {
                new Job 
                { 
                    JobId = 1, 
                    ExtractionDate = DateTime.Now,
                    JobTitle = "Software Engineer",
                    JobDescription = "Develop software applications",
                    RequiredSkills = "C#, .NET Core",
                    CompanyName = "Tech Co",
                    Location = "New York",
                    JobType = "Full-time",
                    PostedDate = DateTime.Now.AddDays(-7),
                    MinSalary = 70000,
                    MaxSalary = 120000
                },
                new Job 
                { 
                    JobId = 2, 
                    ExtractionDate = DateTime.Now,
                    JobTitle = "Data Analyst",
                    JobDescription = "Analyze data and create reports",
                    RequiredSkills = "SQL, Python",
                    CompanyName = "Data Corp",
                    Location = "San Francisco",
                    JobType = "Full-time",
                    PostedDate = DateTime.Now.AddDays(-5),
                    MinSalary = 65000,
                    MaxSalary = 110000
                }
            };
            _mockRepository.Setup(repo => repo.FetchAllJobsAsync()).ReturnsAsync(expectedJobs);

            // Act
            var result = await _jobService.GetAllJobsAsync();

            // Assert
            Assert.Equal(expectedJobs, result);
        }

        [Fact]
        public async Task GetJobByIdAsync_WithValidId_ShouldReturnJob()
        {
            // Arrange
            var expectedJob = new Job 
            { 
                JobId = 1, 
                ExtractionDate = DateTime.Now,
                JobTitle = "Software Engineer",
                JobDescription = "Develop software applications",
                RequiredSkills = "C#, .NET Core",
                CompanyName = "Tech Co",
                Location = "New York",
                JobType = "Full-time",
                PostedDate = DateTime.Now.AddDays(-7),
                MinSalary = 70000,
                MaxSalary = 120000
            };
            _mockRepository.Setup(repo => repo.FetchJobAsync(1)).ReturnsAsync(expectedJob);

            // Act
            var result = await _jobService.GetJobByIdAsync(1);

            // Assert
            Assert.Equal(expectedJob, result);
        }

        [Fact]
        public async Task GetJobByIdAsync_WithInvalidId_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.FetchJobAsync(1)).ReturnsAsync((Job)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _jobService.GetJobByIdAsync(1));
        }

        [Fact]
        public async Task CreateJobAsync_ShouldCallInsertJobAsync()
        {
            // Arrange
            var job = new Job 
            { 
                ExtractionDate = DateTime.Now,
                JobTitle = "Software Engineer",
                JobDescription = "Develop software applications",
                RequiredSkills = "C#, .NET Core",
                CompanyName = "Tech Co",
                Location = "New York",
                JobType = "Full-time",
                PostedDate = DateTime.Now.AddDays(-7),
                MinSalary = 70000,
                MaxSalary = 120000
            };

            // Act
            await _jobService.CreateJobAsync(job);

            // Assert
            _mockRepository.Verify(repo => repo.InsertJobAsync(job), Times.Once);
        }

        [Fact]
        public async Task UpdateJobAsync_ShouldCallUpdateJobAsync()
        {
            // Arrange
            var job = new Job 
            { 
                JobId = 1,
                ExtractionDate = DateTime.Now,
                JobTitle = "Senior Software Engineer",
                JobDescription = "Lead software development projects",
                RequiredSkills = "C#, .NET Core, Azure",
                CompanyName = "Tech Co",
                Location = "New York",
                JobType = "Full-time",
                PostedDate = DateTime.Now.AddDays(-7),
                MinSalary = 90000,
                MaxSalary = 150000
            };

            // Act
            await _jobService.UpdateJobAsync(job);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateJobAsync(job), Times.Once);
        }

        [Fact]
        public async Task DeleteJobAsync_ShouldCallDeleteJobAsync()
        {
            // Arrange
            long jobId = 1;

            // Act
            await _jobService.DeleteJobAsync(jobId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteJobAsync(jobId), Times.Once);
        }
    }
}