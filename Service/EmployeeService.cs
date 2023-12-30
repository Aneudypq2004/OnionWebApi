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
        public EmployeeDto CreateEmployee(EmployeeForCreationDto employee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(Guid Id)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto GetEmployee(Guid Id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            return (null, null);
        }

        public IEnumerable<EmployeeDto> GetEmployees(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto UpdateEmployee(Guid Id, EmployeeDto employee)
        {
            throw new NotImplementedException();
        }
    }
}
