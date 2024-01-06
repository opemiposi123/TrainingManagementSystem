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
    public class TrainingTypeService : ITrainingTypeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IResponseResult _responseResult;

        public TrainingTypeService(
            IRepositoryManager repositoryManager,
            IResponseResult responseResult)
        {
            _repositoryManager = repositoryManager;
            _responseResult = responseResult;
        }

        public async Task<ServiceResponse<string>> CreateAsync(TrainingTypeDto request, CancellationToken cancellationToken = default)
        {
            try
            {
                var isTrainingTypeExist = await _repositoryManager.TrainingTypeRepository.ExistsAsync(c => c.Title == request.Title);

                if (isTrainingTypeExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.ForbidDuplicates);
                }

                var trainingType = new TrainingType
                {
                    Title = request.Title,
                    ResourcePerson = request.ResourcePerson,
                    CostPerHead = request.CostPerHead,
                    OverallBudget = request.OverallBudget,
                    NoOfTrainees = request.NoOfTrainees,
                    TraningTypeCategory = request.TraningTypeCategory,
                };
                var result = await _repositoryManager.TrainingTypeRepository.AddAsync(trainingType);
                int rows = await _repositoryManager.UnitOfWork.SaveChangesAsync();

                if (rows > 0)
                {
                    return _responseResult.Success<string>(message: "Training type record created successfully");
                }

                return _responseResult.Failure<string>(ResponseCodes.ITDeskHelpResponse, description: "Unable to create Training Type");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<string>> DeleteAsync(string trainingTypeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var isTrainingTypeExist = await _repositoryManager.TrainingTypeRepository.ExistsAsync(r => r.Id == trainingTypeId);

                if (!isTrainingTypeExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var trainingType = await _repositoryManager.TrainingTypeRepository.GetByIdAsync(trainingTypeId, cancellationToken);

                await _repositoryManager.TrainingTypeRepository.RemoveAsync(trainingType!);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Training Type deleted successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<TrainingTypeDto>> GetByIdAsync(string trainingTypeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var trainingTypeExist = await _repositoryManager.TrainingTypeRepository.ExistsAsync(r => r.Id == trainingTypeId);

                if (!trainingTypeExist)
                {
                    return _responseResult.Failure<TrainingTypeDto>(ResponseCodes.Record_NotFound);
                }

                var request = await _repositoryManager.TrainingTypeRepository.GetByIdAsync(trainingTypeId);

                var details = new TrainingTypeDto
                {
                    Title = request!.Title,
                    ResourcePerson = request.ResourcePerson,
                    TraningTypeCategory = request.TraningTypeCategory
                };

                return _responseResult.Success(details);
            }
            catch (Exception)
            {
                return _responseResult.Failure<TrainingTypeDto>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<string>> UpdateAsync(TrainingTypeDto model, CancellationToken cancellationToken = default)
        {
            try
            {
                var trainingVendorExist = await _repositoryManager.TrainingTypeRepository.ExistsAsync(r => r.Id == model.Id);

                if (!trainingVendorExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var trainingType = await _repositoryManager.TrainingTypeRepository.GetByIdAsync(model.Id);

                trainingType!.Title = model.Title;
                trainingType.ResourcePerson = model.ResourcePerson;
                trainingType.CostPerHead = model.CostPerHead;
                trainingType.OverallBudget = model.OverallBudget;
                trainingType.NoOfTrainees = model.NoOfTrainees;


                await _repositoryManager.TrainingTypeRepository.UpdateAsync(trainingType);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Training Type updated successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<IEnumerable<TrainingTypeDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _repositoryManager.TrainingTypeRepository.GetAllAsync();

                if (result == null)
                {
                    return _responseResult.Failure<IEnumerable<TrainingTypeDto>>(ResponseCodes.Record_NotFound);
                }

                var data = result
                     .Where(d => d.IsDeleted == false)
                     .Select(x => new TrainingTypeDto
                     {
                         Id = x.Id,
                         ResourcePerson = x.ResourcePerson,
                         Title = x.Title,
                         CostPerHead = x.CostPerHead,
                         NoOfTrainees = x.NoOfTrainees,
                         OverallBudget = x.OverallBudget,
                         TraningTypeCategory = x.TraningTypeCategory
                     });

                return _responseResult.Success(data);
            }
            catch (Exception)
            {
                return _responseResult.Failure<IEnumerable<TrainingTypeDto>>(ResponseCodes.GeneralError);
            }
        }

        public async Task<IEnumerable<SelectListItem>> GetTrainingTypeListItem()
        {
            var trainingtypes = await _repositoryManager.TrainingTypeRepository.GetAllAsync();

            var selectListItem = trainingtypes.Select(item => new SelectListItem()
            {
                Value = item.Id,
                Text = item.Title
            }).ToList();

            return selectListItem;
        }

    }
}
