using Domain.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool tranckChanges);

        Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges);

        Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteCompany(Company entity);

        void UpdateCompany(Company entity);

        void CreateCompany(Company entity);
    }
}
