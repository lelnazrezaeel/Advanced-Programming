using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin1_3
{
    class Program
    {
        static int prime(int a)
        {
            int i, c = 0;
            for(i=1; i<=a; i++)
            {
                if(a%i==0)
                {
                    c++;
                }
            }
            if (c == 2)
                return 1;
            else
                return 0;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (prime(n) == 1)
            {
                if (n % 6 == 1 || n % 6 == 3)
                {
                    Console.WriteLine("YES");
                }
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
