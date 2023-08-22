using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F5
{
    enum carType { Hatchback , Sedan , Suv , Coupe}
    interface IDrive
    {
        string UseFor();
    }
    class Vehicle
    {
        string carName;
        int count;
        public Vehicle(string carName , int count)
        {
            this.carName = carName;
            this.count = count;
        }
    }
    class Car : Vehicle , IDrive 
    {
        carType car;
        public Car(string carName , int count , string car) : base(carName,count)
        {
            this.car = (carType)Enum.Parse(typeof(carType), car);
        }
        public string UseFor()
        {
            return "Used for personal transportation";
        }
    }
    class Truck : Vehicle , IDrive
    {
        bool haveTrailer;
        public Truck(string truckName , int c , bool haveTrailer) : base(truckName,c)
        {
            this.haveTrailer = haveTrailer;
        }
        public string UseFor()
        {
            return "Used to transport heavy equipment";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //car information

            Car c1;
            string cname , ctype;
            int ccnt;
            Random random = new Random();
            int i = random.Next(4);
            carType c = (carType)i;
            ctype = c.ToString();
            Console.WriteLine("Enter the name of the car");
            cname = Console.ReadLine(); 
            Console.WriteLine("Enter the number of car wheels");
            ccnt = int.Parse(Console.ReadLine());
            c1 = new Car(cname, ccnt, ctype);

            //Truck information

            Truck t1;
            string tname;
            int tcnt;
            bool tht;
            Console.WriteLine("Enter the name of the truck");
            tname = Console.ReadLine();
            Console.WriteLine("Enter the number of truck wheels");
            tcnt = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter YES to have a trailer and NO to have not a trailer");
            if(Console.ReadLine()=="YES")
            {
                tht = true;
            }
            else
            {
                tht = false;
            }
            t1 = new Truck(tname, tcnt, tht);

            //array

            IDrive[] drive = new IDrive[2];
            drive[0] = c1;
            drive[1] = t1;
            Console.WriteLine(drive[0].UseFor());
            Console.WriteLine(drive[1].UseFor());
        }
    }
}
