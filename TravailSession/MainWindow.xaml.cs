using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TravailSession.Pages.Admin;

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

            //if (!Singleton.Singleton.getInstance().AdminExiste())
            //{
            //    ajouter();
            //}
            //else
            //{
            //    logIn();
            //}
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

        private async void gestion_clic_item_menu(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuFlyoutItem;
            if (item != null)
            {
                switch (item.Tag)
                {
                    case "exporter":
                        Debug.WriteLine("exporter");
                        var picker = new Windows.Storage.Pickers.FileSavePicker();
                        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
                        WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
                        picker.SuggestedFileName = "Projets";
                        picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });
                        Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();
                        List<Class.Projet> liste = Singleton.Singleton.getInstance().ListeProjetsComplet.ToList();
                        if (monFichier != null)
                            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);
                        break;
                    case "quitter":
                        Application.Current.Exit();
                        break;
                }
            }
        }
        //
        private async void logIn()
        {
            AdminLogIn dialog = new AdminLogIn();
            dialog.XamlRoot = gridRacine.XamlRoot;
            dialog.Title = "Authentification";
            dialog.PrimaryButtonText = "Se connecter";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
        }

        private async void ajouter()
        {
            AdminAjouter dialog = new AdminAjouter();
            dialog.XamlRoot = gridRacine.XamlRoot;
            dialog.Title = "Authentification";
            dialog.PrimaryButtonText = "Se connecter";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
        }

    }
}
