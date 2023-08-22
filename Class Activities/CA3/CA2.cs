using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faaliat3
{
    class Student
    {
        private int num;
        private string[] info = new string[2];
        public Student(string[] s, int n)
        {
            info = s;
            num = n;
        }
        public Student Clone()
        {
            string[] copy = new string[info.Length];
            for (int i = 0; i < info.Length; i++)
            {
                copy[i] = info[i];
            }
            return (new Student(copy, num));
        }
        public Student badClone()
        {
            Student s = this;
            return s ;
        }
        public string stdInfo()
        {
            return info[0] + " " + info[1] + " " + num ;
        }
        public void changeinfo(char c, int n)
        {
            info[0] = c + info[0].Substring(1);
            num += n;
        }
    }
    class Program
    {
        static void studentinfo(params Student[] std)
        {
            foreach (var i in std)
            {
                Console.WriteLine(i.stdInfo());
            }
        }
        static void Main(string[] args)
        {
            string[] std1 = Console.ReadLine().Split(' ');
            string[] inof1 =new string[2] { std1[0], std1[1] };
            int num1 = int.Parse(std1[2]);

            string[] std2 = Console.ReadLine().Split(' ');
            string[] inof2 = new string[2] { std2[0], std2[1] };
            int num2 = int.Parse(std2[2]);

            string[] std3 = Console.ReadLine().Split(' ');
            string[] inof3 = new string[2] { std3[0], std3[1] };
            int num3 = int.Parse(std3[2]);

            Student s1, s2, s3;
            s1 = new Student(inof1, num1);
            s2 = new Student(inof2, num2);
            s3 = new Student(inof3, num3);
            studentinfo(s1, s2, s3);

            Student s4 = s1.Clone();
            s1.changeinfo('A', 3);
            studentinfo(s1, s4);

            Student s5 = s2.badClone();
            s2.changeinfo('B', 2);
            studentinfo(s2, s5);
        }
    }
}
