using System.Net;
using Newtonsoft.Json;

public interface IGenericService<T> where T : new()
{
    Task<IEnumerable<T>> GetAllAsync(string url);
    Task<T> GetCompanyById(string url, Guid id);
}

public class GenericService<T> : IGenericService<T> where T : new()
{
    public readonly HttpClient _httpClient;
    public GenericService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<T>> GetAllAsync(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await _httpClient.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(content) ?? new List<T>();

        }
        return new List<T>();
    }

    public async Task<T> GetCompanyById(string url, Guid id)
    {
        T? result = default;
        var response = await _httpClient.GetAsync(url + id);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<T>(content);

        }
        return result ?? new T();
    }
}