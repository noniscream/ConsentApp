using CommonAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommonAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
    }
}