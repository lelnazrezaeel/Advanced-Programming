using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz2
{
    class Person
    {
        string name, lname;
        int age, hsalary, hnum;
        private int num;
        private Person[] p;
        Person[] p2;
        public Person(string name,string lname,int age,int hsalary,int hnum)
        {
            this.name = name;
            this.lname = lname;
            this.age = age;
            this.hsalary = hsalary;
            this.hnum = hnum;
            string nname = "Ali";
            int aage = 10;
            if(name==null)
            {
                name = nname;
            }
            if(lname==null)
            {
                Console.WriteLine("Enter a non-empty last name\n");
                lname = Console.ReadLine();
            }
            if(age<0)
            {
                age = aage;
            }
            if (hsalary < 0)
            {
                Console.WriteLine("Enter a non-negative salary\n");
                hsalary = int.Parse(Console.ReadLine());
            }
            if (hnum < 0)
            {
                Console.WriteLine("Enter a non-negative hours\n");
                hnum = int.Parse(Console.ReadLine());
            }
        }
        public Person()
        {
            name = "Elnaz";
            lname = "Rezaee";
            age = 19;
            hnum = 3;
            hsalary = 3;
        }
        public int YearSalary()
        {
            return hsalary * hnum * 289;
        }
        public int YearHours()
        {
            return hnum * 289;
        }
        public int ObjectNumber()
        {
            num = p.Length;
            return num;
        }
        public Person[] SearchPerson (string str)
        {
            int k = 0;
            foreach(var pe in p)
            {
                if(pe.name==str)
                {
                    p2[k] = pe;
                    k++;
                }
            }
            return p2;
        }
        public void PrintInfo()
        {
            string output = "Name : " + name + "\nLast name : " + lname + "\nAge : " + age +
           "\nSalary per hours : " + hsalary + "\nHours of work : " + hnum + "\nSalary per year : "
           + YearSalary() + "\nHours of work in one year : " + YearHours();
            Console.WriteLine(output);
        }
        public Person deep_copy()
        {
            string  _name = name;
            string _lname = lname;
            int _age = age;
            int _hsalary = hsalary;
            int _hnum = hnum;
            return new Person(_name, _lname, _age, _hsalary, _hnum);

        }
        public Person shallow_copy()
        {
            string _name = name;
            string _lname = lname;
            int _age = age;
            int _hsalary = hsalary;
            int _hnum = hnum;
            return new Person(name, this.lname, age, this.hsalary, hnum);
        }
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Enter the number of people .");
                int n = int.Parse(Console.ReadLine());
                while(n<0)
                {
                    Console.WriteLine("Enter a non-negative number .");
                    n = int.Parse(Console.ReadLine());
                }
                Person[] a = new Person[n];
                int i = 0;
                for(i=0; i<n;i++)
                {
                    Console.WriteLine("Enter the name .");
                    string esm = Console.ReadLine();
                    Console.WriteLine("Enter the last name .");
                    string famil = Console.ReadLine();
                    Console.WriteLine("Enter the age .");
                    int sen = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the salary per day .");
                    int hoquq = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the hours of work per day .");
                    int saat = int.Parse(Console.ReadLine());
                    a[i] = new Person(esm, famil, sen, hoquq, saat);
                }
                for (i = 0; i < n; i++)
                {
                    a[i].PrintInfo();
                }
                Console.WriteLine(a[0].shallow_copy());
                Console.WriteLine(a[0].deep_copy());
            }
    }
}
