
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWA_test_app.Models.SkinColour;
using DWA_test_app.Models.User;

namespace DWA
{

    class Context : DbContext 
    {
        public Context()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.s
            //Database.
            //Console.WriteLine("Done");
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost; port=5432; database=postgres;username=postgres; password=DWA");
        }*/
        public DbSet<User> Users { get; set;}
        public DbSet<Skin> Skins { get; set;}
 
    }

}
