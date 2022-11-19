using Microsoft.EntityFrameworkCore;
using RealEstate.Model;

namespace RealEstate.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions option):base(option)
        {

        }
      public  DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Properties> properties { get; set; }

    }
}
