using System.Linq.Expressions;
using TrainingManagementService.Entities;

namespace TrainingManagementService.Repositories.Interface;

public interface IDepartmentRepository
{
    Task<Department> AddAsync(Department department, CancellationToken cancellationToken = default);

    Task<Department?> GetAsync(Expression<Func<Department, bool>> expression, CancellationToken cancellationToken = default);

    Task<Department?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

    Task<Department> UpdateAsync(Department department);

    Task RemoveAsync(Department department);

    Task<IEnumerable<Department>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Department>> GetAllAsync(Expression<Func<Department, bool>> expression, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Expression<Func<Department, bool>> expression, CancellationToken cancellationToken = default);
}
