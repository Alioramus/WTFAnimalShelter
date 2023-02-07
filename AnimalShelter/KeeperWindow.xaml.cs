using System.Windows;

namespace AnimalShelter;

public partial class KeeperWindow
{
    private readonly Keeper _keeper;

    public KeeperWindow(Keeper keeper)
    {
        InitializeComponent();
        _keeper = keeper;
        DataContext = _keeper;
    }

    private void SaveKeeper(object sender, RoutedEventArgs e)
    {
        // code to save keeper information
        Close();
    }

    private void Cancel(object sender, RoutedEventArgs e)
    {
        // code to close the window and discard any changes
        Close();
    }
}

