using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Employes;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class AfficherEmployes : Page
{
    Class.Employe employe;
    public AfficherEmployes()
    {
        InitializeComponent();
        Singleton.Singleton.getInstance().chargerDonnes();
        lvListeEmployes.ItemsSource = Singleton.Singleton.getInstance().ListeE;
    }

    private void btModifier_Click(object sender, RoutedEventArgs e)
    {
        employe = lvListeEmployes.SelectedItem as Class.Employe;
        this.Frame.Navigate(typeof(Pages.Employes.ModifierEmployes), employe);
    }
}
