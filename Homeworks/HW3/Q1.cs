using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tamrin3_1
{
    
    class Program
    {
        enum Topic { it = 21, imageprocessing = 27, ai = 36, iot = 45, database = 55, web = 83 };
        enum Type { User , Admin}
        enum AdminP { Count , ChangePassword , Exit}
        enum UserP { Search , Exit}
        static string CesarEncoding(string password)
        {
            int i, j;
            string output = "";
            char[] Letter = new char[26] { 'a' , 'b' , 'c' , 'd' , 'e' , 'f' , 'g' , 'h' , 'i' , 'j' , 'k' , 'l' ,
            'm' , 'n' , 'o' , 'p' , 'q', 'r' , 's' , 't' , 'u' , 'v' , 'w' , 'x' , 'y' , 'z' };
            for (i = 0; i < password.Length; i++)
            {
                for (j = 0; j < 26; j++)
                {
                    if (password[i] == Letter[j])
                    {
                        output += Letter[(j + 3) % 26];
                    }
                }
            }
            return output;
        }
        static bool CheckPassword(string password)
        {
            //hash password

            string check;
            try
            {
                StreamReader pass = new StreamReader("Password.txt");
                check = pass.ReadLine();
                Console.WriteLine(check);
                password.ToLower();
                password = CesarEncoding(password);
                Console.WriteLine(password);
                pass.Close();
            }
            catch(FileNotFoundException)
            {
                check = "Hello@P";
            }
            if(password==check)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Menu()
        {
            //main menu

            Type input;
            Console.WriteLine("If you are admin enter Admin and if you are user enter User");
            input = (Type)Enum.Parse(typeof(Type), Console.ReadLine());
            if (input == Type.Admin)
            {
                Admin();
            }
            if (input == Type.User)
            {
                User();
            }
            else
            {
                Console.WriteLine("Invalid input , Please enter admin or user");
                Menu();
            }
        }
        static void Admin()
        {
            //check password

            string password  , pas , pas1 , pas2;
            Console.WriteLine("Enter your password");
            password = Console.ReadLine();
            if (CheckPassword(password) == true)
            {
                Console.WriteLine("You succeeded");
                while (true)
                {
                    Console.WriteLine("Enter Count or ChangePassword or Exit");
                    AdminP order = (AdminP)Enum.Parse(typeof(AdminP), Console.ReadLine());
                    if (order==AdminP.Count)
                    {
                        int[] c2 = new int[90];
                        c2 = Count();
                        Console.WriteLine("IT : {0}", c2[21]);
                        Console.WriteLine("ImageProcessing : {0}", c2[27]);
                        Console.WriteLine("AI : {0}", c2[36]);
                        Console.WriteLine("IOT : {0}", c2[45]);
                        Console.WriteLine("Database : {0}", c2[55]);
                        Console.WriteLine("Web : {0}", c2[83]);
                    }
                    if (order == AdminP.ChangePassword)
                    {
                        Console.WriteLine("Enter your current password");
                        pas = Console.ReadLine();
                        if (CheckPassword(pas) == true)
                        {
                            StreamWriter pass = new StreamWriter("Password.txt");
                            Console.WriteLine("Enter your new password");
                            pas1 = Console.ReadLine();
                            Console.WriteLine("Enter your new password again");
                            pas2 = Console.ReadLine();
                            if (pas1 == pas2)
                            {
                                pass.WriteLine(pas1);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                                Admin();
                            }
                            pass.Close();
                        }
                        else
                        {
                            Console.WriteLine("You are not allowed");
                        }
                    }
                    if (order == AdminP.Exit)
                    {
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        Admin();
                    }
                }
            }
            else
            {
                Console.WriteLine("Not correct");
                Menu();
            }
        }
        static int[] Count()
        {
            int[] count = new int[90];
            while(true)
            {
                Console.WriteLine("Search : ");
                if (Enum.TryParse(Console.ReadLine().ToLower(), out Topic TopicName))
                {
                    if (Enum.IsDefined(typeof(Topic), TopicName))
                    {
                        count[(int)TopicName]++;
                    }
                    else
                    {
                        Console.WriteLine("It will add soon .");
                    }
                }
            }

        }
        static void User()
        {
            
            UserP order;

            //menu for user
            while(true)
            {
                Console.WriteLine("Enter Search Bar or Exit");
                order = (UserP)Enum.Parse(typeof(UserP), Console.ReadLine());
                if (order == UserP.Search)
                {
                    Count();
                }
                if (order == UserP.Exit)
                {
                    Menu();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    User();
                }
            }
            
        }
        
        
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Menu();
        }
    }
}
