namespace Cotrucking.Wasm.Constant
{
    public class Endpoints
    {

        public static string BaseUrl { get; set; } = string.Empty;
        public static string Companies { get; set; } = string.Empty;
        public static string Drivers { get; set; } = string.Empty;
        public static string Shipments { get; set; } = string.Empty;
        public static string Login { get; set; } = string.Empty;
        public static string Menu { get; set; } = string.Empty;
        public Endpoints(IConfiguration configuration)
        {
            BaseUrl = configuration.GetSection("DefaultEndpoint").Value ?? string.Empty;
            Companies = $"{BaseUrl}/Companies/";
            Login = $"{BaseUrl}/Login/";
            Menu = $"{BaseUrl}/Menu/";
            Shipments = $"{BaseUrl}/Shipments/";
            Drivers = $"{BaseUrl}/Drivers/";
        }
    }
}
