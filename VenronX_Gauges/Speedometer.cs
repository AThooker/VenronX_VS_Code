using System;

namespace VenronX_Gauges
{
    public class Speedometer
    {
        public int Speed { get; set; }
        //First time using Tuple(used so developer can use a data structure wihtout having to create a new type (i.e. another class specifically to hold Min/Max together))

        //without user input
        private int _speedometerMin = 0;
        private int _speedometerMax = 250;
        public Tuple<int, int> SpeedometerSetMinMax
        {
            get
            {
                return Tuple.Create(_speedometerMin, _speedometerMax);
            }
        }

        //With user input
        public int UserSetMin { get; set; }
        public int UserSetMax { get; set; }
        public Tuple<int, int> UserSpeedometerMinMax
        {
            get
            {
                return Tuple.Create(UserSetMin, UserSetMax);
            }
        }
    }
}
