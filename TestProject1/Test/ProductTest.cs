using APIClient;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1.Test
{
    internal class ProductTest : BaseTest
    {
        [Test]
        public async Task GetProducts()
        {
            var client = new ProductClient(_serviceBaseAddress);

            var products = await client.GetProducts();

            Assert.IsNotNull(products, "Failed obtain products");
            Assert.That(products.Data.All(d => d.Year >= 2000), "Not all years more or equal to 2000");
        }
    }
}
