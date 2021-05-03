using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNWN.Models;

namespace WNWN.Data
{
    public static class FoodGroupSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            SeedFoodGroup(context);

        }
        private static void SeedFoodGroup(ApplicationDbContext context)
        {
            if (!context.Groups.Any())
            {
                context.Groups.Add(new FoodGroup("Fruit"));
                context.Groups.Add(new FoodGroup("Vegetable"));
                context.Groups.Add(new FoodGroup("Dairy"));
                context.Groups.Add(new FoodGroup("Seafood"));
                context.Groups.Add(new FoodGroup("Poultry"));
                context.Groups.Add(new FoodGroup("Red Meat"));
                context.Groups.Add(new FoodGroup("Spices"));
                context.Groups.Add(new FoodGroup("Nut & Seed"));
                context.Groups.Add(new FoodGroup("Grain"));
                context.Groups.Add(new FoodGroup("Bread"));
                context.Groups.Add(new FoodGroup("Sweet"));
                context.Groups.Add(new FoodGroup("Spice"));
                context.Groups.Add(new FoodGroup("Condiment"));
                context.Groups.Add(new FoodGroup("Beverage"));
                context.Groups.Add(new FoodGroup("Other"));

                context.SaveChanges();
            }
        }
    }
}