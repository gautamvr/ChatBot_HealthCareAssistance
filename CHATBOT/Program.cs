using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Data.Common;
using System.Configuration;


namespace UILayer
{
    using DataLayer;

    class Program
    {
        public static void Main(string[] args)
        {
            string cpu = "CPU:";
            string you = "YOU:";
            Console.WriteLine(cpu + "Hi, you are talking to Philips Helpline" + "\n");
            string t = Console.ReadLine();
            Console.WriteLine(you + t);
            Console.WriteLine("Do you want information about purchasing monitor or solutions?\n");
            t = Console.ReadLine();
            Console.WriteLine("YOU:{0}\n",t);
            if (t.Contains("monitor")|| t.Contains("monitors"))
            {
            
               AccessDataBase.SetupConnection();
               Console.WriteLine("CPU: Select the Category you want to purchase?");//***************************
               String s=Console.ReadLine();
               AccessDataBase.GetModels(s);
                Console.ReadLine();


            }

            if (t.Contains("solution")|| t.Contains("solutions"))
            {
         
                Console.WriteLine("Solution information to be given from database");
                Console.ReadLine();
            }


        }
    }
}
