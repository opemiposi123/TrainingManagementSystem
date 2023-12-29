using System.Linq.Expressions;
using TrainingManagementService.Entities;

namespace TrainingManagementService.Repositories.Interface
{
    public interface ITrainingTypeRepository
    {
        Task<TrainingType> AddAsync(TrainingType trainingType, CancellationToken cancellationToken = default);

        Task<TrainingType?> GetAsync(Expression<Func<TrainingType, bool>> expression, CancellationToken cancellationToken = default);

        Task<TrainingType?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<TrainingType> UpdateAsync(TrainingType trainingType);

        Task RemoveAsync(TrainingType trainingType);

        Task<IEnumerable<TrainingType>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<TrainingType>> GetAllAsync(Expression<Func<TrainingType, bool>> expression, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<TrainingType, bool>> expression, CancellationToken cancellationToken = default);
    }
}
