using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1_2
{
    //Question 2 :
        //1 ) Func , because ie has return type (it can't be Action (it's not void)) .
        //2 ) Action , because it's 'void' .
        //3 ) No we can't , because its return type is void but we can write it in this form : 
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> factorial = n =>
            {
                int result = 1;
                for(int i=n; i>0; i--)
                {
                    result = result * i;
                }
                Console.WriteLine($"this {result}");
            };
            factorial(4);
        }
    }
}
