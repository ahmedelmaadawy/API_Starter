using Entities.Models;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid id, bool trackChanges);
        Task<Employee> GetEmployeeAsync(Guid CompanyId, Guid id, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee);
        void DeleteEmployee(Employee employee);

    }
}
