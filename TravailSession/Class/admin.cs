namespace TravailSession.Class
{
    internal class Admin
    {
        string email, nom, password;

        public Admin(string email, string nom, string password)
        {
            this.email = email;
            this.nom = nom;
            this.password = password;
        }

        public string Email { get => email; set => email = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Password { get => password; set => password = value; }

        public override string? ToString()
        {
            return $"{nom}, - {email}";
        }
    }
}
