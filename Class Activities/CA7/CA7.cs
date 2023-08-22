using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections;

namespace F6
{
    class LimitedCollection<T> : IEnumerable<T> where T : IComparable<T>
    {
        public T min { get; set; }
        public T max { get; set; }
        public int number { get { return instance.Count(); } }
        public IEnumerable<T> Reverse
        {
            get
            {
                for (int i = instance.Count() - 1; i > -1; i--)
                {
                    yield return instance[i];
                }
            }
        }
        public LimitedCollection(T min, T max)
        {
            this.min = min;
            this.max = max;
        }
        public List<T> instance = new List<T>();
        public void Insert(T val)
        {
            try
            {
                if (this.min.CompareTo(val) < 0 && this.max.CompareTo(val) > 0)
                {
                    instance.Add(val);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch 
            {
                Console.WriteLine($"The input {val} is out of range");
            }
        }
        public T Remove()
        {
            T removed;
            if (instance.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            removed = instance.Min();
            instance.Remove(removed);
            return removed;
        }
        public IEnumerable<T> GetEnumerater()
        {
            foreach(var ins in instance)
            {
                yield return ins;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string max, min;
            int max2, min2;
            string[] input;
            string[] input2;
            int[] numbers;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the max ");
                    max = Console.ReadLine();
                    Console.WriteLine("Enter the min");
                    min = Console.ReadLine();
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input type");
                }
            }
            LimitedCollection<string> limitedCollections = new LimitedCollection<string>(min, max);
            while(true)
            {
                try
                {
                    Console.WriteLine("Enter strings inputs with space");
                    input = Console.ReadLine().Split(' ');
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            foreach (var inp in input)
            {
                limitedCollections.Insert(inp);
            }
            Console.WriteLine($"The number of accepted items is : {limitedCollections.number}");
            Console.WriteLine("The accepted items are : ");
            foreach (var inp in limitedCollections.instance)
            {
                Console.WriteLine($"{inp} ");
            }
            try
            {
                Console.WriteLine($"The removed items is : {limitedCollections.Remove()}");
            }
            catch
            {
                Console.WriteLine("The list is empty");
            }
            Console.WriteLine("The itmes in reversed mode are : ");
            foreach (var inp in limitedCollections.Reverse)
            {
                Console.WriteLine($"{inp} ");
            }

            //int

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the max ");
                    max2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the min");
                    min2 = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Inavalid input type");
                }
            }
            LimitedCollection<int> limitedCollection = new LimitedCollection<int>(min2, max2);
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter strings inputs with space");
                    input2 = Console.ReadLine().Split(' ');
                    numbers = Array.ConvertAll(input2, item => int.Parse(item));
                    break;
                }
                catch 
                {
                    Console.WriteLine("Invalid input type");
                }
            }
            foreach (var i in numbers)
            {
                limitedCollection.Insert(i);
            }
            Console.WriteLine($"The number of accepted items is : {limitedCollection.number}");
            Console.WriteLine("The accepted items are : ");
            foreach (var inp in limitedCollection.instance)
            {
                Console.WriteLine($"{inp} ");
            }
            try
            {
                Console.WriteLine($"The removed items is : {limitedCollection.Remove()}");
            }
            catch
            {
                Console.WriteLine("The list is empty");
            }
            Console.WriteLine("The itmes in reversed mode are : ");
            foreach (var inp in limitedCollection.Reverse)
            {
                Console.WriteLine($"{inp} ");
            }
        }
    }
}
