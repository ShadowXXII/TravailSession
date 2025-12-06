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

namespace TravailSession.Pages.Projets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModifierProjets : Page
    {
        Class.Projet projet;
        public ModifierProjets()
        {
            InitializeComponent();

            calendarDatePkr.MaxDate = new DateTime(2025, 11, 30);
            calendarDatePkr.MinDate = DateTime.Now.AddYears(-35);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            projet = e.Parameter as Class.Projet;
            if (projet != null)
            {
                tblNumeroProjet.Text = projet.NumeroProjet;
                tbxTitre.Text = projet.Titre;
                tbxStatut.Text = projet.Statut;
                calendarDatePkr.Date =  projet.DateDebut;
                nbxBudget.Text = projet.Budget.ToString();
                nbxTotalSalaires.Text = projet.TotalSalaires.ToString();
                nbxNombreEmployesRequis.Text = projet.NombreEmployesRequis.ToString();
                tbxDescription.Text = projet.Description;

            }

        }

        private void btPecedent_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private void btnEnregister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
