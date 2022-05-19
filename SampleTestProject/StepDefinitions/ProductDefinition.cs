using APIClient;
using APIClient.ResponseDto;
using NUnit.Framework;

namespace SampleTestProject.StepDefinitions
{
    [Binding]
    public sealed class ProductDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        public ProductDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("Product service address (.*)")]
        public void GivenProductService(string serviceBaseAddress)
        {
            _scenarioContext["ProductService"] = new ProductClient(serviceBaseAddress);
        }

        [When("Get Products")]
        public async Task GetProducts()
        {
            var products = await ((ProductClient)_scenarioContext["ProductService"]).GetProducts();

            _scenarioContext["Products"] = products;
        }

        [Then("Products year equal or above (.*)")]
        public void LoginTokenNotObtained(int year)
        {
            Assert.That(((ProductsDto)_scenarioContext["Products"]).Data.All(d => d.Year >= year));
        }

    }
}
