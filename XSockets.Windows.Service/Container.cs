using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace XSockets.Windows.Service
{
    public partial class Container : ServiceBase
    {
        public Container()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            new XSockets.Windows.Service.Host.Instance();
        }

        protected override void OnStop()
        {
        }
    }
}
