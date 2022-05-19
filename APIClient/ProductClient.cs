using APIClient.ResponseDto;

namespace APIClient
{
    public class ProductClient : BaseClient
    {
        public ProductClient(string serviceBaseAddress) : base(serviceBaseAddress)
        { }

        public async Task<ProductsDto?> GetProducts()
        {
            var response = await _httpClient.GetAsync("/api/products");

            var products = await GetResponseObject<ProductsDto>(response.Content);

            return products;
        }

    }
}
