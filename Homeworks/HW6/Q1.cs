using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Tamrin_6
{
    class Seller
    {
        string userName, password;
        public Seller(string userName , string password)
        {
            this.userName = userName;
            if (UI.CheckEmail(userName) == false)
            {
                throw new Exception("The username is incorrect !");
            }
            this.password = password;
        }
    }
    interface IDiscount
    {
        int Discount(int price);
    }
    class Student : IDiscount
    {
        string userName, studentID;
        public Student(string userName, string studentID)
        {
            this.userName = userName;
            this.studentID = studentID;
            if (UI.CheckStudentID(studentID) == false)
            {
                throw new Exception("The studentID is incorrect !");
            }
            UI.SaveToFile($"userName : {userName}", $"studentID : {studentID}");
        }
        public int Discount(int price)
        {
            return price - ((20 * price) / 100);
        }
    }
    class Teacher : IDiscount
    {
        string userName, institution;
        public Teacher(string userName, string institution)
        {
            this.userName = userName;
            this.institution = institution;
            UI.SaveToFile($"userName : {userName}", $"institution : {institution}");
        }
        public int Discount(int price)
        {
            return price - ((15 * price) / 100);
        }
    }
    class Customer : IDiscount
    {
        string userName , ID;
        public Customer(string userName, string ID)
        {
            this.userName = userName;
            this.ID = ID;
            if (UI.CheckID(ID) == false)
            {
                throw new Exception("The ID is incorrect !");
            }
        }
        public int Discount(int price)
        {
            return price - ((5 * price) / 100);
        }
    }
    static class UI
    {
        public static bool CheckEmail(string email)
        {
            string emailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            Regex regex = new Regex(emailRegex);
            if (regex.IsMatch(email))
            {
                return true;
            }
            return false;
        }
        public static bool CheckStudentID(this string ID)
        {
            string IDRegex = @"^[9]{1}[0-9]{7}$"; 
            Regex regex = new Regex(IDRegex);
            if (regex.IsMatch(ID))
            {
                return true;
            }
            return false;
        }
        public static void SaveToFile(string line1, string line2)
        {
            if(File.Exists("CustomersInfo.txt"))
            {
                using (StreamWriter streamWriter = File.AppendText("CustomersInfo.txt"))
                {
                    streamWriter.WriteLine(line1);
                    streamWriter.WriteLine(line2);
                    streamWriter.Close();
                }
            }
            else
            {
                using (StreamWriter streamWriter = File.CreateText("CustomersInfo.txt"))
                {
                    streamWriter.WriteLine(line1);
                    streamWriter.WriteLine(line2);
                    streamWriter.Close();
                }
            }
            
        }
        public static bool CheckID(string ID)
        {
            int len = ID.Length;
            int a = int.Parse(ID[9].ToString());
            int b = (int.Parse(ID[0].ToString()) * 10) + (int.Parse(ID[1].ToString()) * 9) + (int.Parse(ID[2].ToString()) * 8)
            + (int.Parse(ID[3].ToString()) * 7) + (int.Parse(ID[4].ToString()) * 6) + (int.Parse(ID[5].ToString()) * 5) 
            + (int.Parse(ID[6].ToString()) * 4) + (int.Parse(ID[7].ToString()) * 3) + (int.Parse(ID[8].ToString()) * 2);
            int c = b % 11;
            if (ID.Distinct().Count()==1)
            {
                return false;
            }
            if (len != 10)
            {
                return false;
            }
            if (a == c && c == 0)
            {
                return true;
            }
            if (c == 1 && a == 1)
            {
                return true;
            }
            if (c > 1)
            {
                if (a == c - 1 || a == 1 - c)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
    public class Media
    {
        public string name;
        public int price , id;
        public Media(string name, int price , int id)
        {
            this.name = name;
            this.price = price;
            this.id = id;
            if (price < 0)
            {
                throw new Exception("Price can't be negative !");
            }
        }
    }
    interface ITax
    {
        int CalculateTax();
    }
    class Books : Media, ITax
    {
        public string author, publisher;
        public Books(string name, int price , int id , string author, string publisher) : base(name, price ,id)
        {
            this.author = author;
            this.publisher = publisher;
        }
        public int CalculateTax()
        {
            return ((10 * price) / 100) + price;
        }
    }
    class Videos : Media, ITax
    {
        public int time, count;
        public Videos(string name, int price , int id , int time, int count) : base(name, price ,id)
        {
            this.time = time;
            this.count = count;
            if(time<0)
            {
                throw new Exception("Time can't be negative !");
            }
            if(count<0)
            {
                throw new Exception("Count can't be negative !");
            }
        }
        public int CalculateTax()
        {
            int timeTax = ((time / 60) * 5 * price) / 100;
            int countTax = (count * 3 * price) / 100;
            return countTax + timeTax + price;
        }
    }
    class Magazine : Media, ITax
    {
        public string publisher;
        public int pages;
        public Magazine(string name, int price , int id , string publisher, int pages) : base(name, price ,id)
        {
            this.publisher = publisher;
            this.pages = pages;
            if(pages<0)
            {
                throw new Exception("Pages can't be negative !");
            }
        }
        public int CalculateTax()
        {
            int tax;
            if(pages>=0 && pages<=20)
            {
                tax = (price * 2) / 100;
            }
            else if(pages>20 && pages<=50)
            {
                tax = (price * 3) / 100;
            }
            else
            {
                tax = (price * 5) / 100;
            }
            return tax + price;
        }
    }
    public static class Library
    {
        public static void AddMedia(Media media)
        {
            if (File.Exists("Info.txt"))
            {
                using (StreamWriter streamWriter = File.AppendText("Info.txt"))
                {
                    streamWriter.WriteLine($"ID : {media.id}");
                    streamWriter.WriteLine($"Name : {media.name}");
                    if(media is Books)
                    {
                        streamWriter.WriteLine($"Price : {((Books)media).CalculateTax()}");
                        streamWriter.WriteLine($"Author : {((Books)media).author}");
                        streamWriter.WriteLine($"Publisher : {((Books)media).publisher}");
                    }
                    else if(media is Videos)
                    {
                        streamWriter.WriteLine($"Price : {((Videos)media).CalculateTax()}");
                        streamWriter.WriteLine($"Time : {((Videos)media).time}");
                        streamWriter.WriteLine($"Count : {((Videos)media).count}");
                    }
                    else if(media is Magazine)
                    {
                        streamWriter.WriteLine($"Price : {((Magazine)media).CalculateTax()}");
                        streamWriter.WriteLine($"Pages : {((Magazine)media).pages}");
                        streamWriter.WriteLine($"Publisher : {((Magazine)media).publisher}");
                    }
                    streamWriter.Close();
                }
            }
            else
            {
                using (StreamWriter streamWriter = File.CreateText("Info.txt"))
                {
                    streamWriter.WriteLine($"ID : {media.id}");
                    streamWriter.WriteLine($"Name : {media.name}");
                    streamWriter.WriteLine($"Price : {media.price}");
                    if (media is Books)
                    {
                        streamWriter.WriteLine($"author : {((Books)media).author}");
                        streamWriter.WriteLine($"publisher : {((Books)media).publisher}");
                    }
                    else if (media is Videos)
                    {
                        streamWriter.WriteLine($"time : {((Videos)media).time}");
                        streamWriter.WriteLine($"count : {((Videos)media).count}");
                    }
                    else if (media is Magazine)
                    {
                        streamWriter.WriteLine($"pages : {((Magazine)media).pages}");
                        streamWriter.WriteLine($"publisher : {((Magazine)media).publisher}");
                    }
                    streamWriter.Close();
                }
            }
        }
        public static void DelMedia(int ID)
        {
            var del = File.ReadAllLines("Info.txt");
            bool flag = false;
            int k = 0;
            StreamWriter streamWriter = new StreamWriter("Info.txt");
            for(int i=0; i<(del.Length/5) ; i++)
            {
                if (int.Parse((del[k]).Split(' ')[2]) == ID)
                {
                    flag = true;
                    Console.WriteLine("Deleted !");
                    i = i * 5 + 5;
                }
                streamWriter.WriteLine(del[i]);
                streamWriter.WriteLine(del[i+1]);
                streamWriter.WriteLine(del[i+2]);
                streamWriter.WriteLine(del[i+3]);
                streamWriter.WriteLine(del[i+4]);
                k += 5;
            }
            streamWriter.Close();
            if (flag == false)
            {
                Console.WriteLine("No media !");
            }
        }
        public static void SearchMedia(int ID)
        {
            int k = 0;
            var search = File.ReadAllLines("Info.txt");
            bool flag = false;
            for(int i=0; i<search.Length; i++)
            {
                if(int.Parse((search[k]).Split(' ')[2])==ID)
                {
                    Console.WriteLine(search[k]);
                    Console.WriteLine(search[k + 1]);
                    Console.WriteLine(search[k + 2]);
                    Console.WriteLine(search[k + 3]);
                    Console.WriteLine(search[k + 4]);
                    flag = true;
                    break;
                }
                k += 5;
            }
            if(flag == false)
            {
                Console.WriteLine("No media !");
            }
        }
    }
    enum AdminUser { Admin, User }
    enum UsersType { Student, Teacher, Normal }
    enum AdminMenu { Add , Search , Delete , ShowCustomers , ChangePass , Exit}
    enum MediaType { Book , Video , Magazine}
    enum UserMenu { Select , Edit , Buy , Chance , Exit}
    enum Edit { Remove , Exit}
    enum Buy { Ok , Cancel}
    class Program
    {
        static void Main(string[] args)
        {
            AdminUser input;
            UsersType usersType;
            AdminMenu adminMenu;
            MediaType media;
            UserMenu user;
            Edit edit;
            Buy buyl;
            DateTime date1, date2=DateTime.Now;
            string userName , password , studentID , name , institution , mainPass = "MyShop1234$" , changePass ,
            mediaName , author , publisher , ID , selectMed , editation;
            int mediaPrice, mediaID, pages, time, count, searchID, delID, cap1 = 0, cap2 = 0, cap3 = 0,
            tota1 = 0 , total2 = 0 , total3 = 0 ;
            int[] randomDiscount = new int[] { 0, 2, 3, 5, 7, 10, 15, 25, 30 };
            List<string> selectMesia = new List<string>();
            List<string> selected1 = new List<string>();
            List<string> selected2 = new List<string>();
            List<string> selected3 = new List<string>();
            List<int> selectPrice = new List<int>();
            List<int> selectedP1 = new List<int>();
            List<int> selectedP2 = new List<int>();
            List<int> selectedP3 = new List<int>();
            Random random;
            int rnddis;
            while (true)
            {
                try
                {
                    Console.WriteLine("If you are user enter User & if you are admin enter Admin :");
                    input = (AdminUser)Enum.Parse(typeof(AdminUser), Console.ReadLine(), true);
                    if (input == AdminUser.Admin)
                    {
                        
                        try
                        {
                            Console.WriteLine("Enter your username :");
                            userName = Console.ReadLine();
                            Console.WriteLine("Enter your password :");
                            password = Console.ReadLine();
                            Seller seller = new Seller(userName , password);
                            if (password != mainPass)
                            {
                                throw new Exception("Incorrect password !");
                            }
                            else
                            {
                                while(true)
                                {
                                    try
                                    {
                                        Console.WriteLine("Please choose : \nAdd \nDelete \nShowCustomers \nSearch \nChangePass \nExit");
                                        adminMenu = (AdminMenu)Enum.Parse(typeof(AdminMenu), Console.ReadLine(),true);
                                        if(adminMenu == AdminMenu.Add)
                                        {
                                            while (true)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter name : ");
                                                    mediaName = Console.ReadLine();
                                                    Console.WriteLine("Enter price : ");
                                                    mediaPrice = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("Enter id : ");
                                                    mediaID = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("Enter the media type : ");
                                                    media = (MediaType)Enum.Parse(typeof(MediaType), Console.ReadLine(), true);
                                                    if (media == MediaType.Book)
                                                    {
                                                        Console.WriteLine("Enter author : ");
                                                        author = Console.ReadLine();
                                                        Console.WriteLine("Enter publisher : ");
                                                        publisher = Console.ReadLine();
                                                        try
                                                        {
                                                            Books books = new Books(mediaName, mediaPrice, mediaID, author, publisher);
                                                            Library.AddMedia(books);
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            Console.WriteLine(e.Message);
                                                        }
                                                    }
                                                    else if (media == MediaType.Magazine)
                                                    {
                                                        Console.WriteLine("Enter publisher : ");
                                                        publisher = Console.ReadLine();
                                                        Console.WriteLine("Enter pages : ");
                                                        pages = int.Parse(Console.ReadLine());
                                                        try
                                                        {
                                                            Magazine magazine = new Magazine(mediaName, mediaPrice, mediaID, publisher, pages);
                                                            Library.AddMedia(magazine);
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            Console.WriteLine(e.Message);
                                                        }
                                                    }
                                                    else if (media == MediaType.Video)
                                                    {
                                                        Console.WriteLine("Enter time : ");
                                                        time = int.Parse(Console.ReadLine());
                                                        Console.WriteLine("Enter count : ");
                                                        count = int.Parse(Console.ReadLine());
                                                        try
                                                        {
                                                            Videos videos = new Videos(mediaName, mediaPrice, mediaID, time, count);
                                                            Library.AddMedia(videos);
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            Console.WriteLine(e.Message);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        throw new Exception();
                                                    }
                                                    break;
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("Invalid input type !");
                                                }     
                                            } 
                                        }
                                        else if(adminMenu == AdminMenu.Search)
                                        {
                                            while(true)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter the ID");
                                                    searchID = int.Parse(Console.ReadLine());
                                                    Library.SearchMedia(searchID);
                                                    break;
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("Invalid input type !");
                                                }
                                            }
                                        }
                                        else if(adminMenu == AdminMenu.Delete)
                                        {
                                            while (true)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter the ID");
                                                    delID = int.Parse(Console.ReadLine());
                                                    Library.DelMedia(delID);
                                                    break;
                                                }
                                                catch(Exception e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }
                                            }
                                        }
                                        else if(adminMenu == AdminMenu.ChangePass)
                                        {
                                            Console.WriteLine($"Tha lastest date is : {date2}");
                                            Console.WriteLine("Enter your password : ");
                                            changePass = Console.ReadLine();
                                            if(mainPass==changePass)
                                            {
                                                Console.WriteLine("Enter your new password : ");
                                                mainPass = Console.ReadLine();
                                                date1 = DateTime.Now;
                                                Console.WriteLine($"Date : {date1}");
                                                date2 = date1;
                                            }
                                            else
                                            {
                                                Console.WriteLine("The password is incorrect !");
                                            }
                                        }
                                        else if(adminMenu == AdminMenu.ShowCustomers)
                                        {
                                            if(!File.Exists("CustomersInfo.txt"))
                                            {
                                                throw new Exception("CustomersInfo file does not exist");
                                            }
                                            var CustomersInfo = File.ReadAllLines("CustomersInfo.txt");
                                            for (int i = 0; i < CustomersInfo.Length; i+=2)
                                            {
                                                Console.WriteLine(CustomersInfo[i] + " " + CustomersInfo[i+1]);
                                            }
                                        }
                                        else if(adminMenu == AdminMenu.Exit)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            throw new Exception("Invalid input !");
                                        }
                                    }
                                    catch(Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if (input == AdminUser.User)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter Student or Teacher or Normal :");
                                usersType = (UsersType)Enum.Parse(typeof(UsersType), Console.ReadLine(), true);
                                if (usersType == UsersType.Student)
                                {
                                    try
                                    {
                                        Console.WriteLine("Enter your name : ");
                                        name = Console.ReadLine();
                                        Console.WriteLine("Enter your studentID : ");
                                        studentID = Console.ReadLine();
                                        Student student = new Student(name, studentID);
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Please choose : \nSelect \nEdit \nBuy \nChance \nExit ");
                                                user = (UserMenu)Enum.Parse(typeof(UserMenu), Console.ReadLine(), true);
                                                if (user == UserMenu.Select)
                                                {
                                                    bool U1 = false;
                                                    try
                                                    {
                                                        var selMed = File.ReadAllLines("Info.txt");
                                                        Console.WriteLine("Please choose : ");
                                                        for(int i=1; i<selMed.Length; i+=5)
                                                        {
                                                            Console.Write($"{selMed[i].Split(' ')[2]} ");
                                                            selectMesia.Add(selMed[i].Split(' ')[2]);
                                                            selectPrice.Add(int.Parse(selMed[i+1].Split(' ')[2]));
                                                        }
                                                        Console.WriteLine();
                                                        selectMed = Console.ReadLine();
                                                        for(int j=0; j<selectMesia.Count; j++)
                                                        {
                                                            if(selectMesia[j] == selectMed)
                                                            {
                                                                if(cap1<=20)
                                                                {
                                                                    selected1.Add(selectMed);
                                                                    selectedP1.Add(selectPrice[j]);
                                                                    cap1++;
                                                                    U1 = true;
                                                                }
                                                                break;
                                                            }
                                                        }
                                                        if(U1 == false)
                                                        {
                                                            Console.WriteLine("The desired product does not exist !");
                                                        }
                                                    }
                                                    catch(Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }  
                                                }
                                                else if (user == UserMenu.Edit)
                                                {
                                                    bool e1 = false;
                                                    Console.WriteLine("Your list is :");
                                                    for(int i=0; i<selected1.Count; i++)
                                                    {
                                                        Console.WriteLine($"{selected1[i]} , {selectedP1[i]}");
                                                    }
                                                    while(true)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please choose : Remove an item \nExit");
                                                            edit = (Edit)Enum.Parse(typeof(Edit), Console.ReadLine(), true);
                                                            if(edit==Edit.Remove)
                                                            {
                                                                Console.WriteLine("Enter name : ");
                                                                editation = Console.ReadLine();
                                                                for(int i=0; i<selected1.Count; i++)
                                                                {
                                                                    if(selected1[i]==editation)
                                                                    {
                                                                        selected1.Remove(selected1[i]);
                                                                        selectedP1.Remove(selectedP1[i]);
                                                                        Console.WriteLine("Removed !");
                                                                        cap1--;
                                                                        e1 = true;
                                                                        break;
                                                                    }
                                                                }
                                                                if (e1 == false)
                                                                {
                                                                    Console.WriteLine("The desired product does not exist !"); 
                                                                }
                                                            }
                                                            if(edit == Edit.Exit)
                                                            {
                                                                break;
                                                            }
                                                            break;
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Invalid input !");
                                                        }
                                                    }
                                                }
                                                else if (user == UserMenu.Buy)
                                                {
                                                    for(int i=0; i<selectedP1.Count; i++)
                                                    {
                                                        tota1 += selectedP1[i];
                                                    }
                                                    Console.WriteLine($"Total : {student.Discount(tota1)}");
                                                    while(true)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please choose : \nOK \nCancel");
                                                            buyl = (Buy)Enum.Parse(typeof(Buy), Console.ReadLine(), true);
                                                            if (buyl == Buy.Ok)
                                                            {
                                                                Console.WriteLine("Thank you for shoping :)");
                                                                for(int i=0; i<selected1.Count; i++)
                                                                {
                                                                    selected1.Remove(selected1[i]);
                                                                    selectedP1.Remove(selectedP1[i]);
                                                                    cap1=0;
                                                                    tota1 = 0;
                                                                }
                                                            }
                                                            if (buyl == Buy.Cancel)
                                                            {
                                                                Console.WriteLine("Ok");
                                                            }
                                                            break;
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Invalid input !");
                                                        }
                                                    }
                                                }
                                                else if (user == UserMenu.Chance)
                                                {
                                                    random = new Random();
                                                    rnddis = random.Next(0, 9);
                                                    tota1 = tota1 - ((tota1 * randomDiscount[rnddis]) / 100);
                                                    Console.WriteLine($"Your discount is : {randomDiscount[rnddis]} \nTotal with discount : {tota1}");
                                                }
                                                else if (user == UserMenu.Exit)
                                                {
                                                    break;
                                                }
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Invalid input !");
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    } 
                                }
                                else if (usersType == UsersType.Teacher)
                                {
                                    Console.WriteLine("Enter your name : ");
                                    name = Console.ReadLine();
                                    Console.WriteLine("Enter your institution : ");
                                    institution = Console.ReadLine();
                                    Teacher teacher = new Teacher(name, institution);
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.WriteLine("Please choose : \nSelect \nEdit \nBuy \nChance \nExit ");
                                            user = (UserMenu)Enum.Parse(typeof(UserMenu), Console.ReadLine(), true);
                                            if (user == UserMenu.Select)
                                            {
                                                bool U2 = false;
                                                try
                                                {
                                                    var selMed = File.ReadAllLines("Info.txt");
                                                    Console.WriteLine("Please choose : ");
                                                    for (int i = 1; i < selMed.Length; i += 5)
                                                    {
                                                        Console.Write($"{selMed[i].Split(' ')[2]} ");
                                                        selectMesia.Add(selMed[i].Split(' ')[2]);
                                                        selectPrice.Add(int.Parse(selMed[i + 1].Split(' ')[2]));
                                                    }
                                                    Console.WriteLine();
                                                    selectMed = Console.ReadLine();
                                                    for (int j = 0; j < selectMesia.Count; j++)
                                                    {
                                                        if (selectMesia[j] == selectMed)
                                                        {
                                                            if (cap2 <= 20)
                                                            {
                                                                selected2.Add(selectMed);
                                                                selectedP2.Add(selectPrice[j]);
                                                                cap2++;
                                                                U2 = true;
                                                            }
                                                            break;
                                                        }
                                                    }
                                                    if (U2 == false)
                                                    {
                                                        Console.WriteLine("The desired product does not exist !");
                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }
                                            }
                                            else if (user == UserMenu.Edit)
                                            {
                                                bool e2 = false;
                                                Console.WriteLine("Your list is :");
                                                for (int i = 0; i < selected1.Count; i++)
                                                {
                                                    Console.WriteLine($"{selected2[i]} , {selectedP2[i]}");
                                                }
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Please choose : Remove an item \nExit");
                                                        edit = (Edit)Enum.Parse(typeof(Edit), Console.ReadLine(), true);
                                                        if (edit == Edit.Remove)
                                                        {
                                                            Console.WriteLine("Enter name : ");
                                                            editation = Console.ReadLine();
                                                            for (int i = 0; i < selected2.Count; i++)
                                                            {
                                                                if (selected2[i] == editation)
                                                                {
                                                                    selected2.Remove(selected2[i]);
                                                                    selectedP2.Remove(selectedP2[i]);
                                                                    Console.WriteLine("Removed !");
                                                                    cap2--;
                                                                    e2 = true;
                                                                    break;
                                                                }
                                                            }
                                                            if (e2 == false)
                                                            {
                                                                Console.WriteLine("The desired product does not exist !");
                                                            }
                                                        }
                                                        if (edit == Edit.Exit)
                                                        {
                                                            break;
                                                        }
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Invalid input !");
                                                    }
                                                }
                                            }
                                            else if (user == UserMenu.Buy)
                                            {
                                                for (int i = 0; i < selectedP2.Count; i++)
                                                {
                                                    total2 += selectedP2[i];
                                                }
                                                if(selectedP2.Count >= 3)
                                                {
                                                    Console.WriteLine($"Total : {teacher.Discount(total2)}");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Total : {total2}");
                                                }
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Please choose : \nOK \nCancel");
                                                        buyl = (Buy)Enum.Parse(typeof(Buy), Console.ReadLine(), true);
                                                        if (buyl == Buy.Ok)
                                                        {
                                                            Console.WriteLine("Thank you for shoping :)");
                                                            for (int i = 0; i < selected2.Count; i++)
                                                            {
                                                                selected2.Remove(selected2[i]);
                                                                selectedP2.Remove(selectedP2[i]);
                                                                cap2 = 0;
                                                                total2 = 0;
                                                            }
                                                        }
                                                        if (buyl == Buy.Cancel)
                                                        {
                                                            Console.WriteLine("Ok");
                                                        }
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Invalid input !");
                                                    }
                                                }
                                            }
                                            else if (user == UserMenu.Chance)
                                            {
                                                random = new Random();
                                                rnddis = random.Next(0, 9);
                                                total2 = total2 - ((total2 * randomDiscount[rnddis]) / 100);
                                                Console.WriteLine($"Your discount is : {randomDiscount[rnddis]} \nTotal with discount : {total2}");
                                            }
                                            else if (user == UserMenu.Exit)
                                            {
                                                break;
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Invalid input !");
                                        }
                                    }
                                }
                                else if (usersType == UsersType.Normal)
                                {
                                    try
                                    {
                                        Console.WriteLine("Enter your name : ");
                                        name = Console.ReadLine();
                                        Console.WriteLine("Enter your ID : ");
                                        ID = Console.ReadLine();
                                        Customer customer = new Customer(name, ID);
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Please choose : \nSelect \nEdit \nBuy \nChance \nExit ");
                                                user = (UserMenu)Enum.Parse(typeof(UserMenu), Console.ReadLine(), true);
                                                if (user == UserMenu.Select)
                                                {
                                                    bool U3 = false;
                                                    try
                                                    {
                                                        var selMed = File.ReadAllLines("Info.txt");
                                                        Console.WriteLine("Please choose : ");
                                                        for (int i = 1; i < selMed.Length; i += 5)
                                                        {
                                                            Console.Write($"{selMed[i].Split(' ')[2]} ");
                                                            selectMesia.Add(selMed[i].Split(' ')[2]);
                                                            selectPrice.Add(int.Parse(selMed[i + 1].Split(' ')[2]));
                                                        }
                                                        Console.WriteLine();
                                                        selectMed = Console.ReadLine();
                                                        for (int j = 0; j < selectMesia.Count; j++)
                                                        {
                                                            if (selectMesia[j] == selectMed)
                                                            {
                                                                if (cap3 <= 20)
                                                                {
                                                                    selected3.Add(selectMed);
                                                                    selectedP3.Add(selectPrice[j]);
                                                                    cap3++;
                                                                    U3 = true;
                                                                }
                                                                break;
                                                            }
                                                        }
                                                        if (U3 == false)
                                                        {
                                                            Console.WriteLine("The desired product does not exist !");
                                                        }
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }
                                                }
                                                else if (user == UserMenu.Edit)
                                                {
                                                    bool e3 = false;
                                                    Console.WriteLine("Your list is :");
                                                    for (int i = 0; i < selected3.Count; i++)
                                                    {
                                                        Console.WriteLine($"{selected3[i]} , {selectedP3[i]}");
                                                    }
                                                    while (true)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please choose : Remove an item \nExit");
                                                            edit = (Edit)Enum.Parse(typeof(Edit), Console.ReadLine(), true);
                                                            if (edit == Edit.Remove)
                                                            {
                                                                Console.WriteLine("Enter name : ");
                                                                editation = Console.ReadLine();
                                                                for (int i = 0; i < selected3.Count; i++)
                                                                {
                                                                    if (selected3[i] == editation)
                                                                    {
                                                                        selected3.Remove(selected3[i]);
                                                                        selectedP3.Remove(selectedP3[i]);
                                                                        Console.WriteLine("Removed !");
                                                                        cap3--;
                                                                        e3 = true;
                                                                        break;
                                                                    }
                                                                }
                                                                if (e3 == false)
                                                                {
                                                                    Console.WriteLine("The desired product does not exist !");
                                                                }
                                                            }
                                                            if (edit == Edit.Exit)
                                                            {
                                                                break;
                                                            }
                                                            break;
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Invalid input !");
                                                        }
                                                    }
                                                }
                                                else if (user == UserMenu.Buy)
                                                {
                                                    for (int i = 0; i < selectedP3.Count; i++)
                                                    {
                                                        total3 += selectedP3[i];
                                                    }
                                                    if (selectedP3.Count >= 5)
                                                    {
                                                        Console.WriteLine($"Total : {customer.Discount(total3)}");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Total : {total3}");
                                                    }
                                                    while (true)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please choose : \nOK \nCancel");
                                                            buyl = (Buy)Enum.Parse(typeof(Buy), Console.ReadLine(), true);
                                                            if (buyl == Buy.Ok)
                                                            {
                                                                Console.WriteLine("Thank you for shoping :)");
                                                                for (int i = 0; i < selected3.Count; i++)
                                                                {
                                                                    selected3.Remove(selected3[i]);
                                                                    selectedP3.Remove(selectedP3[i]);
                                                                    cap3 = 0;
                                                                    total3 = 0;
                                                                }
                                                            }
                                                            if (buyl == Buy.Cancel)
                                                            {
                                                                Console.WriteLine("Ok");
                                                            }
                                                            break;
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Invalid input !");
                                                        }
                                                    }
                                                }
                                                else if (user == UserMenu.Chance)
                                                {
                                                    random = new Random();
                                                    rnddis = random.Next(0, 9);
                                                    total3 = total3 - ((total3 * randomDiscount[rnddis]) / 100);
                                                    Console.WriteLine($"Your discount is : {randomDiscount[rnddis]} \nTotal with discount : {total3}");
                                                }
                                                else if (user == UserMenu.Exit)
                                                {
                                                    break;
                                                }
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Invalid input !");
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    
                                }   
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("You are only allowed to access the user or admin section !");
                }
            }
        }
    }
}

