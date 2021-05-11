using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNWN.Models;

namespace WNWN.Data
{
    public static class NoIngredientsSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            SeedNoIngredients(context);

        }
        private static void SeedNoIngredients(ApplicationDbContext context)
        {
            if (!context.NoIngredients.Any())
            {
                context.NoIngredients.Add(new NoIngredients("Seafood"));
                context.NoIngredients.Add(new NoIngredients("Pork"));
                context.NoIngredients.Add(new NoIngredients("Red Meat"));
                context.NoIngredients.Add(new NoIngredients("Poultry"));

                context.SaveChanges();
            }
        }
    }
}