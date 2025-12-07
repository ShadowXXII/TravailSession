using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Clients;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class AfficherClients : Page
{
    Class.Clients client;
    public AfficherClients()
    {
        InitializeComponent();
        Singleton.Singleton.getInstance().chargerDonnes();
        lvListeClients.ItemsSource = Singleton.Singleton.getInstance().ListeC;
    }

    private void btModifier_Click(object sender, RoutedEventArgs e)
    {
        client = lvListeClients.SelectedItem as Class.Clients;
        this.Frame.Navigate(typeof(Pages.Clients.ModifierClients), client);
    }
}
