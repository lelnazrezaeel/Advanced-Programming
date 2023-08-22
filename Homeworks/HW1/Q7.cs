using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin1_7
{
    
    class Program
    {
        static float Average(int[] arr, int n)
        {
            if (n == 1)
                return (float)arr[n - 1];
            else
            {
                n = n - 1;
                return ((float)(Average(arr, n) * (n) + arr[n]) / (n + 1));
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int i, c = 0;
            int[] a = new int[n];
            string[] b = Console.ReadLine().Split(' ');
            for (i=0; i<n; i++)
            {
                a[i] = int.Parse(b[i]);
                c = c + a[i];
            }
            if(c%n==0)
            {
                Console.WriteLine("{0:F0}", Average(a, n));
            }
            else
            {
                Console.WriteLine(System.Math.Round(Average(a, n), 2));
            }
        }
    }
}
