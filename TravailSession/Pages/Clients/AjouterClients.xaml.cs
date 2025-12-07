using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Text.RegularExpressions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Clients
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjouterClients : Page
    {
        public AjouterClients()
        {
            InitializeComponent();
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
            string addresse = tbxAdresse.Text;
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
            if (string.IsNullOrWhiteSpace(addresse))
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
                    dialog.Title = "Client Ajouter";
                    dialog.Content = "Le client a été ajouter";
                    dialog.CloseButtonText = "OK";
                }

                var result = await dialog.ShowAsync();

                Singleton.Singleton.getInstance().AjouterClient(nom, addresse, numeroTelephone, email);
                Singleton.Singleton.getInstance().getAllClients();
                this.Frame.Navigate(typeof(Pages.Clients.AfficherClients));
            }
            
        }
    }
}
