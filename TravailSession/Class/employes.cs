using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession.Class
{
    internal class employes
    {
        string matricule, nom, prenom, email, photoIdentite, statut;
        DateTime datenaissance, dateEmbauce;
        int tauxHoraire;

        public employes(string matricule, string nom, string prenom, string email, string photoIdentite, string statut, DateTime datenaissance, DateTime dateEmbauce, int tauxHoraire)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.photoIdentite = photoIdentite;
            this.statut = statut;
            this.datenaissance = datenaissance;
            this.dateEmbauce = dateEmbauce;
            this.tauxHoraire = tauxHoraire;
        }

        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string PhotoIdentite { get => photoIdentite; set => photoIdentite = value; }
        public string Statut { get => statut; set => statut = value; }
        public DateTime Datenaissance { get => datenaissance; set => datenaissance = value; }
        public DateTime DateEmbauce { get => dateEmbauce; set => dateEmbauce = value; }
        public int TauxHoraire { get => tauxHoraire; set => tauxHoraire = value; }

        public override string? ToString()
        {
            return $"{matricule} - {nom} {prenom} : {email}, Statut: {statut}, Date de naissance: {datenaissance}, Date d'embauce: {dateEmbauce} - {tauxHoraire}$";
        }
    }
}
