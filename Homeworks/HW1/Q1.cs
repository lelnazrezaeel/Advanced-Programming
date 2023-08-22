using System;

namespace Prime_factors
{
    class Program
    {
    	static int prime(int a)
    	{
    		int i;
    		int c=0;
    		for(i=2 ; i<=Math.Sqrt(a) ; i++)
    		{
    			if(a%i==0)
    			{
    				c++;
    			}
    		}
    		if(c==0)
    		{
    			return 1;
    		}
    		else
    		{
    			return 0;
    		}
    	}
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int  i , cnt = 0 , j ;
            if(prime(a)==1)
            {
            	Console.WriteLine(a);
            }
            else
            {
            	for (i=2 ; i<=a/2 ; i++)
                {
                    if( a%i ==0)
                    {
                        if(prime(i)==1)
                        {
                        	Console.Write("{0} ",i);
                        }
                    }
                }
            }
        }
    }
}
