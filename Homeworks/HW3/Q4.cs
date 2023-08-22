using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tamein3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int i , cstar=0 , cnum=0 , cvowel=0 , cline=0;
            string line="" , a1 , a2 ;
            Console.WriteLine("Enter the first file name");
            a1 = Console.ReadLine()+".txt";
            StreamWriter  writer;
            StreamReader reader;
            try
            {
                reader = new StreamReader(a1);
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("That file does not exist\nEnter a valid name for first file");
                a1 = Console.ReadLine()+ ".txt" ;
                reader = new StreamReader(a1);
            }
            Console.WriteLine("Enter the second file name");
            a2 = Console.ReadLine()+ ".txt";
            try
            {
                writer = new StreamWriter(a2);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Enter a valid name for file");
                a2 = Console.ReadLine() + ".txt";
                writer = new StreamWriter(a2);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                cline++;
                for (i = 0; i < line.Length; i++)
                {
                    if (line[i] == ' ')
                    {
                        writer.Write("*");
                        cstar++;
                    }
                    else if (line[i] == '0' || line[i] == '1' || line[i] == '2' || line[i] == '3' ||
                    line[i] == '4' || line[i] == '5' || line[i] == '6' || line[i] == '7' || line[i] == '8'
                    || line[i] == '9')
                    {
                        writer.Write(line[i]);
                        cnum++;
                    }
                    else if (line[i] == 'e' || line[i] == 'i' || line[i] == 'o' || line[i] == 'u' || line[i] == 'a'
                    || line[i] == 'E' || line[i] == 'I' || line[i] == 'O' || line[i] == 'U' || line[i] == 'A')
                    {
                        writer.Write(line[i]);
                        cvowel++;
                    }
                    else
                    {
                        writer.Write(line[i]);
                    }
                }
                writer.Write("\n");
            }
            reader.Close();
            writer.Close();
            Console.WriteLine("Stars : {0} ", cstar);
            Console.WriteLine("Numbers : {0} ", cnum);
            Console.WriteLine("Vowels : {0} ", cvowel);
            Console.WriteLine("Lines : {0} ", cline);
        }
    }
}
