using Microsoft.AspNetCore.Http;

namespace Persistence.Context.Shared;

internal static class HttpExtension
{
     //<summary>
     //Returns the request source in the form of a v4 IP address, or the machine name (if the request is from the local machine)
     //</summary>
    public static string GetRequestSource(this HttpContext? context)
    {
        var requestSource = context?.Connection.RemoteIpAddress?.MapToIPv4().ToString();

        if (string.Equals(requestSource, context?.Connection.LocalIpAddress?.MapToIPv4().ToString()))
        {
            requestSource = Environment.MachineName; // if request came from local machine, then we will just store machine name
        }

        return requestSource!;
    }
}
