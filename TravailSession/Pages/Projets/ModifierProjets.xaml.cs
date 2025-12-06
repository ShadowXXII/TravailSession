using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravailSession.Class;
using Windows.Foundation;
using Windows.Foundation.Collections;

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

        private void btnEnregister_Click(object sender, RoutedEventArgs e)
        {
            if (projet == null)
                return;

            string numeroProjet = projet.NumeroProjet;
            string titre = tbxTitre.Text;
            string statut = cbxStatut.SelectedItem?.ToString();
            string description = tbxDescription.Text;
            double budget = double.Parse(nbxBudget.Text);
            int totalSalaires = int.Parse(nbxTotalSalaires.Text);
            int nombreEmployesRequis = int.Parse(nbxNombreEmployesRequis.Text);

            Singleton.Singleton.getInstance().ModifierProjets( titre,  statut,  description,  budget,  totalSalaires,  nombreEmployesRequis,  numeroProjet);

            if (Frame.CanGoBack)
                Frame.GoBack();
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
