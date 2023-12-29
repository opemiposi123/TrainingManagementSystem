using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManagementService.Dtos;
using TrainingManagementService.ResponseModel;

namespace TrainingManagementService.Implementation.Interface
{
    public interface ITrainingVendorService
    {
        Task<ServiceResponse<string>> CreateAsync(TrainingVendorDto trainingVendor, CancellationToken cancellationToken = default);

        Task<ServiceResponse<IEnumerable<TrainingVendorDto>>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ServiceResponse<TrainingVendorDto>> GetByIdAsync(string trainingVendorId, CancellationToken cancellationToken = default);

        Task<ServiceResponse<string>> UpdateAsync(TrainingVendorDto trainingVendor, CancellationToken cancellationToken = default);

        Task<ServiceResponse<string>> DeleteAsync(string trainingVendorId, CancellationToken cancellationToken = default);

        Task<IEnumerable<SelectListItem>> GetTrainingVendorListItem();
    }
}
