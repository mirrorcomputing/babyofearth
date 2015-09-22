using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
namespace Wiseserver
{
    public partial class KingService : ServiceBase
    {
        string root = @"D:\☾19##～T☽\";
        SpaceNameDictionary myspacenamelist=new SpaceNameDictionary();
        IPAddress universeip=IPAddress.Parse("114.215.149.121"),myip;
        
        public KingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            myip = IPAddress.Parse("114.215.150.85");

            loadsave();
            portlisten();
        }

        public void loadsave()
        {
            myspacenamelist = new SpaceNameDictionary();
            string[] files = System.IO.Directory.GetFiles(root, "*.❣");
            for (int i = 0; i < files.Length; i++)
            {
                string filetext = System.IO.File.ReadAllText(files[i]);
                string filename=new System.IO.FileInfo(files[i]).Name;
                string head = filename.Substring(0, filename.Length - 2);
                string body = filetext.Substring(filetext.IndexOf(head));
                SpaceName sn = new SpaceName(head, body);
                myspacenamelist.Add(sn);
            }
        }
        Thread listening;
        public void portlisten()
        {
            System.Net.Sockets.Socket udplistener= new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint local = new IPEndPoint(myip,213);
            udplistener.Bind(local);

            listening=new Thread(new ThreadStart(
                delegate()
                {
                    while (true)
                    {
                        IPEndPoint i = new IPEndPoint(IPAddress.Any,213);
                        EndPoint client = (EndPoint)i;
                        byte[] buffer = new byte[1024];
                        int rev = udplistener.ReceiveFrom(buffer, ref client);

                        string yousay = System.Text.Encoding.UTF8.GetString(buffer);
                        SpaceName your = isay(yousay);
                        SpaceName my=new SpaceName() ;
                        if(myspacenamelist.ContainsKey(your.NameHead))
                            my = myspacenamelist[your.NameHead];

                        SpaceName ret = new SpaceName();
                        ret.NameHead = your.NameHead;

                        foreach (KeyValuePair<string, string> m in your)
                        {
                            foreach (KeyValuePair<string, string> n in my)
                            {
                                if (m.Key == n.Key)
                                {
                                    if (m.Value[0] == '=' && n.Value[0] == '≡')
                                    {
                                        ret.Add(n.Key, n.Value);
                                    }
                                }
                            }
                        }
                        udplistener.SendTo(System.Text.Encoding.UTF8.GetBytes(ret.ToString()), client);
                    }
                }
                ));
            listening.Start();
        }
        SpaceName isay(string arg)
        {
            return new SpaceName(arg);
        }
        protected override void OnStop()
        {
            listening.Abort();
        }
    }
}
