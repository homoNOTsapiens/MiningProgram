using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.ComponentModel;
namespace Work
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.getInstance() ;
            singleton.FirstFileName = args[0];
            singleton.SecondFileName = args[1];
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = false;
            // You can start any process, HelloWorld is a do-nothing example.
            myProcess.StartInfo.FileName = "C:\\Users\\ACER\\Desktop\\" + singleton.SecondFileName + ".bat";
            myProcess.StartInfo.CreateNoWindow = false;
            myProcess.Start();
            SystemEvents.SessionSwitch += SESS;
            Console.ReadKey();
        }
        static void SESS(object sender, SessionSwitchEventArgs e)
        {
            Singleton singleton = Singleton.getInstance();
            //Console.WriteLine("Evenst SessionSwitch = "+ e.Reason);
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                Process myProcess = new Process();
                myProcess.StartInfo.UseShellExecute = false;
                // You can start any process, HelloWorld is a do-nothing example.
                myProcess.StartInfo.FileName = "C:\\Users\\ACER\\Desktop\\" + singleton.SecondFileName + ".bat";
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.Start();
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                Process myProcess = new Process();
                myProcess.StartInfo.UseShellExecute = false;
                // You can start any process, HelloWorld is a do-nothing example.
                myProcess.StartInfo.FileName = "C:\\Users\\ACER\\Desktop\\" + singleton.FirstFileName + ".bat";
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.Start();
            }
           
        }
    }
}
