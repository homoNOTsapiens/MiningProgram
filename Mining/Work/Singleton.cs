using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    public class Singleton
    {
        private static Singleton instance;
        private string firstFileName;
        private string secondFileName;
        private bool EventHandled;
        public string FirstFileName
        { get
            {   if (String.IsNullOrEmpty(firstFileName))
                    return "C:\\Users\\ACER\\Desktop\\First.bat";
                else
                return firstFileName; }
            set
            {   
                firstFileName = value;
            }
        }
        public string SecondFileName
        {
            get
            {
                if (String.IsNullOrEmpty(firstFileName))
                    return "C:\\Users\\ACER\\Desktop\\Second.bat";
                else
                    return secondFileName;
            }
            set
            {
                secondFileName = value;
            }
        }
        

        private Singleton()
        { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }

    }
}
