using Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Company>> GetAllCompanies(bool tranckChanges) => await FindAll(tranckChanges).ToListAsync();


        public async Task<Company> GetCompanyAsync(Guid Id, bool tranckChanges) => await FindByCondition(c => c.Id.Equals(Id), tranckChanges).SingleOrDefaultAsync();

        

        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
          return  await FindByCondition(c => ids.Contains(c.Id), trackChanges).ToListAsync();
        }

       
    }
}
