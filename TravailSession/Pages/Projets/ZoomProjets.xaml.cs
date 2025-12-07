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
            bool Validation = true;
            string numeroProjet = tblNumeroProjet.Text;
            string matricule = tbxMatricule.Text;
            int heure = (int)nbxHeure.Value;
            int currentCount = Singleton.Singleton.getInstance().GetEmployeCountForProjet(numeroProjet);
            tblErreurMatricule.Text = string.Empty;
            tblErreurHeure.Text = string.Empty;

            if (Singleton.Singleton.getInstance().EmployeNExistePas(matricule))
            {
                tblErreurMatricule.Text = "Ce matricule n'existe pas dans la base de données.";
                Validation = false;
            }

            if (Singleton.Singleton.getInstance().EmployeOccupe(matricule))
            {
                tblErreurMatricule.Text = "Cet employé travaille déjà sur un autre projet qui n'est pas terminé.";
                Validation = false;
            }

            if (currentCount >= projet.NombreEmployesRequis)
            {
                ContentDialog dialogTropEmployes = new ContentDialog();
                {
                    dialogTropEmployes.XamlRoot = gridRacine.XamlRoot;
                    dialogTropEmployes.Title = "Limite atteinte";
                    dialogTropEmployes.Content = "Vous ne pouvez plus ajouter d'employés. Le nombre requis est déjà atteint.";
                    dialogTropEmployes.CloseButtonText = "OK";

                }
                ;
                var resultTropEmployes = await dialogTropEmployes.ShowAsync();
                Validation = false;
                return;
            }


            if (heure <= 0)
            {
                tblErreurHeure.Text = "L'heure de trvail sur le project ne peux pas être négatif";
            }

            if (Validation)
            {
                ContentDialog dialog = new ContentDialog();
                {
                    dialog.XamlRoot = gridRacine.XamlRoot;
                    dialog.Title = "Employe Ajouter";
                    dialog.Content = "L'employe a été ajouter au projets";
                    dialog.CloseButtonText = "OK";
                }
                ;
                var result = await dialog.ShowAsync();
                Singleton.Singleton.getInstance().AjouterEmployeProjets(matricule, numeroProjet, heure);
                lvEmployes.ItemsSource = Singleton.Singleton.getInstance().GetEmployesForProjet(numeroProjet);
            }
        }
    }
}
