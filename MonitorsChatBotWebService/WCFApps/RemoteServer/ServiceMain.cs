using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteLib;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

using System.Runtime.Remoting.Channels.Tcp;

// We add the reference System.Runtime.Remotimg DLL to get the namespoaces and classes required for .NET Remoting applications.....

//Add the reference of the RemoteLib that was created earlier.The instances of the messenger will be created in the server application.....
namespace RemoteServer
{
    //.NET Remoting allows services accessible through two protocols:TCP and HTTP.
    //TCP Channelis used for Intranet kind of Apps. HTTP is ised for internet Apps.
    //Every service based application needs the following things:
    // An address to access the service
    //Protocol whic contains the info on how service is available
    // A portNo. through which service is accessible.
    class ServiceMain
    {
        static void Main(string[] args)
        {
            //U should create a TCP server object and register the Tcp channel to Windows service
            TcpServerChannel server = new TcpServerChannel(1234);
            //Register the service into the Windows OS...
            ChannelServices.RegisterChannel(server, false);
            //Expose the service to client(Run the Application)
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Messenger), "MsgServices", WellKnownObjectMode.Singleton);


            Console.WriteLine("Server is ready at http://local:1234/MsgServices");
            Console.WriteLine("Press any key to terminate");



            Console.ReadKey();

        }
    }
}
