using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    static internal class SelectedSeans
    {
        public static int seansID;
        public static int kinozal_id;
        public static DateTime Date;
        public static TimeSpan Start;

        public static void setseans(int seans, int zal, DateTime date, TimeSpan time)
        {
            seansID = seans;
            kinozal_id = zal;
            Date = date;
            Start = time;
        }
    }
    
    
}
