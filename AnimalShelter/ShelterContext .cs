using AnimalShelter.Animals;
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
    public DbSet<ActionRequest> ActionRequests { get; set; }
    public DbSet<Keeper> Keepers { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Vet> Vets { get; set; }
    public DbSet<VeterinaryRequest> VeterinaryRequests { get; set; }
    public DbSet<ShelterAction> Actions { get; set; }
}