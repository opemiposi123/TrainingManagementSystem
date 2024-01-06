using ITHelpDesk.Application.Shared.Contracts;
using ITHelpDesk.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManagementService.Dtos;
using TrainingManagementService.Entities;
using TrainingManagementService.Implementation.Interface;
using TrainingManagementService.Repositories.Interface;
using TrainingManagementService.ResponseModel;

namespace TrainingManagementService.Implementation.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IResponseResult _responseResult;

        public TrainingService(
            IRepositoryManager repositoryManager,
            IResponseResult responseResult)
        {
            _repositoryManager = repositoryManager;
            _responseResult = responseResult;
        }

        public async Task<ServiceResponse<string>> CreateAsync(TrainingDto request, CancellationToken cancellationToken = default)
        {
            try
            {
                var training = new Training
                {
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    Budget = request.Budget,
                    TrainingStatus = request.TrainingStatus,
                    //TrainingTypeId = request.TrainingTypeId,
                    TrainingVendorSpecializationId = request.TrainingVendorSpecializationId,
                    TrainingVendorId = request.TrainingVendorId,
                    EmployeeTrainingRequestId = request.EmployeeTrainingRequestId,
                    ApprovingEmployeeId = request.ApprovingEmployeeId,
                };
                var result = await _repositoryManager.TrainingRepository.AddAsync(training);
                int rows = await _repositoryManager.UnitOfWork.SaveChangesAsync();

                if (rows > 0)
                {
                    return _responseResult.Success<string>(message: "Training created successfully");
                }

                return _responseResult.Failure<string>(ResponseCodes.ITDeskHelpResponse, description: "Unable to create Training");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<string>> DeleteAsync(string trainingId, CancellationToken cancellationToken = default)
        {
            try
            {
                var isTrainingExist = await _repositoryManager.TrainingRepository.ExistsAsync(r => r.Id == trainingId);

                if (!isTrainingExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var training = await _repositoryManager.TrainingVendorRepository.GetByIdAsync(trainingId, cancellationToken);

                await _repositoryManager.TrainingVendorRepository.RemoveAsync(training!);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Training deleted successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<TrainingDto>> GetByIdAsync(string trainingId, CancellationToken cancellationToken = default)
        {
            try
            {
                var trainingExist = await _repositoryManager.TrainingVendorRepository.ExistsAsync(r => r.Id == trainingId);

                if (!trainingExist)
                {
                    return _responseResult.Failure<TrainingDto>(ResponseCodes.Record_NotFound);
                }

                var request = await _repositoryManager.TrainingRepository.GetByIdAsync(trainingId);

                var details = new TrainingDto
                {
                    Budget = request.Budget,
                    Description = request.Description
                };

                return _responseResult.Success(details);
            }
            catch (Exception)
            {
                return _responseResult.Failure<TrainingDto>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<string>> UpdateAsync(TrainingDto model, CancellationToken cancellationToken = default)
        {
            try
            {
                var trainingExist = await _repositoryManager.TrainingRepository.ExistsAsync(r => r.Id == model.Id);

                if (!trainingExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var training = await _repositoryManager.TrainingRepository.GetByIdAsync(model.Id);

                training.Budget = model.Budget;
                training.Description = model.Description;
                training.EndTime = model.EndTime;
                training.EndDate = model.EndDate;
                training.StartTime = model.StartTime;
                training.StartDate = model.StartDate;
                training.TrainingStatus = model.TrainingStatus;
               // training.TrainingTypeId = model.TrainingTypeId;
                training.TrainingVendorId = model.TrainingVendorId;
                training.TrainingVendorSpecializationId = model.TrainingVendorSpecializationId;


                await _repositoryManager.TrainingRepository.UpdateAsync(training);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Training updated successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<IEnumerable<TrainingDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _repositoryManager.TrainingRepository.GetAllAsync();

                if (result == null)
                {
                    return _responseResult.Failure<IEnumerable<TrainingDto>>(ResponseCodes.Record_NotFound);
                }

                var data = result
                     .Where(d => d.IsDeleted == false)
                     .Select(x => new TrainingDto
                     {
                         Id = x.Id,
                         Budget = x.Budget,
                         Description = x.Description,
                         EndTime = x.EndTime,
                         TrainingStatus = x.TrainingStatus,
                         TrainingVendorSpecializationId = x.TrainingVendorSpecializationId
                     });

                return _responseResult.Success(data);
            }
            catch (Exception)
            {
                return _responseResult.Failure<IEnumerable<TrainingDto>>(ResponseCodes.GeneralError);
            }
        }

        public async Task<IEnumerable<SelectListItem>> GetTrainingListItem()
        {
            var training = await _repositoryManager.TrainingRepository.GetAllAsync();

            var selectListItem = training.Select(item => new SelectListItem()
            {
                Value = item.Id,
                Text = item.Description
            }).ToList();

            return selectListItem;
        }
    }
}
