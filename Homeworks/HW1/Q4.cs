using System;
class Program
{
    static void Main() 
    {
        int n=int.Parse(Console.ReadLine());
        string b=Console.ReadLine();
        string[] a=new string[2];
        a=Console.ReadLine().Split(' ');
        int s=int.Parse(a[0]);
        int t=int.Parse(a[1]);
        int k=0;
        int f=0;
        int[] c=new int[30];
        for(int i=0;i<30 ; i++)
        {
        	c[i]=1;
        }
        if(t>s)
        {
        	for(int i=s ; i<t-1 ;i++)
        	{
        		if(b[i]=='H' && b[i+1]=='H')
        		{
        			c[k]++;
        		}
        		if(b[i]=='H' && b[i-1]!='H')
        		{
        			f++;
        		}
        		if(b[i]=='H' && b[i+1]!='H')
        		{
        			k++;
        		}
        	}
        }
        if(s>t)
        {
        	for(int i=t ; i<s-1 ;i++)
        	{
        		if(b[i]=='H' && b[i+1]=='H')
        		{
        			c[k]++;
        		}
        		if(b[i]=='H' && b[i-1]!='H')
        		{
        			f++;
        		}
        		if(b[i]=='H' && b[i+1]!='H')
        		{
        			k++;
        		}
        	}
        }
        int d=0;
        for(int i=0 ; i<c.Length ; i++)
        {
        	while(c[i]/2!=0)
        	{
        		d=d+(c[i]%2);
        		c[i]=c[i]/2;
        	}
        }
        Console.WriteLine(d+f);
    }
    
}