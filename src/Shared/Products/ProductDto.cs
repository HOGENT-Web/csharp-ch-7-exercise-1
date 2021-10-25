namespace Shared.Products
{
    public static class ProductDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool InStock { get; set; }
            public decimal Price { get; set; }
        }

        public class Detail : Index
        {
            public string Description { get; set; }
            public string Category { get; set; }
        }
    }
}
