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

namespace TravailSession.Pages.Clients;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class AfficherClients : Page
{
    Class.Clients client;
    public AfficherClients()
    {
        InitializeComponent();
        Singleton.Singleton.getInstance().chargerDonnes();
        lvListeClients.ItemsSource = Singleton.Singleton.getInstance().ListeC;
    }

    private void btModifier_Click(object sender, RoutedEventArgs e)
    {
        client = lvListeClients.SelectedItem as Class.Clients;
        this.Frame.Navigate(typeof(Pages.Clients.ModifierClients), client);
    }
}
