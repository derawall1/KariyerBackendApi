using System.ComponentModel.DataAnnotations;

namespace KariyerBackendApi.Dtos;

public class CreateEmployerDto 
{


    [Required]

    public string PhoneNumber { get; set; } = String.Empty;

    [Required]
    public string CompanyName { get; set; } = String.Empty;

    [Required]
    public string Address { get; set; } = String.Empty;

    [Required]
    public int NumberOfJobAdsToPost { get; set; } = 2;

}

