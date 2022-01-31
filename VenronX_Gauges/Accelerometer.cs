using System;
using System.Collections.Generic;
using System.Linq;

namespace VenronX_Gauges
{
    //min/max with highest level reach stored for later analysis
    partial class Accelerometer : Gauge
    {
        public override int Max { get; set; } = 0;
        Random rnd = new Random();
        public List<double> HighestAccelerations { get; set; } = new List<double>(){0};
        public double TimeFromStartToEnd
        {
            get
            {
                return rnd.Next(0,10);
            }
        }
        public double VelocityDifference
        {
            get
            {
                return rnd.Next(40, 60);
            }
        }

        // Accleration formula: 
        //A = (EndingV - StartingV) / time
        public double GettingNewAcceleration()
        {
            var time = rnd.Next(0,10);
            var veloDiff = rnd.Next(40,60);
            var acceleration = veloDiff / time;
            if (acceleration > Max)
            {
                HighestAccelerations.Add(acceleration);
                Max = Convert.ToInt32(acceleration);
            }
            return Math.Round(Convert.ToDouble(acceleration), 3);
        }
    }
}