using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public EmployeeDto GetEmployee(Guid companyId, Guid employeeId, bool trackCkanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges: false);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employee = _repository.Employee.GetEmployee(companyId, employeeId, trackCkanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges: false);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employees = _repository.Employee.GetEmployees(companyId, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeesDto;

        }
    }
}
