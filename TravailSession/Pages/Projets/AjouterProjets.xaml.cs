using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Org.BouncyCastle.Pqc.Crypto.Lms;
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

namespace TravailSession.Pages.Projets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjouterProjets : Page
    {
        public AjouterProjets()
        {
            InitializeComponent();
            string[] liste = { "en cours", "termine" };
            cbxStatut.ItemsSource = liste;
        }
         private void btPecedent_Click(object sender, RoutedEventArgs e)
         {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private void btnEnregister_Click(object sender, RoutedEventArgs e)
        {

            string titre = tbxTitre.Text;
            string statut = cbxStatut.SelectedItem as string;
            DateTime dateDebut = calendarDatePkr.Date.Value.DateTime;
            double budget = nbxBudget.Value;
            int nombreEmployesRequis = (int)nbxNombreEmployesRequis.Value;
            int identifant = (int)nbxIdentifant.Value;
            string description = tbxDescription.Text;
            double totalSalaires = 0;

            Singleton.Singleton.getInstance().AjouterProjets( titre,  statut,  description,  dateDebut,  budget,  totalSalaires,  nombreEmployesRequis,  identifant);

            this.Frame.Navigate(typeof(Pages.Projets.AfficherProjets));
        }

       
    }
}
