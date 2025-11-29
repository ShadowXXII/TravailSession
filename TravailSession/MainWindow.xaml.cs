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
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void navView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer is NavigationViewItem item)
            {
                switch (item.Tag)
                {
                    case "projets":
                        mainFrame.Navigate(typeof(Pages.Projets.AfficherProjets));
                        break;
                    case "ajouterProjet":
                        mainFrame.Navigate(typeof(Pages.Projets.AjouterProjets));
                        break;
                    case "clients":
                        mainFrame.Navigate(typeof(Pages.Clients.AfficherClients));
                        break;
                    case "ajouterClient":
                        mainFrame.Navigate(typeof(Pages.Clients.AjouterClients));
                        break;
                    case "employes":
                        mainFrame.Navigate(typeof(Pages.Employes.AfficherEmployes));
                        break;
                    case "ajouterEmploye":
                        mainFrame.Navigate(typeof(Pages.Employes.AjouterEmployes));
                        break;
                    default:
                        break;
                }
            }
        }

        private void gestion_clic_item_menu(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuFlyoutItem;
            if (item != null)
            {
                switch (item.Tag)
                {
                    case "exporter":
                        Debug.WriteLine("exporter");
                        //code pour sauvegarde
                        break;
                    case "quitter":
                        Application.Current.Exit();
                        break;
                }
            }
        }
    }
}
