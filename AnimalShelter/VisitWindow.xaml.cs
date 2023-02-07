using System.Windows;

namespace AnimalShelter;

public partial class VisitWindow
{
    private readonly Visit _visit;

    public VisitWindow(Visit visit)
    {
        InitializeComponent();
        _visit = visit;
        DataContext = _visit;
    }

    private void SaveVisit(object sender, RoutedEventArgs e)
    {
        // code to save visit information
    }

    private void Cancel(object sender, RoutedEventArgs e)
    {
        // code to close the window and discard any changes
        Close();
    }
}