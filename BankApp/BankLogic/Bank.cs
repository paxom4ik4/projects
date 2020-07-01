using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{
    public class Bank
    {
        #region Fields
        private Client[] _clients;
        private double _procent;
        #endregion

        #region Properties
        #region PublicProperties
        public bool IsEmpty
        {
            get
            {
                return !Convert.ToBoolean(_clients.Length);
            }
        }
        public int NumOfClients
        {
            get
            {
                int result = 0;
                for (int i = 0; i < _clients.Length; i++)
                {
                    if (_clients[i] != null)
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public double Procent {
            get { return _procent; }
            set
            {
                if (value > 0 && value < 100)
                {
                    _procent = value/100;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid procent");
                }
            }
        }
        #endregion

        #region PrivateProperties
        private int Capacity
        {
            get
            {
                return _clients.Length;
            }
        }

        #endregion
        #endregion

        #region Constructors
        public Bank()
        {
            _clients = new Client[0];
            Procent = 5;
        }
        public Bank(int numberOfClients)
        {
            if (numberOfClients <= 0)
            {
                throw new ArgumentOutOfRangeException("Bank size can't be < 0");
            }
            else
            {
                _clients = new Client[numberOfClients];
                Procent = 5;
            }

        }

        public Bank(Client[] clients)
        {
            _clients = clients;
            Procent = 5;
        }
        #endregion

        #region Methods
        #region PrivateMethods
        private bool IsLoginExist(string login)
        {
            for (int i = 0; i < NumOfClients; i++)
            {
                if (_clients[i].Login.Equals(login))
                {
                    return true;
                }
            }
            return false;
        }
        private void Resize()
        {
            int newCapacity = Convert.ToInt32(Math.Ceiling(Capacity * 1.25));
            Client[] tmp = new Client[newCapacity];
            for (int i = 0; i < NumOfClients; i++)
            {
                tmp[i] = _clients[i];
            }
            _clients = tmp;
        }
        #endregion

        #region PublicMethods
        public Client Authorize(string login, string password)
        {
            for (int i = 0; i < NumOfClients; i++)
            {
                if (_clients[i].Login == login && _clients[i].Password == password)
                {
                    return _clients[i];
                }

            }
            return null;
        }
        public bool Register(Client client)
        {
            if (IsLoginExist(client.Login))
            {
                return false;
            }

            if (NumOfClients == Capacity && Capacity != 0)
            {
                Resize();
                _clients[NumOfClients] = client;
            }
            else if (Capacity == 0)
            {
                _clients = new Client[1];
                _clients[0] = client;
            }
            else
            {
                _clients[NumOfClients] = client;
            }

            return true;
        }

        public void Replenish(Client client, int numOfAccount, decimal amount)
        {
            for (int i = 0; i < NumOfClients; i++)
            {
                if (_clients[i] == client)
                {
                    _clients[i].GetAccounts[numOfAccount].Money += amount;
                }
            }
        }

        public void WithDraw(Client client, int numOfAccount, decimal amount)
        {
            for (int i = 0; i < NumOfClients; i++)
            {
                if (_clients[i] == client)
                {
                    try
                    {
                        Account[] accounts = _clients[i].GetAccounts;
                        Account account = accounts[numOfAccount];
                        account.Money -= (amount + amount * Convert.ToDecimal(Procent));
                        break;

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                    
                }
            }
        }

        #endregion
        #endregion


    }
}
