using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Projets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjouterProjets : Page
    {
        public AjouterProjets()
        {
            InitializeComponent();
            string[] liste = { "en cours", "termine" };
            cbxStatut.ItemsSource = liste;
        }
        private void btPecedent_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private async void btnEnregister_Click(object sender, RoutedEventArgs e)
        {
            bool Validation = true;
            string titre = tbxTitre.Text;
            string statut = cbxStatut.SelectedItem as string;
            string description = tbxDescription.Text;
            double totalSalaires = 0;
            tblErreurTitre.Text = string.Empty;
            tblErreurDateDebut.Text = string.Empty;
            tblErreurBudget.Text = string.Empty;
            tblErreurDescription.Text = string.Empty;
            tblErreurNombreEmployesRequis.Text = string.Empty;
            tblErreurIdentifant.Text = string.Empty;

            double budget = 0;
            if (!double.TryParse(nbxBudget.Text, out budget))
            {
                tblErreurBudget.Text = "Veuillez entrer un budget valide.";
                Validation = false;
            }
            int nombreEmployesRequis = 0;
            if (!int.TryParse(nbxNombreEmployesRequis.Text, out nombreEmployesRequis))
            {
                tblErreurNombreEmployesRequis.Text = "Veuillez entrer un nombre d'employés valide.";
                Validation = false;
            }
            int identifant = 0;
            if (!int.TryParse(nbxIdentifant.Text, out identifant))
            {
                tblErreurIdentifant.Text = "Veuillez entrer un identifiant valide.";
                Validation = false;
            }
            DateTime? dateDebut = calendarDatePkrDateDebut.Date?.DateTime;
            if (dateDebut == null)
            {
                tblErreurDateDebut.Text = "Veuillez sélectionner une date de début.";
                Validation = false;
            }

            if (string.IsNullOrWhiteSpace(titre))
            {
                tblErreurTitre.Text = "Veuillez enter le titre du projet";
                Validation = false;
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                tblErreurDescription.Text = "Veuillez enter une description au projet";
                Validation = false;
            }
            if (budget < totalSalaires)
            {
                tblErreurBudget.Text = "Le budget ne peux pas être plus petit que le total des salaires";
                Validation = false;
            }
            if (budget <= 0)
            {
                tblErreurBudget.Text = "Le budget ne peux pas être plus petit ou égale a 0";
                Validation = false;
            }
            if (nombreEmployesRequis > 5)
            {
                tblErreurNombreEmployesRequis.Text = "Le nombre maximale pour un projet est 5 employes";
                Validation = false;
            }
            if (nombreEmployesRequis <= 0)
            {
                tblErreurNombreEmployesRequis.Text = "Le nombre minimale pour un projet est 1 employes";
                Validation = false;
            }

            if (Validation)
            {
                ContentDialog dialog = new ContentDialog();
                {
                    dialog.XamlRoot = gridRacine.XamlRoot;
                    dialog.Title = "Projet Ajouter";
                    dialog.Content = "Le projet a été créer";
                    dialog.CloseButtonText = "OK";
                }
                ;
                var result = await dialog.ShowAsync();
                Singleton.Singleton.getInstance().AjouterProjets(titre, statut, description, dateDebut.Value, budget, totalSalaires, nombreEmployesRequis, identifant);

                this.Frame.Navigate(typeof(Pages.Projets.AfficherProjets));
            }
        }


    }
}
