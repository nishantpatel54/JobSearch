using JobSearchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApi.Data
{
    public class JobContext : DbContext, IJobContext
    {
        public JobContext(DbContextOptions<JobContext> options): base(options){}

        public virtual DbSet<Job> Jobs {get; set;}
    }
}