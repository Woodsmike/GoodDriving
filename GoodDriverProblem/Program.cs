using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDriverProblem
{
    class Program
    {


        static void Main(string[] args)
        {
            
            //dictionary to store driver instance by using driver name as key
            Dictionary<string, Driver> DrivingRecord = new Dictionary<string, Driver>();

            using (StreamReader reader = new StreamReader("DrivingRecord.txt"))
            {

                string line;
                while ((line = reader.ReadLine()) != null) //make sure line has numbers before entering the while loop
                {
                    double driverMiles = 0;
                    int driverTime = 0;
                    int driverSpeed = 0;

                    //using line split in order to assingn words to an array
                    string[] word = line.Split();

                    //The second index is the driver's name
                    string driverName = word[1];

                    //This is instantiating an object in the dictionary
                    if (word[0].Contains("Driver"))
                    {
                       
                        DrivingRecord[driverName] = new Driver(driverName, driverMiles, driverSpeed, driverTime);
                        var currentDriver = DrivingRecord[driverName];
                        currentDriver.DriverName = driverName;
                       
                    }

                    //if the line begins with 'Trip' then we add values to our dictionary
                    else if (word[0] == "Trip")
                    {
                       
                        var currentDriver = DrivingRecord[driverName];
                        double tripTime = Trip.ConvertDriveTime(word[2], word[3]);
                        double tripMiles = double.Parse(word[4]);
                        double tripMPH = Trip.GetMPH(tripMiles, tripTime);

                        //Update driver properties if entry is not less than 5mph or greater than 100mph
                        if (tripMPH >= 5 || tripMPH <= 100)
                        {
                            //Do calculation of driver's total time and miles in the driver class
                            currentDriver.DriverTime = tripTime;
                            currentDriver.DriverMiles = tripMiles;
                           

                        }

                        //Calculate the overall Speed for a driver
                        currentDriver.DriverSpeed = currentDriver.DriverMPH(tripMiles, tripTime);

                  
                    }

                }
                // use linq in order to sort the values in the dictionary by 'DriverMiles
                var drivingRecordSorted = from entry in DrivingRecord
                          orderby entry.Value.DriverMiles descending
                          select entry;

                //Print out the sorted values
                foreach (KeyValuePair<string, Driver> driver in drivingRecordSorted)
                {
                    
                    Console.WriteLine("{0}: {1} miles @ {2}", driver.Value.DriverName, 
                        Math.Round(driver.Value.DriverMiles), driver.Value.DriverSpeed + " MPH");
                }

            }

        }

    }

}







