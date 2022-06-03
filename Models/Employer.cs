using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KariyerBackendApi.Models;

[Table("Employer")]
public class Employer
{
    [Required]
    [Key]
    public int Id { get; set; } 

    [Required]
    public string PhoneNumber { get; set; } = String.Empty;

    [Required]
    public string CompanyName { get; set; } = String.Empty;

    [Required]
    public string Address { get; set; } = String.Empty;

    [Required]
    public int NumberOfJobAdsToPost { get; set; } = 2;

    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime LastUpdated { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    public ICollection<Job> Jobs { get; set; } = default!;
}

