using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klass_Labb_16e_sep
{
    class Account
    {
        private decimal[] _Transactions = new decimal[2];
        public string OwnerName { get; set; }
        public int OwnerNumber { get; set; }
        public decimal Balance { get; private set; }

        public Account(string ownerName, int ownerNumber)
        {
            OwnerName = ownerName;
            OwnerNumber = ownerNumber;
        }

        public Account(string ownerName, int ownerNumber, decimal balance)
        {
            OwnerName = ownerName;
            OwnerNumber = ownerNumber;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Why would you even do this ?!");
                return;
            }
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Your withdrawal wasn't allowed, police has been contacted.");
                return;
            }
            else if (Balance - amount < 0)
            {
                Console.WriteLine("Your withdrawal wasn't allowed, police has been contacted.");
                return;
            }
            Balance -= amount;
        }

        public void Saldo()
        {
            decimal AccSaldo;
            Console.WriteLine("How much money do you want?");
            AccSaldo = decimal.Parse(Console.ReadLine());
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine("Your accountname is: {0}\nYour accountnumber is: {1}\nYour current balance is: {2}", OwnerName, OwnerNumber, Balance);
        }

        private void TransactionLog(decimal value)
        {

        }
    }
}
