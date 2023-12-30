using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {

            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, mapper));
            
        }

        public ICompanyService CompanyService => _companyService.Value;
    }
}