using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
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
            
            myProcess.StartInfo.FileName =singleton.SecondFileName + ".bat";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
            SystemEvents.SessionSwitch += SESS;
            Console.ReadKey();
        }
        static void SESS(object sender, SessionSwitchEventArgs e)
        {
            Singleton singleton = Singleton.getInstance();
            
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                Process myProcess = new Process();
                myProcess.StartInfo.UseShellExecute = false;
                
                myProcess.StartInfo.FileName =singleton.SecondFileName + ".bat";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                Process myProcess = new Process();
                myProcess.StartInfo.UseShellExecute = false;
                
                myProcess.StartInfo.FileName = singleton.FirstFileName + ".bat";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            }
           
        }
    }
}
