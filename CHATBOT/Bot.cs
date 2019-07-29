using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILayer
{
    public class Bot
    {
        private static string botName = "Bot";

        public static string Prompt(string ques)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(botName + " : " + ques + "\n");
            Console.ResetColor();
            string reply = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You : " + reply + "\n");
            return reply.ToLower();
        }

        public static string Prompt(string ques, string param)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(botName + " : " + ques + "\n", param);
            Console.ResetColor();
            string reply = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You : " + reply + "\n");
            return reply.ToLower();
        }

        public static void PrintLine(string ques)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(botName + " : " + ques + "\n");
        }

        public static void PrintLine(string ques, string param)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(botName + " : " + ques + "\n", param);
        }

        public static void PrintData(string data)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(data + "\n");
        }

        public static void PrintData(string data, string param)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(data + "\n", param);
        }

    }
}
