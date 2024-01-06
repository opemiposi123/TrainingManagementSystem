using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManagementService.Dtos;
using TrainingManagementService.ResponseModel;

namespace TrainingManagementService.Implementation.Interface
{
    public interface ITrainingPlanService
    {
        Task<ServiceResponse<string>> CreateAsync(TrainingPlanDto trainingPlan, CancellationToken cancellationToken = default);

        Task<ServiceResponse<IEnumerable<TrainingPlanDto>>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ServiceResponse<TrainingPlanDto>> GetByIdAsync(string trainingPlanId, CancellationToken cancellationToken = default);

        Task<ServiceResponse<string>> UpdateAsync(TrainingPlanDto trainingPlan, CancellationToken cancellationToken = default);

        Task<ServiceResponse<string>> DeleteAsync(string trainingPlanId, CancellationToken cancellationToken = default);

        Task<IEnumerable<SelectListItem>> GetTrainingPlanListItem();
    }
}
