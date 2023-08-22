using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz4
{
    class Media
    {
        protected int Id , Cost , Count , k=1;
        protected string Name;
        public Media(string Name , int Cost , int Count)
        {
            this.Name = Name;
            if (Name == null)
            {
                throw new Exception("The name can't be null !");
            }
            this.Cost = Cost;
            if (Cost < 0)
            {
                throw new Exception("The cost can't ba negative !");
            }
            this.Count = Count;
            if (Count < 0)
            {
                throw new Exception("The count can't ba negative !");
            }
            Id = k;
            k++;
        }
        public virtual void Show()
        {
            string output;
            if(Count>0)
            {
                output = "Yes";
            }
            else
            {
                output = "No";
            }
            Console.WriteLine($"Name : {Name} , Cost : {Cost} , IsAvailable : {output}");
        }
        public void Charge(int c)
        {
            if(c<0)
            {
                throw new Exception("The chaege number can't be negative");
            }
            Count += c;
        }
    }
    class Book : Media
    {
        string Author { get; }
        int Year { get; }
        public Book (string Name, int Cost, int Count , string Author , int Year) : base(Name,Cost,Count)
        {
            this.Author = Author;
            if (Author == null)
            {
                throw new Exception("The name of author can't be null !");
            }
            this.Year = Year;
            if(Year<0 || Year>2021)
            {
                throw new Exception("Invalid Year !");
            }
            
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Author : {Author} , Year : {Year}");
        }
        public virtual void Kharid(int Count2 , int Cost2)
        {
            if(Count2<=Count && Cost2>=Cost)
            {
                Console.WriteLine("You bought this item !");
                Count -= Count2;
            }
            else
            {
                Console.WriteLine("You can't buy this item !");
            }
        }
    }
    class Magazine : Book
    {
        protected int Month, Pages, SalesAmount=0;
        public Magazine(string Name, int Cost, int Count, string Author, int Year , int Month , int Pages) : base(Name,Cost,Count,Author,Year)
        {
            this.Month = Month;
            if(Month<1 || Month>12)
            {
                throw new Exception("Invalid month !");
            }
            this.Pages = Pages;
            if(Pages<0)
            {
                throw new Exception("Pages can't ba negative !");
            }
            if (Pages < 0)
            {
                throw new Exception("SalesAmount can't ba negative !");
            }
        }
        public override void Kharid(int Count2, int Cost2)
        {
            base.Kharid(Count2, Cost2);
            if (Count2 <= Count && Cost2 >= Cost)
            {
                SalesAmount += (Cost * Count);
            }
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"SalesAmount : {SalesAmount}");
        }
    }
    enum GameType { Strategy , Thought , Sport};
    enum GameStyle { FirstPerson , ThirdPerson };
    enum AgeCategory { Childish , Adolescent , Young };
    class Game : Media
    {
        GameType Type { get; set; }
        string Description { get; set; }
        GameStyle Style { get; set; }
        AgeCategory Category { get; set; }
        public Game(string Name, int Cost, int Count , GameType Type, string Description, GameStyle Style, AgeCategory Category) : base(Name, Cost, Count)
        {
            this.Type = Type;
            this.Description = Description;
            this.Style = Style;
            this.Category = Category;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Type : {Type} , Description : {Description} , Style : {Style} , Category : {Category}")
        }
        public void Kharid2(int Count2, int Cost2)
        {
            if (Count2 <= Count && Cost2 >= Cost)
            {
                Console.WriteLine("You bought this item !");
                Count -= Count2;
            }
            else
            {
                Console.WriteLine("You can't buy this item !");
            }
        }
    }
    static class VahedePul
    {
        public static string CurrencyPrice(this string cost)
        {
            return cost;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input ;
            string[] input2;
            string[] input3;
            string[] input4;
            string[] input5;
            int count;
            while(true)
            {
                try
                {
                    //Media
                    Console.WriteLine("Enter Name , Cost , Count with space");
                    input = Console.ReadLine().Split(' ');
                    Media media = new Media(input[0], int.Parse(input[1]), int.Parse(input[2]));
                    Console.WriteLine("Enter the number you want charge : ");
                    count = int.Parse(Console.ReadLine());
                    media.Charge(count);
                    media.Show();

                    //Book
                    Console.WriteLine("Enter Author and Year with space");
                    input2 = Console.ReadLine().Split(' ');
                    Book book = new Book(input[0], int.Parse(input[1]), int.Parse(input[2]),input2[0],int.Parse(input2[1]));
                    Console.WriteLine("Enter the number and your money  with space: ");
                    input3 = Console.ReadLine().Split(' ');
                    book.Kharid(int.Parse(input3[0]), int.Parse(input3[1]));
                    book.Show();

                    //Magazine
                    Console.WriteLine("Enter Month and PagesNumber with space");
                    input4 = Console.ReadLine().Split(' ');
                    Magazine magazine = new Magazine(input[0], int.Parse(input[1]), int.Parse(input[2]), input2[0], int.Parse(input2[1]),int.Parse(input4[0]),int.Parse(input4[1]));
                    Console.WriteLine("Enter the number and your money  with space: ");
                    input3 = Console.ReadLine().Split(' ');
                    book.Kharid(int.Parse(input3[0]), int.Parse(input3[1]));
                    book.Show();

                    //Game
                    Console.WriteLine("Enter GameType , Description, GameStyle and AgeCategory Category with space");
                    input5 = Console.ReadLine().Split(' ');
                    Game game = new Game(input[0], int.Parse(input[1]), int.Parse(input[2]),(GameType)Enum.Parse(typeof(GameType),input5[0]), int.Parse(input2[1]), int.Parse(input4[0]), int.Parse(input4[1]));
                    Console.WriteLine("Enter the number and your money  with space: ");
                    input3 = Console.ReadLine().Split(' ');
                    game.Kharid2(int.Parse(input3[0]), int.Parse(input3[1]));
                    game.Show();
                }
                catch
                {

                }
            }
            
        }
    }
}
