﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        public ICompanyRepository CompanyRepository { get; }
        public IEmployeeRepository Employee { get; }

        Task Save();
    }
}