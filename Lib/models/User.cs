namespace Lib.models
{
   public class User
    {
        public int Id { get; set; }
        public  string UserName { get; set; }
        public  string Password { get; set; }
        public  string Role { get; set; }

public bool ValidateCredentials(string inputUsername, string inputPassword)
    {
        return inputUsername == UserName && inputPassword == Password;
    }
    }
}
