using System.ComponentModel;

namespace KariyerBackendApi.Dtos;

public  class ResponseDto
{
    [ReadOnly(true)]
    public string Message { get; set; } = string.Empty;
    [ReadOnly(true)]
    public string Error { get; set; } = string.Empty;
}
