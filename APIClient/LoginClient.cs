using APIClient.Dto;
using APIClient.ResponseDto;

namespace APIClient
{
    public class LoginClient : BaseClient
    {
        public LoginClient(string serviceBaseAddress) : base(serviceBaseAddress)
        { }

        public async Task<TokenDto?> Login(LoginDto login)
            => await Login((object)login);

        public async Task<TokenDto?> Login(object dto)
        {
            var data = GetJsonStringContent(dto);

            var response = await _httpClient.PostAsync("/api/login", data);
            var token = await GetResponseObject<TokenDto>(response.Content);

            return token;
        }

    }
}
