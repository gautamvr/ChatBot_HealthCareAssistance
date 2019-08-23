using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace BusinessLayer
{
    using DataLayer;
    public class Logic
    {
        static DAL da = new DAL();
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
                if (newStr != "" && sent.Contains(newStr))
                {
                    return newStr;
                }
            }
            return sent;
        }

        public static Dictionary<int,string> AssignDict(string spec)
        {
            Dictionary<int, string> specs=new Dictionary<int, string>();
            string specArray = da.Execute("Select Distinct " + spec + " from Monitors");
            string[] distinctSpec = specArray.Split('\n');
            for (int i = 0; i < distinctSpec.Length; i++)
            {
                specs.Add(i + 1, distinctSpec[i].TrimEnd());
            }
            return specs;
        }
        
        public static string ParseDictToString(Dictionary<int,string> dict)
        {
            int totalVal = dict.Count;
            dict.Add(totalVal + 1, "Anything");
            string str = string.Join("\n", dict.Select(x => x.Key + "  --->  " + x.Value.TrimEnd()).ToArray());
            return str;
        }

        public static string GetAllSpec(string spec)
        {
            Dictionary<int, string> spec1dict=AssignDict(spec);
            string str=ParseDictToString(spec1dict);
            return str;
        }

        public static string ReturnSpec(int sno,string spec)
        {
            Dictionary<int, string> specdict = AssignDict(spec);

            return specdict[sno];

        }

    }
    
}