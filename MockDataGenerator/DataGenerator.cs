using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MockDataGenerator;
using MockDataGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockDataGenerationAspNetCore
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<NorthwindContext>>();

            var generator = serviceProvider.GetRequiredService<FakeDataGenerator>();

            using(var context = new NorthwindContext(options))
            {
                context.Categories.AddRange(generator.Categories);
                context.Products.AddRange(generator.Products);

                context.SaveChanges();
            }
        }
    }
}
