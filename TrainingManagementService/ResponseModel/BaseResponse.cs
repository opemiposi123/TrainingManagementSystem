namespace TrainingManagementService.ResponseModel;

public record BaseResponse
{
    public bool IsSuccess { get; init; }
    public ErrorResponse Error { get; init; } = default!;
    public int StatusCode { get; init; }
    public string? Message { get; init; }
}

public record ErrorResponse
{
    public string RequestPath { get; init; } = default!;
    public string ErrorCode { get; init; } = default!;
    public string Description { get; init; } = default!;
}

public record ServiceResponse<T> : BaseResponse where T : class
{
    public T Payload { get; init; } = default!;
}
