using DemoWayni.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoWayni.Infrastructure.Seed
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            AddUsers(context);
        }

        private static void AddUsers(ApplicationDbContext context)
        {
            var user = context.Users.FirstOrDefault();
            
            if (user != null) return;

            context.Users.Add(new Domain.Models.User
            {
                FirstName = "Hernán",
                LastName = "Díaz",
                Dni = "45678234"
            });
            
            context.Users.Add(new Domain.Models.User
            {
                FirstName = "Roberto",
                LastName = "Suazo",
                Dni = "97363646"
            });

            context.Users.Add(new Domain.Models.User
            {
                FirstName = "Christian",
                LastName = "Perez",
                Dni = "49834768"
            });

            context.Users.Add(new Domain.Models.User
            {
                FirstName = "Ana",
                LastName = "Fernández",
                Dni = "92376542"
            });

            context.Users.Add(new Domain.Models.User
            {
                FirstName = "Carlos",
                LastName = "Rivero",
                Dni = "23456789"
            });

            context.Users.Add(new Domain.Models.User
            {
                FirstName = "Camila",
                LastName = "Ortega",
                Dni = "92745821"
            });

            context.Users.Add(new Domain.Models.User
            {
                FirstName = "Fiorella",
                LastName = "Morales",
                Dni = "91653862"
            });

            context.Users.Add(new Domain.Models.User
            {
                FirstName = "Victor",
                LastName = "Torres",
                Dni = "86456833"
            });

            context.SaveChanges();
        }
    }
}
