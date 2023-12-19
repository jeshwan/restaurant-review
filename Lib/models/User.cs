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
            /// <summary>
            /// Initializes the properties of a <see cref="User"/> object with the provided values.
            /// </summary>
            /// <param name="userId">The ID of the user.</param>
            /// <param name="userName">The username of the user.</param>
            /// <param name="password">The password of the user.</param>
            /// <param name="role">The role of the user.</param>
            /// <remarks>
            /// This code snippet involves the initialization of various properties of a <see cref="User"/> object:
            /// - <see cref="_userId"/>: The ID of the user.
            /// - <see cref="_userName"/>: The username of the user.
            /// - <see cref="_password"/>: The password of the user.
            /// - <see cref="_role"/>: The role of the user.
            /// </remarks>
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
