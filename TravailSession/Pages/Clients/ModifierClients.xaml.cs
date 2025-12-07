using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Text.RegularExpressions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Clients
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModifierClients : Page
    {
        Class.Clients client;
        public ModifierClients()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            client = e.Parameter as Class.Clients;
            if (client != null)
            {
                tblTitre.Text = client.Identifiant.ToString();
                tbxNom.Text = client.Nom;
                tbxAdresse.Text = client.Adresse;
                tbxNumeroTelephone.Text = client.NumeroTelephone;
                tbxEmail.Text = client.Email;
            }

        }

        private void btPecedent_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private async void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (client == null)
                return;

            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Supprimer";
            dialog.Content = "Voulez-vous vraiment supprimer ce client?";
            dialog.PrimaryButtonText = "Oui";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Primary;

            ContentDialogResult resultat = await dialog.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
            {
                Singleton.Singleton.getInstance().supprimerClient(client.Identifiant);

                this.Frame.Navigate(typeof(Pages.Clients.AfficherClients));
            }

            else
            {
                if (Frame.CanGoBack)
                    Frame.GoBack();
            }
        }

        private async void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (client == null)
                return;
            bool Validation = true;
            string expression = "^[a-zA-Z][a-zA-Z0-9._-]*@[A-Za-z0-9.-]+\\.com$";

            int identifiant = client.Identifiant;
            string nom = tbxNom.Text;
            string adresse = tbxAdresse.Text;
            string numeroTelephone = tbxNumeroTelephone.Text;
            string email = tbxEmail.Text;
            tblErreurNom.Text = string.Empty;
            tblErreurAdresse.Text = string.Empty;
            tblErreurNumeroTelephone.Text = string.Empty;
            tblErreurEmail.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(nom))
            {
                tblErreurNom.Text = "Veuillez enter un nom";
                Validation = false;
            }
            if (string.IsNullOrWhiteSpace(adresse))
            {
                tblErreurAdresse.Text = "Veuillez enter une adresse";
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
            if (string.IsNullOrWhiteSpace(numeroTelephone))
            {
                tblErreurNumeroTelephone.Text = "Veuillez enter un numéro de téléphone";
                Validation = false;
            }

            if (Validation)
            {
                ContentDialog dialog = new ContentDialog();
                {
                    dialog.XamlRoot = gridRacine.XamlRoot;
                    dialog.Title = "Client Modifier";
                    dialog.Content = "Le client a été modifier";
                    dialog.CloseButtonText = "OK";
                }

                var result = await dialog.ShowAsync();

                Singleton.Singleton.getInstance().ModifierClient(identifiant, nom, adresse, numeroTelephone, email);
                Singleton.Singleton.getInstance().getAllClients();
                this.Frame.Navigate(typeof(Pages.Clients.AfficherClients));
            }
            
        }
    }
}
