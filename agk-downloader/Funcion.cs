using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agk_downloader
{
    public class Funcion
    {
        public Funcion() { }

        public static bool IsNumeric(string valor)
        {
            long result;
            return long.TryParse(valor, out result);
        }

        public bool IsDate(String date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
