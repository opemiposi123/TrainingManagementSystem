using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManagementService.Dtos;
using TrainingManagementService.ResponseModel;

namespace TrainingManagementService.Implementation.Interface
{
    public interface IEmployeeTrainingRequestService
    {
        Task<ServiceResponse<string>> TrainingRequest(EmployeeTrainingRequestDto employeeTrainingRequestDto, CancellationToken cancellationToken = default);

        //Task<ServiceResponse<IEnumerable<EmployeeTrainingRequestDto>>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ServiceResponse<EmployeeTrainingRequestDto>> GetByIdAsync(string employeeTrainingRequestId, CancellationToken cancellationToken = default);

        //Task<ServiceResponse<string>> UpdateAsync(EmployeeTrainingRequestDto employeeTrainingRequestId, CancellationToken cancellationToken = default);

        Task<ServiceResponse<string>> DeleteAsync(string employeeTrainingRequestId, CancellationToken cancellationToken = default);

        //Task<IEnumerable<SelectListItem>> GetTrainingListItem();
    }
}
