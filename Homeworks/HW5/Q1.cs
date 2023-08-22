using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin5_1
{
    class Point
    {
        protected double x, y;
        public Point(double x , double y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual void print()
        {
            Console.WriteLine($"Lenght : {x} Width : {y}");
        }
        public virtual void printMethods()
        {

        }
        public virtual void numberShape()
        {
            double number = x + y;
            Console.WriteLine("Shape number : {0:0.##}", number);
        }
    }
    class Circle : Point
    {
        public double r;
        public Circle(double x , double y , double r) : base(x,y)
        {
            if(r<0)
            {
                throw new Exception("Radius can not be negative !");
            }
            this.r = r;
        }
        public double perimeter()
        {
            double p = (Math.PI) * 2 * r;
            return p;
        }
        public double area()
        {
            double s = (Math.PI) * Math.Pow(r,2);
            return s;
        }
        public override void numberShape()
        {
            double number = x + y + r;
            Console.WriteLine("Shape number : {0:0.##}", number);
        }
        public override void print()
        {
            Console.WriteLine($"Lenght : {x} Width : {y} Radius : {r}");
        }
        public override void printMethods()
        {
            Console.WriteLine("Perimeter : {0:0.##}", perimeter());
            Console.WriteLine("Area : {0:0.##}", area());
        }
    }
    class Cylinder : Circle
    {
        double h;
        public Cylinder(double x , double y , double r , double h) : base(x,y,r)
        {
            if(h<0)
            {
                throw new Exception("Height must be positive !");
            }
            this.h = h;
        }
        public double volume()
        {
            double v = area() * h;
            return v;
        }
        public override void numberShape()
        {
            double number = x + y + r + h;
            Console.WriteLine("Shape number : {0:0.##}", number);
        }
        public override void print()
        {
            Console.WriteLine($"Lenght : {x} Width : {y} Radius : {r} Height : {h}");
        }
        public override void printMethods()
        {
            Console.WriteLine("Perimeter : {0:0.##}", perimeter());
            Console.WriteLine("Area : {0:0.##}", area());
            Console.WriteLine("Volume : {0:0.##}", volume());
        }
    }
    enum Type { Point , Circle , Cylinder , ShowAll , Exit};
    class Program
    {
        static void Main(string[] args)
        {
            List <Point> points= new List<Point>();
            Type type;
            double x, y, r, h;
            Point point;
            Circle circle;
            Cylinder cylinder;
            int k = 1;
            while(true)
            {
                try
                {
                    Console.WriteLine("Please choose \nPoint to add a point \nCircle to add a circle \nCylinder to add a cylinder \nShowAll \nExit");
                    type = (Type)Enum.Parse(typeof(Type), Console.ReadLine() ,true);
                    if(type==Type.Point)
                    {
                        while(true)
                        {
                            try
                            {
                                Console.WriteLine("Enter the lenght of point : ");
                                x = double.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the width of point : ");
                                y = double.Parse(Console.ReadLine());
                                point = new Point(x, y);
                                points.Add(point);
                                point.print();
                                point.numberShape();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid input ! ");
                            }
                        }
                    }
                    else if (type == Type.Circle)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter the center length of the circle : ");
                                x = double.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the center width of the circle : ");
                                y = double.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the radius of circle");
                                r = double.Parse(Console.ReadLine());
                                circle = new Circle(x, y , r);
                                points.Add(circle);
                                circle.print();
                                circle.numberShape();
                                circle.printMethods();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid input ! ");
                            }
                        }
                    }
                    else if (type == Type.Cylinder)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter the center length of the cylinder : ");
                                x = double.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the center width of the cylinder : ");
                                y = double.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the radius of cylinder");
                                r = double.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the height of cylinder");
                                h = double.Parse(Console.ReadLine());
                                cylinder = new Cylinder(x, y, r , h);
                                points.Add(cylinder);
                                cylinder.print();
                                cylinder.numberShape();
                                cylinder.printMethods();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid input ! ");
                            }
                        }
                    }
                    else if (type == Type.ShowAll)
                    {
                        if(points.Count == 0)
                        {
                            throw new Exception("The list is empty");
                        }
                        foreach(var p in points)
                        {
                            Console.WriteLine($"Shape {k} :");
                            p.print();
                            p.printMethods();
                            Console.WriteLine();
                            k++;
                        }
                    }
                    else if (type == Type.Exit)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("Enter Ponit or Circle or Cylinder or ShowAll orExit");
                    }
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
}
