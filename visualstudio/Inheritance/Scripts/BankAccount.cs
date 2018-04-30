using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Scripts
{
    //Supper Class / Base Class
    class BankAccount
    {
        public int accountNumber;
        protected float money;

        public BankAccount()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            accountNumber = rand.Next(100000000, 999999999);
        }

        public virtual float Withdraw(float amount)
        {
            //Error check
            if (money > amount)
                money -= amount;
            else
            {
                amount = money;
                money = 0;
                //print "You don't have the funds!"
                //return all the money (return amount;)
            }
            
            return amount;
        }

        public virtual void Deposit(float amount)
        {
            money += amount;
        }

        //forms a statement and returns a string
        //containing said statement
        public virtual string GetStatement()
        {
            //"\n" == new line, "\t" == new tap
            return GetAccountNo() + "\n" + "\t" + GetMoney() + "\n";
        }

        protected string GetAccountNo()
        {
            return "Account No.: " + accountNumber.ToString();
        }
        
        protected string GetMoney()
        {
            return "Money: $" + money.ToString();
        }

    }
}
