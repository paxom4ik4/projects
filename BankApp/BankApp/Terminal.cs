using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BankLogic;

namespace BankApp
{
    class Terminal
    {

        private Client _currentClient;
        private const int ATTEMPTS = 3;
        private const int NumberOfDefaultClients = 3;
        Bank _bank;
        public Terminal()
        {
            _bank = new Bank(GetClients());
        }


        private Client[] GetClients()
        {
            //Клиенты по умолччанию
            Client[] clients = new Client[NumberOfDefaultClients];
            clients[0] = new Client("Lashuk", "Gleb", "Gleb_GQ", "123", new Account[] { new Account(250), new Account(300) });
            clients[1] = new Client("Petrov", "Ivan", "Ivan_COOL", "666", new Account[] { new Account(500) });
            clients[2] = new Client("Strelov", "Vasya", "login", "password");
            return clients;
        }

        private int StartPage()
        {

            string choice = "-1";
            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Welcome to our bank");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Log in");
                Console.WriteLine("2 - Sign up");
                Console.WriteLine("------------------------------");
                choice = Console.ReadLine();
                if (choice != "0" && choice != "1" && choice != "2")
                {
                    Console.WriteLine("Invalid choice");
                }
                Thread.Sleep(500);
                Console.Clear();
            } while (choice != "0" && choice != "1" && choice != "2");
            return Convert.ToInt32(choice);
        }
        private void ExitPage()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Thanks for using");
            Console.ReadKey();
        }
        private bool LogInPage()
        {

            for (int i = 0; i < ATTEMPTS; i++)
            {
                Console.WriteLine("------------------------------");
                Console.Write("Login: ");
                string login = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                _currentClient = _bank.Authorize(login, password);
                if (_currentClient != null)
                {
                    Console.Clear();
                    return true;
                }
                Console.WriteLine("------------------------------");
                Console.WriteLine("Invalid data");
                Thread.Sleep(1000);
                Console.Clear();
            }
            return false;

        }
        private bool SignUpPage()
        {
            for (int i = 0; i < ATTEMPTS; i++)
            {
                string firstName;
                string lastName;
                string login;
                string password;
                Console.WriteLine("------------------------------");
                Console.Write("First Name: ");
                firstName = Console.ReadLine();

                Console.Write("Last Name: ");
                lastName = Console.ReadLine();

                Console.Write("Login: ");
                login = Console.ReadLine();

                Console.Write("Password: ");
                password = Console.ReadLine();

                _currentClient = new Client(lastName, firstName, login, password);


                if (_bank.Register(_currentClient))
                {
                    Thread.Sleep(500);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("We congratulate you to be our user");
                    Thread.Sleep(2000);
                    Console.Clear();
                    return true;

                }
                Console.WriteLine("There is already a user with such a login");
                Console.ReadKey();
                Console.Clear();
            }
            return false;

        }
        private int MainMenu()
        {
            string choice = "-1";
            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("1 - Replenish account");
                Console.WriteLine("2 - Withdraw money");
                Console.WriteLine("3 - Check Balance");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("------------------------------");
                choice = Console.ReadLine();
                if (choice != "0" && choice != "1" && choice != "2" && choice != "3")
                {
                    Console.WriteLine("Invalid choice");
                }
                Thread.Sleep(500);
                Console.Clear();
            } while (choice != "0" && choice != "1" && choice != "2" && choice != "3");

            return Convert.ToInt32(choice);
        }

        private int ChooseAccountPage()
        {
            int currentAccount = 0;
            int numOfAccounts = _currentClient.GetAccounts.Length;
            if (numOfAccounts > 1)
            {

                bool check = false;
                while (!check)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Choose your account");
                    for (int i = 0; i < numOfAccounts; i++)
                    {
                        Console.WriteLine($"{i + 1}: {_currentClient.GetAccounts[i].Money}");
                    }

                    try
                    {
                        currentAccount = Convert.ToInt32(Console.ReadLine()) - 1;
                        check = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    if (currentAccount < 0 || currentAccount >= _currentClient.GetAccounts.Length)
                    {
                        check = false;
                        Console.WriteLine("Invalid Input");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                Console.Clear();
            }
            return currentAccount;
        }
        private bool ReplenishMoneyPage()
        {
            int currentAccount = ChooseAccountPage();

            Console.WriteLine("------------------------------");
            Console.Write("Amount of money to Replenish: ");
            decimal amount = 0;

            try
            {
                amount = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                Thread.Sleep(1000);
                return UnsuccessOperationPage();
            }

            if (amount < 0)
            {
                Console.WriteLine("Invalid Input");
                Thread.Sleep(1000);
                return UnsuccessOperationPage();
            }
            _bank.Replenish(_currentClient, currentAccount, amount);
            Console.Clear();
            bool choice = SuccessOperationPage();
            return choice;
        }
        private bool WithDrawMoneyPage()
        {
            int currentAccount = ChooseAccountPage();

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Current procent is: {_bank.Procent*100}");
            Console.Write("Amount of money to withdraw: ");
            decimal amount = 0;

            try
            {
                amount = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                Thread.Sleep(1000);
                return UnsuccessOperationPage();
            }

            if (amount < 0)
            {
                Console.WriteLine("Invalid Input");
                Thread.Sleep(1000);
                return UnsuccessOperationPage();
            }
            try
            {
                _bank.WithDraw(_currentClient, currentAccount, amount);
            }
            catch 
            {
                Console.WriteLine("Not enough money");
                Thread.Sleep(1000);
                bool res = UnsuccessOperationPage();
                Console.Clear();
                return res;
            }

            bool choice = SuccessOperationPage();
            Console.Clear();
            return choice;
        }
        private bool CheckBalance()
        {
            Console.WriteLine("------------------------------");
            for (int i = 0; i < _currentClient.GetAccounts.Length; i++)
            {
                Console.WriteLine($"{i+1} account: {_currentClient.GetAccounts[i].Money}");
            }

            Console.ReadKey();
            return SuccessOperationPage();

        }
        private bool SuccessOperationPage()
        {
            string input = "-1";
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("The operation is succesful");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Main Menu");
                Console.WriteLine("------------------------------");
                input = Console.ReadLine();
            } while (input != "0" && input != "1");

            Console.Clear();
            if (input == "0")
            {
                return false;
            }

            return true;
            
        }
        private bool UnsuccessOperationPage()
        {
            string input = "-1";
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("The operation is failed");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Main Menu");
                Console.WriteLine("------------------------------");
                input = Console.ReadLine();
            } while (input != "0" && input != "1");

            Console.Clear();
            if (input == "0")
            {
                return false;
            }

            return true;

        }
        /// <summary>
        /// Основной метод
        /// </summary>
        public void RunTerminal()
        {
            int startPage = StartPage();

            if (startPage == 1)
            {
                bool isSuccess = LogInPage();
                if (!isSuccess)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("You made 3 attempts");
                    Console.ReadKey();
                    Console.Clear();
                    ExitPage();
                    return;
                }
            }
            else if (startPage == 2)
            {
                bool isSuccess = SignUpPage();
                if (!isSuccess)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("You made 3 attempts");
                    Console.ReadKey();
                    Console.Clear();
                    ExitPage();
                    return;
                }
            }
            else if (startPage == 0)
            {
                ExitPage();
                return;
            }


            bool res = false;
            do
            {
                int mainMenuChoice = MainMenu();

                if (mainMenuChoice == 0)
                {
                    ExitPage();
                    return;
                }
                else if (mainMenuChoice == 1)
                {
                     res = ReplenishMoneyPage();
                }
                else if (mainMenuChoice == 2)
                {
                    res = WithDrawMoneyPage();
                }
                else if (mainMenuChoice == 3)
                {
                    res = CheckBalance();
                }
            } while (res);

            ExitPage();
        }
    }
}
