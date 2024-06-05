using Blazored.LocalStorage;
using Cotrucking.Wasm.Constant;
using Cotrucking.Wasm.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Cotrucking.Wasm.Services
{
    public interface IAccountService
    {
        Task<User> Login(LoginModel login);
        Task<List<MenuModel>> GetMenuAsync();
    }

    public class AccountService(HttpClient httpClient, ILocalStorageService localStorageService) : GenericService<User>(httpClient), IAccountService
    {

        public async Task<User> Login(LoginModel login)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.Login)
            {
                Content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, Constants.ApplicationJson)
            };

            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(content);
                await localStorageService.SetItemAsync("user",user);
            }
            else{

            }
            return new User();
        }


        public async Task<List<MenuModel>> GetMenuAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.Menu);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<MenuModel>>(content) ?? new List<MenuModel>();

            }
            return new List<MenuModel>();
        }
    }
}
