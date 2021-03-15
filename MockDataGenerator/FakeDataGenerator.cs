using Bogus;
using MockDataGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockDataGenerator
{
    public partial class FakeDataGenerator
    {
        private readonly int categoriesCount = 4;
        private int productCount;
        public FakeDataGenerator()
        {
            Categories = new List<Category>();
            Products = new List<Product>();

            var FakerCategory = new Faker<Category>()
                .RuleFor(c => c.CategoryId, f => 1 + f.IndexFaker)
                .RuleFor(c => c.CategoryName, f => f.Random.Word())
                .RuleFor(c => c.Description, f => f.Lorem.Locale);

            var FakerProduct = new Faker<Product>()
                .RuleFor(p => p.ProductId, f => f.IndexFaker)
                .RuleFor(p => p.ProductName, f => f.Random.Word())
                .RuleFor(p => p.UnitsInStock, f => (short)f.Random.Int(1, 100))
                .RuleFor(p => p.UnitsOnOrder, f => (short)f.Random.Int(1, 100));

            Categories.AddRange(FakerCategory.Generate(categoriesCount));

            foreach (var category in Categories)
            {
                FakerProduct.RuleFor(p => p.CategoryId, f => category.CategoryId).Generate();
                productCount = new Random().Next(2, 8);
                category.Products = FakerProduct.Generate(productCount);

                Products.AddRange(category.Products);
            }
        }

        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
