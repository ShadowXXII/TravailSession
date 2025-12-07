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

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string nom = tbxNom.Text;
            string prenom = tbxPrenom.Text;
            string photoIdentite = tbxLien.Text;
            DateTime dateNaissance = calendarDateNaissance.Date.Value.DateTime;
            string email=tbxEmail.Text;
            DateTime dateEmbauche = calendarDateEmbauce.Date.Value.DateTime;
            double tauxHoraire = double.Parse(nbxTauxHoraire.Text);
            Singleton.Singleton.getInstance().AjouterEmploye( nom,  prenom,  email,  photoIdentite,  dateNaissance,  dateEmbauche,  tauxHoraire);
            Singleton.Singleton.getInstance().getAllEmployes();
            this.Frame.Navigate(typeof(Pages.Employes.AfficherEmployes));
        }
    }
}
