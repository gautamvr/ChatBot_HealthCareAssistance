using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteLib;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemoteClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            Messenger proxy = Activator.GetObject(typeof(Messenger), "tcp://161.85.92.139:1234/MsgServices") as Messenger;
            if (proxy == null)
            {
                Console.WriteLine("Failed to create the service");
                return;
            }

            Console.WriteLine("Please enter the user name");
            string user = Console.ReadLine();
            do
            {
                Console.WriteLine("Pst UR message here");
                string msg = Console.ReadLine();
                proxy.PostMessage(user, msg);

            }
            while (true);
        }
    }
}
