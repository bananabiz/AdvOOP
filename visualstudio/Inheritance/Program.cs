using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Inheritance.Scripts;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            accounts.Add(new SavingAccount());
            accounts.Add(new CheckingAccount());

            accounts[0].Deposit(1000000);
            accounts[1].Deposit(888888);

            accounts[0].Deposit(999);
            accounts[1].Withdraw(1000);

            foreach (var acc in accounts)
            {
                Console.WriteLine(acc.GetStatement());
            }
            Console.ReadLine();

            //savings.Deposit(1000000);
            ////float amount = savings.Withdraw(99);

            //string statement = savings.GetStatement();
            
        }
    }
}
