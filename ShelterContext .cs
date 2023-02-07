using Microsoft.EntityFrameworkCore;

namespace WTFAnimalShelter
{
    public class ShelterContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Data.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }

    }
}
