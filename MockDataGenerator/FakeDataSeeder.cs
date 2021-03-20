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
    public class FakeDataSeeder
    {
        public static void Initialize(ApplicationDbContext context, FakeDataGenerator generator)
        {
            //var options = serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();

            //var generator = serviceProvider.GetRequiredService<FakeDataGenerator>();

            using(context)
            {
                context.Categories.AddRange(generator.Categories);
                context.Products.AddRange(generator.Products);

                context.SaveChanges();
            }
        }
    }
}
