using System.ComponentModel.DataAnnotations;

namespace KariyerBackendApi.Dtos;

public class UpdateEmployerDto 
{
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]

    public string PhoneNumber { get; set; } = String.Empty;

    [Required]
    public string CompanyName { get; set; } = String.Empty;

    [Required]
    public string Address { get; set; } = String.Empty;

    [Required]
    public int NumberOfJobAdsToPost { get; set; }
   

    public DateTime LastUpdated { get; set; }  = DateTime.UtcNow;

    [Required]
    public bool IsActive { get; set; } = true;

}

