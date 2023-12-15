namespace Lib.models
{
    public class User
    {
        public int Id;
        public string Username;
        public string Password;
        public Role Role;

        public User(int Id, string Username, string Password, Role Role)
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
            this.Role = Role;
        }

        public bool ValidateCredentials(string Username, string Password)
        {
            return this.Username == Username && this.Password == Password;
        }
    }
}
