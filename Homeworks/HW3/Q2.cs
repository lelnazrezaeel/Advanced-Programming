using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tamrin3_2
{
    enum Type { Lion=9600 , Tiger=9611 , Bear=9622 , Monkey=9633 , Elephant=9644 , Giraffe=9655 , Owl=9666 }
    enum Food { Meat , Plant}
    class Care
    {
        int ID, number ;
        int[] schedule = new int[3];
        string location;
        Type name;
        Food food;
        public Care(int ID , Type name , string location , Food food , int number , int[]schedule)
        {
            this.ID = ID;
            this.name = (Type)ID;
            this.location = location;
            this.food = food;
            this.number = number;
            this.schedule = schedule;
        }
        public void SetSchedule()
        {
            string[] line = new string[10];
            Random random = new Random();
            if(food==Food.Meat)
            {
                try
                {
                    StreamReader reader = new StreamReader(ID + ".txt");
                    for (int i = 0; i < 4; i++)
                    {
                        line = reader.ReadLine().Split(':','-');
                    }
                    schedule[0] = int.Parse(line[1]);
                    schedule[1] = int.Parse(line[2]);
                    schedule[2] = int.Parse(line[3]);
                    if (schedule[2] == 22)
                    {
                        schedule[2] = random.Next(18, 21);
                    }
                    reader.Close();
                }
                catch(FileNotFoundException)
                {
                    Console.WriteLine("file does not exist .");
                }
            }
            if(food== Food.Plant)
            {
                schedule[2] = random.Next(7, 22);
                schedule[1] = schedule[2] - 3;
                schedule[0] = schedule[1] - 3;
            }
        }
        public void SaveToFile()
        {
            StreamWriter writer = new StreamWriter(ID+".txt");
            writer.WriteLine("ID : {0}", ID);
            writer.WriteLine("Location : {0}", location);
            writer.WriteLine("Food : {0}", food);
            writer.WriteLine("Schedule : {0} - {1} - {2}", schedule[0], schedule[1], schedule[2]);
            writer.WriteLine("Number : {0}", number);            
            writer.Close();
        }
        public static void AllInfo(Care[] cares)
        {
            StreamWriter streamWriter = new StreamWriter("test.txt");
            foreach(Care care in cares)
            {
                streamWriter.WriteLine("Name : {0} ID : {1}\n",care.name,care.ID);
            }
            streamWriter.Close();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int i, ID, n, number;
            int[] schedule = new int[3];
            string location;
            string[] str;
            Food food;
            Console.WriteLine("Enter number of animals to save");
            n = int.Parse(Console.ReadLine());
            Care[] cares = new Care[n];
            while(true)
            {
                try
                {
                    for (i = 0; i < n; i++)
                    {
                        Console.WriteLine("Enter the code");
                        ID = int.Parse(Console.ReadLine());
                        if(ID!=(int)Type.Bear && ID != (int)Type.Tiger && ID != (int)Type.Monkey &&
                        ID != (int)Type.Elephant && ID != (int)Type.Giraffe && ID != (int)Type.Owl && ID != (int)Type.Lion )
                        {
                            Console.WriteLine("The code does not exist , enter a valid code");
                            ID= ID = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Enter the location");
                        location = Console.ReadLine();
                        Console.WriteLine("Enter the food");
                        if (Enum.TryParse(Console.ReadLine(), out food)==false) 
                        {
                            Console.WriteLine("Enter Meat or Plant");
                            food = (Food)Enum.Parse(typeof(Food), Console.ReadLine());
                        }
                        else
                        {
                            food = (Food)Enum.Parse(typeof(Food), Console.ReadLine());
                        }
                        food = (Food)Enum.Parse(typeof(Food), Console.ReadLine());
                        Console.WriteLine("Enter the schedule");
                        str = Console.ReadLine().Split('-');
                        schedule[0] = int.Parse(str[0]);
                        if(schedule[0]<1 || schedule[0]>24)
                        {
                            Console.WriteLine("Enter valid time");
                            schedule[0] = int.Parse(Console.ReadLine());
                        }
                        schedule[1] = int.Parse(str[1]);
                        if (schedule[1] < 1 || schedule[1] > 24)
                        {
                            Console.WriteLine("Enter valid time");
                            schedule[1] = int.Parse(Console.ReadLine());
                        }
                        schedule[2] = int.Parse(str[2]);
                        if (schedule[2] < 1 || schedule[2] > 24)
                        {
                            Console.WriteLine("Enter valid time");
                            schedule[2] = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Enter the number");
                        number = int.Parse(Console.ReadLine());
                        if(number < 0)
                        {
                            Console.WriteLine("Enter a non-negative number");
                            number = int.Parse(Console.ReadLine());
                        }
                        cares[i] = new Care(ID, (Type)ID, location, food, number, schedule);
                        cares[i].SaveToFile();
                        cares[i].SetSchedule();
                        cares[i].SaveToFile();
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            Care.AllInfo(cares);
        }
    }
}
