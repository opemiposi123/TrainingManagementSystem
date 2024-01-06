using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManagementService.Dtos;
using TrainingManagementService.ResponseModel;

namespace TrainingManagementService.Implementation.Interface
{
    public interface ITrainingTypeService
    {
        Task<ServiceResponse<string>> CreateAsync(TrainingTypeDto trainingType, CancellationToken cancellationToken = default);

        Task<ServiceResponse<IEnumerable<TrainingTypeDto>>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ServiceResponse<TrainingTypeDto>> GetByIdAsync(string trainingTypeId, CancellationToken cancellationToken = default);
        Task<ServiceResponse<string>> UpdateAsync(TrainingTypeDto trainingType, CancellationToken cancellationToken = default);

        Task<ServiceResponse<string>> DeleteAsync(string trainingTypeId, CancellationToken cancellationToken = default);

        Task<IEnumerable<SelectListItem>> GetTrainingTypeListItem();
    }
}
