using JobSearchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApi.Data
{
    public interface IJobContext
    {
        DbSet<Job> Jobs {get; set;}
    }
}