using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;

namespace F6
{
    class LimitedCollection<T> where T : IComparable<T>
    {
        static int num = 0;
        public T min { get; set; }
        public T max { get; set; }
        static int number { get { return num; } }
        public LimitedCollection(T min, T max)
        {
            this.min = min;
            this.max = max;
        }
        static List<T> instance = new List<T>();
        public void Insert(T val)
        {
            try
            {
                if (this.min.CompareTo(val) < 0 && this.max.CompareTo(val) > 0)
                {
                    instance.Add(val);
                    num++;
                    Console.WriteLine($"The input {val} added");
                }
                else
                {
                    Console.WriteLine($"The input { val} didn't add");
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Remove()
        {
            try
            {
                if (num != 0)
                {
                    instance.Sort();
                    instance.Remove(instance[0]);
                    num--;
                }
                else
                {
                    Console.WriteLine("The list is empty");
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ItemAccepted()
        {
            foreach (var ins in instance)
            {
                Console.Write($"{ins} ");
            }
            Console.WriteLine();
        }
        public static void Numb()
        {
            Console.WriteLine(number);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the max ");
            string max = Console.ReadLine();
            Console.WriteLine("Enter the min");
            string min = Console.ReadLine();
            LimitedCollection<string>[] limitedCollections = new LimitedCollection<string>[100];
            Console.WriteLine("Enter inputs");
            string[] inputs = Console.ReadLine().Split(' ');
            for (int i = 0; i < inputs.Length; i++)
            {
                limitedCollections[i] = new LimitedCollection<string>(min, max);
                limitedCollections[i].Insert(inputs[i]);
            }
            LimitedCollection<string>.ItemAccepted();
            LimitedCollection<string>.Remove();
            LimitedCollection<string>.Numb();

            Console.WriteLine("Enter the max ");
            int max2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the min");
            int min2 = int.Parse(Console.ReadLine());
            LimitedCollection<int>[] limitedCollection = new LimitedCollection<int>[100];
            Console.WriteLine("Enter inputs");
            string[] input2 = Console.ReadLine().Split(' ');
            int[] inp = new int[input2.Length];
            for (int i = 0; i < input2.Length; i++)
            {
                inp[i] = int.Parse(input2[i]);
            }
            for (int i = 0; i < inputs.Length; i++)
            {
                limitedCollection[i] = new LimitedCollection<int>(min2, max2);
                limitedCollection[i].Insert(inp[i]);
            }
            LimitedCollection<int>.ItemAccepted();
            LimitedCollection<int>.Remove();
            LimitedCollection<int>.Numb();
        }
    }
}
