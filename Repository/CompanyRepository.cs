using Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repository) : base(repository)
        {
        }

        public void CreateCompany(Company entity) => Create(entity);
        
        public void DeleteCompany(Company entity) => Delete(entity);

        public void UpdateCompany(Company entity) => Update(entity);

        public IEnumerable<Company> GetAllCompanies(bool tranckChanges) => FindAll(tranckChanges);
        

        public IEnumerable<Company> GetCompany(Guid Id, bool tranckChanges) => FindByCondition(c => c.Id.Equals(Id), tranckChanges);
      

       
    }
}
