using System.Linq.Expressions;
using TrainingManagementService.Entities;

namespace TrainingManagementService.Repositories.Interface;

public interface IEmployeeRepository
{
    Task<Employee> AddAsync(Employee employee, CancellationToken cancellationToken = default);

    Task<Employee?> GetAsync(Expression<Func<Employee, bool>> expression, CancellationToken cancellationToken = default);

    Task<Employee?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

    Task<Employee> UpdateAsync(Employee employee);

    Task RemoveAsync(Employee employee);

    Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> expression, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Expression<Func<Employee, bool>> expression, CancellationToken cancellationToken = default);
}
