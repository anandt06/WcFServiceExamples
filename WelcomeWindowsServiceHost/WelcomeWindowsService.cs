using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeWindowsServiceHost
{
    public partial class WelcomeWindowsService : ServiceBase
    {
        ServiceHost serviceHost;
        public WelcomeWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            serviceHost = new ServiceHost(typeof(WelcomeService.WelcomeService));
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if(serviceHost!=null)
            serviceHost.Close();
        }
    }
}
