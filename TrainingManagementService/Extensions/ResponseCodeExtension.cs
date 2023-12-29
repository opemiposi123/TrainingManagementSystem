using ITHelpDesk.Domain.Enums;

namespace ITHelpDesk.Domain.Extensions;

public static class ResponseCodeExtension
{
    public static string GetCode(this ResponseCodes responseCodes)
    {
        var type = responseCodes.GetType();
        var property = type.GetField(responseCodes.ToString());
        var attribute = (ResponseCodeDescriberAttribute[])property!.GetCustomAttributes(typeof(ResponseCodeDescriberAttribute), false);
        return attribute[0].Code;
    }

    public static string GetDescription(this ResponseCodes responseCodes)
    {
        var type = responseCodes.GetType();
        var property = type.GetField(responseCodes.ToString());
        var attribute = (ResponseCodeDescriberAttribute[])property!.GetCustomAttributes(typeof(ResponseCodeDescriberAttribute), false);
        return attribute[0].Description;
    }
}

sealed class ResponseCodeDescriberAttribute : Attribute
{
    public string Code { get; }
    public string Description { get; }

    public ResponseCodeDescriberAttribute(string code, string description)
    {
        Code = code;
        Description = description;
    }
}