using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
        public ObservableCollection<Class.EmployeProjet> GetEmployesForProjet(string numeroProjet)
        {
            ObservableCollection<Class.EmployeProjet> liste = new();

            using MySqlConnection con = new MySqlConnection(connectionString);
            using MySqlCommand commande = con.CreateCommand();

            commande.CommandText = "SELECT E.matricule, E.nom, E.prenom, E.tauxHoraire, T.heure FROM Projets INNER JOIN Travail T on Projets.numeroProjet = T.numeroProjet INNER JOIN Employes E on T.matricule = E.matricule WHERE T.numeroProjet = @num;";
            commande.Parameters.AddWithValue("@num", numeroProjet);

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                string matricule = r.GetString("matricule");
                string nom = r.GetString("nom");
                string prenom = r.GetString("prenom");
                double tauxHoraire = r.GetDouble("tauxHoraire");
                int heures = r.GetInt32("heure");
                liste.Add(new Class.EmployeProjet(matricule, nom, prenom, tauxHoraire, heures));
            }

            return liste;
        }

        public int GetEmployeCountForProjet(string numeroProjet)
        {
            int count = 0;

            using MySqlConnection con = new MySqlConnection(connectionString);
            using MySqlCommand commande = con.CreateCommand();
            commande.CommandText = "SELECT COUNT(*) FROM Travail WHERE numeroProjet = @num;";
            commande.Parameters.AddWithValue("@num", numeroProjet);

            con.Open();
            count = Convert.ToInt32(commande.ExecuteScalar());

            return count;
        }

        public bool EmployeOccupe(string matricule)
        {
            using MySqlConnection con = new MySqlConnection(connectionString);
            using MySqlCommand commande = con.CreateCommand();

            commande.CommandText = "SELECT COUNT(*) FROM Travail T INNER JOIN Projets P ON T.numeroProjet = P.numeroProjet  WHERE T.matricule = @matricule AND P.statut <> 'termine';";
            commande.Parameters.AddWithValue("@matricule", matricule);

            con.Open();
            int count = Convert.ToInt32(commande.ExecuteScalar());

            return count > 0;
        }

        public bool EmployeExiste(string matricule)
        {
            using MySqlConnection con = new MySqlConnection(connectionString);
            using MySqlCommand commande = con.CreateCommand();

            commande.CommandText = "SELECT COUNT(*) FROM Employes WHERE matricule = @mat;";
            commande.Parameters.AddWithValue("@mat", matricule);

            con.Open();
            int count = Convert.ToInt32(commande.ExecuteScalar());

            return count > 0;
        }

        public void AjouterEmployeProjets(String matricule, string numeroProjet, int heure)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "INSERT INTO Travail(matricule, numeroProjet, heure) VALUES (@matricule, @numeroProjet, @heure); ";
                commande.Parameters.AddWithValue("@matricule", matricule);
                commande.Parameters.AddWithValue("@numeroProjet", numeroProjet);
                commande.Parameters.AddWithValue("@heure", heure);
                con.Open();
                int i = commande.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void AjouterProjets(string titre, string statut, string description, DateTime dateDebut, double budget, double totalSalaires, int nombreEmployesRequis, int identifant)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "INSERT INTO Projets (titre, dateDebut, description, budget, nombreEmplyesRequis, totalSalaires, statut, identifant)VALUES (@titre, @dateDebut, @description, @budget, @nombreEmplyesRequis, @totalSalaires, @statut, @identifant);";
                commande.Parameters.AddWithValue("@titre", titre);
                commande.Parameters.AddWithValue("@dateDebut", dateDebut);
                commande.Parameters.AddWithValue("@budget", budget);
                commande.Parameters.AddWithValue("@description", description);
                commande.Parameters.AddWithValue("@nombreEmplyesRequis", nombreEmployesRequis);
                commande.Parameters.AddWithValue("@totalSalaires", totalSalaires);
                commande.Parameters.AddWithValue("@statut", statut);
                commande.Parameters.AddWithValue("@identifant", identifant);
                con.Open();
                int i = commande.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void ModifierProjets(string titre, string statut, string description, double budget, double totalSalaires, int nombreEmployesRequis, string numeroProjet)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "UPDATE Projets SET titre = @titre, statut = @statut,  description = '@description', budget = @budget, nombreEmplyesRequis = @nombreEmplyesRequis, totalSalaires = @totalSalaires WHERE numeroProjet = @numeroProjet;";
                commande.Parameters.AddWithValue("@titre", titre);
                commande.Parameters.AddWithValue("@budget", budget);
                commande.Parameters.AddWithValue("@description", description);
                commande.Parameters.AddWithValue("@nombreEmplyesRequis", nombreEmployesRequis);
                commande.Parameters.AddWithValue("@totalSalaires", totalSalaires);
                commande.Parameters.AddWithValue("@statut", statut);
                commande.Parameters.AddWithValue("@numeroProjet", numeroProjet);
                con.Open();
                int i = commande.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void supprimerProjet(string numeroProjet)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;

                
                commande.CommandText = "DELETE FROM Travail WHERE numeroProjet = @numeroProjet;";
                commande.Parameters.AddWithValue("@numeroProjet", numeroProjet);

                con.Open();
                commande.ExecuteNonQuery();

                
                commande.CommandText = "DELETE FROM Projets WHERE numeroProjet = @numeroProjet;";
                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
