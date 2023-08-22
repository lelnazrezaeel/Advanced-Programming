using System;

namespace Faaliat2
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1, b2;
            string[] d = new string[3];
            string[] e = new string[3];
            d = Console.ReadLine().Split(' ');
            e = Console.ReadLine().Split(' ');
            b1 = new Book(d[0], int.Parse(d[1]), int.Parse(d[2]));
            b2 = new Book(e[0], int.Parse(e[1]));
            b1.printinfo();
            b2.printinfo();
        }
    }
    class Book
    {
        private string a;
        private int b, c ;
        public Book(string bkname, int cst , int pgnumber)
        {
            a = bkname;
            b = cst;
            c = pgnumber ;
        }
        public Book(string bkname, int cst)
        {
            a= bkname;
            b= cst ;
            Random pg = new Random();
            c = pg.Next(10, 100);

        }
        public void printinfo()
        {
            Console.WriteLine("{0}  {1}  {2}" , a , b , c);
        }
    }
}
