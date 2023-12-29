using System.Linq.Expressions;
using TrainingManagementService.Entities;

namespace TrainingManagementService.Repositories.Interface
{
    public interface ITrainingRepository
    {
        Task<Training> AddAsync(Training training, CancellationToken cancellationToken = default);

        Task<Training?> GetAsync(Expression<Func<Training, bool>> expression, CancellationToken cancellationToken = default);

        Task<Training?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<Training> UpdateAsync(Training training);
         
        Task RemoveAsync(Training training);

        Task<IEnumerable<Training>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<Training>> GetAllAsync(Expression<Func<Training, bool>> expression, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<Training, bool>> expression, CancellationToken cancellationToken = default);
    }
}
