using JobSearchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApi.Data
{
    interface IJobContext
    {
        DbSet<Job> Jobs {get; set;}
    }
}