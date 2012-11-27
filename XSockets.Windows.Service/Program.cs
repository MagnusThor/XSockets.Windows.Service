using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace XSockets.Windows.Service
{
    static class Program
    {
       
        static void Main()
        {
            ServiceBase[] ServicesToRun = new ServiceBase[] 
                { 
                    new Container() 
                };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
