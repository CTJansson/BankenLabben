using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Klass_Labb_16e_sep
{
    class Program
    {
        static Account[] AccountList = new Account[50];

        static int AccountCount = 0;

        static void Main(string[] args) // EN HEL METOD !
        {
            Menu();
        }

        private static void Menu() // Menysystem
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Create an account with balance");
                Console.WriteLine("3. Make a deposit");
                Console.WriteLine("4. Make a withdraw");
                Console.WriteLine("5. Accountlist");
                Console.WriteLine("6. Search Accountowner");
                Console.WriteLine("7. Change accountname");
                Console.WriteLine("8. Change accountnumber");
                Console.WriteLine("");

                string menuInput = Console.ReadLine();
                if (menuInput == "1")
                {
                    CreateAccount();
                }
                else if (menuInput == "2")
                {
                    CreateAccountWithBalance();
                }
                else if (menuInput == "3")
                {
                    MakeDeposit();
                }
                else if (menuInput == "4")
                {
                    MakeWithdraw();
                }
                else if (menuInput == "5")
                {
                    PrintAccount();
                }
                else if (menuInput == "6")
                {
                    FindAccountWithName();
                }
                else if (menuInput == "7")
                {
                    ChangeAccountName();
                }
                else if (menuInput == "8")
                {
                    ChangeAccountNumber();
                }

                Console.WriteLine("Press Enter to go to the menu.");
                Console.ReadLine();
            }
        }

        private static void PrintAccount() // Returnera innehavare, kontonummer och saldo
        {
           for (int i = 0; i < AccountCount; i++)
            {
                Console.WriteLine("Owner: {0} - AccNr: {1} - Balance: {2}", AccountList[i].OwnerName, AccountList[i].OwnerNumber, AccountList[i].Balance);
            }
        }

        private static void CreateAccount() // Skapa konto utan saldo
        {
            string AccOwner;
            Console.WriteLine("\nEnter a name to set as accountowner");
            AccOwner = Console.ReadLine();

            int AccNumber;
            Console.WriteLine("\nEnter a preferred accountnumber");
            AccNumber = int.Parse(Console.ReadLine());

            Account account = new Account(AccOwner, AccNumber);
            AccountList[AccountCount] = account;
            AccountCount++;
        }

        private static void CreateAccountWithBalance() // Skapa konto med saldo
        {
            string accOwner;
            Console.WriteLine("\nEnter a name to set as accountowner");
            accOwner = Console.ReadLine();

            int accNumber;
            Console.WriteLine("\nEnter a preferred accountnumber");
            accNumber = int.Parse(Console.ReadLine());

            decimal accBalance;
            Console.WriteLine("\nEnter your wished amount");
            accBalance = decimal.Parse(Console.ReadLine());

            Account account = new Account(accOwner, accNumber, accBalance);
            AccountList[AccountCount] = account;
            AccountCount++;
        }

        private static void MakeDeposit() // Göra insättning & Göra insättningar givet kontonummer
        {
            Account account = FindAccountWithNumber();
            if (account == null)
            {
                Console.WriteLine("Account not chosen, please try again.");
                return;
            }
           
            Console.WriteLine("How much dorrah do you want to deposit?");
            decimal input = decimal.Parse(Console.ReadLine());
            account.Deposit(input);

            Console.WriteLine("{0} dorrah added to your account.", input);
        }

        private static void MakeWithdraw() // Genomföra uttag & Göra uttag givet kontonummer
        {
            Account account = FindAccountWithNumber();

            if (account == null)
            {
                Console.WriteLine("Account not chosen, please try again.");
                return;
            }

            Console.WriteLine("How much dorrah do you want to withdraw?");
            decimal input = decimal.Parse(Console.ReadLine());
            account.Withdraw(input);

            Console.WriteLine("{0} dorrah withdrawn from your account.", input);
        }

        private static Account FindAccountWithNumber() // Göra insättning eller uttag på givet kontonummer
        {            
            int accNumber;

            Console.WriteLine("\nType in your accountnumber");
            accNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < AccountCount; i++)
            {
                if (AccountList[i].OwnerNumber == accNumber)
                {
                    return AccountList[i];
                }
            }
            return null;
        }

        private static Account FindAccountWithName() // Söka efter kontonummer på de konton en viss innehavare har
        {
            string input;

            Console.WriteLine("Enter a accountname to search his/hers accountnumbers");
            input = Console.ReadLine();

            Console.WriteLine(input + " accountnumbers:");

            for (int i = 0; i < AccountCount; i++)
            {
                if (input == AccountList[i].OwnerName)
                {
                    Console.WriteLine(AccountList[i].OwnerNumber);
                }
            }
            return null;

            //foreach (var AccountName in AccountList) -- LOL drar mer CPU
            //{
            //    if (AccountName != null && AccountName.OwnerName == input)
            //    {
            //        Console.WriteLine(AccountName.OwnerNumber);
            //    }
            //}
        }

        private static Account ChangeAccountName() // Ändra kontoinnehavare
        {
            string accName;

            Console.WriteLine("\nType in your accountname you want to change");
            accName = Console.ReadLine();

            for (int i = 0; i < AccountCount; i++)
            {
                if (AccountList[i].OwnerName == accName)
                {
                    Console.WriteLine("Type in your new accountname");
                    string newName = Console.ReadLine();
                    AccountList[i].OwnerName = newName;
                }
            }
            return null;
        }

        private static Account ChangeAccountNumber() // Ändra kontonummer
        {
            int accNumber;

            Console.WriteLine("\nType in your accountnumber you want to change");
            accNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < AccountCount; i++)
            {
                if (AccountList[i].OwnerNumber == accNumber)
                {
                    Console.WriteLine("Type in your new accountnumber");
                    int newName = int.Parse(Console.ReadLine());
                    AccountList[i].OwnerNumber = newName;
                }
            }
            return null;
        } 
        
    }
}
