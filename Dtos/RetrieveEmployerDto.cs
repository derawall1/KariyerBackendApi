namespace KariyerBackendApi.Dtos;

public class RetrieveEmployerDto 
{

    public string Id { get; set; } = string.Empty;



    public string PhoneNumber { get; set; } = String.Empty;


    public string CompanyName { get; set; } = String.Empty;


    public string Address { get; set; } = String.Empty;


    public int NumberOfJobAdsToPost { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdated { get; set; }


    public bool IsActive { get; set; } = true;
}

