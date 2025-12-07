using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Projets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AfficherProjets : Page
    {
        public AfficherProjets()
        {
            InitializeComponent();
            Singleton.Singleton.getInstance().chargerDonnes();
            lvListeProjects.ItemsSource = Singleton.Singleton.getInstance().ListeP;
        }

        private void lvListeProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Class.Projet projets = (Class.Projet)lvListeProjects.SelectedItem;
            this.Frame.Navigate(typeof(Pages.Projets.ZoomProjets), projets);
        }
    }
}
