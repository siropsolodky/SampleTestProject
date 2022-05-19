using APIClient;
using APIClient.Dto;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TestProject1.Test
{
    internal class LoginTest : BaseTest
    {

        [Test]
        public async Task Login_CorrectData()
        {
            var client = new LoginClient(_serviceBaseAddress);

            var loginDto = new LoginDto { email = "eve.holt@reqres.in", password = "cityslicka" };

            var token = await client.Login(loginDto);

            Assert.NotNull(token.Token, "Login failed");
        }

        [TestCase("eve.holt@reqres.in", "")]
        [TestCase("", "cityslicka")]
        [TestCase("notEmail", "cityslicka")]
        [TestCase("eve.holt@reqres.in", "notpassword")]
        public async Task Login_WrongData(string login, string password)
        {
            var client = new LoginClient(_serviceBaseAddress);

            var loginDto = new LoginDto { email = login, password = password };

            var token = await client.Login(loginDto);

            Assert.Null(token.Token, "Login successful");
        }

        [Test]
        public async Task Login_DtoWithoutPassword()
        {
            var client = new LoginClient(_serviceBaseAddress);

            var incompleteDto = new { Email = "eve.holt@reqres.in" };

            var token = await client.Login(incompleteDto);

            Assert.Null(token.Token, "Login successful");
        }

        [Test]
        public async Task Login_DtoWithoutEmail()
        {
            var client = new LoginClient(_serviceBaseAddress);

            var incompleteDto = new { Password = "cityslicka" };

            var token = await client.Login(incompleteDto);

            Assert.Null(token.Token, "Login successful");
        }

    }
}
