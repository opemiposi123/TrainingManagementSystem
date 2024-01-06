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
    public class TrainingPlanService : ITrainingPlanService
    {

        private readonly IRepositoryManager _repositoryManager;
        private readonly IResponseResult _responseResult;

        public TrainingPlanService(
            IRepositoryManager repositoryManager,
            IResponseResult responseResult)
        {
            _repositoryManager = repositoryManager;
            _responseResult = responseResult;
        }

        public async Task<ServiceResponse<string>> CreateAsync(TrainingPlanDto request, CancellationToken cancellationToken = default)
        {
            try
            {
                var IsTrainingPlanExist = await _repositoryManager.TrainingPlanRepository.ExistsAsync(c => c.Date == request.Date);

                if (IsTrainingPlanExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.ForbidDuplicates);
                }

                var trainingPlan = new TrainingPlan
                {
                    Date = request.Date,
                    Description = request.Description,
                    Location = request.Location,
                    Platform = request.Platform,
                    CertificateOfCompletion = request.CertificateOfCompletion,
                    ConnectionLink = request.ConnectionLink,
                    AppraisalGap = request.AppraisalGap,
                    Specialization = request.Specialization,
                    TrainingPlatForm = request.TrainingPlatForm,
                    TrainingVendorId = request.TrainingVendorId,
                };
                var result = await _repositoryManager.TrainingPlanRepository.AddAsync(trainingPlan);
                int rows = await _repositoryManager.UnitOfWork.SaveChangesAsync();

                if (rows > 0)
                {
                    return _responseResult.Success<string>(message: "Training Plan  record created successfully");
                }

                return _responseResult.Failure<string>(ResponseCodes.ITDeskHelpResponse, description: "Unable to create Training Plan");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<string>> DeleteAsync(string trainingPlanId, CancellationToken cancellationToken = default)
        {
            try
            {
                var isTrainingPlanExist = await _repositoryManager.TrainingPlanRepository.ExistsAsync(r => r.Id == trainingPlanId);

                if (!isTrainingPlanExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var trainingPlan = await _repositoryManager.TrainingPlanRepository.GetByIdAsync(trainingPlanId, cancellationToken);

                await _repositoryManager.TrainingPlanRepository.RemoveAsync(trainingPlan!);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Training Plan deleted successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<TrainingPlanDto>> GetByIdAsync(string trainingPlanId, CancellationToken cancellationToken = default)
        {
            try
            {
                var trainingPlanExist = await _repositoryManager.TrainingPlanRepository.ExistsAsync(r => r.Id == trainingPlanId);

                if (!trainingPlanExist)
                {
                    return _responseResult.Failure<TrainingPlanDto>(ResponseCodes.Record_NotFound);
                }

                var request = await _repositoryManager.TrainingPlanRepository.GetByIdAsync(trainingPlanId);

                var details = new TrainingPlanDto
                {
                    Id = request.Id,
                    Location = request!.Location
                };

                return _responseResult.Success(details);
            }
            catch (Exception)
            {
                return _responseResult.Failure<TrainingPlanDto>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<string>> UpdateAsync(TrainingPlanDto model, CancellationToken cancellationToken = default)
        {
            try
            {
                var trainingPlanExist = await _repositoryManager.TrainingPlanRepository.ExistsAsync(r => r.Id == model.Id);

                if (!trainingPlanExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var trainingPlan = await _repositoryManager.TrainingPlanRepository.GetByIdAsync(model.Id);

                trainingPlan.Date = model.Date;
                trainingPlan.Description = model.Description;
                trainingPlan.Location = model.Location;
                trainingPlan.Platform = model.Platform;
                trainingPlan.ConnectionLink = model.ConnectionLink;
                trainingPlan.AppraisalGap = model.AppraisalGap;
                trainingPlan.Specialization = model.Specialization;
                trainingPlan.TrainingPlatForm = model.TrainingPlatForm;


                await _repositoryManager.TrainingPlanRepository.UpdateAsync(trainingPlan);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Training Plan updated successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<IEnumerable<TrainingPlanDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _repositoryManager.TrainingPlanRepository.GetAllAsync();

                if (result == null)
                {
                    return _responseResult.Failure<IEnumerable<TrainingPlanDto>>(ResponseCodes.Record_NotFound);
                }

                var data = result
                     .Where(d => d.IsDeleted == false)
                     .Select(x => new TrainingPlanDto
                     {
                         Id = x.Id,
                         Date = x.Date,
                         Location = x.Location,
                         Description = x.Description,
                         Platform = x.Platform,
                         CertificateOfCompletion = x.CertificateOfCompletion,
                         AppraisalGap = x.AppraisalGap,
                         Specialization = x.Specialization,
                         ConnectionLink = x.ConnectionLink,
                         TrainingPlatForm = x.TrainingPlatForm
                     });

                return _responseResult.Success(data);
            }
            catch (Exception)
            {
                return _responseResult.Failure<IEnumerable<TrainingPlanDto>>(ResponseCodes.GeneralError);
            }
        }

        public async Task<IEnumerable<SelectListItem>> GetTrainingPlanListItem()
        {
            var trainingVendors = await _repositoryManager.TrainingPlanRepository.GetAllAsync();

            var selectListItem = trainingVendors.Select(item => new SelectListItem()
            {
                Value = item.Id,
                Text = item.Location
            }).ToList();

            return selectListItem;
        }
    }
}
