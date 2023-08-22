using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tamrin5_22
{
    class Sodoku
    {
        static int[,] sodoku = new int[9, 9]
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };
        static int[,] copySodoku = new int[9, 9]
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };
        static bool CheckRowColBox(int row , int col , int num)
        {
            int i;
            for(i=0; i<9; i++)
            {
                if(sodoku[row , col]!=0)
                {
                    return false;
                }
                if(sodoku[row,i] == num)
                {
                    return false;
                }
                if (sodoku[i, col] == num)
                {
                    return false;
                }
                if (sodoku[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == num)
                {
                    return false;
                }    
            }
            return true;
        }
        public static void Add(int row , int col , int num)
        {
            if (Sodoku.CheckRowColBox(row,col,num)==true)
            {
                sodoku[row, col] = num;
                Console.WriteLine("The call added");
            }
            else
            {
                Console.WriteLine("You can't add because of sodoku's rules !");
            }
        }
        public static void Del(int row , int col)
        {
            if(copySodoku[row,col]!=0)
            {
                Console.WriteLine("You can't delete default cells !");
            }
            else
            {
                if(sodoku[row,col]==0)
                {
                    Console.WriteLine("You can't delete empty cells !");
                }
                else
                {
                    sodoku[row, col] = 0;
                    Console.WriteLine("The cell was deleted !");
                }
            }
        }
        public static void ShowTable()
        {
            int i, j;
            for(i=0; i<37; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            for(i=0; i<9; i++)
            {
                Console.Write("|");
                for(j=0; j<9; j++)
                {
                    if(copySodoku[i,j]!=0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.Write($" {sodoku[i, j]} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                Console.WriteLine();
                for(j=0; j<37; j++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor=ConsoleColor.White;
        }
        public static void CheckInputs(int row , int col , int number)
        {
            if(row<0 || row>8 || col < 0 || col > 8 || number < 1 || number > 9 )
            {
                throw new Exception("The inputs are out of range !");
            }
        }
    }
    enum req { Add , Del , ShowTable , Exit};
    class Program
    {
        static void Main(string[] args)
        {
            req request;
            string[] input;
            int row, col, number;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please choose : \nAdd \nDel \nShowTable \nExit");
                    request = (req)Enum.Parse(typeof(req), Console.ReadLine(), true);
                    Sodoku sodoku = new Sodoku();
                    if(request==req.Add)
                    {
                        while(true)
                        {
                            try
                            {
                                Console.WriteLine("Enter the row , coloumn and number with space :");
                                input = Console.ReadLine().Split(' ');
                                row = int.Parse(input[0])-1;
                                col = int.Parse(input[1])-1;
                                number = int.Parse(input[2]);
                                Sodoku.CheckInputs(row, col, number);
                                Sodoku.Add(row, col, number);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid input type !");
                            }
                        }
                    }
                    else if(request==req.Del)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter the row and coloumn with space :");
                                input = Console.ReadLine().Split(' ');
                                row = int.Parse(input[0])-1;
                                col = int.Parse(input[1])-1;
                                Sodoku.CheckInputs(row, col, 5);
                                Sodoku.Del(row, col);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid input type !");
                            }
                        }
                    }
                    else if(request==req.ShowTable)
                    {
                        Sodoku.ShowTable();
                    }
                    else if(request==req.Exit)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("Your request is invalid ! ");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input !");
                }
            }
        }
    }
}
