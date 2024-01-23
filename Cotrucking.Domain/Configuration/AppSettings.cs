namespace Cotrucking.Domain.Extensions
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
        public string LogConfigFile { get; set; } = default!;
        public string TokenKey { get; set; } = default!;
        public double TokenDuration { get; set; }
    }
}