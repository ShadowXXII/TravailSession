using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Projets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ZoomProjets : Page
    {
        Class.Projet projet;
        public ZoomProjets()
        {
            InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            projet = e.Parameter as Class.Projet;
            if (projet != null)
            {
                tblNumeroProjet.Text = projet.NumeroProjet;
                tblTitre.Text = projet.Titre;
                tblStatut.Text = projet.Statut;
                tblDateDebut.Text = projet.DateDebut.ToString("D");
                tblBudget.Text = projet.Budget.ToString() + "$";
                tblTotalSalaires.Text = projet.TotalSalaires.ToString() + "$";
                tblNombreEmployesRequis.Text = projet.NombreEmployesRequis.ToString();
                tblIdentifant.Text = projet.Identifant.ToString();
                tblClientsName.Text = projet.GetClientName().ToString();
                tblDescription.Text = projet.Description;


            }
            var employes = Singleton.Singleton.getInstance().GetEmployesForProjet(projet.NumeroProjet);
            lvEmployes.ItemsSource = employes;

            double totalSalaires = employes.Sum(e => e.Salaire);
            tblTotalSalaires.Text = totalSalaires + " $";
        }

        private void btPecedent_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(Pages.Projets.ModifierProjets), projet);
        }

        private async void btAjouterEmploye_Click(object sender, RoutedEventArgs e)
        {
            string numeroProjet = tblNumeroProjet.Text;
            string matricule = tbxMatricule.Text;
            int heure = (int)nbxHeure.Value;
            int currentCount = Singleton.Singleton.getInstance().GetEmployeCountForProjet(numeroProjet);

            if (Singleton.Singleton.getInstance().EmployeExiste(matricule))
            {
                ContentDialog dialog = new ContentDialog();
                {
                    dialog.XamlRoot = gridRacine.XamlRoot;
                    dialog.Title = "Matricule introuvable";
                    dialog.Content = "Ce matricule n'existe pas dans la base de données.";
                    dialog.CloseButtonText = "OK";
                }
                ;
                var result = await dialog.ShowAsync();
                return;
            }

            if (Singleton.Singleton.getInstance().EmployeOccupe(matricule))
            {
                ContentDialog dialog = new ContentDialog();
                {
                    dialog.XamlRoot = gridRacine.XamlRoot;
                    dialog.Title = "Employé déjà occupé";
                    dialog.Content = "Cet employé travaille déjà sur un autre projet qui n'est pas terminé.";
                    dialog.CloseButtonText = "OK";
                }
                ;
                var result = await dialog.ShowAsync();
                return;
            }


            if (currentCount >= projet.NombreEmployesRequis)
            {
                ContentDialog dialog = new ContentDialog();
                {
                    dialog.XamlRoot = gridRacine.XamlRoot;
                    dialog.Title = "Limite atteinte";
                    dialog.Content = "Vous ne pouvez plus ajouter d'employés. Le nombre requis est déjà atteint.";
                    dialog.CloseButtonText = "OK";

                }
                ;
                var result = await dialog.ShowAsync();
                return;
            }
            Singleton.Singleton.getInstance().AjouterEmployeProjets(matricule, numeroProjet, heure);
        }
    }
}
