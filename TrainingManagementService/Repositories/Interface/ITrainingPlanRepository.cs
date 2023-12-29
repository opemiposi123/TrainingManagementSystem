using System.Linq.Expressions;
using TrainingManagementService.Entities;

namespace TrainingManagementService.Repositories.Interface
{
    public interface ITrainingPlanRepository
    {
        Task<TrainingPlan> AddAsync(TrainingPlan trainingPlan, CancellationToken cancellationToken = default);

        Task<TrainingPlan?> GetAsync(Expression<Func<TrainingPlan, bool>> expression, CancellationToken cancellationToken = default);

        Task<TrainingPlan?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<TrainingPlan> UpdateAsync(TrainingPlan trainingPlan);

        Task RemoveAsync(TrainingPlan trainingPlan);

        Task<IEnumerable<TrainingPlan>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<TrainingPlan>> GetAllAsync(Expression<Func<TrainingPlan, bool>> expression, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<TrainingPlan, bool>> expression, CancellationToken cancellationToken = default);
    }
}
