using Domain.Models;
using Shared.DataTransferObjects;
using System;


namespace Service.Contracts
{
    public interface IEmployeeService
    {

        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, bool trackChanges);

        EmployeeDto GetEmployee (Guid Id, bool trackChanges);

        EmployeeDto CreateEmployee(EmployeeForCreationDto employee);
        EmployeeDto UpdateEmployee(Guid Id, EmployeeDto employee);

        bool DeleteEmployee(Guid Id);

        (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(
           Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);
        void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee  employeeEntity);
    }
}
