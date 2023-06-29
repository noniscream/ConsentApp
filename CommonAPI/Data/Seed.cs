using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using CommonAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommonAPI.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context){
            if(await context.users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive=true};

            var users = JsonSerializer.Deserialize<List<User>>(userData);

            foreach (var user in users){
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PwdHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("P@ssw0rd"));
                user.PwsSalt = hmac.Key;

                context.users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}