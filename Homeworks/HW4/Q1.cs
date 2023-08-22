using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tamrin4_1
{
    struct Bank
    {
        public string bookName { get; set; }
        public string authorName { get; set; }
        public string publisherName { get; set; }
        public int price { get; set; }
        public string ID { get; set; }
        public char flag { get; set; }
        public Bank(string bookName , string authorName , string publisherName , int price , string ID)
        {
            this.bookName = bookName;
            this.authorName = authorName;
            this.publisherName = publisherName;
            this.price = price;
            this.ID = ID;
            flag =' ';
        }
        
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0, i  , j;
            Bank[] banks = new Bank[100];
            string input , searchID;
            string[] name = new string[100];
            bool rep = false;
            while(true)
            {
                try
                {
                    Console.WriteLine("Please choose \nADD for adding a book \n" +
                    "LIST for showing list of the books that we have in our bookstore \n" +
                    "SEARCH for searching the book that you want based on the ID of the book \n" + 
                    "SORT for sorting list of the books \n" +
                    "DELETE for deleting the book from the list \n" +
                    "EXIT for exiting from the programm");
                    input = Console.ReadLine().ToUpper();
                    if(input=="ADD")
                    {
                        Console.WriteLine("Please enter information of the book : ");
                        Console.WriteLine("Please enter name of the book : ");
                        string bookName = Console.ReadLine();
                        Console.WriteLine("Please enter the writer of the book : ");
                        string authorName = Console.ReadLine();
                        Console.WriteLine("Please enter the ID of the book : ");
                        string ID = Console.ReadLine();
                        Console.WriteLine("Please enter price of the book : ");
                        int price = int.Parse(Console.ReadLine());
                        while (true)
                        {
                            if (price>0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("The price can not be negative , Enter a non_negative price");
                                price=int.Parse(Console.ReadLine());
                            }
                        }
                        Console.WriteLine("Please enter publication of the book : ");
                        string publicationName = Console.ReadLine();
                        foreach (var b in banks)
                        {
                            if (ID == b.ID)
                            {
                                rep = true;
                                Console.WriteLine("The ID is duplicate , books will not be added");
                            }
                        }
                        if(rep==false)
                        {
                            banks[k] = new Bank(bookName, authorName, publicationName, price, ID);
                            k++;
                        }  
                    }
                    else if(input=="LIST")
                    {
                        StreamWriter list = new StreamWriter("List.txt");
                        foreach(var b in banks)
                        {
                            if(b.bookName!=null && b.flag!='*')
                            {
                                Console.WriteLine($"Book : ");
                                list.WriteLine($"Book : ");
                                Console.WriteLine($"name : {b.bookName}");
                                list.WriteLine($"name : {b.bookName}");
                                Console.WriteLine($"writer : {b.authorName}");
                                list.WriteLine($"writer : {b.authorName}");
                                Console.WriteLine($"price : {b.price}");
                                list.WriteLine($"price : {b.price}");
                                Console.WriteLine($"ID : {b.ID}");
                                list.WriteLine($"ID : {b.ID}");
                                Console.WriteLine($"publication : {b.publisherName}");
                                list.WriteLine($"publication : {b.publisherName}");
                            }
                        }
                        list.Close();
                    }
                    else if(input=="SEARCH")
                    {
                        Console.WriteLine("Enter the ID of the book : ");
                        searchID = Console.ReadLine();
                        foreach (var b in banks)
                        {
                            if(searchID==b.ID && b.flag==' ')
                            {
                                Console.WriteLine($"name : {b.bookName}");
                                Console.WriteLine($"writer : {b.authorName}");
                                Console.WriteLine($"price : {b.price}");
                                Console.WriteLine($"publication : {b.publisherName}");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("The book was not found");
                                break;
                            }
                        }
                    }
                    else if(input=="SORT")
                    {
                        string order, temp;
                        int x = 0, y = 0;
                        while(true)
                        {
                            try
                            {
                                Console.WriteLine("Please choose which one do you want \n" + 
                                "SortByName\n"+ "SortByID");
                                order = Console.ReadLine().ToLower();
                                if(order=="sortbyname")
                                {
                                    string[] sortbyname = new string[100];
                                    for(i=0;i<banks.Length; i++)
                                    {
                                        if (banks[i].bookName != null && banks[i].flag != '*')
                                        {
                                            sortbyname[i] = banks[i].bookName;
                                            x++;
                                        }
                                    }
                                    for (i = 0; i < x; i++)
                                    {
                                        for (j = 0; j < x - 1; j++)
                                        {
                                            if(sortbyname[j].CompareTo(sortbyname[j+1])>0)
                                            {
                                                temp = sortbyname[j];
                                                sortbyname[j] = sortbyname[j + 1];
                                                sortbyname[j] = temp;
                                            }
                                        }
                                    }
                                    for(i=0; i<x; i++)
                                    {
                                        Console.WriteLine($"{sortbyname[i]}");
                                    }
                                    x = 0;
                                }
                                else if(order=="sortbyid")
                                {
                                    int[] sortbyid = new int[100];
                                    int temp2;
                                    for (i = 0; i < banks.Length; i++)
                                    {
                                        if(banks[i].ID!=null && banks[i].flag!='*')
                                        {
                                            sortbyid[i] = int.Parse(banks[i].ID);
                                            y++;
                                        }
                                    }
                                    for(i=0; i<y; i++)
                                    {
                                        for(j=0; j<y-1; j++)
                                        {
                                            if(sortbyid[j]>sortbyid[j+1])
                                            {
                                                temp2 = sortbyid[j];
                                                sortbyid[j] = sortbyid[j + 1];
                                                sortbyid[j + 1] = temp2;
                                            }
                                        }
                                    }
                                    for (i = 0; i < y; i++)
                                    {
                                        Console.WriteLine($"{sortbyid[i]}");
                                    }
                                    y = 0;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input");
                                    throw new Exception();
                                }
                                break;
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                    else if(input=="DELETE")
                    {
                        string delID;
                        bool del = false;
                        Console.WriteLine("Enter the ID of the book you want to delete");
                        delID = Console.ReadLine();
                        for(i=0; i<banks.Length; i++)
                        {
                            if(banks[i].bookName!=null && banks[i].ID==delID)
                            {
                                banks[i].flag = '*';
                                del = true;
                                Console.WriteLine("The book is being deleted");
                                break;
                            }
                        }
                        if(del==false)
                        {
                            Console.WriteLine("There is no book with this ID");
                            break;
                        }
                    }
                    else if(input=="EXIT")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Try again");
                }
            }
        }
    }
}
