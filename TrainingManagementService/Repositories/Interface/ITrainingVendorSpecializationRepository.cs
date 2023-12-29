using System.Linq.Expressions;
using TrainingManagementService.Entities;

namespace TrainingManagementService.Repositories.Interface
{
    public interface ITrainingVendorSpecializationRepository
    {
        Task<TrainingVendorSpecialization> AddAsync(TrainingVendorSpecialization trainingType, CancellationToken cancellationToken = default);

        Task<TrainingVendorSpecialization?> GetAsync(Expression<Func<TrainingVendorSpecialization, bool>> expression, CancellationToken cancellationToken = default);

        Task<TrainingVendorSpecialization?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<TrainingVendorSpecialization> UpdateAsync(TrainingVendorSpecialization trainingType);

        Task RemoveAsync(TrainingVendorSpecialization trainingType);

        Task<IEnumerable<TrainingVendorSpecialization>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<TrainingVendorSpecialization>> GetAllAsync(Expression<Func<TrainingVendorSpecialization, bool>> expression, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<TrainingVendorSpecialization, bool>> expression, CancellationToken cancellationToken = default);
    }
}
