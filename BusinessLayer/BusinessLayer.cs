using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace BusinessLayer
{
    
    public class Logic
    {
        public static string ReturnList(List<string> list)
        {
            string str = null;
            foreach (string listItem in list)
            {
                str = str + listItem + "\n";
            }
            return str;
        }
        public static HashSet<string> ParseToHashSet(string data)
        {
            HashSet<string> hashBase = new HashSet<string>();
            string[] strBase = data.Split('\n');
            foreach (var i in strBase)
            {
                hashBase.Add(i);
            }
            return hashBase;
        }

        public static string ExtractKeyword(string data, string sent)
        {
            sent = sent.ToLower();
            data = data.ToLower();
            string[] strBase = data.Split('\n');
            
            foreach (string str in strBase)
            {
                string newStr = str.TrimEnd();
                if (newStr != "")
                {
                    if (sent.Contains(newStr))
                    {
                        return newStr;
                    }
                }
            }
            return sent;
        }

    }
    
}