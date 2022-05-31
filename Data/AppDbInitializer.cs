using BookApi.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //creating a scope that refrences the AppDbContext
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //checking if book exists in the DB
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "The Great Expectation",
                        Description = "Simple book about heroes of the past",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverURL = "www.fb.com",
                        DateAdded = DateTime.Now.AddDays(-15)
                    },
                    new Book()
                    {
                        Title = "Aladeen",
                        Description = "Story about an Arabian mystical pot",
                        IsRead = false,
                        Genre = "Romance",
                        CoverURL = "www.amazon.com",
                        DateAdded = DateTime.Now.AddDays(-2)
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
