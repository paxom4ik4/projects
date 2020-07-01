using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{
    public class Client
    {
        #region Fields
        private string _lastName;
        private string _firstName;
        private string _login;
        private string _password;
        private Account[] _accounts;
        #endregion

        #region Properties
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name can't be empty");
                }
                _lastName = value;
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name can't be empty");
                }
                _firstName = value;
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid login");
                }
                _login = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid password");
                }
                else
                {
                    _password = value;
                }
            }
        }
        public Account[] GetAccounts
        {
            get
            {
                return _accounts;
            }
        }
        #endregion

        #region Ctors
        public Client(string lastName, string firstName, string login, string password)
        {
            LastName = lastName;
            FirstName = firstName;
            Login = login;
            Password = password;
            _accounts = new Account[1];
            _accounts[0] = new Account();
        }

        public Client(string lastName, string firstName, string login, string password, Account[] accounts)
        {
            LastName = lastName;
            FirstName = firstName;
            Login = login;
            Password = password;
            _accounts = accounts;
        }
        public Client(Client clientToCopy) {
            LastName = clientToCopy.LastName;
            FirstName = clientToCopy.FirstName;

        }
        #endregion

    }
}
