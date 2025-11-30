using Microsoft.UI.Xaml.Controls.Primitives;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using TravailSession.Class;

namespace TravailSession.Singleton
{
    internal class Singleton
    {
        string connectionString;
        ObservableCollection<Class.Projet> listeProjets;
        ObservableCollection<Class.Clients> listeClients;
        ObservableCollection<Class.Employe> listeEmployes;

        static Singleton instance = null;

        private Singleton()
        {
            connectionString = "Server=cours.cegep3r.info;Database=a2025_420345ri_gr2_2386119-matthias-champoux;Uid=2386119;Pwd=2386119;";
            listeProjets = new ObservableCollection<Class.Projet>();
            listeClients = new ObservableCollection<Class.Clients>();
            listeEmployes = new ObservableCollection<Class.Employe>();
        }

        public static Singleton getInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }

        public void chargerDonnes()
        {
            getAllClients();
            getAllProjets();
            getAllEmployes();
        }
        public ObservableCollection<Class.Projet> ListeP { get => listeProjets; }
        public void getAllProjets()
        {
            using MySqlConnection con = new MySqlConnection(connectionString);
            using MySqlCommand commande = con.CreateCommand();
            try
            {
                listeProjets.Clear();
                commande.Connection = con;
                commande.CommandText = "SELECT * from projets;";
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    string numeroProjet = r.GetString("numeroProjet");
                    string titre = r.GetString("titre");
                    DateTime dateDebut = r.GetDateTime("dateDebut");
                    string description = r.GetString("description");
                    double budget = r.GetDouble("budget");
                    int nombreEmployesRequis = r.GetInt32("nombreEmplyesRequis");
                    double totalSalaires = r.GetDouble("totalSalaires");
                    string statut = r.GetString("statut");
                    int identifant = r.GetInt32("identifant");
                    Class.Projet projet = new Class.Projet(numeroProjet, titre, statut, description, dateDebut, budget, totalSalaires, nombreEmployesRequis, identifant);
                    listeProjets.Add(projet);
                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                //message d'erreur eventuel

            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public ObservableCollection<Class.Clients> ListeC { get => listeClients; }
        public void getAllClients()
        {
            using MySqlConnection con = new MySqlConnection(connectionString);
            using MySqlCommand commande = con.CreateCommand();
            try
            {
                listeClients.Clear();
                commande.Connection = con;
                commande.CommandText = "SELECT * from clients;";
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    int identifiant = r.GetInt32("identifiant");
                    string nom = r.GetString("nom");
                    string adresse = r.GetString("adresse");
                    string numeroTelephone = r.GetString("numeroTelephone");
                    string email = r.GetString("email");
                    Class.Clients client = new Class.Clients(identifiant, nom, adresse, numeroTelephone, email);
                    listeClients.Add(client);
                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                //message d'erreur eventuel

            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public ObservableCollection<Class.Employe> ListeE { get => listeEmployes; }
        public void getAllEmployes()
        {
            using MySqlConnection con = new MySqlConnection(connectionString);
            using MySqlCommand commande = con.CreateCommand();
            try
            {
                listeEmployes.Clear();
                commande.Connection = con;
                commande.CommandText = "SELECT * FROM Employes;";
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    string matricule = r.GetString("matricule");
                    string nom = r.GetString("nom");
                    string prenom = r.GetString("prenom");
                    DateTime dateNaissance = r.GetDateTime("datenaissance");
                    string email = r.GetString("email");
                    DateTime dateEmbauche = r.GetDateTime("dateEmbauce");
                    double tauxHoraire = r.GetDouble("tauxHoraire");
                    string photoIdentite = r.GetString("photoIdentite");
                    string statut = r.GetString("statut");
                    Class.Employe employe = new Class.Employe(matricule, nom, prenom, email, photoIdentite, statut, dateNaissance, dateEmbauche, tauxHoraire);
                    listeEmployes.Add(employe);
                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                //message d'erreur eventuel

            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
