using Cotrucking.Domain.Enums;

namespace Cotrucking.Domain.Exceptions;

public class ResponseException : Exception
{
    public IList<dynamic>? Params { get; set; }
    public Severity Severity { get; set; }
    public bool Multiple { get; set; }
    public ResponseException() : base() { }
    public ResponseException(string message) : base(message) { }
    public ResponseException(string message, Severity severity) : base(message) { Severity = severity; }
    public ResponseException(string message, params dynamic[] parameters) : base(message) { Params = parameters; }
    public ResponseException(string message, Severity severity, params dynamic[] parameters) : base(message)
    {
        Params = parameters;
        Severity = severity;
    }
    public ResponseException(string message, Exception inner) : base(message, inner) { }
}
