using System;
using System.IO;
using System.Collections.Generic;

namespace agk_downloader
{
    public class Archivos
    {
        public string ArchivoData;
        public string ArchivoLog;

        public Archivos()
        {
            ArchivoData = AppDomain.CurrentDomain.BaseDirectory + @"\Data.txt";
            ArchivoLog = AppDomain.CurrentDomain.BaseDirectory + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
        }

        public void grabaLog(string linea)
        {
            StreamWriter streamWriter = null;
            streamWriter = File.AppendText(ArchivoLog);
            streamWriter.WriteLine(linea);
            streamWriter.Close();
        }

        public void eliminaLog()
        {
            if (File.Exists(ArchivoLog))
            {
                File.SetAttributes(ArchivoLog, FileAttributes.Normal);
                File.Delete(ArchivoLog);
            }
        }

        public Tuple<int, object> leeLog()
        {
            if (File.Exists(ArchivoLog))
            {
                StreamReader ORead = null;
                string Linea = "";
                List<string> listLog = new List<string>();

                ORead = File.OpenText(ArchivoLog);
                while (!ORead.EndOfStream)
                {
                    Linea = ORead.ReadLine().Trim().ToString();
                    if (Linea.Length > 0)
                    {
                        listLog.Add(Linea);
                    }
                }

                ORead.Close();

                return new Tuple<int, object>(1, listLog);
            }
            else
            {
                return new Tuple<int, object>(0, "");
            }
        }

        public void grabaData(string Linea)
        {
            if (File.Exists(ArchivoData))
            {
                File.SetAttributes(ArchivoData, FileAttributes.Normal);
                File.Delete(ArchivoData);
            }

            StreamWriter streamWriter = null;
            streamWriter = File.AppendText(ArchivoData);
            streamWriter.WriteLine(Linea);
            streamWriter.Close();
        }

        public void eliminaData()
        {
            if (File.Exists(ArchivoData))
            {
                File.SetAttributes(ArchivoData, FileAttributes.Normal);
                File.Delete(ArchivoData);
            }
        }
    }
}
