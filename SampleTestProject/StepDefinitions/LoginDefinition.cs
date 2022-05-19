using APIClient;
using APIClient.Dto;
using APIClient.ResponseDto;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace SampleTestProject.StepDefinitions
{
    [Binding]
    public sealed class LoginDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        public LoginDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("Login service address (.*)")]
        public void GivenLoginService(string serviceBaseAddress)
        {
            _scenarioContext["loginService"] = new LoginClient(serviceBaseAddress);
        }

        [When("Login by credentials")]
        public async Task LoginByCredentials(Table table)
        {
            var loginDto = table.CreateInstance<LoginDto>();

            var token = await ((LoginClient)_scenarioContext["loginService"]).Login(loginDto);

            _scenarioContext["loginToken"] = token;
        }

        [Then("Login token obtained")]
        public void LoginTokenObtained()
        {
            Assert.NotNull(((TokenDto)_scenarioContext["loginToken"]).Token);
        }

        [Then("Login token not obtained")]
        public void LoginTokenNotObtained()
        {
            Assert.Null(((TokenDto)_scenarioContext["loginToken"]).Token);
        }

    }
}
