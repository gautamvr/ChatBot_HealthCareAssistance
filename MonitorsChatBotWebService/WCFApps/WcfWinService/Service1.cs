using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
/*
 * Windows service is a kind of App that is strated at the boot up of the windows os.
 * It is provided with an installer through which a windows component called SCM(Service control Manager) creates, registers and consumes our WCF service
 * Every Service App will have a Main function that registers the service to the windows OS.The program.cs contain the code that is required to register the service and run it.
 * When the service runs, events like OnStart gets executed and when it stps,events like OnStop will be executed.Other than theseU could have events like Run to ensure what needs to be done while the service is executing.
 * Windows services are designed to work on Windows OS only.
 * Steps:Create the WCF component along with it's interfaces.
 * Overriding the OnStart method to create WCF service
 * And On Stop code will stop the service.
 * 
 */

namespace WcfWinService
{
    public partial class MySampleWindowsService : ServiceBase
    {
        private ServiceHost host = null;
        public MySampleWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:2222/MathServices");
            host = new ServiceHost(typeof(MathComponent), baseAddress);
            var contract = typeof(IMathService);
            host.AddServiceEndpoint(contract, new WSHttpBinding(), "");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            host.Open();
        }

        protected override void OnStop()
        {
        }
    }
}
