using System;

namespace TravailSession.Class
{
    internal class Employe
    {
        private string matricule, nom, prenom, email, photoIdentite, statut;
        private DateTime dateNaissance, dateEmbauche;
        private double tauxHoraire;

        public Employe(string matricule, string nom, string prenom, string email, string photoIdentite, string statut, DateTime dateNaissance, DateTime dateEmbauche, double tauxHoraire)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.photoIdentite = photoIdentite;
            this.statut = statut;
            this.dateNaissance = dateNaissance;
            this.dateEmbauche = dateEmbauche;
            this.tauxHoraire = tauxHoraire;
        }

        public string Matricule { get => matricule; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string PhotoIdentite { get => photoIdentite; set => photoIdentite = value; }
        public string Statut { get => statut; set => statut = value; }
        public DateTime DateNaissance { get => dateNaissance; }
        public DateTime DateEmbauche { get => dateEmbauche; }
        public double TauxHoraire { get => tauxHoraire; set => tauxHoraire = value; }

        public override string ToString()
        {
            return $"{matricule} - {nom} {prenom} | {email} | {statut} | {tauxHoraire}$/h";
        }
    }
}
