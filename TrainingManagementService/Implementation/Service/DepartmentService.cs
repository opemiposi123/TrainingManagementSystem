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
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IResponseResult _responseResult;

        public DepartmentService(
            IRepositoryManager repositoryManager,
            IResponseResult responseResult)
        {
            _repositoryManager = repositoryManager;
            _responseResult = responseResult;
        }

        public async Task<ServiceResponse<string>> CreateAsync(DepartmentDto request, CancellationToken cancellationToken = default)
        {
            try
            {
                var isDepartmentExist = await _repositoryManager.DepartmentRepository.ExistsAsync(c => c.Name == request.Name);

                if (isDepartmentExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.ForbidDuplicates);
                }

                var department = new Department
                {
                    Name = request.Name,
                    Description = request.Description
                };
                var result = await _repositoryManager.DepartmentRepository.AddAsync(department);
                int rows = await _repositoryManager.UnitOfWork.SaveChangesAsync();

                if (rows > 0)
                {
                    return _responseResult.Success<string>(message: "Department record created successfully");
                }

                return _responseResult.Failure<string>(ResponseCodes.ITDeskHelpResponse, description: "Unable to create department");
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
                var isDepartmentExist = await _repositoryManager.DepartmentRepository.ExistsAsync(r => r.Id == departmentId);

                if (!isDepartmentExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var department = await _repositoryManager.DepartmentRepository.GetByIdAsync(departmentId, cancellationToken);

                await _repositoryManager.DepartmentRepository.RemoveAsync(department!);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Department removed successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<DepartmentDto>> GetByIdAsync(string departmentId, CancellationToken cancellationToken = default)
        {
            try
            {
                var departmentExist = await _repositoryManager.DepartmentRepository.ExistsAsync(r => r.Id == departmentId);

                if (!departmentExist)
                {
                    return _responseResult.Failure<DepartmentDto>(ResponseCodes.Record_NotFound);
                }

                var request = await _repositoryManager.DepartmentRepository.GetByIdAsync(departmentId);

                var details = new DepartmentDto
                {
                    Name = request!.Name,
                    Description = request.Description
                };

                return _responseResult.Success(details);
            }
            catch (Exception)
            {
                return _responseResult.Failure<DepartmentDto>(ResponseCodes.GeneralError);
            }
        }
        public async Task<ServiceResponse<string>> UpdateAsync(DepartmentDto model, CancellationToken cancellationToken = default)
        {
            try
            {
                var departmentExist = await _repositoryManager.DepartmentRepository.ExistsAsync(r => r.Id == model.Id);

                if (!departmentExist)
                {
                    return _responseResult.Failure<string>(ResponseCodes.Record_NotFound);
                }

                var department = await _repositoryManager.DepartmentRepository.GetByIdAsync(model.Id);

                department!.Name = model.Name;
                department.Description = model.Description;

                await _repositoryManager.DepartmentRepository.UpdateAsync(department);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return _responseResult.Success<string>(message: "Department updated successfully!");
            }
            catch (Exception)
            {
                return _responseResult.Failure<string>(ResponseCodes.GeneralError);
            }
        }

        public async Task<ServiceResponse<IEnumerable<DepartmentDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _repositoryManager.DepartmentRepository.GetAllAsync();

                if (result == null)
                {
                    return _responseResult.Failure<IEnumerable<DepartmentDto>>(ResponseCodes.Record_NotFound);
                }

                var data = result
                     .Where(d => d.IsDeleted == false)
                     .Select(x => new DepartmentDto
                     {
                         Id = x.Id,
                         Name = x.Name,
                         Description = x.Description,
                     });

                return _responseResult.Success(data);
            }
            catch (Exception)
            {
                return _responseResult.Failure<IEnumerable<DepartmentDto>>(ResponseCodes.GeneralError);
            }
        }

        public async Task<IEnumerable<SelectListItem>> GetDepartmentListItem()
        {
            var departments = await _repositoryManager.DepartmentRepository.GetAllAsync();

            var selectListItem = departments.Select(item => new SelectListItem()
            {
                Value = item.Id,
                Text = item.Name
            }).ToList();

            return selectListItem;
        }
    }
}
