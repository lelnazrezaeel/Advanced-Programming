using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin4_2
{
    class Product
    {
        List<Product> products = new List<Product>();
        public int ID {get;set;}
        int k = 0;
        public string name { get; set; }
        public int price
        {
            get
            {
                return price;
            }
            set
            {
                price=CheckNeg(value);
            }
        }
        public int CheckNeg(int a)
        {
            if(a<0)
            {
                throw new Exception();
            }
            return a;
        }
        int score { get { return score; } set { score=CheckNeg(value); } }

        string factory { get; }
        public Product(int ID , string name , int price , int score)
        {
            this.ID = ID;
            this.name = name;
            this.price = price;
            this.score = score;
            if(ID>0 && ID<5)
            {
                factory = "A";
            }
            else if(ID>=5 && ID<10 )
            {
                factory = "B";
            }
            else if(ID>=10)
            {
                factory = "C";
            }
            else
            {
                throw new Exception("Invalid ID");
            }
            products[k] = new Product(ID, name, price, score);
            k++;
        }
        public int CheckID(int id)
        {
            foreach(var product in products)
            {
                if(product.ID==id)
                {
                    throw new Exception("Duplicated ID");
                }
            }
            return id;
        }
    }
    enum PType { Phone = 1, car, watch, T_shirt, Laptop, Tablet, Charger, Glass, Robot };
    class Category
    {
        List<Product> products = new List<Product>();
        PType pName;
        int PID;
        
        public Category( int PID , PType pName )
        {
            this.PID = PID;
            this.pName = (PType)PID;
        }
        public void AddProductCategory(params Product[] productss)
        {
            foreach(var product in productss)
            {
                products.Add(product);
            }
        }
        public void FilterByPrice(int min , int max)
        {
            for(int i=0; i<products.Count; i++)
            {
                if(products[i].price > min && products[i].price < max)
                {
                    Console.WriteLine($"{products[i]}");
                }
            }
        }
        public void ShowSupply()
        {
            int i, j , temp;
            for(i=0; i<products.Count; i++)
            {
                for(j=0; j<products.Count - 1; j++)
                {
                    if(products[j].price>products[j+1].price)
                    {
                        temp = products[j].price;
                        products[j].price = products[j + 1].price;
                        products[j + 1].price = temp;
                    }
                }
            }
            for(i=0; i<products.Count; i++)
            {
                Console.Write($"{products[i]}");
            }
            Console.WriteLine();
        }
    }
    struct People
    {
        public string name, lname, phoneNumber;
        public int age;
        public People(string name, string lname, int age, string phoneNumber)
        {
            this.name = name;
            this.lname = lname;
            this.age = age;
            if (phoneNumber.Length != 11 || phoneNumber[0] != 0 || phoneNumber[1] != 9)
            {
                throw new Exception();
            }
            this.phoneNumber = phoneNumber;
        }
    }
    class Cart
    {
        People person;
        List<Product> basket = new List<Product>();
        public Cart(People person)
        {
            this.person = person;
        }
        public void AddProductToCart(params Product[] baskets)
        {
            foreach (var item in baskets)
            {
                basket.Add(item);
            }
        }
        public void CalculatePrice(People person1)
        {
            int i;
            int s = 0;
            Console.WriteLine($"Name : {person1.name}");
            Console.WriteLine($"Last name : {person1.lname}");
            Console.WriteLine($"Phone number : {person1.phoneNumber}");
            Console.WriteLine($"Your factor is : ");
            for(i=0; i<basket.Count; i++)
            {
                s += basket[i].price;
                Console.WriteLine($"name : {basket[i].name}      price : {basket[i].price}");
            }
            Console.WriteLine($"sum : {s}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input, catorder;
            int catnum;
            PType type;
            while(true)
            {
                try
                {
                    Console.WriteLine("Please choose \nCategory \nCart \nExit or Back");
                    input = Console.ReadLine().ToLower();
                    if (input=="category")
                    {
                        int ID , price , score ;
                        string name;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter your category name");
                                string s = Console.ReadLine();
                                if (!Enum.TryParse(s, out type))
                                {
                                    throw new Exception("The desired category does not exist");
                                }
                                type = (PType)Enum.Parse(typeof(PType), s);
                                int PID = (int)type;
                                Category category = new Category(PID, type);
                                Console.WriteLine("Please choose \nAddProductCategory \nFilterByPrice \nShowSupply \nExit or Back");
                                catorder = Console.ReadLine().ToLower();
                                if(catorder=="addproductcategory")
                                {
                                    Console.WriteLine("Enter the number of commodity");
                                    while(true)
                                    {
                                        try
                                        {
                                            catnum = int.Parse(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Enter an integer for items number");
                                        }
                                    }
                                    Product[] cataddorder = new Product[catnum];
                                    Console.WriteLine("Fill the commodity information : ");
                                    for(int i=0; i<catnum; i++)
                                    {
                                        Console.WriteLine("Enter the ID : ");
                                        while (true)
                                        {
                                            try
                                            {
                                                ID = int.Parse(Console.ReadLine());
                                                break;
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Enter an integer for ID");
                                            }
                                        }
                                        Console.WriteLine("Enter the name : ");
                                        name = Console.ReadLine();
                                        Console.WriteLine("Enter the price : ");
                                        while (true)
                                        {
                                            try
                                            {
                                                price = int.Parse(Console.ReadLine());
                                                break;
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Enter an integer for price : ");
                                            }
                                        }
                                        Console.WriteLine("Enter the score : ");
                                        while (true)
                                        {
                                            try
                                            {
                                                score = int.Parse(Console.ReadLine());
                                                break;
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Enter an integer for score : ");
                                            }
                                        }
                                        try
                                        {
                                            cataddorder[i] = new Product(ID, name, price, score);
                                        }
                                        catch(Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        
                                    }
                                    category.AddProductCategory(cataddorder);
                                    break;
                                }
                                else if(catorder=="filterbyprice")
                                {
                                    int min, max;
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.WriteLine("Please enter minimum price : ");
                                            min = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Please enter maximum Price : ");
                                            max = int.Parse(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Invalid input type .");
                                        }
                                    }
                                    Console.WriteLine($"Category name : {type} & Category ID : {PID}");
                                    category.FilterByPrice(min, max);
                                    break;
                                }
                                else if(catorder=="showsupply")
                                {
                                    Console.WriteLine($"Category name : {type} & Category ID : {PID}");
                                    category.ShowSupply();
                                    break;
                                }
                                else if(catorder=="exit" || catorder=="back")
                                {
                                    break;
                                }
                                else
                                {
                                    throw new Exception("Category does not have a command with this name");
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                    else if (input=="cart")
                    {
                        while(true)
                        {
                            string pname="", plname="", phoneNumber="";
                            int age=0;
                            Cart cart = null;
                            People p=new People();
                            try
                            {
                                try
                                {
                                    Console.WriteLine("Enter your name : ");
                                    pname = Console.ReadLine();
                                    Console.WriteLine("Enter your last name : ");
                                    plname = Console.ReadLine();
                                    Console.WriteLine("Enter your age : ");
                                    age = int.Parse(Console.ReadLine());
                                    if (age < 0)
                                    {
                                        throw new Exception("negative age !");
                                    }
                                    Console.WriteLine("Enter your phone number : ");
                                    phoneNumber = Console.ReadLine();
                                    try
                                    {
                                        p = new People(pname, plname, age, phoneNumber);
                                        cart = new Cart(p);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Invalid input");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid inputs");
                                }
                                Console.WriteLine("Please choose \nAddProductToCart \nCalculatePrice \nBack");
                                string cartorder = Console.ReadLine().ToLower();
                                if (cartorder == "addproducttocart")
                                {
                                    int cartnum, cID, cprice, cscore;
                                    string cname;
                                    Console.WriteLine("Enter the number of commodity");
                                    while (true)
                                    {
                                        try
                                        {
                                            cartnum = int.Parse(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Enter an integer for items number");
                                        }
                                    }
                                    Product[] cartaddorder = new Product[cartnum];
                                    Console.WriteLine("Fill the commodity information : ");
                                    for (int i = 0; i < cartnum; i++)
                                    {
                                        Console.WriteLine("Enter the ID : ");
                                        while (true)
                                        {
                                            try
                                            {
                                                cID = int.Parse(Console.ReadLine());
                                                break;
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Enter an integer for ID");
                                            }
                                        }
                                        Console.WriteLine("Enter the name : ");
                                        cname = Console.ReadLine();
                                        Console.WriteLine("Enter the price : ");
                                        while (true)
                                        {
                                            try
                                            {
                                                cprice = int.Parse(Console.ReadLine());
                                                break;
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Enter an integer for price : ");
                                            }
                                        }
                                        Console.WriteLine("Enter the score : ");
                                        while (true)
                                        {
                                            try
                                            {
                                                cscore = int.Parse(Console.ReadLine());
                                                break;
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Enter an integer for score : ");
                                            }
                                        }
                                        try
                                        {
                                            cartaddorder[i] = new Product(cID, cname, cprice, cscore);
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Invalid input");
                                        }
                                        
                                    }
                                    cart.AddProductToCart();
                                    break;
                                }
                                else if (cartorder == "calculateprice")
                                {
                                    Console.WriteLine($"Name : {pname}");
                                    Console.WriteLine($"Last name : {plname}");
                                    Console.WriteLine($"Age : {age}");
                                    Console.WriteLine($"Phone number : {phoneNumber}");
                                    cart.CalculatePrice(p);
                                }
                                else if (cartorder == "back" || cartorder=="exit")
                                {
                                    break;
                                }
                                else
                                {
                                    throw new Exception("Invalid input");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Invalid");
                            }             
                        }
                    }
                    else if (input=="exit" || input=="back")
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Undefined input");
                }
            }
        }
    }
}
