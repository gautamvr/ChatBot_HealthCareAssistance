using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Data.Common;
using System.Configuration;
using BusinessLayer;


namespace UILayer
{
    using DataLayer;

    class UILayer
    {
        public static void Main(string[] args)
        {
            string cpu = "CPU: ";
            string you = "YOU: ";
            Console.WriteLine(cpu + "Hi, you are talking to Philips Helpline");
            string t = Console.ReadLine();
            Console.WriteLine(you + t);
            Console.WriteLine(cpu + "Do you want information about purchasing monitor or solutions?");
            t = Console.ReadLine().ToLower();
            Console.WriteLine(you+"{0}",t);
            if (t.Contains("monitor"))
            {
                Console.WriteLine(cpu+"Categories and Series Names are mentioned below:\n");
                Console.WriteLine(BusinessLogic.GetSerialName());
                Console.WriteLine(cpu+" Select the Category you want to purchase?");
                string s=Console.ReadLine().ToLower();
                Console.WriteLine(you + "{0}", s);
                Console.WriteLine(cpu + "Model Numbers are mentioned below:\n");
                Console.WriteLine(BusinessLogic.GetModels(s));
                Console.ReadLine();
            }

            else if (t.Contains("solution"))
            {
         
                Console.WriteLine("Solution information to be given from database");
                Console.ReadLine();
            }


        }
    }
}
