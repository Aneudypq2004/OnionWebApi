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
            CreateMap<Company, CompanyForCreacionDto>();
            CreateMap<CompanyForCreacionDto, CompanyDto>();
            CreateMap<CompanyForCreacionDto, Company>();
            CreateMap<Company, CompanyDto>();
            CreateMap<IEnumerable<CompanyDto>, IEnumerable<Company>>();

        }
    }
}
