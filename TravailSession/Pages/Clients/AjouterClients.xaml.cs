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
using Windows.Foundation;
using Windows.Foundation.Collections;

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

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string nom = tbxNom.Text;
            string address = tbxAdresse.Text;
            string numeroTelephone = tbxNumeroTelephone.Text;
            string email = tbxEmail.Text;

            Singleton.Singleton.getInstance().AjouterClient(nom, address, numeroTelephone, email);
            Singleton.Singleton.getInstance().getAllClients();
            this.Frame.Navigate(typeof(Pages.Clients.AfficherClients));
        }
    }
}
