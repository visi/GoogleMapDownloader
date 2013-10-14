using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GoogleMapDownloader.Core
{
    public class Log
    {
        private static object lockObj = new object();

        public static void Clear(string logFile)
        {
            StreamWriter sw = new StreamWriter(logFile);
            sw.Close();
        }

        public static void Write(string logFile, string message)
        {
            lock (lockObj)
            {
                StreamWriter sw = new StreamWriter(logFile, true);
                sw.WriteLine(message);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
