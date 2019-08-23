using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLib
{
    public class Messenger:MarshalByRefObject

    {
        public Messenger()
        {
            Console.WriteLine("Messenger service has now started");
        }

        public void PostMessage(string User, string message)
        {
            Console.WriteLine($"{User}:{message}");
        }
    }
}
