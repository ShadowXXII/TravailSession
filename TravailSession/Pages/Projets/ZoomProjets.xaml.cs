using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravailSession.Pages.Projets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ZoomProjets : Page
    {
        Class.Projet projet;
        public ZoomProjets()
        {
            InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            projet = e.Parameter as Class.Projet;
            if (projet != null)
            {
                tblNumeroProjet.Text = projet.NumeroProjet;
                tblTitre.Text = projet.Titre;
                tblStatut.Text = projet.Statut;
                tblDateDebut.Text = projet.DateDebut.ToString("D");
                tblBudget.Text = projet.Budget.ToString() + "$";
                tblTotalSalaires.Text = projet.TotalSalaires.ToString() + "$";
                tblNombreEmployesRequis.Text = projet.NombreEmployesRequis.ToString();
                tblIdentifant.Text = projet.Identifant.ToString();
                tblClientsName.Text = projet.GetClientName().ToString();
                tblDescription.Text = projet.Description;


            }

        }

        private void btPecedent_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(Pages.Projets.ModifierProjets), projet);
        }

        private void btAjouterEmploye_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
