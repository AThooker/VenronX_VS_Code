using System;

namespace VenronX_Gauges
{
    class Speedometer : Gauge
    {
        //Do we need a value to capture the actual speed? if so, why?
        // public int Speed { get; set; }

        //Without user input
        //min is set to 0 in abstract class
        //override gauge for speedometer max
        public override int Max { get; set; } = 200;

        //max set by user
        public int MaxUserSet { get; set; }
        //First time using Tuple (tuples are used to harness a data structure without having to create a new type (i.e. another class specifically for SpeedometerMin/Max)
        public Tuple<int, int> SpeedometerMinMax
        {
            get
            {
                //instead of having two different tuples (one for user input and another for developer-set max)
                // just returning min/max for userSet if it has value and developer-set if userSet is omitted
                if(MaxUserSet > 0)
                {
                    return Tuple.Create(Min, MaxUserSet);
                }
                return Tuple.Create(Min, Max);
            }
        }
    }
}
