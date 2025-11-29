using Microsoft.WindowsAppSDK.Runtime.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TravailSession.Class
{
    internal class Client
    {
        public static List<Client> ClientsList = new List<Client>();

        private int identifiant;
        private string nom, adresse, numeroTelephone, email;

        public Client(int identifiant, string nom, string adresse, string numeroTelephone, string email)
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
