using AutoMapper;
using Contracts;
using Domain.Models;
using Domain.Models.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
       

        public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company)
        {

            var companyEntity = _mapper.Map<Company>(company);

            _repository.CompanyRepository.CreateCompany(companyEntity);

            await _repository.Save();

            var companytoReturn = _mapper.Map<CompanyDto>(companyEntity);

            return companytoReturn;
        }

        public Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection)
        {
            throw new NotImplementedException();
        }


        public async  Task DeleteCompanyAsync(Guid companyId, bool trackChanges)
        {

            var company = await GetCompanyAndCheckIfItExists(companyId, trackChanges);

            _repository.CompanyRepository.DeleteCompany(company);

            await _repository.Save();
        }

        public Task DeleteCompanyAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges)
        {
            var companies = await _repository.CompanyRepository.GetAllCompaniesAsync(trackChanges);

            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }


        public async Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExists(companyId, trackChanges);

            return _mapper.Map<CompanyDto>(company);
        }

        public async Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExists(companyId, trackChanges);

            _mapper.Map(companyForUpdate, company);

            await _repository.Save();

        }

        private async Task<Company> GetCompanyAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var company = await _repository.CompanyRepository.GetCompanyAsync(id, trackChanges);

            return company is null ?  throw new CompanyNotFoundException(id) :  company;

        }
    }
}
