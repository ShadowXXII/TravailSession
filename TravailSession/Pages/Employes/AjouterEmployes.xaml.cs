using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Text.RegularExpressions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Employes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjouterEmployes : Page
    {
        public AjouterEmployes()
        {
            InitializeComponent();
            calendarDateNaissance.MinDate = DateTime.Now.AddYears(-65);
            calendarDateNaissance.MaxDate = DateTime.Now.AddYears(-18);
            calendarDateEmbauce.MaxDate = DateTime.Now;
        }

        private void btPecedent_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private async void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool Validation = true;
            string expression = "^[a-zA-Z][a-zA-Z0-9._-]*@[A-Za-z0-9.-]+\\.com$";

            string nom = tbxNom.Text;
            string prenom = tbxPrenom.Text;
            string photoIdentite = tbxPhotoIdentite.Text;
            string email = tbxEmail.Text;
            tblErreurNom.Text = string.Empty;
            tblErreurPrenom.Text = string.Empty;
            tblErreurEmail.Text = string.Empty;
            tblErreurPhotoIdentite.Text = string.Empty;
            tblErreurHoraire.Text = string.Empty;
            tblErreurDateNaissance.Text = string.Empty;
            tblErreurDateEmbauce.Text = string.Empty;

            DateTime? dateNaissance = calendarDateNaissance.Date?.DateTime;
            if (dateNaissance == null)
            {
                tblErreurDateNaissance.Text = "Veuillez sélectionner une date de naissance.";
                Validation = false;
            }
            DateTime? dateEmbauche = calendarDateEmbauce.Date?.DateTime;
            if (dateEmbauche == null)
            {
                tblErreurDateEmbauce.Text = "Veuillez sélectionner une date d'embauche.";
                Validation = false;
            }
            double tauxHoraire = 0;
            if (!double.TryParse(nbxTauxHoraire.Text, out tauxHoraire))
            {
                tblErreurHoraire.Text = "Veuillez entrer un taux horaire valide.";
                Validation = false;
            }
            if (tauxHoraire > 75)
            {
                tblErreurHoraire.Text = "Veuillez entrer un taux horaire résonable.";
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
                    dialog.Title = "Employe Ajouter";
                    dialog.Content = "L'employé a été ajouter";
                    dialog.CloseButtonText = "OK";
                }

                var result = await dialog.ShowAsync();

                Singleton.Singleton.getInstance().AjouterEmploye(nom, prenom, email, photoIdentite, dateNaissance.Value, dateEmbauche.Value, tauxHoraire);
                Singleton.Singleton.getInstance().getAllEmployes();
                this.Frame.Navigate(typeof(Pages.Employes.AfficherEmployes));
            }

        }
    }
}
