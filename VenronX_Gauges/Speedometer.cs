using System;

namespace VenronX_Gauges
{
    class Speedometer : Gauge
    {
        //Do we need a value to capture the actual speed? if so, why?
        // public int Speed { get; set; }

        //min is set to 0 in abstract class
        //override gauge for speedometer max
        //User CAN set their Max value here
        public override int Max { get; set; } = 200;

        //First time using Tuple (tuples are used to harness a data structure without having to create a new type (i.e. another class specifically for SpeedometerMin/Max)
        public Tuple<int, int> SpeedometerMinMax
        {
            get
            {
                return Tuple.Create(Min, Max);
            }
        }
    }
}
