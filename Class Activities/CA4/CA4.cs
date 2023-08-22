using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4
{
    class Person
    {
        public string name, lname;
        public int age;
        public Person(string name, string lname, int age)
        {
            this.name = name;
            this.lname = lname;
            this.age = age;
        }
        public string Information()
        {
            return name + " " + lname + " " + age;
        }
    }
    class Student : Person
    {
        public string sname;
        public Student(string esm , string famil , int sen , string sname) : base(esm , famil , sen)
        {
            this.sname = sname;
        }
    }
    class Teacher : Person
    {
        public string dname;
        public Teacher(string esm, string famil, int sen, string dname) : base(esm, famil, sen)
        {
            this.dname = dname;
        }
    }
    class Program
    {
        static void Check(object o)
        {
            if(o is Student== true)
            {
                Console.WriteLine("Student");
            }
            if(o is Teacher == true)
            {
                Console.WriteLine("Teacher");
            }
        }
        static void Main(string[] args)
        {
            //student information
            
            Console.WriteLine("Enter the student's name");
            string stdname = Console.ReadLine();
            Console.WriteLine("Enter the student's last name");
            string stdlname = Console.ReadLine();
            Console.WriteLine("Enter the student's age");
            int stdage = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the student's school name");
            string stdsname = Console.ReadLine();
            Student s1 = new Student(stdname, stdlname, stdage , stdsname);

            //teacher information

            Console.WriteLine("Enter the teacher's name");
            string tname = Console.ReadLine();
            Console.WriteLine("Enter the teacher's last name");
            string tlname = Console.ReadLine();
            Console.WriteLine("Enter the teacher's age");
            int tage = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the teacher's lesson name");
            string tlename = Console.ReadLine();
            Teacher t1 = new Teacher(tname, tlname, tage, tlename);

            //print student information

            Console.WriteLine(s1.Information());

            //print teacher information

            Console.WriteLine(t1.Information());

            //Check object

            Check(s1);
            Check(t1);
        }
    }
}
