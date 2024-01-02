using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(Guid companyId, Guid id, bool empTrackChanges);

        Task<IEnumerable<Employee>> GetEmployees(Guid companyId, bool trackChanges);

        Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChange);
    }
}
