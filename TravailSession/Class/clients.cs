using System.Collections.Generic;

namespace TravailSession.Class
{
    internal class Clients
    {
        public static List<Clients> ClientsList = new List<Clients>();

        private int identifiant;
        private string nom, adresse, numeroTelephone, email;

        public Clients(int identifiant, string nom, string adresse, string numeroTelephone, string email)
        {
            this.identifiant = identifiant;
            this.nom = nom;
            this.adresse = adresse;
            this.numeroTelephone = numeroTelephone;
            this.email = email;

            ClientsList.Add(this);
        }

        public int Identifiant { get => identifiant; set => identifiant = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string NumeroTelephone { get => numeroTelephone; set => numeroTelephone = value; }
        public string Email { get => email; set => email = value; }

        public override string ToString()
        {
            return $"{identifiant} - {nom} | {email} | {numeroTelephone}";
        }
    }
}
