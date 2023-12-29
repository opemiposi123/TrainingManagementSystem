using ITHelpDesk.Application.Shared.Contracts;
using ITHelpDesk.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManagementService.Dtos;
using TrainingManagementService.Entities;
using TrainingManagementService.Implementation.Interface;
using TrainingManagementService.Repositories.Interface;
using TrainingManagementService.Repositories.Service;
using TrainingManagementService.ResponseModel;

namespace TrainingManagementService.Implementation.Service
{
    public class TrainingVendorService : ITrainingVendorService

    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IResponseResult _responseResult;

        public TrainingVendorService(
            IRepositoryManager repositoryManager,
            IResponseResult responseResult)
        {
            _repositoryManager = repositoryManager;
            _responseResult = responseResult;
        }

        public async Task<ServiceResponse<string>> CreateAsync(TrainingVendorDto request, CancellationToken cancellationToken = default)
        {
            try
            {
                var isTrainingvendorExist = await _repositoryManager.TrainingVendorRepository.ExistsAsync(c => c.VendorName == request.VendorName);

                if (isTrainingvendorExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.ForbidDuplicates);
                }

                var trainingVendor = new TrainingVendor
                {
                    VendorName = request.VendorName,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    ImageUrl = request.ImageUrl,
                    Website = request.Website,
                    TrainingVendorSpecializationId = request.TrainingVendorSpecializationId,
                    CountOfSpecialization = request.CountOfSpecialization,
                };
                var result = await _repositoryManager.TrainingVendorRepository.AddAsync(trainingVendor);
                int rows = await _repositoryManager.UnitOfWork.SaveChangesAsync();

                if (rows > 0)
                {
                    return _responseResult.Success<string>(message: "TrainingVendor  record created successfully");
                }

                return _responseResult.Failure<string>(ResponseCodes.ITDeskHelpResponse, description: "Unable to create TrainingVendor");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<string>> DeleteAsync(string departmentId, CancellationToken cancellationToken = default)
        {
            try
            {
                var isTrainingVendorExist = await _repositoryManager.TrainingVendorRepository.ExistsAsync(r => r.Id == departmentId);

                if (!isTrainingVendorExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var department = await _repositoryManager.TrainingVendorRepository.GetByIdAsync(departmentId, cancellationToken);

                await _repositoryManager.TrainingVendorRepository.RemoveAsync(department!);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Training Vendor deleted successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<TrainingVendorDto>> GetByIdAsync(string trainingVendorId, CancellationToken cancellationToken = default)
        {
            try
            {
                var trainingVendorExist = await _repositoryManager.TrainingVendorRepository.ExistsAsync(r => r.Id == trainingVendorId);

                if (!trainingVendorExist)
                {
                    return _responseResult.Failure<TrainingVendorDto>(ResponseCodes.Record_NotFound);
                }

                var request = await _repositoryManager.TrainingVendorRepository.GetByIdAsync(trainingVendorId);

                var details = new TrainingVendorDto
                {
                    VendorName = request!.VendorName,
                    Email = request.Email,
                    TrainingVendorSpecializationId = request.TrainingVendorSpecializationId
                };

                return _responseResult.Success(details);
            }
            catch (Exception)
            {
                return _responseResult.Failure<TrainingVendorDto>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<string>> UpdateAsync(TrainingVendorDto model, CancellationToken cancellationToken = default)
        {
            try
            {
                var trainingVendorExist = await _repositoryManager.TrainingVendorRepository.ExistsAsync(r => r.Id == model.Id);

                if (!trainingVendorExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var trainingVendor = await _repositoryManager.TrainingVendorRepository.GetByIdAsync(model.Id);

                trainingVendor!.VendorName = model.VendorName;
                trainingVendor.Email = model.Email;
                trainingVendor.PhoneNumber = model.PhoneNumber;
                trainingVendor.Website = model.Website;
                trainingVendor.ImageUrl = model.ImageUrl;


                await _repositoryManager.TrainingVendorRepository.UpdateAsync(trainingVendor);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Training Vendor updated successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<IEnumerable<TrainingVendorDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _repositoryManager.TrainingVendorRepository.GetAllAsync();

                if (result == null)
                {
                    return _responseResult.Failure<IEnumerable<TrainingVendorDto>>(ResponseCodes.Record_NotFound);
                }

                var data = result
                     .Where(d => d.IsDeleted == false)
                     .Select(x => new TrainingVendorDto
                     {
                         Id = x.Id,
                         VendorName = x.VendorName,
                         Email = x.Email,
                         PhoneNumber = x.PhoneNumber,
                         ImageUrl = x.ImageUrl,
                         Website = x.Website,
                         TrainingVendorSpecializationId = x.TrainingVendorSpecializationId
                     });

                return _responseResult.Success(data);
            }
            catch (Exception)
            {
                return _responseResult.Failure<IEnumerable<TrainingVendorDto>>(ResponseCodes.GeneralError);
            }
        }

        public async Task<IEnumerable<SelectListItem>> GetTrainingVendorListItem()
        {
            var trainingVendors = await _repositoryManager.TrainingVendorRepository.GetAllAsync();

            var selectListItem = trainingVendors.Select(item => new SelectListItem()
            {
                Value = item.Id,
                Text = item.VendorName
            }).ToList();

            return selectListItem;
        }
    }
}
