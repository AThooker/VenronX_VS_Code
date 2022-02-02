using System;
using System.Collections.Generic;
using System.Linq;

namespace VenronX_Gauges
{
    //min/max with highest level reach stored for later analysis
    public class Accelerometer : Gauge
    {
        public override int Max { get; set; } = 0;
        public List<double> HighestAccelerations { get; set; } = new List<double>(){0};
        //Bring in random class for random time differences 
        //and random velocity differences for acceleration calc
        Random rnd = new Random();
        //Get random value to signify our time we use each time we gauge the velocity
        public double TimeFromStartToEnd
        {
            get
            {
                return rnd.Next(1,10);
            }
        }
        //Get random value to signify the difference in velocity
        //Ideally this would actually be done by gauging the speed of something moving in a certain direction
        public double VelocityDifference
        {
            get
            {
                return rnd.Next(40, 60);
            }
        }

        //Acceleration(a) is measured by dividing the "change in velocity"(delta-v) by the "change in time"(delta-t)
        // a = delta-v / delta-t
        public double Accleration
         { 
             get
             {
                 var accel = VelocityDifference / TimeFromStartToEnd;
                 if(accel > HighestAccelerations.Max())
                 {
                     HighestAccelerations.Add(accel);
                 }
                 return accel;
             }
         }

        //Using acceleration method instead of properties
        
        // public double GettingNewAcceleration()
        // {
        //     var time = rnd.Next(0,10);
        //     var veloDiff = rnd.Next(40,60);
        //     var acceleration = veloDiff / time;
        //     if (acceleration > Max)
        //     {
        //         HighestAccelerations.Add(acceleration);
        //         Max = Convert.ToInt32(acceleration);
        //     }
        //     return Math.Round(Convert.ToDouble(acceleration), 3);
        // }
    }
}