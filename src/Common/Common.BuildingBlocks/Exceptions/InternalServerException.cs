namespace Catalog.API.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException(string message) : base(message)
    {
    }

    public InternalServerException(string name, string details) : base(details)
    {
        Details = details;
    }

    public string Details { get; }
}
