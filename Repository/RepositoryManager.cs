using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(RepositoryContext repositorycontext)
        {
            _repositoryContext = repositorycontext;
            _companyRepository = new Lazy<ICompanyRepository>(() =>
            new CompanyRepository(repositorycontext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() =>
            new EmployeeRepository(repositorycontext));
        }

        public ICompanyRepository Company => _companyRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
    }
}
