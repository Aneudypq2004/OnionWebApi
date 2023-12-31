﻿using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext repositoryContext;

        private readonly Lazy<ICompanyRepository> companyRepository;
        private readonly Lazy<IEmployeeRepository> employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
            companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
            employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
            
        }

        public ICompanyRepository CompanyRepository => companyRepository.Value;
        public IEmployeeRepository Employee => employeeRepository.Value;


        public async Task Save()
        {
            await repositoryContext.SaveChangesAsync();
        }
    }
}
