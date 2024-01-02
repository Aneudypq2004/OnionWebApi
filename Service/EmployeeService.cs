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
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public EmployeeService(IRepositoryManager repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;

        }
       

        public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto GetEmployee(Guid Id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto CreateEmployee(EmployeeForCreationDto employee)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto UpdateEmployee(Guid Id, EmployeeDto employee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(Guid Id)
        {
            throw new NotImplementedException();
        }

        public (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            throw new NotImplementedException();
        }

        public void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            throw new NotImplementedException();
        }


        // HELP

        private async Task<Employee> GetEmployeeForCompanyAndCheckIfItExists(Guid companyId, Guid id, bool trackChanges)
        {
            var employeeDb = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges);

            return employeeDb is null ? throw new EmployeeNotFoundException(id.ToString()) : employeeDb;
        }


        private async Task CheckIfCompanyExists(Guid companyId, bool trackChanges)
        {
            var company = await _repository.CompanyRepository.GetCompanyAsync(companyId, trackChanges);

            if (company is null) throw new CompanyNotFoundException(companyId);
        }
    }
}
