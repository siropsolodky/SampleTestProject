using Newtonsoft.Json;
using System.Text;

namespace APIClient
{
    public abstract class BaseClient
    {
        protected readonly string _serviceBaseAddress;
        protected readonly HttpClient _httpClient;

        protected BaseClient(string serviceBaseAddress)
        {
            _serviceBaseAddress = serviceBaseAddress;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_serviceBaseAddress)
            };
        }

        protected StringContent GetJsonStringContent(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, Encoding.UTF8, "Application/json");
        }

        protected async Task<T> GetResponseObject<T>(HttpContent content) 
        {
            var responseContent = await content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<T>(responseContent);

            return response;
        }

    }
}
