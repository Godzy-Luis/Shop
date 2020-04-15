using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entities;
using Shop.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;
        private readonly IUserHelper userHelper;

        public IUserHelper UserHelper { get; }

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            UserHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.UserHelper.GetUserByEmailAsync("ing.luisenriquemtz93@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Luis",
                    LastName = "Martinez",
                    Email = "ing.luisenriquemtz93@gmail.com",
                    UserName = "ing.luisenriquemtz93@gmail.com",
                    PhoneNumber = "9622735211"
                };

                var result = await this.UserHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.Products.Any())
            {
                this.AddProduct("First Product", user);
                this.AddProduct("Second Product", user);
                this.AddProduct("Third Product", user);
                await this.context.SaveChangesAsync();
            }



            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("iWatch Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }

    }
}
