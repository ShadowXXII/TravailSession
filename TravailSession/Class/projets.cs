using System;
using System.Linq;

namespace TravailSession.Class
{
    internal class Projet
    {
        private string numeroProjet, titre, statut, description;
        private DateTime dateDebut;
        private double budget, totalSalaires;
        private int nombreEmployesRequis, identifant;

        public Projet(string numeroProjet, string titre, string statut, string description, DateTime dateDebut, double budget, double totalSalaires, int nombreEmployesRequis, int identifant)
        {
            this.numeroProjet = numeroProjet;
            this.titre = titre;
            this.statut = statut;
            this.description = description;
            this.dateDebut = dateDebut;
            this.budget = budget;
            this.totalSalaires = totalSalaires;
            this.nombreEmployesRequis = nombreEmployesRequis;
            this.identifant = identifant;
        }

        public string NumeroProjet { get => numeroProjet; set => numeroProjet = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Description { get => description; set => description = value; }
        public string Statut { get => statut; set => statut = value; }
        public DateTime DateDebut { get => dateDebut; set => dateDebut = value; }
        public double Budget { get => budget; set => budget = value; }
        public double TotalSalaires { get => totalSalaires; set => totalSalaires = value; }
        public int NombreEmployesRequis { get => nombreEmployesRequis; set => nombreEmployesRequis = value; }
        public int Identifant { get => identifant; set => identifant = value; }

        public override string ToString()
        {
            return $"{numeroProjet} - {titre} | Client : {GetClientName()} | Début : {dateDebut.ToShortDateString()} | Budget : {budget}$";
        }


        public string GetClientName()
        {
            var client = Clients.ClientsList.FirstOrDefault(c => c.Identifiant == identifant);

            return client != null ? client.Nom : "Inconnu";
        }
    }
}
