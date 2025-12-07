using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Text.RegularExpressions;

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
                tbxPhotoIdentite.Text = employe.PhotoIdentite;
                nbxTauxHoraire.Value = employe.TauxHoraire;

            }

        }

        private void btPecedent_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private async void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (employe == null)
                return;
            bool Validation = true;
            string expression = "^[a-zA-Z][a-zA-Z0-9._-]*@[A-Za-z0-9.-]+\\.com$";
            string matricule = employe.Matricule;
            string nom = tbxNom.Text;
            string prenom = tbxPrenom.Text;
            string email = tbxEmail.Text;
            string photoIdentite = tbxPhotoIdentite.Text;
            tblErreurNom.Text = string.Empty;
            tblErreurPrenom.Text = string.Empty;
            tblErreurEmail.Text = string.Empty;
            tblErreurPhotoIdentite.Text = string.Empty;
            tblErreurHoraire.Text = string.Empty;


            if (!double.TryParse(nbxTauxHoraire.Text, out double tauxHoraire))
            {
                tblErreurHoraire.Text = "Veuillez entrer un  salaire valide.";
                Validation = false;
            }
            if (string.IsNullOrWhiteSpace(nom))
            {
                tblErreurNom.Text = "Veuillez enter un nom";
                Validation = false;
            }
            if (string.IsNullOrWhiteSpace(prenom))
            {
                tblErreurPrenom.Text = "Veuillez enter un prenom";
                Validation = false;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                tblErreurEmail.Text = "Veuillez enter un email";
                Validation = false;
            }
            if (!Regex.IsMatch(email, expression))
            {
                tblErreurEmail.Text = "Veuillez enter un email valide";
                Validation = false;
            }
            if (string.IsNullOrWhiteSpace(photoIdentite))
            {
                tblErreurPhotoIdentite.Text = "Veuillez enter un lien pour une photo de profile";
                Validation = false;
            }
            if (Validation)
            {
                ContentDialog dialog = new ContentDialog();
                {
                    dialog.XamlRoot = gridRacine.XamlRoot;
                    dialog.Title = "Employe Modifier";
                    dialog.Content = "L'employé a été modifier";
                    dialog.CloseButtonText = "OK";
                }

                var result = await dialog.ShowAsync();

                Singleton.Singleton.getInstance().ModifierEmploye(matricule, nom, prenom, email, photoIdentite, tauxHoraire);
                Singleton.Singleton.getInstance().getAllEmployes();
                this.Frame.Navigate(typeof(Pages.Employes.AfficherEmployes));
            }
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
