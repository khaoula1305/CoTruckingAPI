namespace Cotrucking.Domain.Extensions
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
        public string LogConfigFile { get; set; } = default!;
        public Jwt Jwt { get; set; } = new Jwt();
    }

    public class Jwt
    {
        public string Secret { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public double TokenDuration { get; set; }
    }
}