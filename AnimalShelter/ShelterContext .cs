using Microsoft.EntityFrameworkCore;

namespace AnimalShelter;

public class ShelterContext : DbContext
{
    private string ConnectionString { get; }
    
    public ShelterContext()
    {
        ConnectionString = "AnimalShelter.db";
    }
    
    public ShelterContext(string connectionString)
    {
        ConnectionString = connectionString;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source = {ConnectionString}");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public virtual DbSet<Keeper> Keepers { get; set; }
    public DbSet<Visit> Visits { get; set; }
}