using Crates.Api.Core;
using Crates.Api.Models;
using System;
using System.Linq;

namespace Crates.Api.Data
{
    public static class SeedData
    {
        public static void Seed(CratesDbContext context)
        {
            UserConfiguration.Seed(context);
        }

        internal class UserConfiguration
        {
            internal static void Seed(CratesDbContext context)
            {
                var user = context.Users.SingleOrDefault(x => x.Username == "admin");

                if (user == null)
                {
                    user = new User
                    {
                        UserId = new Guid("4d757c4c-8a05-4db3-a872-0fdea0ddd421"),
                        Username = "admin"
                    };

                    user.Password = new PasswordHasher().HashPassword(user.Salt, "admin");

                    context.Users.Add(user);
                    context.SaveChanges();
                }

            }
        }
    }
}
