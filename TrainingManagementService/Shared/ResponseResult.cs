using ITHelpDesk.Application.Shared.Contracts;
using ITHelpDesk.Domain.Enums;
using ITHelpDesk.Domain.Extensions;
using TrainingManagementService.ResponseModel;

namespace ITHelpDesk.Application.Shared;

public class ResponseResult : IResponseResult
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ResponseResult(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ServiceResponse<T> Failure<T>(ResponseCodes responseCodes, int statusCode = 400, string description = null!, string message = null!) where T : class
    {
        return new ServiceResponse<T>
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Message = message,
            Error = new ErrorResponse
            {
                RequestPath = _httpContextAccessor.HttpContext.Request.Path,
                ErrorCode = responseCodes.GetCode(),
                Description = string.IsNullOrWhiteSpace(description) ? responseCodes.GetDescription() : description
            },
            Payload = null
        };
    }

    public ServiceResponse<T> Success<T>(T payload = null!, int statusCode = 200, string message = null!) where T : class
    {
        return new ServiceResponse<T>
        {
            IsSuccess = true,
            StatusCode = statusCode,
            Message = message,
            Payload = payload
        };
    }
}