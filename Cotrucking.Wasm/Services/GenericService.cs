using System.Net;
using System.Text;
using Cotrucking.Wasm.Constant;
using Cotrucking.Wasm.Models;
using Newtonsoft.Json;
namespace Cotrucking.Wasm.Services;
public interface IGenericService<T, U> where T : new() where U : class
{
    Task<IEnumerable<T>> GetAllAsync(string url);
    Task<ResponseModel<T>> Search(string url, RequestModel<U> search);
    Task<T> Insert(string url, T model);
    Task<T> GetCompanyById(string url, Guid id);
}

public class GenericService<T, U> : IGenericService<T, U> where T : new() where U : class
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

    public virtual async Task<T> GetCompanyById(string url, Guid id)
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

    public virtual async Task<T> Insert(string url, T model)
    {
        T? result = default;
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, Constants.ApplicationJson)
        };
        var response = await _httpClient.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<T>(content);

        }
        return result ?? new T();
    }

    public virtual async Task<ResponseModel<T>> Search(string url, RequestModel<U> search)
    {
        ResponseModel<T>? result = default;
        var request = new HttpRequestMessage(HttpMethod.Post, url + "search")
        {
            Content = new StringContent(JsonConvert.SerializeObject(search), Encoding.UTF8, Constants.ApplicationJson)
        };
        var response = await _httpClient.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<ResponseModel<T>>(content);

        }
        return result ?? new ResponseModel<T>();
    }
}