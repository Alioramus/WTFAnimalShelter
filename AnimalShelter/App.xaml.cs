using System;
using System.Runtime.InteropServices;
using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AnimalShelter;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private const int AttachParentProcess = -1;

    /// <summary>
    ///  Redirects the console output of the current process to the parent process.
    ///  For debugging purposes / Szymon
    /// </summary>
    /// <param name="e"></param>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var facade = new DatabaseFacade( new ShelterContext());
        facade.EnsureCreated();
        Console.WriteLine("Begin init");
        AttachToParentConsole();
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