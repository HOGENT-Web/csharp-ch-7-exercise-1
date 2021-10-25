using FluentValidation;

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

        public class Create
        {
            public string Name { get; set; }
            public bool InStock { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }

            public class Validator : AbstractValidator<Create>
            {
                public Validator()
                {
                    RuleFor(x => x.Name).NotEmpty().Length(1,250);
                    RuleFor(x => x.Price).InclusiveBetween(1,250);
                    RuleFor(x => x.Category).NotEmpty().Length(1, 250);
                }
            }
        }
    }
}
