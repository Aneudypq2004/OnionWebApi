using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetCompanies(bool tranckChanges);
        CompanyDto GetCompany(Guid Id, bool tranckChanges);
        CompanyDto CreateCompany(CompanyForCreacionDto company);
        CompanyDto UpdateCompany(Guid Id, CompanyDto Company);

        bool DeleteCompany(Guid Id);

    }
}
