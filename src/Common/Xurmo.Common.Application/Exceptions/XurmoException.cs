using Xurmo.Common.Domain;

namespace Xurmo.Common.Application.Exceptions;
public sealed class XurmoException : Exception
{
    public XurmoException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
