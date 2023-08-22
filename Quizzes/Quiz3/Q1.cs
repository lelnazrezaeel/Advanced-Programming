using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz3
{
    class Account
    {
        protected int instance = 0 , id, accnum;
        protected double inventory;
        protected string cardnum;
        public Account(double inventory)
        {
            id = instance;
            Random random = new Random();
            accnum =random.Next(10000000,100000000);
            cardnum = random.Next(1, 10).ToString();
            for(int i=0; i<15; i++)
            {
                cardnum += random.Next(0, 10).ToString();
            }
            this.inventory = inventory;
            instance++;
        }
        public virtual void deposit(int money)
        {
            Console.WriteLine("not implemented");
        }
        public virtual void withdraw(int money)
        {
            Console.WriteLine("not implemented");
        }
        public virtual void profit(int month)
        {
            Console.WriteLine("not implemented");
        }
        public virtual void log()
        {
            Console.WriteLine("not implemented");
        }
    }
    class JuniorAcc : Account
    {
        int max, min;
        double limit;
        double monpro = 7 / 100;
        public JuniorAcc(int max , int min , double inventory):base(inventory)
        {
            this.max = max;
            this.min = min;
            limit = (inventory / 2);
        }
        public override void deposit(int money)
        {
            try
            {
                if (money+inventory > max )
                {
                    throw new Exception();
                }
                else
                {
                    inventory += money;
                }
            }
            catch
            {
                Console.WriteLine("something was wrong");
            } 
        }
        public override void withdraw(int money)
        {
            try
            {
                if (inventory - money < min)
                {
                    throw new Exception();
                }
                else
                {
                    inventory -= money;
                }
            }
            catch
            {
                Console.WriteLine("something was wrong");
            }
        }
        public override void log()
        {
            Console.WriteLine(max.ToString() + " " + min.ToString() + " " + monpro.ToString() +
            " " + limit.ToString());
        }
        public override void profit(int month)
        { 

            if(inventory>max)
            {
                inventory = max;
            }
            else
            {
                inventory += (month * monpro);
            }
        }
        public void prize()
        {
            Random random = new Random();
            int prizes = random.Next(0, 21);
            inventory += prizes;
            if(inventory>max)
            {
                inventory = max;
            }
            Console.WriteLine($"Your prize is {prizes}");
            Console.WriteLine($"Your account balance now is {inventory}");
        }
    }
    class longTimeAcc : Account
    {
        int min = 500;
        double pro = 15/100;
        bool block=false;
        public longTimeAcc(double inventory):base(inventory)
        {
            this.min = min;
        }
        public override void deposit(int money)
        {
            if(block==false)
            {
                inventory += money;
            }
            else
            {
                Console.WriteLine("The account was blocked");
            }
        }
        public override void withdraw(int money)
        {
            try
            {
                if(inventory-money<min)
                {
                    throw new Exception();
                }
                else
                {
                    if(block==false)
                    {
                        inventory -= money;
                    }
                    else
                    {
                        Console.WriteLine("The account was blocked");
                    }
                }
            }
            catch
            {
                Console.WriteLine("something was wrong");
            }
        }
        public override void log()
        {
            Console.WriteLine(min.ToString() + " " + pro.ToString());
        }
        public override void profit(int month)
        {
            if(block==false)
            {
                inventory += (month * pro);
            }
            else
            {
                Console.WriteLine("something was wrong");
            }
        }
        public void blockUnblock()
        {
            if(block==false)
            {
                block = true;
            }
            else
            {
                block = false;
            }
        }
    }
    class Bank
    {
        List<string> users = new List<string>();
        public int balance;
        int min, max;
        public void hesab(string name)
        {
            users.Add(name);
        }
        public void hesab2()
        {
            Console.WriteLine("Enrter your balance");
        }
    }
    class Person
    {
        Account balance;
        

        JuniorAcc JuniorAcc = new JuniorAcc(4000, 1000, 2000);

    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
