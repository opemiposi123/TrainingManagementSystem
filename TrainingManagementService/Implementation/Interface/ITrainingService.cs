using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManagementService.Dtos;
using TrainingManagementService.ResponseModel;

namespace TrainingManagementService.Implementation.Interface
{
    public interface ITrainingService
    {
        Task<ServiceResponse<string>> CreateAsync(TrainingDto training, CancellationToken cancellationToken = default);

        Task<ServiceResponse<IEnumerable<TrainingDto>>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ServiceResponse<TrainingDto>> GetByIdAsync(string trainingId, CancellationToken cancellationToken = default);

        Task<ServiceResponse<string>> UpdateAsync(TrainingDto training, CancellationToken cancellationToken = default);

        Task<ServiceResponse<string>> DeleteAsync(string trainingId, CancellationToken cancellationToken = default);

        Task<IEnumerable<SelectListItem>> GetTrainingListItem();
    }
}
