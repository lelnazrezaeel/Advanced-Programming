using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin2_3
{
    class Emloyee
    {
        public int degree, balance;
        public bool special, loaned, hired = false;
        public string name;
        public Emloyee(bool hired)
        {
            this.hired = hired;
        }
        public Emloyee(string name ,int degree)
        {
            this.name=name;
            balance = 0;
            loaned = false;
            special = false;
            hired = true;
        }
        public void ename(string name)
        {
            int c = 0 , i;
            for(i=0; i<name.Length; i++)
            {
                if(!char.IsLower(name[i]))
                {
                    Console.WriteLine("Enter all letters of the name in lower case");
                    name = Console.ReadLine();
                }
            }
        }
        public int salary(int degree)
        {
            if (degree==1)
            {
                balance += 100;
            }
            if (degree==2)
            {
                balance += 300;
            }
            if (degree==3)
            {
                balance += 700;
            }
            if (degree==4)
            {
                balance += 900;
            }

            return balance;
        }
        public void get(int q)
        {
            if(q>balance)
            {
                Console.WriteLine("NotEnoughMoney");
            }
            else
            {
                balance -= q;
            }
        }
        public void Special(Emloyee emloyee)
        {
            emloyee.special = true;
        }
        public void Loan(Emloyee emloyee)
        {
            if(emloyee.loaned==false && emloyee.special==true)
            {
                balance = balance + ((emloyee.salary(emloyee.degree)) * 3);
                emloyee.loaned = false;
                Console.WriteLine("accepted");
            }
            else
            {
                Console.WriteLine("rejected");
            }
        }
        public int Promote(Emloyee emloyee)
        { 
            emloyee.degree = emloyee.degree + 1;
            return degree;
        }
        public void Celle(Emloyee emloyee)
        {
            emloyee.loaned = false;
        }
        public void Regress(Emloyee emloyee)
        {
            emloyee.degree = emloyee.degree - 1;
        }
        public void Report(Emloyee emloyee)
        {
            if (emloyee.special == true)
            {
                Console.WriteLine("Special {0} {1} {2}", emloyee.name, emloyee.degree, emloyee.balance);

            }
            else
            {
                Console.WriteLine("{0} {1} {2}", emloyee.name, emloyee.degree, emloyee.balance);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i, _degree, j = 0;
            int quantity;
            string _name; 
            Emloyee[] employees = new Emloyee[100];
            for(i=0; i<100; i++)
            {
                employees[i] = new Emloyee(false);
            }
            string[] order;
            Console.WriteLine("Enter your requests : ");
            while(true)
            {
                order = Console.ReadLine().Split(' ');
                if(order[0]=="hire")
                {
                    _name = order[1];
                    _degree = int.Parse(order[2]);
                    foreach(var emp in employees)
                    {
                        if(emp.name==_name)
                        {
                            Console.WriteLine("Enter a non-duplicate name");
                            _name = Console.ReadLine();
                        }
                    }
                    employees[j] = new Emloyee(_name, _degree);
                    j++;
                }
                if(order[0]=="pay")
                {
                    _name = order[1];
                    foreach(var emp in employees)
                    {
                        if(emp.name==_name && emp.degree!=0 && emp.degree != 5)
                        {
                            _degree = emp.degree;
                            emp.salary(_degree);
                        }
                    }
                }
                if (order[0] == "get")
                {
                    _name = order[1];
                    quantity = int.Parse(order[2]);
                    foreach (var emp in employees)
                    {
                        if (emp.name == _name )
                        {
                            emp.get(quantity);
                        }
                    }
                }
                if (order[0] == "special")
                {
                    _name = order[1];
                    foreach (var emp in employees)
                    {
                        if (emp.name == _name && emp.degree!=0 && emp.degree != 5)
                        {
                            emp.Special(emp);
                        }
                    }
                }
                if (order[0] == "loan")
                {
                    _name = order[1];
                    foreach (var emp in employees)
                    {
                        if (emp.name == _name && emp.degree!=0 && emp.degree != 5)
                        {
                            emp.Loan(emp);
                        }
                    }
                }
                if (order[0]== "promote")
                {
                    foreach(var emp in employees)
                    {
                        if(emp.special==true)
                        {
                            emp.Promote(emp);
                            if(emp.degree==5)
                            {
                                foreach(var em in employees)
                                {
                                    em.Celle(em);
                                }
                            }
                        }
                    }
                }
                if (order[0] == "regress")
                {
                    foreach (var emp in employees)
                    {
                        if (emp.special == false)
                        {
                            emp.Regress(emp);
                        }
                    }
                }
                if (order[0] == "report")
                {
                    _name = order[1];
                    foreach (var emp in employees)
                    {
                        if (emp.name == _name)
                        {
                            emp.Report(emp);
                        }
                    }
                }
                if (order[0] == "End")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
