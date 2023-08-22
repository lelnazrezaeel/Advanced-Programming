using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int i, j, k ;
            for(i=1; i<=n ; i++)
            {
                for(j=1; j<=n-i; j++)
                {
                    Console.Write(" ");
                }
                for (j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.Write("\n");
            }
            for (i = 1; i < n; i++)
            {
                for (j = 1; j <=i; j++)
                {
                    Console.Write(" ");
                }
                for (j = 1; j <= n-i; j++)
                {
                    Console.Write("* ");
                }
                Console.Write("\n");
            }
        }
    }
}
