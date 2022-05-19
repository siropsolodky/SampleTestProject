using System.Text.Json.Serialization;

namespace APIClient.Dto
{
    public class LoginDto
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
