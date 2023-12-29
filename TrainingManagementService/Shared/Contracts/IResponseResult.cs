using ITHelpDesk.Domain.Enums;
using TrainingManagementService.ResponseModel;

namespace ITHelpDesk.Application.Shared.Contracts;

public interface IResponseResult
{
    ServiceResponse<T> Failure<T>(ResponseCodes responseCodes, int statusCode = StatusCodes.Status400BadRequest, string description = default!, string message = default!) where T : class;

    ServiceResponse<T> Success<T>(T payload = default!, int statusCode = StatusCodes.Status200OK, string message = default!) where T : class;
}
