using DWA_test_app.Models.SkinColour;
using DWA_test_app.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace DWA_test_app.Database
{
    public class ApplicationContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Skin> Skins { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            Database.EnsureCreated(); 
        }

    }
}
