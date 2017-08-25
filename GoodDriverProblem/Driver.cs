using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDriverProblem
{
    class Driver
    {
        private string driverName;
        private double driverMiles;
        private double driverTime;
        private int driverSpeed;

        public string DriverName
        {
            get { return this.driverName; }
            set { this.driverName = value; }
        }
        
        public double DriverMiles
        {
            get { return this.driverMiles; }
            set { this.driverMiles += value; }
        }
        public double DriverTime
        {
            get { return this.driverTime; }
            set { this.driverTime += value; }
        }
        public int DriverSpeed
        {
            get { return this.driverSpeed; }
            set { this.driverSpeed = value; }
        }

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
