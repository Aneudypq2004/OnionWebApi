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
        IEnumerable<Company> GetAllCompanies(bool tranckChanges);

        IEnumerable<Company> GetCompany(Guid Id, bool tranckChanges);

        void DeleteCompany(Company entity);

        void UpdateCompany(Company entity);

        void CreateCompany(Company entity);
    }
}
