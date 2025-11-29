using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;

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

            getAllProjets();
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
    }
}
