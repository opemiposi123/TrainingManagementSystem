using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManagementService.Dtos;
using TrainingManagementService.ResponseModel;

namespace TrainingManagementService.Implementation.Interface
{
    public interface IDepartmentService
    {
        Task<ServiceResponse<string>> CreateAsync(DepartmentDto department, CancellationToken cancellationToken = default);

        Task<ServiceResponse<IEnumerable<DepartmentDto>>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ServiceResponse<DepartmentDto>> GetByIdAsync(string departmentId, CancellationToken cancellationToken = default);

        Task<ServiceResponse<string>> UpdateAsync(DepartmentDto department, CancellationToken cancellationToken = default);

        Task<ServiceResponse<string>> DeleteAsync(string departmentId, CancellationToken cancellationToken = default);

        Task<IEnumerable<SelectListItem>> GetDepartmentListItem();
    }
}
