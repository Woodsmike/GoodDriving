using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDriverProblem
{
    class Trip
    {
        public int MPH { get; set; }
        public int MilesDriven { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        

        public static double ConvertDriveTime(string start, string end)
        {
            DateTime startTime = Convert.ToDateTime(start);                                 
            DateTime endTime = Convert.ToDateTime(end);

            double hoursDriving = (endTime - startTime).TotalHours;
            double roundedHoursDriving = Math.Round(hoursDriving, 2);
            return roundedHoursDriving;
        }

      
        public static int GetMPH(double MilesDriven, double driverTime)
        {
            int mph = Convert.ToInt32(Math.Round(MilesDriven / driverTime, 2));
            return mph;
            
        }

    }
   
}
