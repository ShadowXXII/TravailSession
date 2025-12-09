namespace TravailSession.Class
{
    internal class Admin
    {
        string email, password;

        public Admin(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public override string? ToString()
        {
            return $"- {email}";
        }
    }
}
