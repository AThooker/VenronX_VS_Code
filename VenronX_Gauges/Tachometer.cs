using System;
using CustomExceptions;

namespace VenronX_Gauges
{
    class Tachometer : Gauge
    {
        //tachometer measures the working speed of an engine, in revolutions per minute (RPM's)
        public int Rpm { get; set; }
        public override int Max { get; set; } = 7000;
        private int Redline = 5500;
        public Tuple<int, int, int> TachometerMinMaxRedline
        {
            get
            {
                return Tuple.Create(Min, Max, Redline);
            }
        }

        //Exception if rpm is at or exceeds redline value
        public void TestRpmAgainstRedline()
        {
            if(Rpm >= Redline)
            {
                throw new DoNotExceedRedline(Redline);
            }
        }
    }
}