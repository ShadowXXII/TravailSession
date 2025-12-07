using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Projets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModifierProjets : Page
    {
        Class.Projet projet;
        public ModifierProjets()
        {
            InitializeComponent();
            string[] liste = { "en cours", "termine" };
            cbxStatut.ItemsSource = liste;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            projet = e.Parameter as Class.Projet;
            if (projet != null)
            {
                tblNumeroProjet.Text = projet.NumeroProjet;
                tbxTitre.Text = projet.Titre;
                cbxStatut.Text = projet.Statut;
                nbxBudget.Text = projet.Budget.ToString();
                nbxTotalSalaires.Text = projet.TotalSalaires.ToString();
                nbxNombreEmployesRequis.Text = projet.NombreEmployesRequis.ToString();
                tbxDescription.Text = projet.Description;

            }

        }

        private void btPecedent_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private async void btnEnregister_Click(object sender, RoutedEventArgs e)
        {
            if (projet == null)
                return;
            bool Validation = true;
            string numeroProjet = projet.NumeroProjet;
            string titre = tbxTitre.Text;
            string statut = cbxStatut.SelectedItem?.ToString();
            string description = tbxDescription.Text;
            tblErreurTitre.Text = string.Empty;
            tblErreurBudget.Text = string.Empty;
            tblErreurDescription.Text = string.Empty;
            tblErreurNombreEmployesRequis.Text = string.Empty;
            tblErreurTotalSalaires.Text = string.Empty;

            if (!double.TryParse(nbxBudget.Text, out double budget))
            {
                tblErreurBudget.Text = "Veuillez entrer un budget valide.";
                Validation = false;
            }

            if (!double.TryParse(nbxTotalSalaires.Text, out double totalSalaires))
            {
                tblErreurTotalSalaires.Text = "Veuillez entrer un total des salaires valide.";
                Validation = false;
            }

            if (!int.TryParse(nbxNombreEmployesRequis.Text, out int nombreEmployesRequis))
            {
                tblErreurNombreEmployesRequis.Text = "Veuillez entrer un nombre valide.";
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
            if (totalSalaires < 0)
            {
                tblErreurTotalSalaires.Text = "Le le total des salaires ne peux pas être inférieur a 0";
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
                    dialog.Title = "Projet Modifier";
                    dialog.Content = "Le projet a été modifier";
                    dialog.CloseButtonText = "OK";
                }
                ;
                var result = await dialog.ShowAsync();

                Singleton.Singleton.getInstance().ModifierProjets(titre, statut, description, budget, totalSalaires, nombreEmployesRequis, numeroProjet);

                if (Frame.CanGoBack)
                    Frame.GoBack();
            }
        }

        private async void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (projet == null)
                return;

            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Supprimer";
            dialog.Content = "Voulez-vous vraiment supprimer ce projet?";
            dialog.PrimaryButtonText = "Oui";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Primary;

            ContentDialogResult resultat = await dialog.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
            {
                Singleton.Singleton.getInstance().supprimerProjet(projet.NumeroProjet);

                this.Frame.Navigate(typeof(Pages.Projets.AfficherProjets));
            }

            else
            {
                if (Frame.CanGoBack)
                    Frame.GoBack();
            }

        }
    }
}
