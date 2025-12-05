using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession.Class
{
    internal class EmployeProjet
    {
        private string matricule, nom, prenom;
        private double tauxHoraire, salaire;
        private int heure;

        public EmployeProjet(string matricule, string nom, string prenom, double tauxHoraire, int heure)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.tauxHoraire = tauxHoraire;
            this.heure = heure;
        }

        public string Matricule { get => matricule; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public double TauxHoraire { get => tauxHoraire; set => tauxHoraire = value; }
        public double Salaire { get => salaire; set => salaire = value; }
        public int Heure { get => heure; set => heure = value; }
    }
}
