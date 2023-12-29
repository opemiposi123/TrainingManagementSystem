using System.Linq.Expressions;
using TrainingManagementService.Entities;

namespace TrainingManagementService.Repositories.Interface
{
    public interface ITrainingVendorRepository 
    {
        Task<TrainingVendor> AddAsync(TrainingVendor trainingType, CancellationToken cancellationToken = default);

        Task<TrainingVendor?> GetAsync(Expression<Func<TrainingVendor, bool>> expression, CancellationToken cancellationToken = default);

        Task<TrainingVendor?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<TrainingVendor> UpdateAsync(TrainingVendor trainingType);

        Task RemoveAsync(TrainingVendor trainingType);

        Task<IEnumerable<TrainingVendor>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<TrainingVendor>> GetAllAsync(Expression<Func<TrainingVendor, bool>> expression, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<TrainingVendor, bool>> expression, CancellationToken cancellationToken = default);
    }
}
