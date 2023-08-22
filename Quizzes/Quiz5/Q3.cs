using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz5__
{
    class Circle
    {
        int x, y, r;
        List<Circle> Circles ;
        public Circle(int x , int y , int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            if (r < 0)
            {
                throw new Exception("Negative radius !");
            }
            Circles = new List<Circle>();
        }
        
        public static Circle operator +(Circle circle1 , Circle circle2)
        {
            Circle circle ;
            circle = new Circle(circle1.x + circle2.x, circle1.y + circle2.y, circle1.r + circle2.r);
            return circle;
        }
        public static Circle operator -(Circle circle1, Circle circle2)
        {
            Circle circle;
            circle = new Circle(circle1.x - circle2.x, circle1.y - circle2.y, circle1.r - circle2.r);
            return circle;
        }
        public static Circle operator *(Circle circle1, Circle circle2)
        {
            Circle circle;
            circle = new Circle(circle1.x * circle2.x, circle1.y * circle2.y, circle1.r * circle2.r);
            return circle;
        }
        public static bool operator ==(Circle circle1, Circle circle2)
        {
            if(circle1.x==circle2.x && circle1.y == circle2.y && circle1.r == circle2.r )
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Circle circle1, Circle circle2)
        {
            if (circle1.x == circle2.x || circle1.y == circle2.y || circle1.r == circle2.r)
            {
                return false;
            }
            return true;
        }
        public void print()
        {
            Console.WriteLine($"x : {x} y : {y} r : {r}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(0, 0, 10);
            Circle c2 = new Circle(5, 3, 6);
            Circle c3 = c1 + c2;
            c3.print();
            c3 = c1 - c2;
            c3.print();
            c3 = c1 * c2;
            c3.print();
        }
    }
}
