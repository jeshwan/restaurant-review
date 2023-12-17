namespace Lib.models
{
    public class User
    {
        private int _userId;
        private string _userName;
        private string _password;
        private Role _role;

        public User(int userId, string userName, string password)
        {
            _userId = userId;
            _userName = userName;
            _password = password;
            _role = Role.Regular;
        }

        public string UserName
        {
            get { return _userName; }
            set { }
        }
        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public bool ValidateCredentials(string userName, string password)
        {
            return this._userName == userName && this._password == password;
        }
    }
}
