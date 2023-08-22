using System;
class Program
{
	static void MaxNum(int[] arr)
    {
    	int max=-10000000;
        for(int i=0;i<arr.Length;i++)
        {
        	if(arr[i]>max)
        	{
        		max=arr[i];
        	}
        }
        Console.WriteLine(max);
    }
    static void Main() 
    {
        int n;
        n=int.Parse(Console.ReadLine());
        int[] arr=new int[n];
        for(int i=0 ; i<n ; i++)
        {
        	arr[i]=int.Parse(Console.ReadLine());
        }
        MaxNum(arr);
    }
}