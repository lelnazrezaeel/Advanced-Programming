using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin2_5
{
    
    class Book
    {
        public string bname;
        public int bid , bcount;
        public Book(int bid , string bname , int bcount)
        {
            this.bid = bid;
            this.bname = bname;
            this.bcount = bcount;
        }
    }
    class Member
    {
        public string mname;
        public int mid;
        Book[] b = new Book[5];
        public Member(int mid,string mname)
        {
            this.mid = mid;
            this.mname = mname;
        }
        Book[] books = new Book[5];
        public string getbook(Book book)
        {
            int i ;
            string output="";
            for(i=0 ; i<5 ; i++)
            {
                if(books[i]==null)
                {
                    books[i] = book;
                    output = "can";
                    break;
                }
                else
                {
                    output = "Max Reached : " + mid + " " + mname;
                }
            }
            return output;
        }
        public void returnbook (Book book)
        {
            int i;
            for(i=0; i<5;i++)
            {
                if (books[i].bid == book.bid)
                {
                    books[i] = null;
                    break;
                }
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Book[] books = new Book[50];
            Member[] members = new Member[50];
            int i=0 , _bid , _bcount , _mid , k=0 , j;
            bool available = true;
            string _bname , _mname;
            Console.WriteLine("Enter addBook to add some books \nEnter addMember to add some members \n" +
            "Enter getBook to take a book \n" +"Enter returnBook to return a book \n" +
            "Enter bookStat to view a summery of the status of books \n Enter memberStat " +
            "to view a summery of the status of the members");
            string[] order;
            while(true)
            {
                order =Console.ReadLine().Split(' ');
                if(order[0]=="addBook")
                {
                    _bid = int.Parse(order[1]);
                    _bname = order[2];
                    _bcount = int.Parse(order[3]);
                    foreach(var book in books)
                    {
                        if(book.bname==_bname)
                        {
                            book.bcount+=_bcount;
                            available = false;
                        }
                    }
                    if(available==false)
                    {
                        books[i] = new Book(_bid, _bname, _bcount);
                        i++;
                    }
                }
                if(order[0]=="addMember")
                {
                    _mid = int.Parse(order[1]);
                    _mname = order[2];
                    members[k] = new Member(_mid, _mname);
                    k++;
                }
                if (order[0] == "getBook") 
                {
                    _mid = int.Parse(order[1]);
                    _bid = int.Parse(order[2]);
                    foreach(var book in books)
                    {
                        if(book.bid==_bid)
                        {
                            if(book.bcount>0)
                            {
                                for(j=0; j<50; j++)
                                {
                                    if(members[j].mid==_mid)
                                    {
                                        if(members[j].getbook(book)=="can")
                                        {
                                            book.bcount--;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine(members[j].getbook(book));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("NotAvailable : {0} , {1}", book.bname, book.bname);
                            }
                        }
                    }
                }
                if(order[0]=="returnBook")
                {
                    _mid = int.Parse(order[1]);
                    _bid = int.Parse(order[2]);
                    foreach(var book in books)
                    {
                        foreach(var member in members)
                        {
                            if(book.bid==_bid)
                            {
                                if(member.mid==_mid)
                                {
                                    member.returnbook(book);
                                    book.bcount++;
                                    break;
                                }
                            }
                        }
                    }
                }
                if(order[0]=="bookStat")
                {
                    foreach(var book in books)
                    {
                        Console.WriteLine("{0} {1} {2}", book.bname, book.bid, book.bcount);
                    }
                }
                if(order[0]=="memberStat")
                {
                    foreach(var member in members)
                    {
                        Console.WriteLine("{0} {1}", member.mname, member.mid);
                    }
                    foreach(var book in books)
                    {
                        Console.WriteLine(book.bname, book.bid);
                    }
                }
            }
        }
    }
}
