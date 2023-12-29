using ITHelpDesk.Domain.Extensions;

namespace ITHelpDesk.Domain.Enums;

public enum ResponseCodes
{
    [ResponseCodeDescriber("96", "An error occured")]
    GeneralError = 1,

    [ResponseCodeDescriber("95", "Service time out. Please try again later")]
    ServiceTimeOut,

    [ResponseCodeDescriber("94", "Invalid Request")]
    ITDeskHelpResponse,

    [ResponseCodeDescriber("93", "Unsupported Media Type")]
    UnsupportedMediaType,

    [ResponseCodeDescriber("92", "Access Denied. Reason: Insufficient permissions")]
    AccessDenied_Insufficient_Permission,

    [ResponseCodeDescriber("91", "Access Denied. Reason: Unauthenticated request")]
    AccessDenied_UnauthenticatedUser,

    [ResponseCodeDescriber("90", "Access Denied. Reason: Invalid credentials")]
    AccessDenied_InvalidCredentials,

    [ResponseCodeDescriber("89", "Validation Failure")]
    ValidationFailure,

    [ResponseCodeDescriber("88", "AutoMapper Failure")]
    AutoMapperFailure,

    [ResponseCodeDescriber("87", "File Name Must Contain .png, .jpeg or .pdf Extension")]
    InvalidFileName,

    [ResponseCodeDescriber("86", "Record not found")]
    Record_NotFound,

    [ResponseCodeDescriber("85", "User not found")]
    User_NotFound,

    [ResponseCodeDescriber("84", "Bad Setup")]
    BadSetup,

    [ResponseCodeDescriber("83", "Duplicate Detected")]
    ForbidDuplicates
}
