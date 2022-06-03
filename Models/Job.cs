using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KariyerBackendApi.Models;

[Table("Job")]
public class Job
{
    [Required]
    [Key]
    public int Id { get; set; } 

   

    [Required]
    public string PositionTitle { get; set; } = String.Empty;

    [Required]
    public string JobDescription { get; set; } = String.Empty;

    [Required]
    public int DurationOfJobPostAd { get; set; }

   
    public int JobPostingQuality { get; set; }

    
    public string PreksAndBenefits { get; set; } = String.Empty;

    
    public string WorkType { get; set; } = String.Empty;

    
    public decimal Salary { get; set; } 

  
    public DateTime PostedDate { get; set; } 

  
    public DateTime LastUpdated { get; set; } 

   
    public bool IsActive { get; set; }

    public Employer Employer { get; set; } = new Employer();
}

