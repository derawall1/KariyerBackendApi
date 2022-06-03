using System.ComponentModel.DataAnnotations;

namespace KariyerBackendApi.Dtos;

public class CreateJobDto 
{


   

    [Required]
    public string PositionTitle { get; set; } = String.Empty;

    [Required]
    public string JobDescription { get; set; } = String.Empty;

    [Required]
    public int DurationOfJobPostAd { get; set; }




    public string PreksAndBenefits { get; set; } = String.Empty;


    public string WorkType { get; set; } = String.Empty;


    public decimal Salary { get; set; }


}

