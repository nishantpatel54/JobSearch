using System.ComponentModel.DataAnnotations;

namespace JobSearchApi.Models
{
    public class Job
    {
        [Key]
        public long JobId {get; set;}
        [Required]
        public DateTime ExtractionDate {get; set;}
        [Required]
        public string JobTitle {get; set;}
        [Required]
        public string JobDescription {get; set;}
        [Required]
        public string RequiredSkills {get; set;}
        [Required]
        public string CompanyName {get; set;}
        [Required]
        public string Location {get;set;}
        [Required]
        public string JobType {get; set;}
        
        public DateTime PostedDate {get; set;}

        public long MinSalary {get;set;}

        public long MaxSalary {get; set;}

    }

}