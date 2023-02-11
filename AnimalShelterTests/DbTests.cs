using AnimalShelter;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalShelterTests;

public class InMemoryDbTests : IDisposable
{
    protected InMemoryDbTests()
    {
        var builder = new ContainerBuilder();
        var context = new InMemoryShelterContext();
        context.Database.EnsureDeleted();
        builder.RegisterType<InMemoryShelterContext>().As<ShelterContext>().InstancePerDependency();
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
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();
        optionsBuilder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .UseInternalServiceProvider(serviceProvider);
    }
}