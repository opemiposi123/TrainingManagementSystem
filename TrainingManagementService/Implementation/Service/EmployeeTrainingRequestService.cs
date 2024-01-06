using ITHelpDesk.Application.Shared.Contracts;
using ITHelpDesk.Domain.Enums;
using TrainingManagementService.Dtos;
using TrainingManagementService.Entities;
using TrainingManagementService.Implementation.Interface;
using TrainingManagementService.Repositories.Interface;
using TrainingManagementService.ResponseModel;

namespace TrainingManagementService.Implementation.Service
{
    public class EmployeeTrainingRequestService : IEmployeeTrainingRequestService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IResponseResult _responseResult;

        public EmployeeTrainingRequestService(
            IRepositoryManager repositoryManager,
            IResponseResult responseResult)
        {
            _repositoryManager = repositoryManager;
            _responseResult = responseResult;
        }

        public async Task<ServiceResponse<string>> TrainingRequest(EmployeeTrainingRequestDto request, CancellationToken cancellationToken = default)
        {
            try
            {
                var employeeTrainingRequest = new EmployeeTrainingRequest
                {
                    EmployeeId = request.EmployeeId,
                    ApprovalStatus = request.ApprovalStatus,
                    Budget = request.Budget,
                    DepartmentId = request.DepartmentId,
                    TrainingTypeId = request.TrainingTypeId,
                    RequestedDate = request.RequestedDate
                };
                var result = await _repositoryManager.EmployeeTrainingRequestRepository.AddAsync(employeeTrainingRequest);
                int rows = await _repositoryManager.UnitOfWork.SaveChangesAsync();

                if (rows > 0)
                {
                    return _responseResult.Success<string>(message: "Training Request submitted successfully");
                }

                return _responseResult.Failure<string>(ResponseCodes.ITDeskHelpResponse, description: "Unable to submit Training Request");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<string>> DeleteAsync(string employeeTrainingRequestId, CancellationToken cancellationToken = default)
        {
            try
            {
                var isemployeeTrainingRequestExist = await _repositoryManager.EmployeeTrainingRequestRepository.ExistsAsync(r => r.Id == employeeTrainingRequestId);

                if (!isemployeeTrainingRequestExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var trainingRequest = await _repositoryManager.EmployeeTrainingRequestRepository.GetByIdAsync(employeeTrainingRequestId, cancellationToken);

                await _repositoryManager.EmployeeTrainingRequestRepository.RemoveAsync(trainingRequest!);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Employee Training Request deleted successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<EmployeeTrainingRequestDto>> GetByIdAsync(string employeeTrainingRequestId, CancellationToken cancellationToken = default)
        {
            try
            {
                var employeeTrainingRequest = await _repositoryManager.EmployeeTrainingRequestRepository.ExistsAsync(r => r.Id == employeeTrainingRequestId);

                if (!employeeTrainingRequest)
                {
                    return _responseResult.Failure<EmployeeTrainingRequestDto>(ResponseCodes.Record_NotFound);
                }

                var request = await _repositoryManager.EmployeeTrainingRequestRepository.GetByIdAsync(employeeTrainingRequestId);

                var details = new EmployeeTrainingRequestDto
                {
                    Duration = request!.Duration,
                    Budget = request.Budget
                };

                return _responseResult.Success(details);
            }
            catch (Exception)
            {
                return _responseResult.Failure<EmployeeTrainingRequestDto>(ResponseCodes.GeneralError);
            }
        }
    }
}
