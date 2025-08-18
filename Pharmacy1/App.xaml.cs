using Pharmacy1.Data;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Pharmacy1;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static PharmDB db;

    private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
    {
        db = new PharmDB();
    }
}

