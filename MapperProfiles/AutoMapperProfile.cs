using AutoMapper;
using KariyerBackendApi.Models;
using KariyerBackendApi.Dtos;

namespace KariyerBackendApi.MapperProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateEmployerDto, Employer>();
        CreateMap<UpdateEmployerDto, Employer>();
        CreateMap<Employer, RetrieveEmployerDto>();
        CreateMap<CreateJobDto, Job>();
        CreateMap<UpdateJobDto, Job>();
        CreateMap<Job, RetrieveJobDto>();


    }
}

   
