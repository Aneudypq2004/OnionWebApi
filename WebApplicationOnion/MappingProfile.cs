using AutoMapper;
using Domain.Models;
using Shared.DataTransferObjects;

namespace WebApplicationOnion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Company, CompanyForCreationDto>();
            CreateMap<CompanyForCreationDto, CompanyDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<Company, CompanyDto>();
            CreateMap<IEnumerable<CompanyDto>, IEnumerable<Company>>();

        }
    }
}
