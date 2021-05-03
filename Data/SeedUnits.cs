using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNWN.Models;

namespace WNWN.Data
{
    public static class SeedUnits
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            SeedUnit(context);

        }
        private static void SeedUnit(ApplicationDbContext context)
        {
            if (!context.Units.Any())
            {
                context.Units.Add(new Units("Gram"));
                context.Units.Add(new Units("Ounce"));
                context.Units.Add(new Units("Cup"));
                context.Units.Add(new Units("Mililiter"));
                context.Units.Add(new Units("Fluid Ounce"));
                context.Units.Add(new Units("Teaspoon"));
                context.Units.Add(new Units("Tablespoon"));
                context.Units.Add(new Units("Peice"));

                context.SaveChanges();
            }
        }
    }
}