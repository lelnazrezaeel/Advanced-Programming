using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin1_4
{
    class TwoComplex
    {
        int a, b, c, d;
        public void Start()
        {
            Console.WriteLine(" Enter the real part of the first number");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter the imaginery part of the first number");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter the real part of the second number");
            c = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter the imaginary part of the second number");
            d = int.Parse(Console.ReadLine());
        }
        public void Mul()
        {
            int mul_i = (a * c) - (b * d);
            int mul_j = (a * d) + (b * c);
            Console.WriteLine("The answer is {0} + {1}j", mul_i, mul_j);
        }
        public void Div()
        {
            int den = (c * c) + (d * d);
            float div_i = ((float)((a*c)+(b*d)) / den) ;
            float div_j = ((float)((b*c)+(a*(-d))) / den) ;
            Console.WriteLine("The answer is {0:.##} + {1:.##}j", div_i, div_j);
        }
        public void Add()
        {
            int sum_i = a + c;
            int sum_j = b + d;
            Console.WriteLine("The answer is {0} + {1}j", sum_i, sum_j);
        }
        public void Sub()
        {
            int sub_i = a - c;
            int sub_j = b - d;
            Console.WriteLine("The answer is {0} + {1}j", sub_i, sub_j);
        }
        public void ChangeNumber()
        {
            Console.WriteLine(" Enter the real part of the first number");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter the imaginery part of the first number");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter the real part of the second number");
            c = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter the imaginary part of the second number");
            d = int.Parse(Console.ReadLine());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TwoComplex t = new TwoComplex();
            t.Start();
            Console.WriteLine("Enter 1 for addition \nEnter 2 for submission \nEnter 3 for multiplication"
+ " \nEnter 4 for division \nEnter 5 for Change number \nEnter 6 for close");
            int op;
            while (true)
            {
                op = int.Parse(Console.ReadLine());
                if (op == 1)
                { 
                    t.Add();
                }
                if (op == 2)
                {
                    t.Sub();
                }
                if (op == 3)
                {
                    t.Mul();
                }
                if (op == 4)
                {
                    t.Div();
                }
                if(op == 5)
                {
                    t.ChangeNumber();
                }
                if(op == 6)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
