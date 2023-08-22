using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin3_3
{
    enum Type { Normal , TA , Rebel}
    class Student
    {
        string name, lname , ID;
        int  hour;
        Type type;
        public Student(string name , string lname , string ID , int hour ,Type type )
        {
            this.type = type ;
            this.name = name;
            this.lname = lname;
            this.ID = ID;
            this.hour = hour;
        }
        public bool CheckID(string ID)
        {
            bool output = false;
            if(ID.Length==8 && ID[0]=='9')
            {
                if(ID[1]=='5' || ID[1] == '6' || ID[1] == '7' || ID[1] == '8' || ID[1] == '9')
                {
                    output = true;
                }
            }
            return output;
        }
        public int Score()
        {
            int score = 0;
            int finalscore = 0;
            if(hour >= 0 && hour < 3)
            {
                score = 0;
            }
            else if(hour >= 3 && hour < 6)
            {
                score = 6;
            }
            else if(hour >= 6 && hour <=8)
            {
                score = 8;
            }
            if(type==Type.TA)
            {
                finalscore = score * 2;
            }
            if(type==Type.Normal)
            {
                finalscore = score;
            }
            if(type==Type.Rebel)
            {
                finalscore = score / 2;
            }
            return finalscore;
        }
        public void Info()
        {

        }
        public void PrintInfo()
        {
            Console.WriteLine(name + " " + lname + " : " + "{0}", Score());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string ID , name , lname;
            int  hours=0;
            Type type=Type.TA;
            int n , i , j ;
            try
            {
                Console.WriteLine("Enter number of people");
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter an integer number");
                n = int.Parse(Console.ReadLine());
            }
            string[] id = new string[n];
            string[] input ;
            Student[] students = new Student[n];
            for(i=0; i<n; i++)
            {
                while(true)
                {
                    try
                    {
                        Console.WriteLine("Enter name, family, code, hours and group of person {0} : ", i + 1);
                        input = Console.ReadLine().Split(',');
                        name = input[0];
                        lname = input[1];
                        ID = input[2];
                        for (j = 0; j < id.Length; j++)
                        {
                            if (ID == id[j])
                            {
                                Console.WriteLine("The ID is repetitive");
                                throw new Exception();
                            }
                        }
                        id[i] = input[2];
                        if (input.Length==5)
                        {
                            hours = int.Parse(input[3]);
                            if (hours < 0 || hours > 8)
                            {
                                Console.WriteLine("Hours must be between 0 and 8");
                                throw new Exception();
                            }
                            if (Enum.TryParse(input[4], out type) == true)
                            {
                                type = (Type)Enum.Parse(typeof(Type), input[4]);
                            }
                            else
                            {
                                Console.WriteLine("Enter TA or Normal or Rebel");
                                throw new Exception();
                            }
                        }
                        if(input.Length==4)
                        {
                            hours = 6;
                            if (Enum.TryParse(input[3], out type) == true)
                            {
                                type = (Type)Enum.Parse(typeof(Type), input[3]);
                            }
                            else
                            {
                                Console.WriteLine("Enter TA or Normal or Rebel");
                                throw new Exception();
                            }
                        }
                        students[i] = new Student(name, lname, ID, hours, type);
                        if (students[i].CheckID(ID) == false)
                        {
                            Console.WriteLine("Invalid ID ");
                            ID = Console.ReadLine();
                            for (j = 0; j < id.Length; j++)
                            {
                                if (ID == id[j])
                                {
                                    Console.WriteLine("The ID is repetitive");
                                    throw new Exception();
                                }
                            }
                            id[i] = input[2];
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Enter information again");
                    }
                }
                
            }
            foreach(Student student in students)
            {
                student.PrintInfo();
            }
        }
    }
}
