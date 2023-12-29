using System.Linq.Expressions;
using TrainingManagementService.Entities;

namespace TrainingManagementService.Repositories.Interface
{
    public interface IEmployeeTrainingRequestRepository
    {
        Task<EmployeeTrainingRequest> AddAsync(EmployeeTrainingRequest trainingRequest, CancellationToken cancellationToken = default);

        Task<EmployeeTrainingRequest?> GetAsync(Expression<Func<EmployeeTrainingRequest, bool>> expression, CancellationToken cancellationToken = default);

        Task<EmployeeTrainingRequest?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<EmployeeTrainingRequest> UpdateAsync(EmployeeTrainingRequest trainingRequest);

        Task RemoveAsync(EmployeeTrainingRequest trainingRequest);

        Task<IEnumerable<EmployeeTrainingRequest>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<EmployeeTrainingRequest>> GetAllAsync(Expression<Func<EmployeeTrainingRequest, bool>> expression, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<EmployeeTrainingRequest, bool>> expression, CancellationToken cancellationToken = default);
    }
}
