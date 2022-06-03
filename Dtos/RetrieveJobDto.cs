namespace KariyerBackendApi.Dtos;

public class RetrieveJobDto 
{

    public string Id { get; set; } = String.Empty;

    public string EmployerId { get; set; } = String.Empty;

    public string CompanyName { get; set; } = String.Empty;

    public string PositionTitle { get; set; } = String.Empty;


    public string JobDescription { get; set; } = String.Empty;


    public int DurationOfJobPostAd { get; set; }


    public int JobPostingQuality { get; set; }


    public string PreksAndBenefits { get; set; } = String.Empty;


    public string WorkType { get; set; } = String.Empty;


    public decimal Salary { get; set; }


    public DateTime PostedDate { get; set; }


    public DateTime LastUpdated { get; set; }


    public bool IsActive { get; set; }
}

