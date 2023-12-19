using System.Text.Json.Serialization;

namespace Lib.models
{
    public class User
    {
        [JsonPropertyName("userId")]
        private int _userId;

        [JsonPropertyName("userName")]
        private string _userName;

        [JsonPropertyName("password")]
        private string _password;

        [JsonPropertyName("role")]
        private Role _role;


        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public User()
        {
        }

        public User(int userId, string userName, string password, Role role = Role.Regular)
        {
            _userId = userId;
            _userName = userName;
            _password = password;
            _role = role;
        }

        public bool ValidateCredentials(string userName, string password)
        {
            return _userName == userName && _password == password;
        }
    }
}
