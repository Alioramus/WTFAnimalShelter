using AnimalShelter;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelterTests;

public class InMemoryDbTests: IDisposable
{
    protected InMemoryDbTests()
    {
        var builder = new ContainerBuilder();
        var context = new InMemoryShelterContext();
        context.Database.EnsureDeleted();
        builder.RegisterInstance(context).As<ShelterContext>().SingleInstance();
        builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
        builder.RegisterType<PasswordService>().As<IPasswordService>().SingleInstance();
        builder.RegisterType<UsernameService>().As<IUsernameService>().SingleInstance();
        App.AppContainer = builder.Build();
    }

    public void Dispose()
    {
        App.AppContainer.Resolve<ShelterContext>().Database.EnsureDeleted();
    }
}

public class InMemoryShelterContext : ShelterContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "AnimalShelter");
    }
}