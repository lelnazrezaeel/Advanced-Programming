using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin1_6
{
    class Program
    {
        static void Square(ref int a)
        {
            a = a * a;
        }
        static void Sum(out int b , int[] arr)
        {
            int i ;
            b = 0;
            for(i=0; i<10; i++)
            {
                b = b + arr[i];
            }
        }
        static void Main(string[] args)
        { 
            int i;
            int d = 0;
            int[] c = new int[10] ;
            Random r = new Random();
            for (i=0; i<10; i++ )
            {
                c[i] = r.Next(2);
                Square(ref c[i]);
                Console.WriteLine(c[i]);
            }
            Sum(out d, c);
            Console.WriteLine($"The answer is {d}");
        }
    }
}
