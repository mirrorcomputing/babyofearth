using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace Wiseserver
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new KingService() 
            };
            ServiceBase.Run(ServicesToRun);

            //KingService king = new KingService();
            //king.connectuniverse();
            //king.loadsave();
            //king.portlisten();
        }
    }
}
