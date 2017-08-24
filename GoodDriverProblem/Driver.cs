using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDriverProblem
{
    class Driver
    {
        public string driverName;
        private double driverMiles;
        private double driverTime;
        private int driverSpeed;

        public string DriverName { get; set; }
        public double DriverMiles { get; set; }
        public double DriverTime { get; set; }
        public int DriverSpeed { get; set; }

        public Driver()
        {
            //default
        }
        public Driver(string DriverName, double DriverMiles, double DriverTime, int DriverSpeed)
        {
            this.DriverName = driverName;
            this.DriverMiles = driverMiles;
            this.DriverTime = driverTime;
            this.DriverSpeed = driverSpeed;

        }
        public int DriverMPH(double driverMiles, double driverTime)

        {
            int mph = Convert.ToInt32(Math.Round(DriverMiles / DriverTime, 2));
            return mph;
        }
    }
}
