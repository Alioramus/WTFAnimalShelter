using Autofac;
using AnimalShelter;

namespace AnimalShelterE2E;

public class E2EFixture: IDisposable
{
    protected E2EFixture()
    {
        new App();
        var builder = new ContainerBuilder();
        var shelterContext = new ShelterContext("AnimalShelterTestsE2E.db");
        shelterContext.Database.EnsureCreated();
        builder.RegisterInstance(shelterContext).AsSelf().SingleInstance();
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
