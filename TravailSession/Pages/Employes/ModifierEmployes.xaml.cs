using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravailSession.Class;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Employes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModifierEmployes : Page
    {
        Class.Employe employe;
        public ModifierEmployes()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            employe = e.Parameter as Class.Employe;
            if (employe != null)
            {
                tblTitre.Text = employe.Matricule;
                tbxNom.Text = employe.Nom;
                tbxPrenom.Text = employe.Prenom;
                tbxEmail.Text = employe.Email;
                tbxLien.Text = employe.PhotoIdentite;
                nbxTauxHoraire.Value = employe.TauxHoraire;

            }

        }

        private void btPecedent_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (employe == null)
                return;

            string matricule = employe.Matricule;
            string nom = tbxNom.Text;
            string prenom = tbxPrenom.Text;
            string email = tbxEmail.Text;
            string PhotoIdentite = tbxLien.Text;
            double tauxHoraire = nbxTauxHoraire.Value;

            Singleton.Singleton.getInstance().ModifierEmploye(matricule, nom, prenom, email, PhotoIdentite, tauxHoraire);
            Singleton.Singleton.getInstance().getAllEmployes();
            this.Frame.Navigate(typeof(Pages.Employes.AfficherEmployes));
        }

        private async void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (employe == null)
                return;

            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Supprimer";
            dialog.Content = "Voulez-vous vraiment supprimer cet employe?";
            dialog.PrimaryButtonText = "Oui";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Primary;

            ContentDialogResult resultat = await dialog.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
            {
                Singleton.Singleton.getInstance().supprimerEmploye(employe.Matricule);

                this.Frame.Navigate(typeof(Pages.Employes.AfficherEmployes));
            }

            else
            {
                if (Frame.CanGoBack)
                    Frame.GoBack();
            }
        }
    }
}
