using Cotrucking.Domain.Enums;

namespace Cotrucking.Domain.Exceptions
{
    public class ErrorResponseModel
    {
        public IList<dynamic>? Params { get; set; }
        public Severity Severity { get; set; }
        public string? Message { get; set; }
    }
}
