using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tamrin2_2
{
    class Circle
    {
        private double xo, yo, r;
        public Circle(double xo, double yo, double r)
        {
            this.xo = xo;
            this.yo = yo;
            this.r = r;
        }
        public double PCircle() => 2 * r * Math.PI;
        public double SCircle() => Math.PI * r * r;
        public static double DSpot(double x, double y) => Math.Sqrt((x * x) + (y * y));
        public double DCircle(double x, double y) => Math.Sqrt(((x - xo) * (x - xo)) + ((y - yo) * (y - yo)));
        public string SC(double x, double y)
        {
            string output="";
            double dis = Math.Sqrt(((x - xo) * (x - xo)) + ((y - yo) * (y - yo)));
            if (dis < r)
            {
                output = "The spot is inside the circle";
            }
            if (dis > r)
            {
                output = "The spot is outside the circle";
            }
            if (dis == r)
            {
                output = "The spot is on the circle";
            }
            return output;
        }
        public string CInfo()
        {
            string output = xo + " " + yo + " " + r;
            return output;
        }
        public Circle CCopy()
        {
            double _xo = xo - 2;
            double _yo = yo + 1;
            double _r = (r * 2) - 3;
            if (_r==0)
            {
                _r = 1;
            }
            if (_r<0 )
            {
                _r = _r * (-1);
            }
            return new Circle(_xo, _yo, _r);
        }
    }
   
    class Program
    {
        static void Comprasion(double[] c)
        {
            int i , j ;
            double d;
            for (i = 0; i < c.Length ; i++)
            {
                for (j = 0; j < c.Length-i-1; j++)
                {
                    if(c[j]>c[j+1])
                    {
                        d = c[j];
                        c[j] = c[j+1];
                        c[j+1] = d;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            StreamWriter writer;
            writer = new StreamWriter("Circle.txt");
            //The first part of the main

            double xc, yc, rc , xs , ys;
            Console.WriteLine("Enter the center length of the circle : ");
            xc = double.Parse(Console.ReadLine());

            writer.WriteLine("Enter the center length of the circle : {0:0.##}", xc);

            Console.WriteLine("Enter the center width of the circle : ");
            yc = double.Parse(Console.ReadLine());

            writer.WriteLine("Enter the center width of the circle : {0:0.##}", yc);

            Console.WriteLine("Enter the radius of the circle : ");
            rc = double.Parse(Console.ReadLine());

            writer.WriteLine("Enter the radius of the circle : {0:0.##}", rc);

            while (rc <= 0)
            {
                Console.WriteLine("Enter a non-negative number for the radius of the circle : ");
                rc = int.Parse(Console.ReadLine());

                writer.WriteLine("Enter a non-negative number for the radius of the circle : {0:0.##}", rc);
            }

            Circle c1 = new Circle(xc, yc, rc);
            Console.WriteLine("The circumference of the circle is {0:0.##}", c1.PCircle());

            writer.WriteLine("The circumference of the circle is {0:0.##}", c1.PCircle());

            Console.WriteLine("The area of the circle is {0:0.##}", c1.SCircle());

            writer.WriteLine("The area of the circle is {0:0.##}", c1.SCircle());


            Console.WriteLine("Enter the length of the spot : ");
            xs = double.Parse(Console.ReadLine());

            writer.WriteLine("Enter the length of the spot : {0:0.##}", xs);

            Console.WriteLine("Enter the width of the spot : ");
            ys = double.Parse(Console.ReadLine());

            writer.WriteLine("Enter the width of the spot : {0:0.##}", ys);

            Console.WriteLine("The distance from the point to the origin of the coordinates" +
            " is {0:0.##}", Circle.DSpot(xs, ys));

            writer.WriteLine("The distance from the point to the origin of the coordinates" +
            " is {0:0.##}", Circle.DSpot(xs, ys));

            Console.WriteLine("The distance from the point to the center of the circle is {0:0.##}"
            , c1.DCircle(xs, ys));

            writer.WriteLine("The distance from the point to the center of the circle is {0:0.##}"
            , c1.DCircle(xs, ys));

            Console.WriteLine(c1.SC(xs, ys));

            writer.WriteLine(c1.SC(xs, ys));
            //The second part of the main

            Console.WriteLine("Enter the number of the circles : ");
            int n = int.Parse(Console.ReadLine());

            writer.WriteLine("Enter the number of the circles : {0}", n);

            int i , k=1;
            Circle[] circles = new Circle[n];
            double[] d = new double[2 * n];
            for (i=0; i<n; i++)
            {
                Console.WriteLine("Enter the center length of the circle {0} : ",k);
                xc = double.Parse(Console.ReadLine());

                writer.WriteLine("Enter the center length of the circle {0} : {0:0.##}", k, xc);

                Console.WriteLine("Enter the center width of the circle {0} : ",k);
                yc = double.Parse(Console.ReadLine());

                writer.WriteLine("Enter the center width of the circle {0} : {0:0.##}", k, yc);

                Console.WriteLine("Enter the radius of the circle {0} : ",k);
                rc = double.Parse(Console.ReadLine());

                writer.WriteLine("Enter the radius of the circle {0} : {0:0.##}", k, rc);

                k++;
                while (rc <= 0)
                {
                    Console.WriteLine("Enter a non-negative number for the radius of the circle : ");
                    rc = int.Parse(Console.ReadLine());

                    writer.WriteLine("Enter a non-negative number for the radius of the circle : {0:0.##}", rc);
                }
                circles[i] = new Circle(xc, yc, rc);
                d[i] = Circle.DSpot(xc, yc);
                d[i + n] = Circle.DSpot(xc-2, yc+1);
            }
            k = 1;
            for (i=0; i<n; i++)
            {
                Console.WriteLine("The length , width and radius of the circle {0} are : {1}" +
                " respectively ", k, circles[i].CInfo());

                writer.WriteLine("The length , width and radius of the circle {0} are : {1}" +
                " respectively ", k, circles[i].CInfo());

                Console.WriteLine("The length, width and radius of the copy of circle {0} " +
                "are : {1}", k, circles[i].CCopy().CInfo());

                writer.WriteLine("The length, width and radius of the copy of circle {0} " +
                "are : {1}", k, circles[i].CCopy().CInfo());

                k++;
            }
            
            double[] p = new double[2 * n];
            double[] s = new double[2 * n];
            for (i=0; i<n; i++)
            {
                p[i] = circles[i].PCircle();
                s[i] = circles[i].SCircle();

            }
            for (i = n; i < 2 * n; i++)
            {
                p[i] = circles[i-n].CCopy().PCircle();
                s[i] = circles[i-n].CCopy().SCircle();
            }
           
            Console.WriteLine("List of circles sorted by environment : ");
            writer.WriteLine("List of circles sorted by environment : ");
            Comprasion(p);
            for(i=0; i<p.Length; i++)
            {
                Console.Write("{0:0.## }", p[i]);
                writer.Write("{0:0.## }", p[i]);
            }

            Console.WriteLine("\nList of circles sorted by area : ");
            writer.WriteLine("\nList of circles sorted by area : ");
            Comprasion(s);
            for (i = 0; i < s.Length; i++)
            {
                Console.Write("{0:0.## }", s[i]);
                writer.Write("{0:0.## }", s[i]);
            }

            Console.WriteLine("Sorted list of circles based on " +
            "the distance of the center of the circle from the origin of the coordinates : ");
            writer.WriteLine("Sorted list of circles based on " +
            "the distance of the center of the circle from the origin of the coordinates : ");
            Comprasion(d);
            for (i = 0; i < d.Length; i++)
            {
                Console.Write("{0:0.## }", d[i]);
                writer.Write("{0:0.## }", d[i]);
            }

            writer.Close();
        }
    }
}
