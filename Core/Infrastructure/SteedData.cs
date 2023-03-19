using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure
{
    public class SteedData
    {
        public static void SteedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (context.Products.Count() ==  0 && context.Categories.Count() == 0)
            {
                Category vitamins = new Category { Name = "vitamins" };
                Category beverages = new Category { Name = "beverages" };
                Category chemistry = new Category { Name = "chemistry" };
                Category cosmetics = new Category { Name = "cosmetics" };


                context.Products.AddRange(
                    new Product
                    {
                        Name = "Gingo Biloba",
                        Price = 120,
                        Category = vitamins
                    },
                    new Product
                    {
                        Name = "Tea",
                        Price = 7000,
                        Category = beverages
                    },
                     new Product
                     {
                         Name = "Pudra",
                         Price = 2000,
                         Category = chemistry
                     },
                      new Product
                      {
                          Name = "Maska",
                          Price = 1600,
                          Category = cosmetics
                      }
                );

                context.SaveChanges();
            }
        }
    }
}
