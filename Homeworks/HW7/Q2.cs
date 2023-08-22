using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin7_2
{
    interface IPersonality
    {
        string name { get; set; }
        int score { get; set; }
        string Personality();
    }
    class Bear : IPersonality
    {
        public string name { get; set; } = "Pooh";
        public int score { get; set; } = 5;
        public Bear(string name , int score)
        {
            this.name = name;
            this.score = score;
        }
        public string Personality()
        {
            string res;
            res = $"{name} is yellow bear. \nHe loves honey. \nHis name’s rate is {score}";
            return res;
        }
    }
    class Pig : IPersonality
    {
        public string name { get; set; } = "Piglet";
        public int score { get; set; } = 4;
        public Pig(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public string Personality()
        {
            string res;
            res = $"{name} is pink pig. \nHe is a little cowardly \nHis name’s rate is {score}";
            return res;
        }
    }
    class Tiger : IPersonality
    {
        public string name { get; set; } = "Tiger";
        public int score { get; set; } = 3;
        public Tiger(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public string Personality()
        {
            string res;
            res = $"{name} is a naughty Tiger. \nHe is always smiling. \nHis name’s rate is {score}";
            return res;
        }
    }
    class Kangaroo : IPersonality
    {
        public string name { get; set; } = "Roo";
        public int score { get; set; } = 2;
        public Kangaroo(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public string Personality()
        {
            string res;
            res = $"{name} is a naughty kangaroo kid. \nHe is Tiger's friend. \nHis name’s rate is {score}";
            return res;
        }
    }
    class Donkey : IPersonality
    {
        public string name { get; set; } = "Eeyore";
        public int score { get; set; } = 1;
        public Donkey(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public string Personality()
        {
            string res;
            res = $"{name} is a tired donkey. \nHe always grumbles. \nHis name’s rate is {score}";
            return res;
        }
    }
    class Friends<T> where T : IPersonality
    {
        T name;
        public Friends(T name)
        {
            this.name = name;
        }
        public string Print()
        {
            return name.Personality();
        }
        public static implicit operator Friends<T>(T name)
        {
            return name == null ? null : new Friends<T>(name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Friends<Bear> bear = new Bear("Pooh", 5);
            Friends<Pig> piglet = new Pig("Piglet", 4);
            Friends<Tiger> tiger = new Tiger("Tiger", 3);
            Friends<Kangaroo> roo = new Kangaroo("Roo", 2);
            Friends<Donkey> eeyore = new Donkey("Eryore", 1);
            Console.WriteLine(bear.Print());
            Console.WriteLine(piglet.Print());
            Console.WriteLine(tiger.Print());
            Console.WriteLine(roo.Print());
            Console.WriteLine(eeyore.Print());
        }
    }
}
