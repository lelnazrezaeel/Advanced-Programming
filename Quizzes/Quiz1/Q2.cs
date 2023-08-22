using System;
class Program
{
    static void Main() 
    {
        String a =Console.ReadLine();
        String[] b = new string [500];
        b=a.Split(' ');
        String k , v ;
        k=Console.ReadLine();
        v=Console.ReadLine();
        for(int i=0;i<=b.Lenght ; i++)
        {
        	if(b[i].Equals(k))
        	{
        		b[i].Insert(b[i].Length, "v")
        	    b[i].Remove(0,b[i].Length);
        	}
        }
        for(int i=b.Length ; i>=0 ; i--)
        {
        	Console.WriteLine("b[i]&");
        }
    }
    
}