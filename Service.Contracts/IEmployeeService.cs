using Domain.LinkModels;
using Domain.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;


namespace Service.Contracts
{
    public interface IEmployeeService
    {

        Task<(LinkResponse linkResponse, MetaData metaData)> GetEmployeesAsync(Guid companyId, LinkParameters linkParameters, bool trackChanges);

        Task<EmployeeDto> CreateEmployee(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges);
        Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges);
        Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges);

        (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(
           Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);
        void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
    }
}
