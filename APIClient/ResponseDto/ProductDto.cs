namespace APIClient.ResponseDto
{
    public class ProductsDto
    {
        public IEnumerable<ProductDto> Data { get; set; }
    }

    public class ProductDto
    {
        public int Id;
        public string Name;
        public int Year;
        public string Color;
        public string Pantone_value;
    }

}
