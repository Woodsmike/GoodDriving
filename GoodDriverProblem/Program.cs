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



            //List<string> totalList = new List<string>();
            //List<string> allDrivers = new List<string>();
            //List<string> goodDriverList = new List<string>();
            //List<string> minsList = new List<string>();
            //List<string> driverNames = new List<string>();
            //List<string> tripDriverNames = new List<string>();
            //List<int> minsNumbers = new List<int>();
            string[] words = new string[] { };

            //double milesDriven = 0;
            //double MPH = 0;
            //double drivingDbl = 0;
            string driverName = "";
            double driverMiles = ' ';
            int driverTime = 0;
            int driverSpeed = 0;
            Dictionary<string, Driver> DrivingRecord = new Dictionary<string, Driver>();

            using (StreamReader reader = new StreamReader("DrivingRecord.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    
                    string[] word = line.Split(' ');

                    if (word[0].Contains("Driver"))
                    {
                        driverName = word[1];
                        DrivingRecord[driverName] = new Driver();
                        var currentDriver = DrivingRecord[driverName];
                        currentDriver.DriverName = driverName;
                        //Console.WriteLine(currentDriver.DriverName);
                    }


                    else if (word[0] == "Trip")
                    {
                        driverName = word[1];
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
                            Console.Write(currentDriver.DriverName + ": ");
                            Console.Write(currentDriver.DriverMiles + " ");
                            //Console.WriteLine(currentDriver.DriverTime);
                          
                        }

                        //Calculate the overall Speed for a driver
                        currentDriver.DriverSpeed = currentDriver.DriverMPH(tripMiles,tripTime);
                        
                        Console.WriteLine(tripMPH + "\n");
                    }

                    



                    //driverName = words[1];
                    //String timeText = words[2]; // The String array contans 21:31:00
                    //String timeText1 = words[3];
                    //DateTime time2 = Convert.ToDateTime(timeText);
                    //DateTime time1 = Convert.ToDateTime(timeText1);
                    //TimeSpan drivingTime = (time1 - time2);

                    //String miles = words[4];
                    //milesDriven = double.Parse(miles);
                    //drivingDbl = (double)drivingTime.Minutes;

                    //allDrivers.Add(driverName);  //index 0
                    //allDrivers.Add(milesDriven.ToString()); // index 1
                    //allDrivers.Add(drivingDbl.ToString());  // index 2


                }
                //for (int i = 0; i < allDrivers.Count; i += 3)
                //{
                //    Console.Write(allDrivers[i]);
                //    for (int j = 1; j < allDrivers.Count - 1; j += 3)
                //    {
                //        Console.Write(allDrivers[j]);
                //        for (int k = 2; k < allDrivers.Count - 2; k += 3)
                //        {
                //            MPH = (double.Parse(allDrivers[j]) / (double.Parse(allDrivers[k]) / 60));
                //            Console.WriteLine(allDrivers[k]);

                //        }
                //    }

                //}
                //MPH = milesDriven / (drivingDbl / 60);
                //Console.Write(allDrivers[0] + " " + allDrivers[1] + " " + "@ " + MPH + "\n");
                //foreach (string names in driverNames)
                //{
                //    for (int i = 0; 1 < allDrivers.Count - 1; i += 3)
                //    {
                //        if (names != allDrivers[i])
                //        {
                //            Console.WriteLine(driverNames[i] + "0 miles driven");
                //        }
                //    }
                }

            var drivingRecordSorted = from entry in DrivingRecord
                                      orderby entry.Value.DriverMiles descending
                                      select entry;

            foreach (KeyValuePair<string, Driver> driver in DrivingRecord)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine("{0}" , driver.Value);
            }


        }

        }
        
}









