using System;
class Program
{
    static void Main() 
    {
        String[] a =new string[1000];
        String b=Console.ReadLine();
        String c="";
        a=b.Split(' ');
        int i,j;
        for(i=0 ; i<=a.Lenght ; i++)
        {
        	for(j=0 ; j<=a.Length ; j++)
        	{
        		if(string.CompareOrdinal(a[i],a[j])>0)
        		{
        			c=a[j];
        			a[j]=a[i];
        			a[i]=c;
        		}
        	}
        }
        for(i=0;i<=a.Lenght ; i++)
        {
        	Console.Write(" {0}" ,a[i] );
        }
    }
    
}