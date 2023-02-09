using System;
using System.Runtime.InteropServices;
using System.Windows;
using Autofac;
using NLog;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AnimalShelter;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    public static IContainer AppContainer { get; private set; }
    private const int AttachParentProcess = -1;

    /// <summary>
    ///  Redirects the console output of the current process to the parent process.
    ///  For debugging purposes / Szymon
    /// </summary>
    /// <param name="e"></param>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        AttachToParentConsole();
        ConfigureLogging();

        Logger.Info("Begin init");

        ConfigureDependencyInjection();
        ConfigureDatabase();

        Logger.Info("End init");
    }

    private static void ConfigureLogging()
    {
        LogManager.Setup().LoadConfiguration(builder => {
            builder.ForLogger().FilterMinLevel(LogLevel.Info).WriteToConsole();
            builder.ForLogger().FilterMinLevel(LogLevel.Debug).WriteToFile(fileName: "file.txt");
        });
    }

    private void ConfigureDatabase()
    {
        Logger.Info("Database init");
        var facade = new DatabaseFacade(AppContainer.Resolve<ShelterContext>());
        // facade.EnsureDeleted();
        facade.EnsureCreated();
        Logger.Info("Database init done");
    }

    private void ConfigureDependencyInjection()
    {
        Logger.Info("Dependency injection init");
        var builder = new ContainerBuilder();
        builder.RegisterType<ShelterContext>().AsSelf().SingleInstance();
        builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
        builder.RegisterType<PasswordService>().As<IPasswordService>().SingleInstance();
        builder.RegisterType<UsernameService>().As<IUsernameService>().SingleInstance();
        AppContainer = builder.Build();
        Logger.Info("Dependency injection init done");
    }

    [DllImport("kernel32.dll")]
    private static extern bool AttachConsole(int dwProcessId);
    
    /// <summary>
    ///     Redirects the console output of the current process to the parent process.
    /// </summary>
    /// <remarks>
    ///     Must be called before calls to <see cref="Console.WriteLine()" />.
    /// </remarks>
    private static void AttachToParentConsole()
    {
        AttachConsole(AttachParentProcess);
    }
}