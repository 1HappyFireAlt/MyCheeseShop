using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;
using System.Runtime.CompilerServices;

namespace MyCheeseShop.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN"
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");

                if (!_context.Cheeses.Any())
                {
                    var cheeses = GetCheeses();
                    _context.Cheeses.AddRange(cheeses);
                    await _context!.SaveChangesAsync();
                }
            }
        }

        private List<Cheese> GetCheeses()
        {
            return
            [
                new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Medium", Price = 8.99m, ImageUrl = "cheddar.png"},
                new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and buttery", Strength = "Mild", Price = 10.50m },
                new Cheese { Name = "Gouda", Type = "Semi-Hard", Description = "Rich and nutty", Strength = "Medium", Price = 9.75m },
                new Cheese { Name = "Blue Cheese", Type = "Soft", Description = "Strong and pungent", Strength = "Strong", Price = 12.25m },
                new Cheese { Name = "Parmesan", Type = "Hard", Description = "Sharp and savory", Strength = "Strong", Price = 11.99m },
                new Cheese { Name = "Camembert", Type = "Soft", Description = "Creamy and earthy", Strength = "Mild", Price = 10.75m },
                new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and milky", Strength = "Mild", Price = 7.50m },
                new Cheese { Name = "Swiss", Type = "Semi-Hard", Description = "Sweet and nutty", Strength = "Medium", Price = 9.25m },
                new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly", Strength = "Medium", Price = 8.50m },
                new Cheese { Name = "Havarti", Type = "Semi-Soft", Description = "Creamy and mild", Strength = "Mild", Price = 9.99m },
                new Cheese { Name = "Gruyere", Type = "Hard", Description = "Rich and salty", Strength = "Strong", Price = 12.50m },
                new Cheese { Name = "Provolone", Type = "Semi-Hard", Description = "Sharp and nutty", Strength = "Medium", Price = 10.99m },
                new Cheese { Name = "Roquefort", Type = "Soft", Description = "Intense and salty", Strength = "Strong", Price = 13.75m },
                new Cheese { Name = "Munster", Type = "Semi-Soft", Description = "Creamy and pungent", Strength = "Medium", Price = 9.75m },
                new Cheese { Name = "Edam", Type = "Semi-Hard", Description = "Mild and nutty", Strength = "Mild", Price = 8.75m },
                new Cheese { Name = "Colby", Type = "Semi-Hard", Description = "Mild and tangy", Strength = "Mild", Price = 8.25m },
                new Cheese { Name = "Monterey Jack", Type = "Semi-Hard", Description = "Buttery and mild", Strength = "Mild", Price = 9.25m },
                new Cheese { Name = "Pepper Jack", Type = "Semi-Hard", Description = "Spicy and creamy", Strength = "Medium", Price = 9.50m },
                new Cheese { Name = "Limburger", Type = "Soft", Description = "Pungent and tangy", Strength = "Strong", Price = 11.75m },
                new Cheese { Name = "Asiago", Type = "Hard", Description = "Nutty and savory", Strength = "Medium", Price = 10.25m }
            ];
        }
    }
}