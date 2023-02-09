using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace AnimalShelter;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ShelterContext>(options => options.UseSqlite("Data Source = Data.db"));
    }
}