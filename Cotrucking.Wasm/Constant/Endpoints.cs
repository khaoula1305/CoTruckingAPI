namespace Cotrucking.Wasm.Constant
{
    public class Endpoints
    {

        public static string BaseUrl { get; set; } = string.Empty;
        public static string Companies { get; set; } = string.Empty;
        public Endpoints(IConfiguration configuration)
        {
            BaseUrl = configuration.GetSection("DefaultEndpoint").Value ?? string.Empty;
            Companies = $"{BaseUrl}/Companies/";
        }
    }
}
