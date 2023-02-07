using Microsoft.EntityFrameworkCore;

namespace WTFAnimalShelter
{
    public class UserDataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Data.db");
        }

        public DbSet<User> Users { get; set; }
    }
}
