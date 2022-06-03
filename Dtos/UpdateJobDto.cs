using System.ComponentModel.DataAnnotations;

namespace KariyerBackendApi.Dtos;

public class UpdateJobDto 
{ 
    [Required]
    public string Id { get; set; } = String.Empty;

    [Required]

    public string EmployerId { get; set; } = String.Empty;

    [Required]
    public string PositionTitle { get; set; } = String.Empty;

    [Required]
    public string JobDescription { get; set; } = String.Empty;

    [Required]
    public int DurationOfJobPostAd { get; set; }


    public string PreksAndBenefits { get; set; } = String.Empty;


    public string WorkType { get; set; } = String.Empty;


    public decimal Salary { get; set; }

    public DateTime LastUpdated { get; set; }


    public bool IsActive { get; set; }


}

