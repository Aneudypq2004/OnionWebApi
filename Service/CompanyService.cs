using AutoMapper;
using Contracts;
using Domain.Models;
using Domain.Models.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public CompanyDto CreateCompany(CompanyForCreacionDto companyCreateDto)
        {
           var company =  _mapper.Map<Company>(companyCreateDto);

            _repository.CompanyRepository.CreateCompany(company);

            _repository.Save();

            var companytoReturn = _mapper.Map<CompanyDto>(company);

            return companytoReturn;  
        }

        public bool DeleteCompany(Guid Id)
        {
            var company = _repository.CompanyRepository.GetCompany(Id, false).FirstOrDefault();
            
            if(company == null)
            {
                return false;
            }

            _repository.CompanyRepository.DeleteCompany(company);

            _repository.Save();

            return true;
        }

        public IEnumerable<CompanyDto> GetCompanies(bool tranckChanges)
        {
            var companies = _repository.CompanyRepository.GetAllCompanies(tranckChanges);

            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public CompanyDto GetCompany(Guid Id, bool tranckChanges)
        {
            var company = _repository.CompanyRepository.GetCompany(Id, tranckChanges).FirstOrDefault();

            return company == null ? throw new CompanyNotFoundException(Id) : _mapper.Map<CompanyDto>(company);
        }

        public CompanyDto UpdateCompany(Guid Id, CompanyDto Company)
        {
            throw new NotImplementedException();
        }
    }
}
