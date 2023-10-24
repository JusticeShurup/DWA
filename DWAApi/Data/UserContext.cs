
using DWAApi.Models;
using DWAApi.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DWAApi.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        public UserContext(DbContextOptions<UserContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DWA;Username=postgres;Password=super");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new UserInfoConfiguration().Configure(modelBuilder.Entity<UserInfo>());
        }
    }
}
