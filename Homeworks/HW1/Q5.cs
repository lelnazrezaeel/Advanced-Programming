using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = new string[3];
            string r;
            int a, b, k;
            r = Console.ReadLine();
            s = r.Split(' ');
            k = int.Parse(s[0]);
            a = int.Parse(s[1]);
            b = int.Parse(s[2]);
            int f=a;
            int g=b;
            int c = 0 , res=0;
            int d, e;
            d = a % k;
            e = b % k;
            if(d<0)
                d=d+k;
            if(e<0)
                e=e+k;
            if(b>a)
            {
                if(k-d<=d)
                {
                    c = c + k - d;
                    a = a + k - d;
                }
                else
                {
                    c = c + d;
                    a = a - d;
                } 
                if (k - e >= e)
                {
                    c = c + e;
                    b = b - e;
                }
                else
                {
                    c = c + k - e;
                    b = b + k - e;
                }
                res = c + ((b - a) / k);
            }
            else
            {
            	if(k-e<=e)
                {
                    c = c + k - e;
                    b = b + k - e;
                }
                else
                {
                    c = c + e;
                    b = b - e;
                }
                if (k - d >= d)
                {
                    c = c + d;
                    a = a - d;
                }
                else
                {
                    c = c + k - d;
                    a = a + k - d;
                }
                res = c + ((a - b) / k);
            }
            if(f>g)
            {
                if(f-g<=res)
                {
                    Console.WriteLine(f-g);
                }
                else
                {
                	Console.WriteLine(res);
                }
            }
            if(g>=f)
            {
                if(g-f<=res)
                {
                    Console.WriteLine(g-f);
                }
            
                else
                {
                    Console.WriteLine(res);
                }
            }
        }
    }
}
