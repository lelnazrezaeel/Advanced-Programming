using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_1
{
    class Conference
    {
        string cname, hname;
        int cap;
        Participant[] prt;
        public Conference(string cname , string hname , int cap)
        {
            this.cname = cname;
            this.hname = hname;
            this.cap = cap;
        }
        public Conference(string cname, string hname, int cap , params Participant[] prt)
        {
            this.cname = cname;
            this.hname = hname;
            this.cap = cap;
            this.prt = prt;
        }
        public void AddParticipant(params Participant[] prtc)
        {
            int i;
            for(i=0; i< prtc.Length; i++)
            {
                if(prtc.Length>cap)
                {
                    Console.WriteLine("The hall is full !");
                }
                else
                {
                    prt[prtc.Length] = new Participant(prtc[prtc.Length].name, prtc[prtc.Length].lname, prtc[prtc.Length].ID);
                }
            }
        }
    }
    class Participant
    {
        public string name , lname;
        public int cost, ID;
        static int count;
        public Participant(int ID)
        {
            this.ID = ID;
            count++;
        }
        public Participant(string name , string lname , int ID )
        {
            this.name = name;
            this.lname = lname;
            this.ID = ID;
            count++;
        }
        public static int CalculatePrice()
        {
            int i = 900;
            return i + 100;
        }
        public static int CountParticipant(params Participant[] prt)
        {
            return count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
