using Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repository) : base(repository)
        {
        }

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, bool trackChange, EmployeeParameters parameters)
        {
            var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChange)
                                .FilterEmployees(parameters.MinAge, parameters.MaxAge)
                                .Search(parameters.SearchTerm)
                                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                                .Take(parameters.PageSize)
                                .Sort(parameters.OrderBy)
                                .ToListAsync();

            var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChange).CountAsync();

          
            return new PagedList<Employee>(employees, count, parameters.PageNumber, parameters.PageSize);
        }
    }
}
